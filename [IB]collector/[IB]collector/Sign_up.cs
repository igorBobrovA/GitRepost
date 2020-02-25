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
using System.Net;
using System.Net.Mail;

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
            Form SI = Application.OpenForms[0];
            SI.Show();
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
                pictureBox1.Image = Image.FromFile("image/Open.png");
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
                pictureBox1.Image = Image.FromFile("image/Close.png");
            }
            else
            {
                IsVisibale = true;
                textBox2.PasswordChar = '\0';
                pictureBox1.Image = Image.FromFile("image/Open.png");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "Login" && textBox2.Text != "Password" && textBox3.Text != "Gmail")
            {
                bool IsExists = false;
                StreamReader User_Info = new StreamReader("users/Users_info.txt");
                while (!User_Info.EndOfStream)
                {
                    string[] tmp = User_Info.ReadLine().Split(',');
                    try
                    {
                        MailAddress MA = new MailAddress(textBox3.Text);
                        if (tmp[0] == textBox1.Text)
                        {
                            MessageBox.Show("Данное имя пользователя уже используется", "Ошибка при регистрации", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            IsExists = true;
                            break;
                        }
                        if (tmp[3] == textBox3.Text)
                        {
                            MessageBox.Show("Данный електронный адрес уже используется", "Ошибка при регистрации", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            IsExists = true;
                            break;
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Електронный адрес введён неверно", "Ошибка при регистрации", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        IsExists = true;
                        break;
                    }
                }
                User_Info.Close();
                if (!IsExists)
                {
                    StreamWriter User_write = new StreamWriter("users/Users_info.txt", true);
                    User_write.WriteLine(textBox1.Text + "," + textBox2.Text + "," + textBox3.Text + ",u,False");
                    MessageBox.Show("Вы успешно зарегистрировались", "Регистрация успешна", MessageBoxButtons.OK, MessageBoxIcon.Information);                 
                    User_write.Close();
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Все поля должны быть заполнены", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
