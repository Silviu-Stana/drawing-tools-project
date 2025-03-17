using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proiect1___Shapes
{
    public abstract class Shape
    {
        public int X { get; set; }
        public int Y { get; set; }
        public abstract void Draw(Graphics g);
        public abstract void Move(int deltaX, int deltaY);
        public abstract void Resize(float factor);
    }

    public interface IDrawable
    {
        void Draw(Graphics g);
    }

    public interface IMovable
    {
        void Move(int deltaX, int deltaY);
    }

    public interface IResizable
    {
        void Resize(float factor);
    }

}
