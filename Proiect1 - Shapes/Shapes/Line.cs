using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proiect1___Shapes
{
    public class Line : Shape, IDrawable, IMovable, IResizable, IDrawingTool
    {
        public Pen pen { get; set; }
        public Point p1 { get; set; }
        public Point p2 { get; set; }

        private List<Shape> shapes; // The collection of lines to draw on the canvas
        private Point? startPoint = null;
        Point currentPoint;
        private bool isDrawing = false;


        public Line(int x1, int y1, int x2, int y2)
        {
            p1 = new Point(x1, y1);
            p2 = new Point(x2, y2);
        }

        public Line(List<Shape> shapes)
        {
            this.shapes = shapes;
        }

        public override void Draw(Graphics g)
        {
            pen = new Pen(Color.Black, 3);
            g.DrawLine(pen, p1, p2);
        }

        public override void Move(int deltaX, int deltaY)
        {
            //System.Diagnostics.Debug.WriteLine($"Move called with deltaX: {deltaX}, deltaY: {deltaY}");
            //Mutam ambele puncte ale liniei
            p1 = new Point(p1.X + deltaX, p1.Y + deltaY);
            p2 = new Point(p2.X + deltaX, p2.Y + deltaY);

        }

        public override void Resize(float factor)
        {
            if (p1 == null || p2 == null) return;

            //Calculam noua pozitie a punctului 2
            int newX = p1.X + (int)((p2.X - p1.X) * factor);
            int newY = p1.Y + (int)((p2.Y - p1.Y) * factor);

            //Mutam punctul 2 la noua pozitie
            p2 = new Point(newX, newY);
        }


        public void OnPaint(Graphics g)
        {
            // Draw temporary line while dragging
            if (isDrawing && startPoint.HasValue)
            {
                g.DrawLine(pen, startPoint.Value, currentPoint);
            }
        }

        public void OnMouseDown(object sender, MouseEventArgs e)
        {
            if (!startPoint.HasValue)
            {
                // First click - Set start point
                startPoint = e.Location;
                isDrawing = true;
            }
            else
            {
                // Second click - Commit the final line
                shapes.Add(new Line(startPoint.Value.X, startPoint.Value.Y, e.X, e.Y));
                startPoint = null; // Reset for new drawing
                isDrawing = false;

                (sender as Panel)?.Invalidate(); // Force repaint to save final shape
            }
        }

        public void OnMouseMove(object sender, MouseEventArgs e)
        {
            if (isDrawing && startPoint.HasValue)
            {
                // Update current mouse position
                currentPoint = e.Location;
                (sender as Panel).Invalidate(); // Redraw the panel
            }
        }

        public void OnMouseUp(object sender, MouseEventArgs e)
        {
            //Nimic necesar aici
        }
    }
}
