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
    /// Логика взаимодействия для LessonItemPage.xaml
    /// </summary>
    public partial class LessonItemPage : Page
    {
        public LessonItemPage()
        {
            InitializeComponent();
            Update();
        }

        private void RemoveSubject_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show($"Данный предмет будет удален. Вы действительно желаете этого?",
                        "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                var itemID = (UsersDG.SelectedItem as DB.Предмет).ID;

                var itemDel = DB.Connect.connection.Предмет.FirstOrDefault(i => i.ID == itemID);
                var lesson = DB.Connect.connection.Занятие.FirstOrDefault(i => i.ПредметID == itemID);
                if (lesson == null)
                {
                    var dostup = DB.Connect.connection.Доступ.FirstOrDefault(i => i.ПредметID == itemID);
                    if (dostup == null)
                    {
                        DB.Connect.connection.Предмет.Remove(itemDel);
                        DB.Connect.connection.SaveChanges();
                        Update();
                    }
                    else { MessageBox.Show("Данный предмет уже используется! Удалите все уроки и доступы, связанные с ним!"); }
                }
                else { MessageBox.Show("Данный предмет уже используется! Удалите все уроки и доступы, связанные с ним!"); }
            }
        }

        private void UsersDG_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var itemID = (UsersDG.SelectedItem as DB.Предмет).ID;
            ProjectClasses.TeacherClass.selectedLessonItemID = itemID;
            NavigationService.Navigate(new AdminPages.ClassesPage());

        }

        private void lessonItemAddButton_Click(object sender, RoutedEventArgs e)
        {
            AdminWins.LessonItemAddWin win = new AdminWins.LessonItemAddWin();
            win.ShowDialog();
            Update();
        }

        private void EditSubject_Click(object sender, RoutedEventArgs e)
        {
            var itemID = (UsersDG.SelectedItem as DB.Предмет).ID;
            ProjectClasses.TeacherClass.selectedLessonItemID = itemID;
            AdminWins.LessonItemEditWin win = new AdminWins.LessonItemEditWin(); 
            win.ShowDialog();
            Update();
        }

        private void Update()
        {
            var search = DB.Connect.connection.Предмет.ToList();
            search = search.Where(i => i.Наименование.ToLower().Contains(SearchBox.Text.ToLower().Trim())).ToList();
            UsersDG.ItemsSource = search.OrderBy(i => i.Наименование).ToList();
            UsersDG.SelectedIndex = 0;
        }
        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Update();
        }
    }
}
