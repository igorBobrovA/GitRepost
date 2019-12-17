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
    public partial class Sign_up : Form
    {
        public Sign_up()
        {
            InitializeComponent();
        }

        private void Sign_up_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        bool IsVisibale = true;
        private void textBox_Enter(object sender, EventArgs e)
        {
            TextBox tb = sender as TextBox;
            if (tb.Text == "Login" || tb.Text == "Password" || tb.Text == "Gmail")
            {
                tb.Text = "";
                tb.ForeColor = Color.Black;
            }
        }

        private void Sign_up_Shown(object sender, EventArgs e)
        {
            button1.Focus();
        }

        private void textBox_Leave(object sender, EventArgs e)
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
            }
            else if (textBox3.Text == "")
            {
                textBox3.Text = "Gmail";
                textBox3.ForeColor = Color.DarkGray;
            }

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (IsVisibale == true && textBox2.Text != "Password")
            {
                IsVisibale = false;
                textBox2.PasswordChar = '*';
                pictureBox1.Image = Image.FromFile("image/.png");
            }
            else
            {
                IsVisibale = true;
                textBox2.PasswordChar = '\0';
                pictureBox1.Image = Image.FromFile(".png");
            }
        }
    }
}
