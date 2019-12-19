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
    public partial class Sign_in : Form
    {
        bool IsVisibale = true;
        public Sign_in()
        {
            InitializeComponent();
        }
        private void Sign_in_Shown(object sender, EventArgs e)
                {
            button1.Focus();
                }
        private void button2_Click(object sender, EventArgs e)
        {
            Form SU = new Sign_up();
            SU.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (IsVisibale == true && textBox2.Text != "Password")
            {
                IsVisibale = false;
                textBox2.PasswordChar = '*';
                pictureBox1.Image = Image.FromFile("image/Close.png");
            }
            else
            {
                IsVisibale = true;
                textBox2.PasswordChar = '\0';
                pictureBox1.Image = Image.FromFile("image/Open.png");
            }
        }

        private void tb_enter(object sender, EventArgs e)
        {
            TextBox tb = sender as TextBox;
            if (tb.Text == "Login" || tb.Text == "Password" || tb.Text == "Gmail")
            {
                tb.Text = "";
                tb.ForeColor = Color.Black;
            }
        }

        private void tb_leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "Login";
                textBox1.ForeColor = Color.DarkGray;
            }
            else if (textBox2.Text == "")
            {
                textBox2.PasswordChar = '\0';
                textBox2.Text = "Password";
                textBox2.ForeColor = Color.DarkGray;
                pictureBox1.Image = Image.FromFile("image/Open.png");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
