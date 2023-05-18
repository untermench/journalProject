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
            hren.ItemsSource = DB.Connect.connection.Пользователь.ToList();
        }

        private void loginButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var log = DB.Connect.connection.Пользователь.FirstOrDefault(i => i.Логин == _logBox.Text.TrimEnd().TrimStart() && i.Пароль == _pasBox.Password.TrimEnd().TrimStart());
                if (log != null)
                {
                    ProjectClasses.TeacherClass.id = log.ID;
                    switch (log.Тип)
                    {
                        case 1:
                            {
                                ProjectWin.AdminWin wiad = new ProjectWin.AdminWin();
                                wiad.Show();
                                Close();
                                break;
                            }

                        case 2:
                            {
                                ProjectWin.FrameWin win = new ProjectWin.FrameWin();
                                win.Show();
                                Close();
                                break;
                            }
                    }
                }
                else MessageBox.Show("Указаны неверные данные");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }
        }

        private void ResetPasswordButton_Click(object sender, RoutedEventArgs e)
        {
            ProjectWin.ResetPasswordWin win = new ProjectWin.ResetPasswordWin();
            win.ShowDialog();
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }
    }
}
