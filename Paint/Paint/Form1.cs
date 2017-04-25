using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Input.Manipulations;
//using System.Windows.Input.Key;
using System.Windows.Forms;

namespace Paint
{
    public partial class Form1 : Form
    {
        enum Shape
        {
            Free,
            Line,
            Ellipse,
            Reichtangle,
            Triangle,
            Fill,
            Pipette,
            Spray
        };

        SaveFileDialog SD = new SaveFileDialog();
        OpenFileDialog FD = new OpenFileDialog(); 
        
        public Color OriginColor;
        public Point start, current, end;
        public Bitmap bmp;
        public Pen pen = new Pen(System.Drawing.Color.Black, 2);
        public GraphicsPath gp; // 2nd Layer        
        Shape Current = Shape.Free;
        public Graphics g; // 1st layer
        Cursor NW = Cursor.Current;        
        Queue<Point> q = new Queue<Point>();
        bool[,] used;
        public void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {           
            start = e.Location;            
            switch (Current)
            {
                case Shape.Pipette:
                    pen.Color = bmp.GetPixel(start.X, start.Y);
                    Color.BackColor = pen.Color;
                    break;
                case Shape.Fill:
                    OriginColor = bmp.GetPixel(start.X, start.Y);
                    Fill_Area(start);
                    break;
               
            }
        }
        
        public void Fill_RandomArea(Point start, Point nw)
        {
            used = new bool[pictureBox1.Width, pictureBox1.Height];
            if (pen.Color == OriginColor)
            {
                return;
            }
            q.Enqueue(nw);
            while (q.Count > 0)
            {
                //MessageBox.Show(q.Count.ToString());
                nw = q.Dequeue();
                used[nw.X, nw.Y] = true;
                if (new Random().Next(0, 100) <= 25)
                    bmp.SetPixel(nw.X, nw.Y, pen.Color);
                TryHardt(start, new Point(nw.X + 1, nw.Y));
                TryHardt(start, new Point(nw.X - 1, nw.Y));
                TryHardt(start, new Point(nw.X, nw.Y + 1));
                TryHardt(start, new Point(nw.X, nw.Y - 1));
                
            }
            pictureBox1.Refresh();
        }
        public void TryHardt(Point start, Point nw)
        {
            //MessageBox.Show(start.X.ToString() + " " + start.Y.ToString() + "\n" + nw.X.ToString() + " " + nw.Y.ToString());
            if (nw.X < 0 || nw.X >= pictureBox1.Width || nw.Y < 0 || nw.Y >= pictureBox1.Height || Math.Abs(start.X - nw.X) + Math.Abs(start.Y - nw.Y) > pen.Width) return;
            if (used[nw.X, nw.Y]) return;
            if (new Random().Next(0, 100) <= 25)
                bmp.SetPixel(nw.X, nw.Y, pen.Color);
            q.Enqueue(nw);

        }


        public void pictureBox1_MouseEnter(object sender, EventArgs e)
        {

        }

        public void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (Current != Shape.Pipette)
            {
                NW = DefaultCursor;
            }
            if (Cursor.Current != NW)
            {
                Cursor.Current = NW;
            }
            if (e.Button == MouseButtons.Left)
            {
                Point LU, DR;
                LU = new Point();
                DR = new Point();
                switch (Current)
                {
                    case Shape.Spray:
                        Pen backup = new Pen(Color.BackColor);
                        current = e.Location;
                        float radius = (float)numericUpDown2.Value;
                        Random rnd = new Random();
                        for (int i = 0; i < 100; ++i)
                        {                           
                            double angle = rnd.NextDouble() * (Math.PI * 2);
                            double length = rnd.NextDouble() * radius;

                            double x = e.X + Math.Cos(angle) * length;
                            double y = e.Y + Math.Sin(angle) * length;

                            g.DrawEllipse(backup, new Rectangle((int)x - 1, (int)y - 1, 1, 1));
                        }
                        start = current;
                        break;
                    case Shape.Free:                        
                        current = e.Location;
                        g.DrawLine(pen, start, current);
                        start = current;
                        break;
                    case Shape.Ellipse:
                        current = e.Location;
                        gp.Reset();
                        LU = new Point(Math.Min(start.X, current.X), Math.Min(start.Y, current.Y));
                        DR = new Point(Math.Max(start.X, current.X), Math.Max(start.Y, current.Y));
                        gp.AddEllipse(new Rectangle(LU, new Size(DR.X - LU.X, DR.Y - LU.Y)));
                        break;
                    case Shape.Triangle:
                        current = e.Location;
                        gp.Reset();
                        LU = new Point(Math.Min(start.X, current.X), Math.Min(start.Y, current.Y));
                        DR = new Point(Math.Max(start.X, current.X), Math.Max(start.Y, current.Y));
                        Point top, left, right;
                        top = new Point((DR.X - LU.X) / 2 + LU.X, (LU.Y));
                        left = new Point(LU.X, DR.Y);
                        right = new Point(DR.X, DR.Y);
                        gp.AddLine(top, left);
                        gp.AddLine(top, right);
                        gp.AddLine(right, left);
                        break;
                    case Shape.Line:
                        current = e.Location;
                        gp.Reset();
                        gp.AddLine(start, current);
                        break;
                    case Shape.Reichtangle:
                        current = e.Location;
                        LU = new Point(Math.Min(start.X, current.X), Math.Min(start.Y, current.Y));
                        DR = new Point(Math.Max(start.X, current.X), Math.Max(start.Y, current.Y));
                        gp.Reset();
                        gp.AddRectangle(new Rectangle(LU, new Size(DR.X - LU.X, DR.Y - LU.Y)));
                        break;
                }
            }            
            pictureBox1.Refresh();
        }

        public void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            
            g.DrawPath(pen, gp);    
            gp.Reset();        
            pictureBox1.Refresh();
        }

        private void Line_Click(object sender, EventArgs e)
        {
            Current = Shape.Line;
        }

        private void Free_Click(object sender, EventArgs e)
        {
            Current = Shape.Free;            
        }

        private void Rectangle_Click(object sender, EventArgs e)
        {
            Current = Shape.Reichtangle;            
        }

       

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            if (cd.ShowDialog() == DialogResult.OK)
            {
                pen.Color = cd.Color;
                Color.BackColor = cd.Color;
            }
        }

        private void Elipse_Click(object sender, EventArgs e)
        {
            Current = Shape.Ellipse;            
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            pen.Width = (float) numericUpDown2.Value;
        }

        private void Triangle_Click(object sender, EventArgs e)
        {
            Current = Shape.Triangle;

        }

        private void Save_Click(object sender, EventArgs e)
        {
            
            if (SD.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image.Save(SD.FileName + ".png");
                //pictureBox1.Refresh();
                //g = Graphics.FromImage(pictureBox1.Image);
            }
            //pictureBox1.Image.Save("Deus Vult.jpg");
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void Pipette_Click(object sender, EventArgs e)
        {
            Current = Shape.Pipette;
            NW = new Cursor("C:\\Users\\Asus\\Documents\\Visual Studio 2015\\Projects\\Week #12\\Paint\\Paint\\Resources\\Skyrim-normal.cur");
            Cursor.Current = NW;            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void Fill_Click(object sender, EventArgs e)
        {
            Current = Shape.Fill;
        }

        public bool Ok(Point nw)
        {
            if (nw.X < 0 || nw.X >= pictureBox1.Width || nw.Y < 0 || nw.Y >= pictureBox1.Height) return false;
            return true;
        }
        public void Try (Point nw)
        {
            if (nw.X < 0 || nw.X >= pictureBox1.Width || nw.Y < 0 || nw.Y >= pictureBox1.Height) return;
            if (bmp.GetPixel(nw.X, nw.Y) != OriginColor) return;
            bmp.SetPixel(nw.X, nw.Y, pen.Color);
            q.Enqueue(nw);

        }
        public void Fill_Area(Point nw)
        {
            if (pen.Color == OriginColor)
            {
                return;
            }            
            q.Enqueue(nw);
            while (q.Count > 0)
            {
                //MessageBox.Show(q.Count.ToString());
                nw = q.Dequeue();
                bmp.SetPixel(nw.X, nw.Y, pen.Color);
                Try(new Point(nw.X + 1, nw.Y));
                Try(new Point(nw.X - 1, nw.Y));
                Try(new Point(nw.X, nw.Y + 1));
                Try(new Point(nw.X, nw.Y - 1));
                //nw = q.First();
                //q.Dequeue();
                //bmp.SetPixel(nw.X, nw.Y, pen.Color);
                //if (Ok(new Point(nw.X + 1, nw.Y)) && bmp.GetPixel(nw.X + 1, nw.Y) == OriginColor)
                //{
                //    bmp.SetPixel(nw.X + 1, nw.Y, pen.Color);
                //    q.Enqueue(new Point(nw.X + 1, nw.Y));
                //}
                //if (Ok(new Point(nw.X - 1, nw.Y)) && bmp.GetPixel(nw.X - 1, nw.Y) == OriginColor)
                //{
                //    bmp.SetPixel(nw.X - 1, nw.Y, pen.Color);
                //    q.Enqueue(new Point(nw.X - 1, nw.Y));
                //}
                //if (Ok(new Point(nw.X, nw.Y + 1)) && bmp.GetPixel(nw.X, nw.Y + 1) == OriginColor)
                //{
                //    bmp.SetPixel(nw.X, nw.Y + 1, pen.Color);
                //    q.Enqueue(new Point(nw.X, nw.Y + 1));
                //}
                //if (Ok(new Point(nw.X, nw.Y - 1)) && bmp.GetPixel(nw.X, nw.Y - 1) == OriginColor)
                //{
                //    bmp.SetPixel(nw.X, nw.Y + 1, pen.Color);
                //    q.Enqueue(new Point(nw.X, nw.Y - 1));
                //}
            }
            pictureBox1.Refresh();
            //bmp.SetPixel(nw.X, nw.Y, pen.Color);
            //if (bmp.GetPixel(nw.X + 1, nw.Y) == OriginColor)
            //{                
            //    Fill_Area(new Point(nw.X + 1, nw.Y));
            //}
            //if (bmp.GetPixel(nw.X - 1, nw.Y) == OriginColor)
            //{                
            //    Fill_Area(new Point(nw.X - 1, nw.Y));
            //}
            //if (bmp.GetPixel(nw.X, nw.Y + 1) == OriginColor)
            //{                
            //    Fill_Area(new Point(nw.X, nw.Y + 1));
            //}
            //if (bmp.GetPixel(nw.X, nw.Y - 1) == OriginColor)
            //{                
            //    Fill_Area(new Point(nw.X, nw.Y - 1));
            //}
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.Image = bmp;            
            pictureBox1.Refresh();
            g = Graphics.FromImage(pictureBox1.Image);
        }

        private void Load_Click(object sender, EventArgs e)
        {
            
            if (FD.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(FD.FileName);
                pictureBox1.Refresh();
                g = Graphics.FromImage(pictureBox1.Image);
            }
        }

        private void Spray_Click(object sender, EventArgs e)
        {
            Current = Shape.Spray;
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawPath(pen, gp);
        }
       
        public Form1()
        {
            InitializeComponent();
            var jpgImage = new Byte[100000];
            //var bw = new Bitmap(File.Open("Deus VUlt.jpeg", FileMode.Create));
            //var bw = new Bitmap(File.Open("Deus VUlt.jpeg", FileMode.OpenOrCreate));
            //var bw = new Bitmap("C:\\Users\\Asus\\Documents\\Visual Studio 2015\\Projects\\Week #12\\Paint\\Paint\\bin\\Debug\\Deus VUlt.jpeg");
            Bitmap bw = new Bitmap(Image.FromFile(@"C:\Users\Asus\Documents\Visual Studio 2015\Projects\Week #12\Paint\Paint\bin\Debug\Deus Vult.jpg"));
            //var bw = new BinaryWriter(File.Open("Deus Vult.jpeg", FileMode.Create, FileAccess.Write, FileShare.None)))
            //;            
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;
            result = MessageBox.Show("Want to load saved picture?", "Achtung!", buttons);
            if (result == DialogResult.Yes)
            {
                bmp = bw;
            }
            //bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            else
            {
                bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            }
            pictureBox1.Image = bmp;            
            g = Graphics.FromImage(pictureBox1.Image); 
            gp = new GraphicsPath();
            
            //button1.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.Image));

        }
    }
}