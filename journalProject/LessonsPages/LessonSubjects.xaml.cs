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
    /// Логика взаимодействия для LessonSubjects.xaml
    /// </summary>
    public partial class LessonSubjects : Page
    {
        public LessonSubjects()
        {
            InitializeComponent();

            UsersDG.ItemsSource = DB.Connect.connection.Предмет.Where(i => DB.Connect.connection.Доступ.Any(j => j.ПредметID == i.ID && j.УчительID == ProjectClasses.TeacherClass.id && j.КлассID == ProjectClasses.TeacherClass.groupID)).ToList();
            UsersDG.SelectedIndex = 0;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new LessonsPages.LessonsGroupPage());
        }

        private void UsersDG_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var itemID = (UsersDG.SelectedItem as DB.Предмет).ID;
            ProjectClasses.TeacherClass.selectedLessonItemID = itemID;
            NavigationService.Navigate(new LessonsPage());
        }
    }
}
