using Newtonsoft.Json;
using System;
using System.Drawing;

namespace Proiect1___Shapes
{
    public class Square : Shape, IDrawable, IMovable, IResizable
    {
        private Pen pen { get; set; }
        private Point p1 { get; set; }
        public override string JsonType => "Square";

        public Point p2 { get; set; }
        [JsonProperty]
        public int width, height;

        private bool isFinalized = false;
        public override bool IsFinalized { get => isFinalized; set => isFinalized = value; }
        public override void FinalizeDrawing() => isFinalized = true;

        public Square()
        {
            pen = new Pen(Color.Black, 3);
        }

        public override void Draw(Graphics g)
        {
            if (width < 0 && height < 0)
            {
                //Daca mouse-ul a fost miscat in sus si la stanga, inseamna ca pozitia X si Y sunt ambele negative
                p2 = new Point(p1.X + width, p1.Y + height);
                width = Math.Abs(width);
                height = Math.Abs(height);
            }
            else if (width < 0)
            {
                //Daca mouse-ul a fost miscat la stanga, inseamna ca pozitia X este negativa. Square e desenat mereu din punctul stanga-sus.
                //De aceea mutam punctul p2 la noua pozitie, si desenam incepand de acolo.
                p2 = new Point(p1.X + width, p1.Y);
                width = Math.Abs(width);
            }
            else if (height < 0)
            {
                p2 = new Point(p1.X, p1.Y + height);
                height = Math.Abs(height);
            }

            g.DrawRectangle(pen, p2.X, p2.Y, width, height);
        }

        public override void Move(int deltaX, int deltaY)
        {
            //Mutam Punctul
            p1 = new Point(p1.X + deltaX, p1.Y + deltaY);
        }

        public void Resize(float deltaX, float deltaY)
        {
            // Ajusteaza in functie de miscarea mouse-ului  
            width += (int)deltaX;
            height += (int)deltaY;

            if (width < 0)
            {
                p2 = new Point(p2.X + width, p2.Y);
                width = Math.Abs(width);
            }

            if (height < 0)
            {
                p2 = new Point(p2.X, p2.Y + height);
                height = Math.Abs(height);
            }
        }

        public override void StartDrawing(Point startPoint)
        {
            p1 = startPoint;
            p2 = startPoint;
        }

        public override void UpdateDrawing(Point currentPoint)
        {
            // Calculez distanta dintre punctul p1 de si pozitia curenta a mouse-ului.
            // Pentru un patrat, lungimea si latimea sunt egale
            width = currentPoint.X - p1.X;
            height = currentPoint.Y - p1.Y;
        }
    }
}
