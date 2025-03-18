using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Proiect1___Shapes
{
    public class Circle : Shape, IDrawable, IMovable, IResizable
    {
        public Pen pen { get; set; }
        public Point p1 { get; set; }
        public int Radius { get; set; }

        private bool isFinalized = false;
        public override bool IsFinalized { get => isFinalized; set => isFinalized = value; }
        public override void FinalizeDrawing() => IsFinalized = true;

        public Circle()
        {
            pen = new Pen(Color.Black, 3);
        }

        public override void Draw(Graphics g)
        {
            //p1.x-Radius ne ajuta sa desenam cercul centrat in punctului p1
            //in loc ca punctul p1 sa fie coltul stanga-sus al cercului
            g.DrawEllipse(pen, p1.X - Radius, p1.Y - Radius, 2 * Radius, 2 * Radius);
        }

        public override void Move(int deltaX, int deltaY)
        {
            //Mutam punctul central al cercului
            p1 = new Point(p1.X + deltaX, p1.Y + deltaY);
        }

        public override void Resize(float factor)
        {
            Radius = (int)(Radius * factor);
        }

        public override void StartDrawing(Point startPoint)
        {
            p1 = startPoint;
            Radius = 10;
        }

        public override void UpdateDrawing(Point currentPoint)
        {
            //Mareste sau scade Cercul cu miscarea mouse.
            //Gaseste distanta de la centru (p1) la pozitia curenta a mouse-ului
            //Folosesc formula de distanta Euclidiana (radical din patratele diferentei)
            Radius = (int)Math.Sqrt(Math.Pow(currentPoint.X - p1.X, 2) + Math.Pow(currentPoint.Y - p1.Y, 2));
        }

    }

}
