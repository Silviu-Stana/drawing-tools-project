using Newtonsoft.Json;
using System;
using System.Drawing;
using static System.Windows.Forms.AxHost;


namespace Proiect1___Shapes
{
    public abstract class Shape : IDrawable
    {
        public abstract string JsonType { get; }
        public abstract void Draw(Graphics g);
        public abstract void Move(int deltaX, int deltaY);

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
        void Resize(float deltaX, float deltaY);
    }

}
