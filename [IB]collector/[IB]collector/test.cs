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
    public partial class test : Form
    {
        public test()
        {
            InitializeComponent();
        }
        Random R;
        private void test_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form back = Application.OpenForms[1];
            back.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            int a = Convert.ToInt32(textBox1.Text),
                b = Convert.ToInt32(textBox2.Text),
                sum = 0;
            if (a < b)
            {
                for (int a1 = a; a1 < b + 1; a1++)
                {
                    richTextBox1.Text += a1 + " ";
                    sum += a1;
                }
            }
            else if (a > b)
            {
                for (int a1 = a; a1 > b - 1; a1--)
                {
                    richTextBox1.Text += a1 + " ";
                    sum += a1;
                }
            }
            else
            {
                MessageBox.Show("Все числа равны", "Google", MessageBoxButtons.OK, MessageBoxIcon.Information);
                richTextBox1.Text = a + "";
                sum += a;
            }
            richTextBox1.Text += "\n\nСумма = " + sum;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Создать массив на 30 рандомных 1, 100 элементов
            richTextBox1.Text = "";
            int[] mas = new int[30];
            R = new Random();
            mas[0] = R.Next(1, 100);
            int min = mas[0],
                max = mas[0];
            string st = "";
            for (int i = 1; i < mas.Length; i++)
            {
                mas[i] = R.Next(1, 101);
                richTextBox1.Text += mas[i] + " ";
                if (mas[i] > max)
                {
                    max = mas[i];
                }
                if (mas[i] < min)
                {
                    min = mas[i];
                }
                if (mas[i] % 3 == 0)
                {
                    richTextBox2.Text += mas[i] + " ";
                }
            }
            
            MessageBox.Show("Минимальное число: " + min + "\nМаксимальное число: " + max,
                            "Внимание от Google", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //создать рандомный лист с рандомными эл.
            //кол. эл от 1 - 30
            //знач эл от -100 - 100
            R = new Random();
            int listEl = R.Next(1, 31);
            List<int> list = new List<int>();
            for (int i = 0; i < listEl; i++)
            {
                list.Add(R.Next(-100, 101));
            }
        }
    }
}
