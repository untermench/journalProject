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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace journalProject
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            hren.ItemsSource = DB.Connect.connection.Учитель.ToList();
        }

        private void loginButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var log = DB.Connect.connection.Учитель.FirstOrDefault(i => i.Логин == _logBox.Text.TrimEnd().TrimStart() && i.Пароль == _pasBox.Password.TrimEnd().TrimStart());
                if (log != null)
                {
                    ProjectClasses.TeacherClass.id = log.ID;
                    ProjectWin.FrameWin win = new ProjectWin.FrameWin();
                    win.Show();
                    Close();
                }
                else MessageBox.Show("Указаны неверные данные");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }
        }
    }
}
