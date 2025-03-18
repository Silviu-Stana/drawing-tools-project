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
    public class MoveTool : ITool
    {
        private Line selectedLine = null;
        private Point lastMousePosition;
        private bool isDragging = false;

        private readonly Func<IDrawable> shapeFactory; //creaza dinamic o instanta a formei selectate

        public MoveTool(Func<IDrawable> shapeFactory)
        {
            this.shapeFactory = shapeFactory;
        }

        public void OnPaint(Point point)
        {
            // Draw the selected shape while it's being moved
            if (isDragging && selectedLine != null)
            {
                //selectedLine.OnPaint(sender, g);
                System.Diagnostics.Debug.WriteLine($"Dragging line -> p1: ({selectedLine.p1.X}, {selectedLine.p1.Y}), p2: ({selectedLine.p2.X}, {selectedLine.p2.Y})");
            }
        }

        public void OnMouseDown(Point point)
        {
            // Check if we are selecting a shape
            //if (IsClickNearLine(e.Location, line))
            //{
            //    selectedLine = line;
            //    lastMousePosition = e.Location;
            //    isDragging = true;
            //}
        }

        public void OnMouseMove(Point point)
        {
            if (isDragging && selectedLine != null)
            {
                //Point newMousePosition = e.Location;

                //int deltaX = newMousePosition.X - lastMousePosition.X;
                //int deltaY = newMousePosition.Y - lastMousePosition.Y;

                //selectedLine.Move(deltaX, deltaY);

                //lastMousePosition = newMousePosition; // Update AFTER the move
            }
        }

        public void OnMouseUp(Point point)
        {
            isDragging = false;
            selectedLine = null;
        }

        private bool IsClickNearLine(Point p, Line line)
        {
            const int threshold = 15; // Distance in pixels to consider it "on the line"

            float dx = line.p2.X - line.p1.X;
            float dy = line.p2.Y - line.p1.Y;
            float lungimePatratica = dx * dx + dy * dy;

            if (lungimePatratica == 0) return false; // Line is a single point

            float t = ((p.X - line.p1.X) * dx + (p.Y - line.p1.Y) * dy) / lungimePatratica;
            t = Math.Max(0, Math.Min(1, t)); // Clamp between 0 and 1

            float closestX = line.p1.X + t * dx;
            float closestY = line.p1.Y + t * dy;

            float distance = (float)Math.Sqrt((p.X - closestX) * (p.X - closestX) + (p.Y - closestY) * (p.Y - closestY));

            return distance <= threshold;
        }

        public void OnPaint(object sender, Graphics graphics)
        {
            throw new NotImplementedException();
        }
    }
}
