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
    /// Логика взаимодействия для ThemesPage.xaml
    /// </summary>
    public partial class ThemesPage : Page
    {
        public ThemesPage()
        {
            InitializeComponent();
            Update();

        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ClassesPage());
        }

        private void UsersDG_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var themeId = (UsersDG.SelectedItem as DB.Тема).ID;
            ProjectClasses.TeacherClass.themeID = themeId;
            AdminWins.LessonThemeEdit win = new AdminWins.LessonThemeEdit();
            win.ShowDialog();
            Update();
        }

        private void lessonItemAddButton_Click(object sender, RoutedEventArgs e)
        {
            AdminWins.LessonThemeAdd win = new AdminWins.LessonThemeAdd();
            win.ShowDialog();
            Update();
        }

        private void RemoveSubject_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show($"Данный предмет будет удален. Вы действительно желаете этого?",
                        "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                var itemID = (UsersDG.SelectedItem as DB.Тема).ID;

                var itemDel = DB.Connect.connection.Тема.FirstOrDefault(i => i.ID == itemID);
                var lesson = DB.Connect.connection.Занятие.FirstOrDefault(i => i.ТемаID == itemID);
                if (lesson == null)
                {

                    DB.Connect.connection.Тема.Remove(itemDel);
                    DB.Connect.connection.SaveChanges();
                    Update();
                }
                else { MessageBox.Show("Данная тема уже используется! Удалите все занятия, связанные с ней!"); }
            }
        }

        private void Update()
        {
            var search = DB.Connect.connection.Тема.ToList();
            search = search.Where(i => i.Название.ToLower().Contains(SearchBox.Text.ToLower().Trim()) && i.ПредиетID == ProjectClasses.TeacherClass.selectedLessonItemID && i.Класс == ProjectClasses.TeacherClass.lesclasit.ToString()).ToList();
            UsersDG.ItemsSource = search.OrderBy(i => i.Название).ToList();
            UsersDG.SelectedIndex = 0;
        }
        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Update();
        }
    }
}
