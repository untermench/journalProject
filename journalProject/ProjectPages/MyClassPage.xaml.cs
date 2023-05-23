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

namespace journalProject.ProjectPages
{
    /// <summary>
    /// Логика взаимодействия для MyClassPage.xaml
    /// </summary>
    public partial class MyClassPage : Page
    {
        public MyClassPage()
        {
            InitializeComponent();

            var user = DB.Connect.connection.Пользователь.FirstOrDefault(i => i.ID == ProjectClasses.TeacherClass.id);

            if (user.Тип == 1)
                RemoveGroupButton.Visibility = Visibility.Visible;
            else
            {
                var group = DB.Connect.connection.Класс.FirstOrDefault(i => i.ID == ProjectClasses.TeacherClass.groupID);
                if (group.Класс_рукID == ProjectClasses.TeacherClass.id)
                    OtkazButton.Visibility = Visibility.Visible;
            }

            UsersDG.ItemsSource = DB.Connect.connection.Ученик.Where(i => i.КлассID == ProjectClasses.TeacherClass.groupID).ToList();
            UsersDG.SelectedIndex = 0;
        }

        private void UsersDG_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            int studentID = (UsersDG.SelectedItem as DB.Ученик).ID;
            var stud = DB.Connect.connection.Ученик.FirstOrDefault(i => i.ID == studentID);
            ProjectClasses.TeacherClass.selectedStudID = stud.ID;
            NavigationService.Navigate(new ProjectPages.LessonSubjects());
        }

        private void StudAddButton_Click(object sender, RoutedEventArgs e)
        {
            ProjectWin.StudAddToGroup win = new ProjectWin.StudAddToGroup();
            win.ShowDialog();
            UsersDG.ItemsSource = DB.Connect.connection.Ученик.Where(i => i.КлассID == ProjectClasses.TeacherClass.groupID).ToList();

        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            int studentID = (UsersDG.SelectedItem as DB.Ученик).ID;
            var stud = DB.Connect.connection.Ученик.FirstOrDefault(i => i.ID == studentID);
            ProjectClasses.TeacherClass.selectedStudID = stud.ID;
            AdminWins.StudentEdit win = new AdminWins.StudentEdit();
            win.ShowDialog();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MyGroupsPage());
        }

        private void OtkazButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (MessageBox.Show($"Вы действительно хотите отказать от данной группы?",
                        "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    var group = DB.Connect.connection.Класс.FirstOrDefault(i => i.ID == ProjectClasses.TeacherClass.groupID);
                    group.Класс_рукID = null;
                    DB.Connect.connection.SaveChanges();
                    NavigationService.Navigate(new MyGroupsPage());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка", ex.Message);
            }
        }

        private void RemoveGroupButton_Click(object sender, RoutedEventArgs e)
        {
            AdminWins.DeleteClass win = new AdminWins.DeleteClass();
            win.ShowDialog();
            var user = DB.Connect.connection.Пользователь.FirstOrDefault(i => i.ID == ProjectClasses.TeacherClass.id);

            if (user.Тип == 1)
                RemoveGroupButton.Visibility = Visibility.Visible;
            else
            {
                var group = DB.Connect.connection.Класс.FirstOrDefault(i => i.ID == ProjectClasses.TeacherClass.groupID);
                if (group.Класс_рукID == ProjectClasses.TeacherClass.id)
                    OtkazButton.Visibility = Visibility.Visible;
            }
            var gru = DB.Connect.connection.Класс.FirstOrDefault(i => i.ID == ProjectClasses.TeacherClass.groupID);
            if (gru != null)
            {
                UsersDG.ItemsSource = DB.Connect.connection.Ученик.Where(i => i.КлассID == ProjectClasses.TeacherClass.groupID).ToList();
                UsersDG.SelectedIndex = 0;
            }
            else
                NavigationService.Navigate(new MyGroupsPage());
        }

        private void EditButton_Click_1(object sender, RoutedEventArgs e)
        {
            ProjectWin.EditGroupWin win = new ProjectWin.EditGroupWin();
            win.ShowDialog();
            var group = DB.Connect.connection.Класс.FirstOrDefault(i => i.ID == ProjectClasses.TeacherClass.groupID);
            var user = DB.Connect.connection.Пользователь.FirstOrDefault(i => i.ID == ProjectClasses.TeacherClass.id);
            if(group.Класс_рукID != user.ID && user.Тип != 1)
                NavigationService.Navigate(new MyGroupsPage());
        }

        private void RemoveStudentButton_Click(object sender, RoutedEventArgs e)
        {
            int studentID = (UsersDG.SelectedItem as DB.Ученик).ID;
            if (MessageBox.Show($"Данный ученик будет удален из данной группы. Вы уверены в этом?",
                        "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                var student = DB.Connect.connection.Ученик.FirstOrDefault(i => i.ID == studentID);
                student.КлассID = null;
                DB.Connect.connection.SaveChanges();
                UsersDG.ItemsSource = DB.Connect.connection.Ученик.Where(i => i.КлассID == ProjectClasses.TeacherClass.groupID).ToList();
                UsersDG.SelectedIndex = 0;
            }
        }

        private void DostupAddButton_Click(object sender, RoutedEventArgs e)
        {
            ProjectWin.DostupAddWin win = new ProjectWin.DostupAddWin();
            win.ShowDialog();
        }
    }
}
