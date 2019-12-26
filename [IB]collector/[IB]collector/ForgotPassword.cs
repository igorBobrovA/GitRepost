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

namespace _IB_collector
{
    public partial class ForgotPassword : Form
    {
        public ForgotPassword()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //MailAddress MA = new MailAddress(textBox1.Text);
                MailAddress From = new MailAddress("SigmaIrkReports@mail.ru", "GitRpost");
                MailAddress to = new MailAddress("bobrovigor250107@gmail.com");
                MailMessage m = new MailMessage(From, to);
                m.Subject = "восстановление пароля";
                Random R = new Random();
                int cod = R.Next();
                m.Body = "код для восстановления пароля: <br>" + "<p stule=\"font-size:20px;\"><b>" + cod + "</b></p>";
                m.IsBodyHtml = true;
                SmtpClient SMTP = new SmtpClient("smtp.mail.ru", 587);
                SMTP.Credentials = new NetworkCredential("SigmaIrkReports@mail.ru", "OstanovkaSuvorova");
                SMTP.EnableSsl = true;
                SMTP.DeliveryMethod = SmtpDeliveryMethod.Network;
                SMTP.Send(m);
            }
            catch 
            {
                MessageBox.Show("Электронный адрес введён неправильно", "Ошибка при вводе", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ForgotPassword_Load(object sender, EventArgs e)
        {

        }
    }
}
