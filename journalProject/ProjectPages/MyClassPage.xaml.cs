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
    /// Логика взаимодействия для MyClassPage.xaml
    /// </summary>
    public partial class MyClassPage : Page
    {
        public MyClassPage()
        {
            InitializeComponent();
            var myclass = DB.Connect.connection.Класс.FirstOrDefault(i => i.УчительID == ProjectClasses.TeacherClass.id);
            classView.ItemsSource = DB.Connect.connection.Ученик.Where(i => i.КлассID == myclass.ID).ToList();
        }

        private void checkButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void editButton_Click(object sender, RoutedEventArgs e)
        {
            var uchenikID = classView.SelectedItem as DB.Ученик;
            ProjectClasses.TeacherClass.schoID = uchenikID.ID;
            ProjectWin.EditWin win = new ProjectWin.EditWin();
            win.ShowDialog();
        }

        private void refreshButton_Click(object sender, RoutedEventArgs e)
        {
            var myclass = DB.Connect.connection.Класс.FirstOrDefault(i => i.УчительID == ProjectClasses.TeacherClass.id);
            classView.ItemsSource = DB.Connect.connection.Ученик.Where(i => i.КлассID == myclass.ID).ToList();
        }

        private void _searchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var ser = DB.Connect.connection.Ученик.ToList();
            ser = ser.Where(i => i.Фамилия.ToLower().Contains(_searchBox.Text.ToLower().Trim()) || i.Имя.ToLower().Contains(_searchBox.Text.ToLower().Trim()) || i.Отчество.ToLower().Contains(_searchBox.Text.ToLower().Trim())).ToList();
            classView.ItemsSource = ser.OrderBy(i => i.Фамилия).ToList();
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            ProjectWin.AddWin win = new ProjectWin.AddWin();
            win.ShowDialog();
        }
    }
}
