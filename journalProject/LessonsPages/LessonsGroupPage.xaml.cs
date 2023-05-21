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
    /// Логика взаимодействия для LessonsGroupPage.xaml
    /// </summary>
    public partial class LessonsGroupPage : Page
    {
        public LessonsGroupPage()
        {
            InitializeComponent();

            var dostup = DB.Connect.connection.Класс.Where(i => DB.Connect.connection.Доступ.Any(c => c.КлассID == i.ID && c.УчительID == ProjectClasses.TeacherClass.id)).ToList();

            UsersDG.ItemsSource = dostup;
            UsersDG.SelectedIndex = 0;

        }

        private void UsersDG_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var classID = (UsersDG.SelectedItem as DB.Класс).ID;
            ProjectClasses.TeacherClass.groupID = classID;
            NavigationService.Navigate(new LessonSubjects());
        }
    }
}
