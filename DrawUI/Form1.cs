using Proiect1___Shapes;
using Proiect1___Shapes.Repository;
using Proiect1___Shapes.Tools;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace DrawUI
{
    public partial class Form1 : Form
    {
        Graphics g;
        Pen pen = new Pen(Color.Black, 3);

        private Func<Shape> shapeFactory;
        private ITool currentTool;
        private List<Shape> shapes = new List<Shape>();


        public Form1()
        {
            InitializeComponent();

            //Prevent Flicker while moving the mouse
            DrawingPanel.GetType().GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic)?.SetValue(DrawingPanel, true, null);

            SelectTool(DRAW, () => new DrawTool(shapeFactory));
            SelectShape(DrawLine, () => new Line());
        }

        private void DrawingPanel_Paint(object sender, PaintEventArgs e)
        {
            // To draw on THIS panel
            g = e.Graphics;

            // Enable anti-aliasing
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            foreach (var shape in shapes) shape.Draw(g);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.SuspendLayout();
        }


        void DrawTriangle_Click(object sender, EventArgs e) => SelectShape(DrawTriangle, () => new Triangle());
        void DrawLine_Click(object sender, EventArgs e) => SelectShape(DrawLine, () => new Line());
        void DrawCircle_Click(object sender, EventArgs e) => SelectShape(DrawCircle, () => new Circle());
        void DrawSquare_Click(object sender, EventArgs e) => SelectShape(DrawSquare, () => new Square());

        private void SelectShape(PictureBox toolPicture, Func<Shape> shapeFactory)
        {
            ResetShapesBackgroundColors();
            SetBackgroundColorForPicture(toolPicture, Color.Gainsboro);

            // Set the current tool to DrawTool with the selected shape factory
            currentTool = new DrawTool(() =>
            {
                var shape = shapeFactory(); // Create a shape instance
                shapes.Add(shape);
                return shape;
            });
        }
        void ResetShapesBackgroundColors()
        {
            DrawTriangle.BackColor = Color.Transparent;
            DrawCircle.BackColor = Color.Transparent;
            DrawSquare.BackColor = Color.Transparent;
            DrawLine.BackColor = Color.Transparent;
        }
        void SetBackgroundColorForPicture(PictureBox pic, Color color) => pic.BackColor = color;




        private void DrawTool_Click(object sender, EventArgs e) => SelectTool(DRAW, () => new DrawTool(shapeFactory));
        private void MoveTool_Click(object sender, EventArgs e) => SelectTool(MOVE, () => new MoveTool(shapeFactory));
        private void RESIZE_Click(object sender, EventArgs e) => SelectTool(RESIZE, () => new ResizeTool(shapeFactory));
        void SelectTool(Label toolPicture, Func<ITool> toolFactory)
        {
            ResetToolsBackgroundColors();
            SetBackgroundColorForLabel(toolPicture, Color.Gainsboro);

            // Create the selected tool dynamically
            currentTool = toolFactory();
        }
        void ResetToolsBackgroundColors()
        {
            MOVE.BackColor = Color.White;
            DRAW.BackColor = Color.White;
            RESIZE.BackColor = Color.White;
        }
        void SetBackgroundColorForLabel(Label label, Color color) => label.BackColor = color;


        private void DrawingPanel_MouseDown(object sender, MouseEventArgs e)
        {
            currentTool.OnMouseDown(e.Location);
            Invalidate();
        }
        private void DrawingPanel_MouseMove(object sender, MouseEventArgs e)
        {
            currentTool.OnMouseMove(e.Location);
            Invalidate();
        }
        private void DrawingPanel_MouseUp(object sender, MouseEventArgs e)
        {
            currentTool.OnMouseUp(e.Location);
            Invalidate();
        }
    }
}
