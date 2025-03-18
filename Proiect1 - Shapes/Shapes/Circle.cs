using System;
using System.Drawing;

namespace Proiect1___Shapes
{
    public class Circle : Shape, IDrawable, IMovable, IResizable
    {
        private Pen pen { get; set; }
        public Point p1 { get; set; }
        public float Radius { get; set; }
        public override string JsonType => "Circle";

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

        public void Resize(float deltaX, float deltaY)
        {
            // Adjust the radius based on the delta values (assuming deltaY affects the radius directly)
            float newRadius = Radius - deltaY;

            if (newRadius < 0) newRadius = 0;

            Radius = newRadius;
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
