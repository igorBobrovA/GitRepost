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
    public partial class Shop : Form
    {
        public Shop()
        {
            InitializeComponent();
        }

        private void Shop_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form back = Application.OpenForms[1];
            back.Show();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            int S = 0,
                N = 0;
            double z = 0,
                   Pa = 0,
                   V = 0;
            Random R = new Random();
            if (textBox1.Text != "" || textBox2.Text != "" || textBox3.Text != "")
            {
                N = Convert.ToInt32(textBox3.Text);
                Pa = Convert.ToDouble(textBox2.Text);
                S = Convert.ToInt32(textBox1.Text);
                for (int i = 0; i < N; i++)
                {
                    z = R.NextDouble() * 10;
                    if (z < Pa)
                    { V = V + S;
                    }
                }
                       
                richTextBox1.Text = "Сумма денег: " + V;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int N = 0,
                NumM = 0,
                NumP = 0;
            double P = 0,
                   z = 0;
            Random R = new Random();
            if (textBox5.Text != "" || textBox7.Text != "")
            {
                N = Convert.ToInt32(textBox5.Text);
                P = Convert.ToDouble(textBox7.Text);
                for (int i = 0; i < N; i++)
                {
                    NumM = R.Next(0, 20);
                    for (int a = 0; a < NumM; a++)
                    {
                        z = R.NextDouble();
                        if (z < P)
                        {
                            NumP++;
                        }
                    }
                }
                richTextBox1.Text = "Число покупок: " + NumP;
            }
        }
    }
}
