using System;
using System.Drawing;
using System.Windows.Forms;

namespace Proiect1___Shapes.Repository
{
    public interface ITool
    {
        void OnPaint(object sender, Graphics g);
        void OnMouseDown(object sender, MouseEventArgs e);
        void OnMouseMove(object sender, MouseEventArgs e);
        void OnMouseUp(object sender, MouseEventArgs e);
    }
}
