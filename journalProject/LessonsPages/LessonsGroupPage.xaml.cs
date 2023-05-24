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
            Update();

        }

        private void UsersDG_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var classID = (UsersDG.SelectedItem as DB.Класс).ID;
            ProjectClasses.TeacherClass.groupID = classID;
            NavigationService.Navigate(new LessonSubjects());
        }

        private void RemoveGroupDostup_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show($"Даннsq доступ к группе будет удалено. Вы действительно хотите удалить его?",
                        "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                var dostupID = (UsersDG.SelectedItem as DB.Класс).ID;
                var dostup = DB.Connect.connection.Доступ.Where(i => i.УчительID == ProjectClasses.TeacherClass.id && i.КлассID == dostupID).ToList();
                var removeList = new List<DB.Доступ> { };
                foreach(var rem in dostup)
                {
                    removeList.Add(rem);
                }
                DB.Connect.connection.Доступ.RemoveRange(removeList);
                DB.Connect.connection.SaveChanges();

                Update();
            }
        }

        private void Update()
        {
            var search = DB.Connect.connection.Класс.ToList();
            search = search.Where(i => i.Префикс.ToLower().Contains(SearchBox.Text.ToLower().Trim()) && DB.Connect.connection.Доступ.Any(c => c.КлассID == i.ID && c.УчительID == ProjectClasses.TeacherClass.id)).ToList();
            UsersDG.ItemsSource = search.OrderBy(i => i.Префикс).ToList();
            UsersDG.SelectedIndex = 0;
        }

        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Update();
        }

    }
}
