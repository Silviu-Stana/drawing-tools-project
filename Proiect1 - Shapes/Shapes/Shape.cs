using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proiect1___Shapes
{
    public abstract class Shape : IDrawable
    {
        public int X { get; set; }
        public int Y { get; set; }

        public abstract void Draw(Graphics g);
        public abstract void Move(int deltaX, int deltaY);
        public abstract void Resize(float factor);

        // Add IDrawable methods
        public abstract void StartDrawing(Point startPoint);
        public abstract void UpdateDrawing(Point currentPoint);
        public abstract void FinalizeDrawing();
        public abstract bool IsFinalized { get; set; }
    }

    public interface IDrawable
    {
        void Draw(Graphics g);
        void StartDrawing(Point startPoint);
        void UpdateDrawing(Point currentPoint);
        void FinalizeDrawing();
        bool IsFinalized { get; set; }
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
