using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect1___Shapes
{
    public class Triangle : Shape, IDrawable, IMovable, IResizable
    {
        private Pen pen { get; set; }
        public Point p1 { get; set; }
        public Point p2 { get; set; }
        public Point p3 { get; set; }
        public override string JsonType => "Triangle";


        private bool isFinalized = false;
        public override bool IsFinalized { get => isFinalized; set => isFinalized = value; }
        public override void FinalizeDrawing()
        {
            if (p1 != Point.Empty && p2 != Point.Empty && p3 != Point.Empty)
            {
                IsFinalized = true;
            }
        }

        public Triangle()
        {
            pen = new Pen(Color.Black, 3);
        }

        public override void Draw(Graphics g)
        {
            //Desenam triunghiul cu 3 puncte
            if (p1 != Point.Empty && p2 != Point.Empty && p3 != Point.Empty)
            {
                Point[] points = { p1, p2, p3 };
                g.DrawPolygon(pen, points);
            }
        }

        public override void Move(int deltaX, int deltaY)
        {
            //Mutam toate cele 3 puncte ale triunghiului
            p1 = new Point(p1.X + deltaX, p1.Y + deltaY);
            p2 = new Point(p2.X + deltaX, p2.Y + deltaY);
            p3 = new Point(p3.X + deltaX, p3.Y + deltaY);
        }

        public void Resize(float deltaX, float deltaY)
        {
            // Calculate the center (centroid) of the triangle
            float centerX = (p1.X + p2.X + p3.X) / 3f;
            float centerY = (p1.Y + p2.Y + p3.Y) / 3f;

            // Calculate scaling factors based on deltaX and deltaY
            float scaleX = 1 + deltaX / 100;  // Scale factor based on horizontal movement
            float scaleY = 1 + deltaY / 100;  // Scale factor based on vertical movement

            // Scale each point relative to the center
            p1 = ScalePoint(p1, centerX, centerY, scaleX, scaleY);
            p2 = ScalePoint(p2, centerX, centerY, scaleX, scaleY);
            p3 = ScalePoint(p3, centerX, centerY, scaleX, scaleY);
        }

        private Point ScalePoint(Point point, float centerX, float centerY, float scaleX, float scaleY)
        {
            // Scale the point relative to the center
            int newX = (int)(centerX + (point.X - centerX) * scaleX);
            int newY = (int)(centerY + (point.Y - centerY) * scaleY);

            return new Point(newX, newY);
        }

        public override void StartDrawing(Point startPoint)
        {
            p1 = startPoint;
        }

        public override void UpdateDrawing(Point currentPoint)
        {
            // As the mouse moves, adjust points to create a triangle
            if (p1 != Point.Empty) p2 = new Point(currentPoint.X, p1.Y); // Make the second point horizontal to p1
            if (p2 != Point.Empty) p3 = new Point(p1.X, currentPoint.Y); // Make the third point vertical to p1
        }
    }
}