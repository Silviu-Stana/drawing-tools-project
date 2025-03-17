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
        private List<Shape> shapes; // The collection of shapes to draw on the canvas

        // Constructor to pass the collection of shapes
        public ResizeTool(List<Shape> shapes)
        {
            this.shapes = shapes;
        }

        public void OnPaint(object sender, Graphics g)
        {
            throw new NotImplementedException();
        }

        public void OnMouseDown(object sender, MouseEventArgs e)
        {
            throw new NotImplementedException();
        }

        public void OnMouseMove(object sender, MouseEventArgs e)
        {
            throw new NotImplementedException();
        }

        public void OnMouseUp(object sender, MouseEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
