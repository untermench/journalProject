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
using System.Windows.Shapes;

namespace journalProject.ProjectWin
{
    /// <summary>
    /// Логика взаимодействия для StudAddToGroup.xaml
    /// </summary>
    public partial class StudAddToGroup : Window
    {
        public StudAddToGroup()
        {
            InitializeComponent();

            StudentDG.ItemsSource = DB.Connect.connection.Ученик.Where(i => i.КлассID == null).ToList();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void AddGroupButton_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void addStud_Click(object sender, RoutedEventArgs e)
        {
            int studentID = (StudentDG.SelectedItem as DB.Ученик).ID;
            var student = DB.Connect.connection.Ученик.FirstOrDefault(i => i.ID == studentID);
            student.КлассID = ProjectClasses.TeacherClass.groupID;

            DB.Connect.connection.SaveChanges();
            StudentDG.ItemsSource = DB.Connect.connection.Ученик.Where(i => i.КлассID == null).ToList();
        }
    }
}
