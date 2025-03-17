using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect1___Shapes
{
    public class Triangle : Shape, IDrawable, IMovable, IResizable
    {
        public Pen pen { get; set; }
        public Point p1 { get; set; }
        public Point p2 { get; set; }
        public Point p3 { get; set; }

        public Triangle(int x1, int y1, int x2, int y2, int x3, int y3)
        {
            pen = new Pen(Color.Black, 3);
            p1 = new Point(x1, y1);
            p2 = new Point(x2, y2);
            p3 = new Point(x3, y3);
        }

        public override void Draw(Graphics g)
        {
            //Desenam triunghiul cu 3 puncte
        }

        public override void Move(int deltaX, int deltaY)
        {
            //Mutam toate cele 3 puncte ale triunghiului
            p1.Offset(deltaX, deltaY);
            p2.Offset(deltaX, deltaY);
            p3.Offset(deltaX, deltaY);
        }

        public override void Resize(float factor)
        {
            if (p1 == null || p2 == null || p3 == null) return;

            //Distanta dintre Punctul1 si Punctul2 inmultita cu factorul (creste sau scade)
            int newX2 = p1.X + (int)((p2.X - p1.X) * factor);
            int newY2 = p1.Y + (int)((p2.Y - p1.Y) * factor);

            //Distanta dintre Punctul1 si Punctul3 inmultita cu factorul
            int newX3 = p1.X + (int)((p3.X - p1.X) * factor);
            int newY3 = p1.Y + (int)((p3.Y - p1.Y) * factor);

            //Mutam punctele 2 si 3 la noile pozitii
            p2 = new Point(newX2, newY2);
            p3 = new Point(newX3, newY3);
        }
    }
}
