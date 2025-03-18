using System;
using System.Drawing;
using System.Windows.Forms;

namespace Proiect1___Shapes.Repository
{
    public interface ITool
    {
        void OnMouseDown(Point position);
        void OnMouseMove(Point position);
        void OnMouseUp(Point position);
    }
}
