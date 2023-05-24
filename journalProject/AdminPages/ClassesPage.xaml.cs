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
    /// Логика взаимодействия для ClassesPage.xaml
    /// </summary>
    public partial class ClassesPage : Page
    {

        public class MyClass
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
        public ClassesPage()
        {
            InitializeComponent();

            List<MyClass> myList = new List<MyClass>();
            for (int i = 11; i > 0; i--)
            {
                myList.Add(new MyClass { Id = i, Name = i + " класс"});
            }

            UsersDG.ItemsSource = myList;
        }

        private void UsersDG_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var id = UsersDG.SelectedItem as MyClass;
            if (id != null)
            {
                ProjectClasses.TeacherClass.lesclasit = id.Id;
                NavigationService.Navigate(new ThemesPage());
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new LessonItemPage());
        }
    }
}
