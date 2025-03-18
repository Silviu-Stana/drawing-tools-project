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
        private IDrawable selectedShape = null;
        private Point lastMousePosition;
        private bool isDragging = false;

        private readonly List<IDrawable> shapes; // Retrieves the list of shapes dynamically

        public MoveTool(List<IDrawable> shapes)
        {
            this.shapes = shapes;
        }


        public void OnMouseDown(Point point)
        {
            selectedShape = FindClosestShape(point, shapes);

            if (selectedShape != null)
            {
                lastMousePosition = point;
                isDragging = true;
            }
        }

        public void OnMouseMove(Point point)
        {
            if (isDragging && selectedShape is IMovable movableShape)
            {
                int deltaX = point.X - lastMousePosition.X;
                int deltaY = point.Y - lastMousePosition.Y;

                movableShape.Move(deltaX, deltaY);
                lastMousePosition = point; // Update after moving
            }
        }

        public void OnMouseUp(Point point)
        {
            isDragging = false;
            selectedShape = null;
        }

        private IDrawable FindClosestShape(Point p, List<IDrawable> shapes)
        {
            const int threshold = 15; // Tolerance for selection
            IDrawable closestShape = null;
            float minDistance = float.MaxValue;

            foreach (var shape in shapes)
            {
                float distance = GetDistanceToShape(p, shape);

                if (distance < threshold && distance < minDistance)
                {
                    minDistance = distance;
                    closestShape = shape;
                }
            }

            return closestShape;
        }

        private float GetDistanceToShape(Point p, IDrawable shape)
        {
            switch (shape)
            {
                case Line line:
                    return GetDistanceToLine(p, line);
                case Triangle triangle:
                    return GetDistanceToPolygon(p, new[] { triangle.p1, triangle.p2, triangle.p3 });
                case Square rectangle:
                    return GetDistanceToSquare(p, rectangle);
                case Circle circle:
                    return GetDistanceToCircle(p, circle);
                default:
                    return float.MaxValue;
            }
        }

        private float GetDistanceToLine(Point p, Line line)
        {
            float dx = line.p2.X - line.p1.X;
            float dy = line.p2.Y - line.p1.Y;
            float lenSq = dx * dx + dy * dy;

            if (lenSq == 0) return Distance(p, line.p1);

            float t = ((p.X - line.p1.X) * dx + (p.Y - line.p1.Y) * dy) / lenSq;
            t = Math.Max(0, Math.Min(1, t));

            float closestX = line.p1.X + t * dx;
            float closestY = line.p1.Y + t * dy;

            return Distance(p, new Point((int)closestX, (int)closestY));
        }

        private float GetDistanceToPolygon(Point p, Point[] vertices)
        {
            float minDistance = float.MaxValue;

            for (int i = 0; i < vertices.Length; i++)
            {
                Point p1 = vertices[i];
                Point p2 = vertices[(i + 1) % vertices.Length]; // Loop around

                float distance = GetDistanceToLine(p, new Line { p1 = p1, p2 = p2 });

                if (distance < minDistance)
                    minDistance = distance;
            }

            return minDistance;
        }

        private float GetDistanceToSquare(Point p, Square square)
        {
            // Define the top-left corner of the square (p2)
            Point topLeft = square.p2;
            // Calculate the bottom-right corner using the width and height
            Point bottomRight = new Point(topLeft.X + square.width, topLeft.Y + square.height);

            // Define the four corners of the square
            Point topRight = new Point(bottomRight.X, topLeft.Y);
            Point bottomLeft = new Point(topLeft.X, bottomRight.Y);

            // Calculate the distance to each side of the square
            float distanceToTop = GetDistanceToLine(p, new Line { p1 = topLeft, p2 = topRight });
            float distanceToRight = GetDistanceToLine(p, new Line { p1 = topRight, p2 = bottomRight });
            float distanceToBottom = GetDistanceToLine(p, new Line { p1 = bottomRight, p2 = bottomLeft });
            float distanceToLeft = GetDistanceToLine(p, new Line { p1 = bottomLeft, p2 = topLeft });

            // Return the minimum distance to any side of the square
            return Math.Min(Math.Min(distanceToTop, distanceToRight), Math.Min(distanceToBottom, distanceToLeft));
        }


        private float GetDistanceToCircle(Point p, Circle circle)
        {
            float centerDistance = Distance(p, circle.p1);
            return Math.Abs(centerDistance - circle.Radius);
        }

        private float Distance(Point p1, Point p2)
        {
            float dx = p1.X - p2.X;
            float dy = p1.Y - p2.Y;
            return (float)Math.Sqrt(dx * dx + dy * dy);
        }
    }
}
