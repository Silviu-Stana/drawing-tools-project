using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Proiect1___Shapes
{
    public class Circle : Shape, IDrawable, IMovable, IResizable
    {
        public int Radius { get; set; }

        public Circle(int x, int y, int radius)
        {
            X = x;
            Y = y;
            Radius = radius;
        }

        public Circle()
        {
        }

        public override void Draw(Graphics g)
        {
            g.FillEllipse(Brushes.Blue, X - Radius, Y - Radius, Radius * 2, Radius * 2);
        }

        public override void Move(int deltaX, int deltaY)
        {
            X += deltaX;
            Y += deltaY;
        }

        public override void Resize(float factor)
        {
            Radius = (int)(Radius * factor);
        }
    }

}
