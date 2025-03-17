using Proiect1___Shapes.Repository;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.LinkLabel;

namespace Proiect1___Shapes.Tools
{
    public class DrawTool : ITool
    {
        private List<Shape> shapes;
        private Pen pen;
        private Type selectedShapeType;
        private Shape currentShape;

        public DrawTool(List<Shape> shapes, Pen pen, Type selectedShapeType)
        {
            this.shapes = shapes;
            this.pen = pen;
            this.selectedShapeType = selectedShapeType;

        }

        public void OnPaint(object sender, Graphics g)
        {
            foreach (var shape in shapes) if (shape is IDrawable drawableShape) drawableShape.Draw(g);
        }

        public void OnMouseDown(object sender, MouseEventArgs e)
        {
            if (selectedShapeType == typeof(Line))
            {
                currentShape = new Line(shapes); // Pass shapes to Line constructor
            }
            else
            {
                currentShape = ShapeFactory.CreateShape(selectedShapeType, shapes);
            }

            if (currentShape is IDrawingTool creatableShape)
            {
                creatableShape.OnMouseDown(sender, e);
                shapes.Add(currentShape); // Add the shape after starting a draw operation
            }
        }

        public void OnMouseMove(object sender, MouseEventArgs e)
        {
            if (currentShape is IDrawingTool creatableShape) creatableShape.OnMouseMove(sender, e);
        }

        public void OnMouseUp(object sender, MouseEventArgs e)
        {
            if (currentShape is IDrawingTool creatableShape) creatableShape.OnMouseUp(sender, e);
        }

        public class ShapeFactory
        {
            public static Shape CreateShape(Type shapeType, List<Shape> shapes)
            {
                if (shapeType == typeof(Line))
                    return new Line(shapes);
                if (shapeType == typeof(Circle))
                    return new Circle();
                // Add more shapes as needed
                return null;
            }
        }
    }
}
