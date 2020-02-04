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
            richTextBox2.Text = "";
            richTextBox3.Text = "";
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
                    z = R.NextDouble();// * 10;
                    if (z < Pa)
                    { V = V + S;
                    }
                }
                       
                richTextBox1.Text = "Сумма денег: " + V;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            richTextBox2.Text = "";
            richTextBox3.Text = "";
            int N = 0,
                NumM = 0,
                NumP = 0,
                NumW = 0;
            double P = 0,
                   z = 0;
            string Who = "";
            Random R = new Random();
            if (textBox5.Text != "" || textBox7.Text != "")
            {
                N = Convert.ToInt32(textBox5.Text);
                P = Convert.ToDouble(textBox6.Text);
                for (int i = 0; i < N; i++)
                {
                    NumM = R.Next(0, 20);
                    for (int a = 0; a < NumM; a++)
                    {
                        z = R.NextDouble();
                        if (z < P)
                        {
                            NumP++;
                            NumW++;
                        }
                    }
                    Who += (i + 1) + " продавец сделал продаж: " + NumW +"\n";
                    NumW = 0;
                }
                richTextBox2.Text = "Число покупок: " + NumP + "\n\n" + Who;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            richTextBox2.Text = "";
            richTextBox3.Text = "";
            Random R = new Random();
            double A1 = 0,
                   A2 = 0,
                   A3 = 0,
                   NumAP1 = 0,
                   NumAP2 = 0,
                   NumAP3 = 0,
                   z = 0;
            int day = 0,
                NumP = 0,
                NumA1 = 0,
                NumA2 = 0,
                NumA3 = 0,
                NumAA1 = 0,
                NumAA2 = 0,
                NumAA3 = 0;
            string tovar = " товар купили: ",
                   EveryDay1 = "",
                   EveryDay2 = "",
                   EveryDay3 = "";
            if (textBox9.Text != "")
            {
                day = Convert.ToInt32(textBox9.Text);
            }
            if (textBox8.Text != "")
            {
                A3 = Convert.ToDouble(textBox8.Text);
            }
            if (textBox7.Text != "")
            {
                A2 = Convert.ToDouble(textBox7.Text);
            }
            if (textBox6.Text != "")
            {
                A1 = Convert.ToDouble(textBox6.Text);
            }
            if (A1 + A2 + A3 > 1)
            {
                MessageBox.Show("Ошибка генерации", "Ошибка генерации", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else
            {
                for (int i = 0; i < day; i++)
                {
                    NumP = R.Next(1, 151);
                    for (int a = 0; a < NumP; a++)
                    {
                        z = R.NextDouble();
                        if (z < A1)
                        {
                            NumA1++;
                            NumAA1++;
                        }
                        else if (z < A1 + A2)
                        {
                            NumA2++;
                            NumAA2++;
                        }
                        else
                        {
                            NumA3++;
                            NumAA3++;
                        }
                    }
                    EveryDay1 += "1 вид товара купили " + NumAA1 + " за " + (i + 1) + " дней\n";
                    NumAA1 = 0;
                    EveryDay2 += "2 вид товара купили " + NumAA2 + " за " + (i + 1) + " дней\n";
                    NumAA2 = 0;
                    EveryDay3 += "3 вид товара купили " + NumAA3 + " за " + (i + 1) + " дней\n";
                    NumAA3 = 0;

                }
                richTextBox3.Text = "За " + day + " дней было куплено: " + 1 + tovar + NumA1 + "\n" + 2 + tovar + NumA2 + "\n" + 3 + tovar + NumA3 + "\n" + EveryDay1 + EveryDay2 + EveryDay3;
            }                   
        }
    }
}
