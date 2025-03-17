using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect1___Shapes
{
    public class GraphicTool
    {
        public List<Shape> Shapes { get; private set; }
        public IShapeRepository ShapeRepository { get; set; }

        public GraphicTool()
        {
            Shapes = new List<Shape>();
        }

        public void AddShape(Shape shape)
        {
            Shapes.Add(shape);
        }

        public void DrawAllShapes(Graphics g)
        {
            foreach (var shape in Shapes)
            {
                shape.Draw(g);
            }
        }

        public void DrawShape(Shape shape, Point currentClickLocation, Graphics g)
        {
            shape.Draw(g);
        }

        public void MoveShape(Shape shape, int deltaX, int deltaY)
        {
            shape.Move(deltaX, deltaY);
        }

        public void ResizeShape(Shape shape, float factor)
        {
            shape.Resize(factor);
        }
        public void SaveShapes() { }
        public void LoadShapes() { }
    }
}
