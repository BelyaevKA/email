using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Письма.UserClasses;

namespace Письма
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            textBox1.Text = "task_code_development@list.ru";
            textBox2.Text = "Антон Игоревич";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) ||
                    string.IsNullOrWhiteSpace(textBox2.Text) ||
                    string.IsNullOrWhiteSpace(textBox3.Text) ||
                    string.IsNullOrWhiteSpace(textBox4.Text))
            {
                MessageBox.Show("заполните все поля");
                return;
            }
            string smtp = "smtp.mail.ru";
            StringPair fromInfo = new StringPair("npfep33@mail.ru","Хазеев Д.Р. и Беляев К.А.");
            string password = "ZaZJJwsvHujZYed885L0";

            StringPair toInfo = new StringPair(textBox1.Text, textBox2.Text);
            string subject = textBox3.Text;
            string body = $"{DateTime.Now}\n" +
                $"{Dns.GetHostName()} \n" +
                $"{Dns.GetHostAddresses(Dns.GetHostName()).First()} \n" +
                $"{textBox4.Text}";

            InfoEmailSending info = new InfoEmailSending(smtp, fromInfo, password, toInfo, subject, body);
            SendingEmail sendingEmail = new SendingEmail(info);
            sendingEmail.Send();

            MessageBox.Show("Письмо отправлено!");
            foreach ( TextBox textBox in Controls.OfType<TextBox>())
            {
                textBox.Text = "";
            }

        }
    }
}
