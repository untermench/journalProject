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

namespace journalProject.ProjectWin
{
    /// <summary>
    /// Логика взаимодействия для SettingsWin.xaml
    /// </summary>
    public partial class SettingsWin : Window
    {
        public SettingsWin()
        {
            InitializeComponent();
            var user = DB.Connect.connection.Пользователь.FirstOrDefault(i => i.ID == ProjectClasses.TeacherClass.id);

            NameBox.Text = user.Имя;
            SurnameBox.Text = user.Фамилия;
            PatronymicBox.Text = user.Отчетсво;
            MailBox.Text = user.Почта;
            PasBox.Password = user.Пароль;
            LoginBox.Text = user.Логин;

        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                var user = DB.Connect.connection.Пользователь.FirstOrDefault(i => i.ID == ProjectClasses.TeacherClass.id);

                user.Имя = NameBox.Text;
                user.Фамилия = SurnameBox.Text;
                user.Отчетсво = PatronymicBox.Text;
                user.Почта = MailBox.Text;
                user.Пароль = PasBox.Password;
                user.Логин = LoginBox.Text;

                DB.Connect.connection.SaveChanges();
                MessageBox.Show("Ваши данные были изменены");
            }
            catch(Exception ex)
            {
                MessageBox.Show("Ощибка", ex.Message, MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
