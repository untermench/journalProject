using System;
using System.Collections.Generic;
using System.Linq;
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

namespace journalProject.AdminWins
{
    /// <summary>
    /// Логика взаимодействия для AdminAddWin.xaml
    /// </summary>
    public partial class AdminAddWin : Window
    {
        public AdminAddWin()
        {
            InitializeComponent();
            userTypeCB.ItemsSource = DB.Connect.connection.Тип_пользователя.ToList();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (NameBox.Text == " ".Trim() || SurnameBox.Text == " ".Trim() || PatronymicBox.Text == " ".Trim() || LoginBox.Text == " ".Trim() || PasBox.Password == " ".Trim() || MailBox.Text == " ".Trim())
                {
                    MessageBox.Show("Заполните пустые поля!");
                }
                else
                {
                    var user = new DB.Пользователь();

                    user.Тип = ((DB.Тип_пользователя)userTypeCB.SelectedItem).ID;
                    user.Имя = NameBox.Text;
                    user.Фамилия = SurnameBox.Text;
                    user.Отчетсво = PatronymicBox.Text;
                    user.Логин = LoginBox.Text;
                    user.Пароль = PasBox.Password;
                    user.Почта = MailBox.Text;

                    var loginTest = DB.Connect.connection.Пользователь.FirstOrDefault(i => i.Логин == LoginBox.Text);
                    if (loginTest != null)
                    {
                        MessageBox.Show("Данный логин занят!");
                    }
                    else
                    {
                        var mailText = DB.Connect.connection.Пользователь.FirstOrDefault(i => i.Почта == MailBox.Text);
                        if (mailText != null)
                        {
                            MessageBox.Show("Данная почта занята!");
                        }
                        else
                        {
                            DB.Connect.connection.Пользователь.Add(user);
                            DB.Connect.connection.SaveChanges();
                            MessageBox.Show("Пользователь успешно добавлен!");
                            Close();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка", ex.Message);
            }
        }

        private void userTypeCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selection_gp = userTypeCB.SelectedItem as DB.Тип_пользователя;
        }
    }
}
