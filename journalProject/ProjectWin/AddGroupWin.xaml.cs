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
    /// Логика взаимодействия для AddGroupWin.xaml
    /// </summary>
    public partial class AddGroupWin : Window
    {
        public AddGroupWin()
        {
            InitializeComponent();

            StudentDG.ItemsSource = DB.Connect.connection.Ученик.Where(i => i.КлассID == null).ToList();
            StudentDG.SelectedIndex = 0;

            GroupTeacherCB.ItemsSource = DB.Connect.connection.Пользователь.Where(i => i.Тип == 2).ToList();

        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void GroupTeacherCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selection_gp = GroupTeacherCB.SelectedItem as DB.Пользователь;
        }

        private void AddGroupButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var group = new DB.Класс();
                group.Номер = Convert.ToInt32(GroupNumberCB.Text);
                group.Префикс = GroupPrefixCB.Text;
                if (GroupTeacherCB.Text != null)
                    group.Класс_рукID = ((DB.Пользователь)GroupTeacherCB.SelectedItem).ID;
                else
                    group.Класс_рукID = null;

                DB.Connect.connection.Класс.Add(group);

                var students = StudentDG.SelectedItem as DB.Ученик;
                if (students != null)
                {
                    students.КлассID = group.ID;
                }

                DB.Connect.connection.SaveChanges();

                MessageBox.Show("Класс создан");

                StudentDG.ItemsSource = DB.Connect.connection.Ученик.Where(i => i.КлассID == null).ToList();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
                
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            
        }
        private void UnheckBox_Checked(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
