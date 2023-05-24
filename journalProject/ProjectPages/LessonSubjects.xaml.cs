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
    /// Логика взаимодействия для LessonSubjects.xaml
    /// </summary>
    public partial class LessonSubjects : Page
    {
        public LessonSubjects()
        {
            InitializeComponent();
            UsersDG.ItemsSource = DB.Connect.connection.Предмет.ToList();
            UsersDG.SelectedIndex = 0;

        }

        private void UsersDG_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (UsersDG.SelectedItem != null)
                {
                    int lessontItemID = (UsersDG.SelectedItem as DB.Предмет).ID;
                    var lessonItem = DB.Connect.connection.Предмет.FirstOrDefault(i => i.ID == lessontItemID);
                    ProjectClasses.TeacherClass.selectedLessonItemID = lessonItem.ID;
                    NavigationService.Navigate(new ProjectPages.StudentLessons());
                }
            }
            catch
            {

            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            if(ProjectClasses.TeacherClass.studSelectionMode == 2)
            NavigationService.Navigate(new MyClassPage());
            else
            NavigationService.Navigate(new AdminPages.AdminStudentObs());
        }
    }
}
