using Proiect1___Shapes.Repository;
using Proiect1___Shapes.Tools;
using System;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Proiect1___Shapes
{
    public class Line : Shape, IDrawable, IMovable, IResizable
    {
        public Point p1 { get; set; }
        public Point p2 { get; set; }
        public override string JsonType => "Line";

        private Pen pen { get; set; }
        private bool isFinalized = false;
        public override bool IsFinalized { get => isFinalized; set => isFinalized = value; }
        public override void FinalizeDrawing() => IsFinalized = true;

        public Line()
        {
            pen = new Pen(Color.Black, 3);
        }

        public override void Draw(Graphics g)
        {
            g.DrawLine(pen, p1, p2);
        }

        public override void Move(int deltaX, int deltaY)
        {
            //System.Diagnostics.Debug.WriteLine($"Move called with deltaX: {deltaX}, deltaY: {deltaY}");
            //Mutam ambele puncte ale liniei
            p1 = new Point(p1.X + deltaX, p1.Y + deltaY);
            p2 = new Point(p2.X + deltaX, p2.Y + deltaY);

        }

        public void Resize(float deltaX, float deltaY)
        {
            // Update the second point (p2) based on mouse movement
            p2 = new Point(p2.X + (int)deltaX, p2.Y + (int)deltaY);
        }


        public void OnPaint(object sender, Graphics g)
        {
            g.DrawLine(pen, p1, p2);
        }

        public override void StartDrawing(Point startPoint)
        {
            // First click - Set start point
            p1 = startPoint;
            p2 = startPoint;
        }

        public override void UpdateDrawing(Point currentPoint)
        {
            p2 = currentPoint;
        }
    }
}
