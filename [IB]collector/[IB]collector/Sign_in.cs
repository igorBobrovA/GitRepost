using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net.Mail;

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
            if (tb.Text == "Login or Gmail" || tb.Text == "Password" || tb.Text == "Gmail")
            {
                tb.Text = "";
                tb.ForeColor = Color.Black;
            }
        }

        private void tb_leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "Login or Gmail";
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
            if (textBox1.Text != "Login or Gmail" && textBox2.Text != "Password")
            {
                bool Acces = false;
                string login_Gmail = textBox1.Text,
                       Password = textBox2.Text;
                int LoginOrGmail = 0;
                try
                {
                    MailAddress MA = new MailAddress(textBox1.Text);
                    LoginOrGmail = 2;
                }
                catch
                {
                    LoginOrGmail = 0;
                }
                using(StreamReader SR = new StreamReader("users/Users_info.txt"))
                {
                    while (!SR.EndOfStream)
                    {
                        string[] tmp = SR.ReadLine().Split(',');
                        if (login_Gmail == tmp[LoginOrGmail] && Password == tmp[1])
                        {
                            MessageBox.Show("Вы успешно авторизовались", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Acces = true;
                            Form main = new MAIN(login_Gmail, tmp[3]);
                            main.Show();
                            this.Hide();
                            break;
                        }
                    }
                }
                if (!Acces)
                {
                    MessageBox.Show("Вы не авторизовались", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                MessageBox.Show("Все поля должны быть заполнены", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            Form FP = new ForgotPassword();
            FP.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Form Main = new MAIN("Хатскер", "a");
            Main.Show();
            this.Hide();
        }
    }
}
