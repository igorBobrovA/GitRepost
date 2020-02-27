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
using System.Data.SQLite;

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
                finally
                {
                    SQLiteConnection con = new SQLiteConnection(@"DataSource=Users/Users_info.db;Version=3;");
                    SQLiteCommand cmd = new SQLiteCommand();
                    cmd.Connection = con;
                    con.Open();
                    if (LoginOrGmail == 0)
                    {
                        cmd.CommandText = "Select * From Users Where login = '" + textBox1.Text + "'"+
                            " and password = '" + textBox2.Text + "'";
                    }
                    else
                    {
                        cmd.CommandText = "Select * From Users Where email = '" + textBox1.Text + "'" +
                            " and password = '" + textBox2.Text + "'";
                    }
                    SQLiteDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        string log = reader.GetValue(1).ToString(),
                               rights = reader.GetValue(4).ToString(),
                               ban = reader.GetValue(5).ToString();
                        if (ban == "False")
                        {
                            MessageBox.Show("Вы успешно авторизовались", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Form main = new MAIN(log, rights);
                            main.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Вас забанили\nВы не авторизовались", "У вас бан", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Вы не авторизовались", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    con.Close();
                }
                
                /*using(StreamReader SR = new StreamReader("users/Users_info.txt"))
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
                }*/
            }
            else
                MessageBox.Show("Все поля должны быть заполнены", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form FP = new ForgotPassword();
            FP.Show();
        }

        private void label1_Click_1(object sender, EventArgs e)
        {
            Form main = new MAIN("Ха_Лолка", "a");
            main.Show();
            this.Hide();
        }

        private void label1_MouseEnter(object sender, EventArgs e)
        {
            Form main = new MAIN("Ха_Лолка", "a");
            main.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            button4.Visible = false;
            this.Focus();
        }

        private void Sign_in_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                button4.Visible = true;
            }
        }
    }
}
