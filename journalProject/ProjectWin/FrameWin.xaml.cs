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
    /// Логика взаимодействия для FrameWin.xaml
    /// </summary>
    public partial class FrameWin : Window
    {
        public FrameWin()
        {
            InitializeComponent();
            double screenHeight = System.Windows.SystemParameters.PrimaryScreenHeight;
            double taskbarHeight = screenHeight - SystemParameters.WorkArea.Height; 
            screenHeight -= taskbarHeight - 9;
            this.MaxHeight = screenHeight;
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            WindowState = WindowState.Normal;
            this.DragMove();
        }
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnRestore_Click(object sender, RoutedEventArgs e)
        {
            if (WindowState == WindowState.Normal)
                WindowState = WindowState.Maximized;
            else
                WindowState = WindowState.Normal;
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void MyClasRB_Checked(object sender, RoutedEventArgs e)
        {
            var myclass = DB.Connect.connection.Класс.FirstOrDefault(i => i.Класс_рукID == ProjectClasses.TeacherClass.id);
            if (myclass != null)
            {
                PagesFrame.Navigate(new ProjectPages.MyGroupsPage());
            }
            else
            {
                MessageBox.Show("Класс не найден");
            }
        }

        private void MyCabinetRB_Checked(object sender, RoutedEventArgs e)
        {
            MyCabinetRB.IsChecked = false;
            SettingsWin win = new SettingsWin();
            win.ShowDialog();
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow win = new MainWindow();
            win.Show();
            this.Close();
        }

        private void rdNotes_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void Border_MouseMove(object sender, MouseEventArgs e)
        {

        }
    }
}
