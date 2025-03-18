namespace DrawUI
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.DrawTriangle = new System.Windows.Forms.PictureBox();
            this.DrawCircle = new System.Windows.Forms.PictureBox();
            this.DrawSquare = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.DrawLine = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.DRAW = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.RESIZE = new System.Windows.Forms.Label();
            this.MOVE = new System.Windows.Forms.Label();
            this.DrawingPanel = new System.Windows.Forms.Panel();
            this.SaveShapes = new System.Windows.Forms.Button();
            this.LoadShapes = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DrawTriangle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DrawCircle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DrawSquare)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DrawLine)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // DrawTriangle
            // 
            this.DrawTriangle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.DrawTriangle.BackColor = System.Drawing.Color.Transparent;
            this.DrawTriangle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DrawTriangle.Image = ((System.Drawing.Image)(resources.GetObject("DrawTriangle.Image")));
            this.DrawTriangle.Location = new System.Drawing.Point(429, 12);
            this.DrawTriangle.MaximumSize = new System.Drawing.Size(100, 100);
            this.DrawTriangle.Name = "DrawTriangle";
            this.DrawTriangle.Size = new System.Drawing.Size(100, 100);
            this.DrawTriangle.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.DrawTriangle.TabIndex = 0;
            this.DrawTriangle.TabStop = false;
            this.DrawTriangle.Click += new System.EventHandler(this.DrawTriangle_Click);
            // 
            // DrawCircle
            // 
            this.DrawCircle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.DrawCircle.BackColor = System.Drawing.Color.Transparent;
            this.DrawCircle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DrawCircle.ErrorImage = null;
            this.DrawCircle.Image = ((System.Drawing.Image)(resources.GetObject("DrawCircle.Image")));
            this.DrawCircle.Location = new System.Drawing.Point(545, 12);
            this.DrawCircle.MaximumSize = new System.Drawing.Size(100, 100);
            this.DrawCircle.Name = "DrawCircle";
            this.DrawCircle.Size = new System.Drawing.Size(100, 100);
            this.DrawCircle.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.DrawCircle.TabIndex = 1;
            this.DrawCircle.TabStop = false;
            this.DrawCircle.Click += new System.EventHandler(this.DrawCircle_Click);
            // 
            // DrawSquare
            // 
            this.DrawSquare.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.DrawSquare.BackColor = System.Drawing.Color.Transparent;
            this.DrawSquare.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DrawSquare.Image = ((System.Drawing.Image)(resources.GetObject("DrawSquare.Image")));
            this.DrawSquare.Location = new System.Drawing.Point(667, 12);
            this.DrawSquare.MaximumSize = new System.Drawing.Size(100, 100);
            this.DrawSquare.Name = "DrawSquare";
            this.DrawSquare.Size = new System.Drawing.Size(100, 100);
            this.DrawSquare.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.DrawSquare.TabIndex = 2;
            this.DrawSquare.TabStop = false;
            this.DrawSquare.Click += new System.EventHandler(this.DrawSquare_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(280, 48);
            this.label1.TabIndex = 3;
            this.label1.Text = "Select Shape:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.DrawLine);
            this.panel1.Controls.Add(this.DrawCircle);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.DrawTriangle);
            this.panel1.Controls.Add(this.DrawSquare);
            this.panel1.Location = new System.Drawing.Point(43, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(789, 124);
            this.panel1.TabIndex = 4;
            // 
            // DrawLine
            // 
            this.DrawLine.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.DrawLine.BackColor = System.Drawing.Color.Transparent;
            this.DrawLine.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DrawLine.Image = ((System.Drawing.Image)(resources.GetObject("DrawLine.Image")));
            this.DrawLine.Location = new System.Drawing.Point(302, 12);
            this.DrawLine.MaximumSize = new System.Drawing.Size(100, 100);
            this.DrawLine.Name = "DrawLine";
            this.DrawLine.Size = new System.Drawing.Size(100, 100);
            this.DrawLine.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.DrawLine.TabIndex = 4;
            this.DrawLine.TabStop = false;
            this.DrawLine.Click += new System.EventHandler(this.DrawLine_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(75, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 48);
            this.label2.TabIndex = 4;
            this.label2.Text = "Tool:";
            // 
            // DRAW
            // 
            this.DRAW.AutoSize = true;
            this.DRAW.BackColor = System.Drawing.Color.White;
            this.DRAW.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DRAW.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.DRAW.Font = new System.Drawing.Font("Lemon", 25.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DRAW.Location = new System.Drawing.Point(206, 33);
            this.DRAW.Name = "DRAW";
            this.DRAW.Size = new System.Drawing.Size(164, 57);
            this.DRAW.TabIndex = 5;
            this.DRAW.Text = "DRAW";
            this.DRAW.Click += new System.EventHandler(this.DrawTool_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel2.Controls.Add(this.RESIZE);
            this.panel2.Controls.Add(this.MOVE);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.DRAW);
            this.panel2.Location = new System.Drawing.Point(838, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(814, 124);
            this.panel2.TabIndex = 5;
            // 
            // RESIZE
            // 
            this.RESIZE.AutoSize = true;
            this.RESIZE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.RESIZE.Font = new System.Drawing.Font("Lemon", 25.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RESIZE.ForeColor = System.Drawing.Color.Goldenrod;
            this.RESIZE.Location = new System.Drawing.Point(579, 33);
            this.RESIZE.Name = "RESIZE";
            this.RESIZE.Size = new System.Drawing.Size(182, 57);
            this.RESIZE.TabIndex = 7;
            this.RESIZE.Text = "RESIZE";
            this.RESIZE.Click += new System.EventHandler(this.RESIZE_Click);
            // 
            // MOVE
            // 
            this.MOVE.AutoSize = true;
            this.MOVE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MOVE.Font = new System.Drawing.Font("Lemon", 25.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MOVE.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.MOVE.Location = new System.Drawing.Point(390, 33);
            this.MOVE.Name = "MOVE";
            this.MOVE.Size = new System.Drawing.Size(160, 57);
            this.MOVE.TabIndex = 6;
            this.MOVE.Text = "MOVE";
            this.MOVE.Click += new System.EventHandler(this.MoveTool_Click);
            // 
            // DrawingPanel
            // 
            this.DrawingPanel.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.DrawingPanel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.DrawingPanel.Location = new System.Drawing.Point(43, 156);
            this.DrawingPanel.Name = "DrawingPanel";
            this.DrawingPanel.Size = new System.Drawing.Size(1609, 790);
            this.DrawingPanel.TabIndex = 6;
            this.DrawingPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.DrawingPanel_Paint);
            this.DrawingPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DrawingPanel_MouseDown);
            this.DrawingPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.DrawingPanel_MouseMove);
            this.DrawingPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.DrawingPanel_MouseUp);
            // 
            // SaveShapes
            // 
            this.SaveShapes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveShapes.Location = new System.Drawing.Point(72, 965);
            this.SaveShapes.Name = "SaveShapes";
            this.SaveShapes.Size = new System.Drawing.Size(220, 49);
            this.SaveShapes.TabIndex = 7;
            this.SaveShapes.Text = "Save Shapes";
            this.SaveShapes.UseVisualStyleBackColor = true;
            this.SaveShapes.Click += new System.EventHandler(this.SaveShapes_Click);
            // 
            // LoadShapes
            // 
            this.LoadShapes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoadShapes.Location = new System.Drawing.Point(311, 965);
            this.LoadShapes.Name = "LoadShapes";
            this.LoadShapes.Size = new System.Drawing.Size(220, 49);
            this.LoadShapes.TabIndex = 8;
            this.LoadShapes.Text = "Load Shapes";
            this.LoadShapes.UseVisualStyleBackColor = true;
            this.LoadShapes.Click += new System.EventHandler(this.LoadShapes_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1694, 1035);
            this.Controls.Add(this.LoadShapes);
            this.Controls.Add(this.SaveShapes);
            this.Controls.Add(this.DrawingPanel);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DrawTriangle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DrawCircle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DrawSquare)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DrawLine)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox DrawTriangle;
        private System.Windows.Forms.PictureBox DrawCircle;
        private System.Windows.Forms.PictureBox DrawSquare;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label DRAW;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label RESIZE;
        private System.Windows.Forms.Label MOVE;
        private System.Windows.Forms.Panel DrawingPanel;
        private System.Windows.Forms.PictureBox DrawLine;
        private System.Windows.Forms.Button SaveShapes;
        private System.Windows.Forms.Button LoadShapes;
    }
}

