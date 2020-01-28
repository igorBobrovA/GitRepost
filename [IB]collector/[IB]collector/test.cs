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
            richTextBox2.Text = "";
            richTextBox3.Text = "";
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
                richTextBox1.Text = a + "\n";
                sum += a;
            }
            richTextBox1.Text += "\n\nСумма = \n" + sum;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Создать массив на 30 рандомных 1, 100 элементов
            richTextBox1.Text = "";
            richTextBox2.Text = "";
            richTextBox3.Text = "";
            int[] mas = new int[50];
            R = new Random();
            mas[0] = R.Next(-100, 101);
            int min = mas[0],
                max = mas[0];
            string st = "";
            for (int i = 1; i < mas.Length; i++)
            {
                mas[i] = R.Next(-100, 101);
                richTextBox1.Text += mas[i] + "\n";
                if (mas[i] > max)
                {
                    max = mas[i];
                }
                if (mas[i] < min)
                {
                    min = mas[i];
                }
                if (mas[i] > 0)
                {
                    richTextBox2.Text += mas[i] + "\n";
                }
                if (mas[i] % 3 == 0)
                {
                    richTextBox3.Text += mas[i] + "\n";
                }
            }
            
            MessageBox.Show("Минимальное число: " + min + "\nМаксимальное число: " + max,
                            "Внимание от Google", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            richTextBox2.Text = "";
            richTextBox3.Text = "";
            R = new Random();
            List<int> list = new List<int>();
            for (int i = 0; i < 20; i++)
            {
                list.Add(R.Next(-1000, 1001));
                richTextBox1.Text += list[i] + "\n";
            }
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] >= 10 && list[i] <= 99 || list[i] <= -10 && list[i] >= -99)
                {
                    list.Remove(list[i]);
                    i--;
                }
            }
            for (int i = 0; i < list.Count; i++)
            {
                richTextBox2.Text += list[i] + "\n";
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            richTextBox2.Text = "";
            richTextBox3.Text = "";
            R = new Random();
            int[] mas = new int[10];
            int box = 0;
            for (int i = 0; i < 10; i++)
            {
                mas[i] = R.Next(10, 101);
                richTextBox1.Text += mas[i] + "\n";
            }
            for (int a = 0; a < 10; a++)
            {
            for (int i = 1; i < 10; i++)
            {
                if (mas[i] > mas[i - 1])
                {
                    box = mas[i];
                    mas[i] = mas[i - 1];
                    mas[i - 1] = box;
                }
            }
            }
            for (int i = 0; i < 10; i++)
            {
                richTextBox2.Text += mas[i] + "\n";
            }
        }
    }
}
