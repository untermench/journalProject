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
    /// Логика взаимодействия для AdminWin.xaml
    /// </summary>
    public partial class AdminWin : Window
    {
        public AdminWin()
        {
            InitializeComponent();
            PagesFrame.Navigate(new ProjectPages.AdminUsers());

            UsersRB.IsChecked = true;
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

        private void UsersRB_Checked(object sender, RoutedEventArgs e)
        {
            PagesFrame.Navigate(new ProjectPages.AdminUsers());
        }

        private void GroupsRB_Checked(object sender, RoutedEventArgs e)
        {
            PagesFrame.Navigate(new ProjectPages.MyGroupsPage());
        }

        private void StudentsRB_Checked(object sender, RoutedEventArgs e)
        {
            PagesFrame.Navigate(new AdminPages.AdminStudentObs());

        }

        private void OtherRB_Checked(object sender, RoutedEventArgs e)
        {
            PagesFrame.Navigate(new AdminPages.LessonItemPage());
        }

        private void Cabinets_Checked(object sender, RoutedEventArgs e)
        {
            CabintWin win = new CabintWin();
            win.ShowDialog();
        }
    }
}
