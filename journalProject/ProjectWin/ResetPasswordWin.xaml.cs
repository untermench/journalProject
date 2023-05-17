using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace journalProject.ProjectWin
{
    /// <summary>
    /// Логика взаимодействия для ResetPasswordWin.xaml
    /// </summary>
    public partial class ResetPasswordWin : Window
    {
        public ResetPasswordWin()
        {
            InitializeComponent();
        }
        string pas = "";
        int mailcash;
        private void goButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var mail = DB.Connect.connection.Пользователь.FirstOrDefault(i => i.Почта == mailBox.Text);
                if (mail != null)
                {
                    mailcash = mail.ID;
                    int length = 6;
                    const string valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
                    StringBuilder res = new StringBuilder();
                    Random rnd = new Random();
                    while (0 < length--)
                    {
                        res.Append(valid[rnd.Next(valid.Length)]);
                    }
                    pas = res.ToString();

                    MailAddress from = new MailAddress("k_aguero@list.ru", "Учет обучающихся колледжа");
                    MailAddress to = new MailAddress(mailBox.Text);
                    MailMessage m = new MailMessage(from, to);
                    m.Subject = "Восстановление пароля";
                    m.Body = $"<h2>Код восстановления: {pas}</h2>";
                    m.IsBodyHtml = true;
                    SmtpClient smtp = new SmtpClient("smtp.mail.ru", 2525);
                    smtp.Credentials = new NetworkCredential("k_aguero@list.ru", "DFH10VkWEttxTW5QdP5e");
                    smtp.EnableSsl = true;
                    smtp.Send(m);
                    Console.Read();
                    MessageBox.Show("Готово");

                    mailBox.Visibility = Visibility.Hidden;
                    goButton.Visibility = Visibility.Hidden;
                    mailLable.Visibility = Visibility.Hidden;

                    vvodBox.Visibility = Visibility.Visible;
                    vvodButton.Visibility = Visibility.Visible;
                    vvodLabel.Visibility = Visibility.Visible;
                }
                else
                {
                    MessageBox.Show("Неверные данные");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка" + ex.Message);
            }
        }

        private void vvodButton_Click(object sender, RoutedEventArgs e)
        {
            if (vvodBox.Text == pas)
            {
                vvodBox.Visibility = Visibility.Hidden;
                vvodButton.Visibility = Visibility.Hidden;
                vvodLabel.Visibility = Visibility.Hidden;

                pasBox.Visibility = Visibility.Visible;
                pasLabel.Visibility = Visibility.Visible;
                resetButton.Visibility = Visibility.Visible;
            }
            else
            {
                MessageBox.Show("Неверный код");
                Close();
            }
        }

        private void resetButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var user = DB.Connect.connection.Пользователь.FirstOrDefault(i => i.ID == mailcash);
                user.Пароль = pasBox.Text;
                DB.Connect.connection.SaveChanges();
                MessageBox.Show("Пароль изменен");
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка" + ex.Message);
            }

        }
    }
}