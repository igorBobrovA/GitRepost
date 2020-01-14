using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;
using System.IO;

namespace _IB_collector
{
    public partial class ForgotPassword : Form
    {
        public ForgotPassword()
        {
            InitializeComponent();
        }

        int cod, seconds = 120;
        string info;
        
        private void ForgotPassword_Shown_1(object sender, EventArgs e)
        {
            button1.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        { 
            bool IsSending = false;
            try
            {
                using(StreamReader sr = new StreamReader("users/Users_info.txt"))
                {
                    while (!sr.EndOfStream)
                    {
                        
                        string[] tmp = sr.ReadLine().Split(',');
                        if (tmp[2] == textBox1.Text)
                        {
                            info = "Ваш e-mail  " + tmp[2] + "\nВаш пароль " + tmp[1];
                            MailAddress From = new MailAddress("SigmaIrkReports@mail.ru", "GitRpost");
                            MailAddress to = new MailAddress(textBox1.Text); 
                            MailMessage m = new MailMessage(From, to);
                            m.Subject = "восстановление пароля";
                            Random R = new Random();
                            cod = R.Next();
                            m.Body = "код для восстановления пароля: <br>" + "<p stule=\"font-size:20px;\"><b>" + cod + "</b></p>";
                            m.IsBodyHtml = true;
                            SmtpClient SMTP = new SmtpClient("smtp.mail.ru", 587);
                            SMTP.Credentials = new NetworkCredential("SigmaIrkReports@mail.ru", "OstanovkaSuvorova"); //
                            SMTP.EnableSsl = true;
                            SMTP.DeliveryMethod = SmtpDeliveryMethod.Network;
                            SMTP.Send(m);
                            textBox2.ReadOnly = false;
                            IsSending = true;
                            timer1.Enabled = true;
                            button1.Enabled = false;
                            seconds = 120;
                            break;
                        }
                    }
                }
                if (!IsSending)
                {
                    MessageBox.Show("Код не был отправлен\nПроверте" +
                        " актуальность введённых данных", "Ошибка", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            catch  (Exception ex)
            {
                MessageBox.Show("Произошла ошибка: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void TB_enter(object sender, EventArgs e)
        {
            TextBox tb = sender as TextBox;
            if (tb.ForeColor == Color.DarkGray)
            {
                tb.Text = "";
                tb.ForeColor = Color.Black;
            }
        }

        private void TB_leave(object sender, EventArgs e)
        {
            TextBox tb = sender as TextBox;
            if (tb.Name == "textBox1" && tb.Text == "")
            {
                tb.Text = "Введите Gmail";
                tb.ForeColor = Color.DarkGray;
            }
            else if (tb.Name == "textBox2" && tb.Text == "")
            {
                tb.Text = "Введите код";
                tb.ForeColor = Color.DarkGray;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (cod.ToString() == textBox2.Text)
                        {
                            MessageBox.Show(info, "Успешное Вастоеавление пароля"
                                            , MessageBoxButtons.OK, MessageBoxIcon.Information); 
                        }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            seconds--;
            label1.Text = "Следующий код можно отправить через " + seconds + " сек.";
            if (seconds == 0)
            {
                button1.Enabled = true;
                timer1.Enabled = false;
            }
        }
    }
}
