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
    public class ResizeTool : ITool
    {
        private readonly Func<IDrawable> shapeFactory; //creaza dinamic o instanta a formei selectate

        public ResizeTool(Func<IDrawable> shapeFactory)
        {
            this.shapeFactory = shapeFactory;
        }

        public void OnMouseDown(Point position)
        {
            throw new NotImplementedException();
        }

        public void OnMouseMove(Point position)
        {
            throw new NotImplementedException();
        }

        public void OnMouseUp(Point position)
        {
            throw new NotImplementedException();
        }
    }
}
