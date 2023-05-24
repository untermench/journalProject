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
    /// Логика взаимодействия для StudentLessons.xaml
    /// </summary>
    public partial class StudentLessons : Page
    {
        public StudentLessons()
        {
            InitializeComponent();
            UsersDG.ItemsSource = DB.Connect.connection.Занятие_ученик.Where(i => i.УченикID == ProjectClasses.TeacherClass.selectedStudID && i.Занятие.ПредметID == ProjectClasses.TeacherClass.selectedLessonItemID).ToList();
            UsersDG.SelectedIndex = 0;

        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new LessonSubjects());
        }
    }
}
