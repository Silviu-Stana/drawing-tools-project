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
        private List<Line> lines; // The collection of lines to draw on the canvas

        // Constructor to pass the collection of lines
        public ResizeTool(List<Line> lines)
        {
            this.lines = lines;
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
