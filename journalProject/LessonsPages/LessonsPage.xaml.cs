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

namespace journalProject.LessonsPages
{
    /// <summary>
    /// Логика взаимодействия для LessonsPage.xaml
    /// </summary>
    public partial class LessonsPage : Page
    {
        public LessonsPage()
        {
            InitializeComponent();

            UsersDG.ItemsSource = DB.Connect.connection.Занятие.Where(i => i.ПредметID == ProjectClasses.TeacherClass.selectedLessonItemID && i.КлассID == ProjectClasses.TeacherClass.groupID).ToList();
            UsersDG.SelectedIndex = 0;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new LessonSubjects());
        }

        private void lessonAddButton_Click(object sender, RoutedEventArgs e)
        {
            LessonsWins.LessonWinAdd won = new LessonsWins.LessonWinAdd();
            won.ShowDialog();
            UsersDG.ItemsSource = DB.Connect.connection.Занятие.Where(i => i.ПредметID == ProjectClasses.TeacherClass.selectedLessonItemID && i.КлассID == ProjectClasses.TeacherClass.groupID).ToList();
        }
    }
}
