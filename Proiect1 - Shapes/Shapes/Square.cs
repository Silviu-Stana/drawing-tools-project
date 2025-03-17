using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect1___Shapes
{
    public class Square : Shape, IDrawable, IMovable, IResizable
    {
        public Pen pen { get; set; }
        public int width, height;

        public Square(int x, int y)
        {
            pen = new Pen(Color.Black);
            X = x;
            Y = y;
        }

        public override void Draw(Graphics g)
        {
            g.DrawRectangle(pen, X, Y, width, height);
        }

        public override void Move(int deltaX, int deltaY)
        {
            //Mutam Punctul
            X += deltaX;
            Y += deltaY;
        }

        public override void Resize(float factor)
        {
            width = (int)(width * factor);
            height = (int)(height * factor);
        }
    }
}
