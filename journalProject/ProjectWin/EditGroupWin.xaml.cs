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
    /// Логика взаимодействия для EditGroupWin.xaml
    /// </summary>
    public partial class EditGroupWin : Window
    {
        public EditGroupWin()
        {
            InitializeComponent();
            StudentDG.ItemsSource = DB.Connect.connection.Ученик.Where(i => i.КлассID == ProjectClasses.TeacherClass.groupID).ToList();
            StudentDG.SelectedIndex = 0;

            var group = DB.Connect.connection.Класс.FirstOrDefault(i => i.ID == ProjectClasses.TeacherClass.groupID);

            GroupTeacherCB.ItemsSource = DB.Connect.connection.Пользователь.Where(i => i.Тип == 2).ToList();

            GroupTeacherCB.SelectedItem = group.Пользователь;
            GroupNumberCB.Text = group.Номер.ToString();
            GroupPrefixCB.Text = group.Префикс;

        }

        private void GroupTeacherCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selection_gp = GroupTeacherCB.SelectedItem as DB.Пользователь;
        }

        private void AddGroupButton_Click(object sender, RoutedEventArgs e)
        {
            var group = DB.Connect.connection.Класс.FirstOrDefault(i => i.ID == ProjectClasses.TeacherClass.groupID);

            group.Номер = Convert.ToInt32(GroupNumberCB.Text);
            group.Префикс = GroupPrefixCB.Text;

            if(((DB.Пользователь)GroupTeacherCB.SelectedItem).ID != group.Класс_рукID)
            {
                if (MessageBox.Show($"Подтвердить передачу группы?",
                        "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    group.Класс_рукID = ((DB.Пользователь)GroupTeacherCB.SelectedItem).ID;
                }
            }
            DB.Connect.connection.SaveChanges();
            MessageBox.Show("Данные изменены");
            Close();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
