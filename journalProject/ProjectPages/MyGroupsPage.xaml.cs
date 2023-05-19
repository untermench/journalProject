using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace journalProject.ProjectPages
{
    /// <summary>
    /// Логика взаимодействия для MyGroupsPage.xaml
    /// </summary>
    public partial class MyGroupsPage : Page
    {
        public MyGroupsPage()
        {
            InitializeComponent();

            var userObs = DB.Connect.connection.Пользователь.FirstOrDefault(i => i.ID == ProjectClasses.TeacherClass.id);
            if (userObs.Тип == 1)
            {
                UsersDG.ItemsSource = DB.Connect.connection.Класс.ToList();
                UsersDG.SelectedIndex = 0;

                GroupAddButton.Visibility = Visibility.Visible;
            }
            else
            {
                UsersDG.ItemsSource = DB.Connect.connection.Класс.Where(i => i.Класс_рукID == ProjectClasses.TeacherClass.id).ToList();
                UsersDG.SelectedIndex = 0;

                GroupButton.Visibility = Visibility.Visible;
            }

           
        }

        private void UsersDG_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            int groupID = (UsersDG.SelectedItem as DB.Класс).ID;
            var groupStud = DB.Connect.connection.Класс.FirstOrDefault(i => i.ID == groupID);
            ProjectClasses.TeacherClass.groupID = groupStud.ID;
            NavigationService.Navigate(new ProjectPages.MyClassPage());

        }

        private void GroupAddButton_Click(object sender, RoutedEventArgs e)
        {
            ProjectWin.AddGroupWin win = new ProjectWin.AddGroupWin();
            win.ShowDialog();
            UsersDG.ItemsSource = DB.Connect.connection.Класс.ToList();

        }

        private void GroupButton_Click(object sender, RoutedEventArgs e)
        {
            AdminWins.GroupSelectTeacher win = new AdminWins.GroupSelectTeacher();
            win.ShowDialog();
            UsersDG.ItemsSource = DB.Connect.connection.Класс.Where(i => i.Класс_рукID == ProjectClasses.TeacherClass.id).ToList();

        }
    }
}
