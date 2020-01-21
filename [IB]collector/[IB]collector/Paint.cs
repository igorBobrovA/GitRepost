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
        float MoonY = 470F, SunY = 50F;
        int alfo2 = 255, alfo = 255, BlackCordX = -255;

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
                new Point(50, 50), new Point(300, 3000), Color.DarkGray, Color.DarkGray);

            gr.FillEllipse(Brushes.Black, 50, 50, 300, 300);
            gr.FillEllipse(Brushes.Teal, 0, 50, 300, 300);
        }
        

        private void timer1_Tick(object sender, EventArgs e)
        {
            BlackCordX++;
            if (BlackCordX >= -157 && BlackCordX < 98)
            {
                alfo--;
            }
            else if(BlackCordX > 98 && alfo < 255)
            {
                alfo++;
            }
            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Graphics gr = Graphics.FromImage(pictureBox1.Image);
            gr.FillRectangle(Brushes.Black, 0, 0, 470, 470);
            Brush br = new SolidBrush(Color.FromArgb(alfo, 0, 191, 255));
            gr.FillRectangle(br, 0, 0, 470, 470);
            GraphicsPath path = new GraphicsPath();
            path.AddEllipse(98, 98, 250, 250);
            PathGradientBrush brush = new PathGradientBrush(path);
            brush.CenterColor = Color.Yellow;
            Color[] colors = { Color.Orange };
            brush.SurroundColors = colors;
            gr.FillEllipse(brush, 98, 98, 255, 255);
            gr.FillEllipse(Brushes.Black, BlackCordX, 98, 255, 255);
            if (BlackCordX == 600)
            {
                BlackCordX = -255;
                alfo = 255;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled || timer2.Enabled)
            {
                timer1.Enabled = false;
                timer2.Enabled = false;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            SunY += 1.647F;
            if (alfo2 > 0) alfo2--;

            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Graphics gr = Graphics.FromImage(pictureBox1.Image);
            gr.FillRectangle(Brushes.Black, 0, 0, 470, 470);
            Brush br = new SolidBrush(Color.FromArgb(alfo2, 0, 191, 255));
            Brush Lime = new SolidBrush(Color.FromArgb(alfo2, 50, 205, 50));
            Brush LimeGreen = new SolidBrush(Color.FromArgb(alfo2, 20, 80, 0));
            gr.FillRectangle(br, 0, 0, 470, 470);
            GraphicsPath path = new GraphicsPath();
            path.AddEllipse(135, SunY, 200, 200);
            PathGradientBrush brush = new PathGradientBrush(path);
            brush.CenterColor = Color.Yellow;
            Color[] colors = { Color.Orange };
            brush.SurroundColors = colors;
            
            gr.FillEllipse(brush, 135, SunY, 200, 200); //солнце
            
            if (SunY > 470)
            {
                if (MoonY > 50)
                {
                    MoonY -= 1.647F;
                    GraphicsPath path1 = new GraphicsPath();
                    path1.AddEllipse(135, MoonY, 200, 200);
                    PathGradientBrush brush1 = new PathGradientBrush(path1);
                    brush1.CenterColor = Color.Gray;
                    Color[] colors1 = { Color.White };
                    brush1.SurroundColors = colors1;
                    gr.FillEllipse(brush1, 135, MoonY, 200, 200);
                }
            }

            gr.FillEllipse(Brushes.DarkGreen, 180, 350, 400, 200);  //задний план
            gr.FillEllipse(Brushes.DarkGreen, -100, 340, 400, 375); //    /|\
            gr.FillEllipse(Lime, 180, 350, 400, 200);       //             |
            gr.FillEllipse(LimeGreen, -100, 340, 400, 375); //передний план
        }

        private void button6_Click(object sender, EventArgs e)
        {
            MoonY = 470F; SunY = 50F; alfo2 = 255;
            timer2.Enabled = true;
        }
    }
}
