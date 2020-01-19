using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _IB_collector
{
    public partial class Paint : Form
    {
        public Paint()
        {
            InitializeComponent();
        }

        private void Paint_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form back = Application.OpenForms[1];
            back.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random r = new Random();
            int a = 50,
                b = 50,
                a1 = 1,
                b1 = 1,
                a2 = 470,                
                b2 = 470;
                a2 = a2 - a;
                b2 = b2 - b;
            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Graphics gr = Graphics.FromImage(pictureBox1.Image);
            
            int points = r.Next(1, 101);
            for (int i = 0; i < points - 1; i++)
            {
                int s1 = r.Next(a1, a2);
                int s2 = r.Next(b1, b2);
                GraphicsPath path = new GraphicsPath();
                path.AddEllipse(s1, s2, a, b);
                PathGradientBrush brush = new PathGradientBrush(path);
                brush.CenterColor = Color.FromArgb(r.Next(1, 256), r.Next(1, 256), r.Next(1, 256), r.Next(1, 256));
                Color[] colors = { Color.FromArgb(r.Next(1, 256), r.Next(1, 256), r.Next(1, 256), r.Next(1, 256)) };
                brush.SurroundColors = colors;
                gr.FillEllipse(brush, s1, s2, a, b);
            }

            

            //gr.DrawLine(Pens.Black, 10, 10, 50, 50);
            //gr.DrawEllipse(Pens.Black, 80, 80, 120, 120);
            //gr.FillEllipse(Brushes.YellowGreen, 81, 81, 118, 118);
            //gr.FillRectangle(Brushes.Aqua, 200, 200, 50, 50);
            //Random r = new Random();
            //Brush br = new SolidBrush(Color.FromArgb(r.Next(1, 256), r.Next(1, 256), r.Next(1, 256), r.Next(1, 256)));
            //Point[] points = new Point[3];
            //points[0] = new Point(50, 200);
            //points[1] = new Point(50, 300);
            //points[2] = new Point(100, 150);
            //gr.FillPolygon(br, points);
            // Должно появиться 100 кругов(рандомные цвета и 30 на 30) в рандомных местах
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Graphics gr = Graphics.FromImage(pictureBox1.Image);
            GraphicsPath path = new GraphicsPath();
            path.AddEllipse(50, 50, 300, 300);
            PathGradientBrush brush = new PathGradientBrush(path);
            brush.CenterColor = Color.Gray;
            Color[] colors = {Color.Black};
            brush.SurroundColors = colors;
            gr.FillEllipse(brush, 50, 50, 300, 300);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Graphics gr = Graphics.FromImage(pictureBox1.Image);
            LinearGradientBrush br1 = new LinearGradientBrush(
                new Point(10, 10), new Point(210, 210), Color.Blue, Color.Yellow);
            LinearGradientBrush br2 = new LinearGradientBrush(
                new Point(220, 10), new Point(220, 210), Color.Blue, Color.Yellow);
            LinearGradientBrush br3 = new LinearGradientBrush(
                new Point(10, 220), new Point(210, 220), Color.Blue, Color.Yellow);

            gr.FillRectangle(br1, 10, 10, 200, 200);
            gr.FillRectangle(br2, 220, 10, 200, 200);
            gr.FillRectangle(br3, 10, 220, 200, 200);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Graphics gr = Graphics.FromImage(pictureBox1.Image);
            LinearGradientBrush br1 = new LinearGradientBrush(
                new Point(50, 50), new Point(300, 3000), Color.DarkGray, Color.Black);

            gr.FillEllipse(Brushes.Black, 50, 50, 300, 300);
            gr.FillEllipse(Brushes.Teal, 0, 50, 300, 300);
        }
    }
}
