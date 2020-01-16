using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Graphics gr = Graphics.FromImage(pictureBox1.Image);
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
    }
}
