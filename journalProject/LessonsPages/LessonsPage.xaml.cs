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

            UsersDG.ItemsSource = DB.Connect.connection.Занятие.Where(i => i.ПредметID == ProjectClasses.TeacherClass.selectedLessonItemID && i.КлассID == ProjectClasses.TeacherClass.groupID && i.УчительID == ProjectClasses.TeacherClass.id).ToList();
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
            UsersDG.ItemsSource = DB.Connect.connection.Занятие.Where(i => i.ПредметID == ProjectClasses.TeacherClass.selectedLessonItemID && i.КлассID == ProjectClasses.TeacherClass.groupID && i.УчительID == ProjectClasses.TeacherClass.id).ToList();
        }

        private void UsersDG_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var lessonID = (UsersDG.SelectedItem as DB.Занятие).ID;
            ProjectClasses.TeacherClass.lessonID = lessonID;
            LessonsWins.LessonWinEdit win = new LessonsWins.LessonWinEdit();
            win.ShowDialog();
            UsersDG.ItemsSource = DB.Connect.connection.Занятие.Where(i => i.ПредметID == ProjectClasses.TeacherClass.selectedLessonItemID && i.КлассID == ProjectClasses.TeacherClass.groupID && i.УчительID == ProjectClasses.TeacherClass.id).ToList();


        }

        private void RemoveLessonButton_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show($"Данное занятие будет удалено. Вы действительно хотите удалить его?",
                        "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                var lessonID = (UsersDG.SelectedItem as DB.Занятие).ID;
                var lesson = DB.Connect.connection.Занятие.FirstOrDefault(i => i.ID == lessonID);
                var lessonStudent = DB.Connect.connection.Занятие_ученик.Where(i => i.ЗанятиеID == lesson.ID).ToList();
                var removeList = new List<DB.Занятие_ученик> { };
                foreach (var rem in lessonStudent)
                {
                    removeList.Add(rem);
                }
                DB.Connect.connection.Занятие_ученик.RemoveRange(removeList);
                DB.Connect.connection.Занятие.Remove(lesson);
                DB.Connect.connection.SaveChanges();
                UsersDG.ItemsSource = DB.Connect.connection.Занятие.Where(i => i.ПредметID == ProjectClasses.TeacherClass.selectedLessonItemID && i.КлассID == ProjectClasses.TeacherClass.groupID && i.УчительID == ProjectClasses.TeacherClass.id).ToList();
            }
        }
    }
}
