namespace Paint
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Free = new System.Windows.Forms.Button();
            this.Rectangle = new System.Windows.Forms.Button();
            this.Line = new System.Windows.Forms.Button();
            this.Elipse = new System.Windows.Forms.Button();
            this.Color = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.Triangle = new System.Windows.Forms.Button();
            this.Save = new System.Windows.Forms.Button();
            this.Pipette = new System.Windows.Forms.Button();
            this.Fill = new System.Windows.Forms.Button();
            this.Clear = new System.Windows.Forms.Button();
            this.Load = new System.Windows.Forms.Button();
            this.Spray = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.Control;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(12, 63);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1031, 506);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseEnter += new System.EventHandler(this.pictureBox1_MouseEnter);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // Free
            // 
            this.Free.Location = new System.Drawing.Point(12, 12);
            this.Free.Name = "Free";
            this.Free.Size = new System.Drawing.Size(60, 45);
            this.Free.TabIndex = 1;
            this.Free.Text = "Pen";
            this.Free.UseVisualStyleBackColor = true;
            this.Free.Click += new System.EventHandler(this.Free_Click);
            // 
            // Rectangle
            // 
            this.Rectangle.Location = new System.Drawing.Point(78, 12);
            this.Rectangle.Name = "Rectangle";
            this.Rectangle.Size = new System.Drawing.Size(60, 45);
            this.Rectangle.TabIndex = 2;
            this.Rectangle.Text = "Rectangle";
            this.Rectangle.UseVisualStyleBackColor = true;
            this.Rectangle.Click += new System.EventHandler(this.Rectangle_Click);
            // 
            // Line
            // 
            this.Line.Location = new System.Drawing.Point(144, 12);
            this.Line.Name = "Line";
            this.Line.Size = new System.Drawing.Size(60, 45);
            this.Line.TabIndex = 3;
            this.Line.Text = "Line";
            this.Line.UseVisualStyleBackColor = true;
            this.Line.Click += new System.EventHandler(this.Line_Click);
            // 
            // Elipse
            // 
            this.Elipse.Location = new System.Drawing.Point(210, 12);
            this.Elipse.Name = "Elipse";
            this.Elipse.Size = new System.Drawing.Size(60, 45);
            this.Elipse.TabIndex = 4;
            this.Elipse.Text = "Ellipse";
            this.Elipse.UseVisualStyleBackColor = true;
            this.Elipse.Click += new System.EventHandler(this.Elipse_Click);
            // 
            // Color
            // 
            this.Color.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Color.Location = new System.Drawing.Point(413, 11);
            this.Color.Name = "Color";
            this.Color.Size = new System.Drawing.Size(64, 44);
            this.Color.TabIndex = 5;
            this.Color.UseVisualStyleBackColor = false;
            this.Color.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.Control;
            this.button2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button2.BackgroundImage")));
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.Location = new System.Drawing.Point(483, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(50, 44);
            this.button2.TabIndex = 6;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Font = new System.Drawing.Font("Times New Roman", 16.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numericUpDown2.Location = new System.Drawing.Point(803, 13);
            this.numericUpDown2.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(97, 40);
            this.numericUpDown2.TabIndex = 8;
            this.numericUpDown2.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown2.ValueChanged += new System.EventHandler(this.numericUpDown2_ValueChanged);
            // 
            // Triangle
            // 
            this.Triangle.Location = new System.Drawing.Point(276, 13);
            this.Triangle.Name = "Triangle";
            this.Triangle.Size = new System.Drawing.Size(60, 45);
            this.Triangle.TabIndex = 9;
            this.Triangle.Text = "Triangle";
            this.Triangle.UseVisualStyleBackColor = true;
            this.Triangle.Click += new System.EventHandler(this.Triangle_Click);
            // 
            // Save
            // 
            this.Save.Location = new System.Drawing.Point(539, 11);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(60, 45);
            this.Save.TabIndex = 10;
            this.Save.Text = "Save";
            this.Save.UseVisualStyleBackColor = true;
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // Pipette
            // 
            this.Pipette.Location = new System.Drawing.Point(972, 13);
            this.Pipette.Name = "Pipette";
            this.Pipette.Size = new System.Drawing.Size(59, 45);
            this.Pipette.TabIndex = 11;
            this.Pipette.Text = "Pipette";
            this.Pipette.UseVisualStyleBackColor = true;
            this.Pipette.Click += new System.EventHandler(this.Pipette_Click);
            // 
            // Fill
            // 
            this.Fill.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.Fill.Location = new System.Drawing.Point(906, 13);
            this.Fill.Name = "Fill";
            this.Fill.Size = new System.Drawing.Size(60, 45);
            this.Fill.TabIndex = 12;
            this.Fill.Text = "Fill";
            this.Fill.UseVisualStyleBackColor = true;
            this.Fill.Click += new System.EventHandler(this.Fill_Click);
            // 
            // Clear
            // 
            this.Clear.Location = new System.Drawing.Point(605, 11);
            this.Clear.Name = "Clear";
            this.Clear.Size = new System.Drawing.Size(60, 45);
            this.Clear.TabIndex = 13;
            this.Clear.Text = "Clear";
            this.Clear.UseVisualStyleBackColor = true;
            this.Clear.Click += new System.EventHandler(this.Clear_Click);
            // 
            // Load
            // 
            this.Load.Location = new System.Drawing.Point(671, 12);
            this.Load.Name = "Load";
            this.Load.Size = new System.Drawing.Size(60, 45);
            this.Load.TabIndex = 14;
            this.Load.Text = "Load";
            this.Load.UseVisualStyleBackColor = true;
            this.Load.Click += new System.EventHandler(this.Load_Click);
            // 
            // Spray
            // 
            this.Spray.Location = new System.Drawing.Point(342, 14);
            this.Spray.Name = "Spray";
            this.Spray.Size = new System.Drawing.Size(60, 45);
            this.Spray.TabIndex = 15;
            this.Spray.Text = "Spray";
            this.Spray.UseVisualStyleBackColor = true;
            this.Spray.Click += new System.EventHandler(this.Spray_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1055, 581);
            this.Controls.Add(this.Spray);
            this.Controls.Add(this.Load);
            this.Controls.Add(this.Clear);
            this.Controls.Add(this.Fill);
            this.Controls.Add(this.Pipette);
            this.Controls.Add(this.Save);
            this.Controls.Add(this.Triangle);
            this.Controls.Add(this.numericUpDown2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.Color);
            this.Controls.Add(this.Elipse);
            this.Controls.Add(this.Line);
            this.Controls.Add(this.Rectangle);
            this.Controls.Add(this.Free);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button Free;
        private System.Windows.Forms.Button Rectangle;
        private System.Windows.Forms.Button Line;
        private System.Windows.Forms.Button Elipse;
        private System.Windows.Forms.Button Color;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.Button Triangle;
        private System.Windows.Forms.Button Save;
        private System.Windows.Forms.Button Pipette;
        private System.Windows.Forms.Button Fill;
        private System.Windows.Forms.Button Clear;
        private System.Windows.Forms.Button Load;
        private System.Windows.Forms.Button Spray;
    }
}

