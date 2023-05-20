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

namespace journalProject.AdminPages
{
    /// <summary>
    /// Логика взаимодействия для AdminStudentObs.xaml
    /// </summary>
    public partial class AdminStudentObs : Page
    {
        public AdminStudentObs()
        {
            InitializeComponent();
            UsersDG.ItemsSource = DB.Connect.connection.Ученик.ToList();
            UsersDG.SelectedIndex = 0;
        }

        private void UsersDG_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            int studentID = (UsersDG.SelectedItem as DB.Ученик).ID;
            var stud = DB.Connect.connection.Ученик.FirstOrDefault(i => i.ID == studentID);
            ProjectClasses.TeacherClass.selectedStudID = stud.ID;
            NavigationService.Navigate(new ProjectPages.LessonSubjects());
            ProjectClasses.TeacherClass.studSelectionMode = 1;
        }

        private void StudAddButton_Click(object sender, RoutedEventArgs e)
        {
            AdminWins.StudentCreateWin win = new AdminWins.StudentCreateWin();
            win.ShowDialog();
            UsersDG.ItemsSource = DB.Connect.connection.Ученик.ToList();
            UsersDG.SelectedIndex = 0;
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            int studentID = (UsersDG.SelectedItem as DB.Ученик).ID;
            var stud = DB.Connect.connection.Ученик.FirstOrDefault(i => i.ID == studentID);
            ProjectClasses.TeacherClass.selectedStudID = stud.ID;
            AdminWins.StudentEdit win = new AdminWins.StudentEdit();
            win.ShowDialog();
        }
    }
}
