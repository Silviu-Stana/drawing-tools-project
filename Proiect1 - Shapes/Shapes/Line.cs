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
        public Pen pen { get; set; }
        public Point p1 { get; set; }
        public Point p2 { get; set; }

        // Implement the IsFinalized property
        private bool isFinalized = false;
        public override bool IsFinalized
        {
            get => isFinalized;
            set => isFinalized = value;
        }

        public Line()
        {
            pen = new Pen(Color.Black, 3);
        }

        public override void Draw(Graphics g)
        {
            //if (!IsFinalized)  //can be used to have different color while drawing
            //{
            g.DrawLine(pen, p1, p2);
            //}
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

        public override void FinalizeDrawing() => IsFinalized = true;

    }
}
