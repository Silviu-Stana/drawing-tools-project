using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proiect1___Shapes
{
    public class Square : Shape, IDrawable, IMovable, IResizable
    {
        public Pen pen { get; set; }
        public Point p1 { get; set; }
        public int width, height;

        private bool isFinalized = false;
        public override bool IsFinalized { get => isFinalized; set => isFinalized = value; }

        Graphics g;

        public override void FinalizeDrawing()
        {
            if (width < 0) p1 = new Point(p1.X + width, p1.Y);
            if (height < 0) p1 = new Point(p1.X, p1.Y + height);

            isFinalized = true;

            g.DrawRectangle(pen, p1.X, p1.Y, width, height);

            Console.WriteLine($"Finalized Drawing at {p1}. Width: {width}, Height: {height}");
        }


        public Square()
        {
            pen = new Pen(Color.Black, 3);
        }

        public override void Draw(Graphics g)
        {
            this.g = g;

            int drawX = p1.X;
            int drawY = p1.Y;

            if (width < 0)
            {
                drawX = p1.X + width;  // Move the drawing point left
                width = Math.Abs(width);  // Make width positive for drawing
            }

            if (height < 0)
            {
                drawY = p1.Y + height;  // Move the drawing point upwards
                height = Math.Abs(height);  // Make height positive for drawing
            }

            g.DrawRectangle(pen, drawX, drawY, width, height);
        }

        public override void Move(int deltaX, int deltaY)
        {
            //Mutam Punctul
            p1 = new Point(p1.X + deltaX, p1.Y + deltaY);
        }

        public override void Resize(float factor)
        {
            width = (int)(width * factor);
            height = (int)(height * factor);
        }

        public override void StartDrawing(Point startPoint)
        {
            p1 = startPoint;
        }

        public override void UpdateDrawing(Point currentPoint)
        {
            // Calculez dinstanta dintre punctul p1 de si pozitia curenta a mouse-ului.
            // Pentru un patrat, lungimea si latimea sunt egale
            width = currentPoint.X - p1.X;
            height = currentPoint.Y - p1.Y;
        }
    }
}
