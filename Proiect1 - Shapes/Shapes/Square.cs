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

        public override bool IsFinalized { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public int width, height;

        public Square()
        {
            pen = new Pen(Color.Black);
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

        public override void StartDrawing(Point startPoint)
        {
            throw new NotImplementedException();
        }

        public override void UpdateDrawing(Point currentPoint)
        {
            throw new NotImplementedException();
        }

        public override void FinalizeDrawing()
        {
            throw new NotImplementedException();
        }
    }
}
