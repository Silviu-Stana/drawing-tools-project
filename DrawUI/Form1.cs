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
        Type selectedShape;

        private ITool selectedTool;

        List<Shape> shapes = new List<Shape>();

        public Form1()
        {
            InitializeComponent();
            selectedTool = new DrawTool(shapes, pen, selectedShape);

            //Prevent Flicker while moving the mouse
            DrawingPanel.GetType().GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic)?.SetValue(DrawingPanel, true, null);

            SelectTool(typeof(DrawTool), DRAW);
            SelectShape(typeof(Line), DrawLine);
        }

        private void DrawingPanel_Paint(object sender, PaintEventArgs e)
        {
            selectedTool.OnPaint(sender, e.Graphics);

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


        void DrawTriangle_Click(object sender, EventArgs e) => SelectShape(typeof(Triangle), DrawTriangle);
        void DrawLine_Click(object sender, EventArgs e) => SelectShape(typeof(Line), DrawLine);
        void DrawCircle_Click(object sender, EventArgs e) => SelectShape(typeof(Circle), DrawCircle);
        void DrawSquare_Click(object sender, EventArgs e) => SelectShape(typeof(Square), DrawSquare);
        void SelectShape(Type shapeType, PictureBox toolPicture)
        {
            ResetShapesBackgroundColors();
            selectedShape = shapeType;
            SetBackgroundColorForPicture(toolPicture, Color.Gainsboro);

            // If the draw tool is currently selected, update it with the new shape type
            if (selectedTool is DrawTool)
            {
                selectedTool = new DrawTool(shapes, pen, selectedShape);
            }
        }
        void ResetShapesBackgroundColors()
        {
            DrawTriangle.BackColor = Color.Transparent;
            DrawCircle.BackColor = Color.Transparent;
            DrawSquare.BackColor = Color.Transparent;
            DrawLine.BackColor = Color.Transparent;
        }
        void SetBackgroundColorForPicture(PictureBox pic, Color color) => pic.BackColor = color;




        private void DrawTool_Click(object sender, EventArgs e) => SelectTool(typeof(DrawTool), DRAW);
        private void MoveTool_Click(object sender, EventArgs e) => SelectTool(typeof(MoveTool), MOVE);
        private void RESIZE_Click(object sender, EventArgs e) => SelectTool(typeof(ResizeTool), RESIZE);
        void SelectTool(Type toolType, Label toolPicture)
        {
            ResetToolsBackgroundColors();
            SetBackgroundColorForLabel(toolPicture, Color.Gainsboro);
            if (toolType == typeof(DrawTool)) selectedTool = new DrawTool(shapes, pen, selectedShape);
            //else if (toolType == typeof(MoveTool)) selectedTool = new MoveTool(shapes);
            //else if (toolType == typeof(ResizeTool)) selectedTool = new ResizeTool(shapes);
        }
        void ResetToolsBackgroundColors()
        {
            MOVE.BackColor = Color.White;
            DRAW.BackColor = Color.White;
            RESIZE.BackColor = Color.White;
        }
        void SetBackgroundColorForLabel(Label label, Color color) => label.BackColor = color;


        private void DrawingPanel_MouseDown(object sender, MouseEventArgs e) => selectedTool.OnMouseDown(sender, e);
        private void DrawingPanel_MouseMove(object sender, MouseEventArgs e) => selectedTool.OnMouseMove(sender, e);
        private void DrawingPanel_MouseUp(object sender, MouseEventArgs e) => selectedTool.OnMouseUp(sender, e);
    }
}
