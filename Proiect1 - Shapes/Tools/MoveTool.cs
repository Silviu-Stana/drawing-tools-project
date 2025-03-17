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
        private List<Line> lines; // The collection of lines to draw on the canvas

        private Line selectedLine = null;
        private Point lastMousePosition;
        private bool isDragging = false;

        // Constructor to pass the collection of lines
        public MoveTool(List<Line> lines)
        {
            this.lines = lines;
        }

        public void OnPaint(object sender, Graphics g)
        {
            // Draw the selected shape while it's being moved
            if (isDragging && selectedLine != null)
            {
                selectedLine.OnPaint(sender, g);
                System.Diagnostics.Debug.WriteLine($"Dragging line -> p1: ({selectedLine.p1.X}, {selectedLine.p1.Y}), p2: ({selectedLine.p2.X}, {selectedLine.p2.Y})");
            }
        }

        public void OnMouseDown(object sender, MouseEventArgs e)
        {
            // Check if we are selecting a shape
            foreach (var line in lines)
            {
                if (IsClickNearLine(e.Location, line))
                {
                    selectedLine = line;
                    lastMousePosition = e.Location;
                    isDragging = true;
                }
            }
        }

        public void OnMouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging && selectedLine != null)
            {
                Point newMousePosition = e.Location;

                int deltaX = newMousePosition.X - lastMousePosition.X;
                int deltaY = newMousePosition.Y - lastMousePosition.Y;

                selectedLine.Move(deltaX, deltaY);

                lastMousePosition = newMousePosition; // Update AFTER the move
                (sender as Panel)?.Invalidate();
            }
        }

        public void OnMouseUp(object sender, MouseEventArgs e)
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
    }
}
