using Proiect1___Shapes.Repository;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Proiect1___Shapes.Tools
{
    public class DrawTool : ITool
    {
        private IDrawable currentShape;
        private readonly Func<IDrawable> shapeFactory; //creaza dinamic o instanta a formei selectate

        public DrawTool(Func<IDrawable> shapeFactory)
        {
            this.shapeFactory = shapeFactory;
        }

        public void OnMouseDown(Point position)
        {
            if (currentShape == null || currentShape.IsFinalized)
            {
                currentShape = shapeFactory();
                currentShape.StartDrawing(position);
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
            //Nothing to do here
        }
    }
}
