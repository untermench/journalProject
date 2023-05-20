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

namespace journalProject.AdminWins
{
    /// <summary>
    /// Логика взаимодействия для GroupSelectTeacher.xaml
    /// </summary>
    public partial class GroupSelectTeacher : Window
    {
        public GroupSelectTeacher()
        {
            InitializeComponent();

            ClassCB.ItemsSource = DB.Connect.connection.Класс.Where(i => i.Класс_рукID == null).ToList();

        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (ClassCB.SelectedItem != null)
            {
                var user = ((DB.Класс)ClassCB.SelectedItem).ID;

                var group = DB.Connect.connection.Класс.FirstOrDefault(i => i.ID == user);

                group.Класс_рукID = ProjectClasses.TeacherClass.id;

                DB.Connect.connection.SaveChanges();
            }
            Close();

        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selection_gp = ClassCB.SelectedItem as DB.Класс;
        }
    }
}
