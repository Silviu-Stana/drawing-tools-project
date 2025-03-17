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
        private Type selectedShapeType;

        public DrawTool(List<Shape> shapes, Pen pen, Type selectedShapeType)
        {
            this.shapes = shapes;
            this.selectedShapeType = selectedShapeType;

        }

        private Point? startPoint = null;
        private bool isDrawing = false;


        public void OnPaint(object sender, Graphics g)
        {
            foreach (IDrawable shape in shapes) shape.Draw(g);
        }

        public void OnMouseDown(object sender, MouseEventArgs e)
        {
            if (!startPoint.HasValue)
            {
                // First click - Set start point
                startPoint = e.Location;
                isDrawing = true;
            }
            else
            {
                // Second click - Commit the final line
                shapes.Add(new Line(startPoint.Value.X, startPoint.Value.Y, e.X, e.Y));
                startPoint = null; // Reset for new drawing
                isDrawing = false;
                (sender as Panel)?.Invalidate(); // Force repaint to save final shape
            }
        }

        public void OnMouseMove(object sender, MouseEventArgs e)
        {
            if (selectedShapeType is ITool creatableShape) creatableShape.OnMouseMove(sender, e);
        }

        public void OnMouseUp(object sender, MouseEventArgs e)
        {
            if (selectedShapeType is ITool creatableShape) creatableShape.OnMouseUp(sender, e);
        }
    }
}
