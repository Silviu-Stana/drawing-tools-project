using Proiect1___Shapes.Repository;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace Proiect1___Shapes.Tools
{
    public class DrawTool : ITool
    {
        private IDrawable currentShape;
        private readonly Func<IDrawable> shapeFactory; //creaza dinamic o instanta a formei selectate
        private readonly List<IDrawable> shapes;

        public DrawTool(Func<IDrawable> shapeFactory, List<IDrawable> shapes)
        {
            this.shapeFactory = shapeFactory;
            this.shapes = shapes;
        }

        public void OnMouseDown(Point position)
        {
            Console.WriteLine($"Drawing started at {position}");
            if (currentShape == null || currentShape.IsFinalized)
            {
                currentShape = shapeFactory();
                currentShape.StartDrawing(position);

                // Add to the shapes list immediately after creation
                shapes.Add(currentShape);
            }
            else
            {
                currentShape.FinalizeDrawing();
                currentShape = null;
            }
        }

        public void OnMouseMove(Point position)
        {
            if (currentShape != null && !currentShape.IsFinalized)
            {
                currentShape.UpdateDrawing(position);
            }
        }

        public void OnMouseUp(Point position)
        {

        }
    }
}
