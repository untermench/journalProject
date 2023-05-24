using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
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
    /// Логика взаимодействия для AdminUsers.xaml
    /// </summary>
    public partial class AdminUsers : Page
    {
        public AdminUsers()
        {
            InitializeComponent();
            Update();
        }


        private void UsersDG_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                int removeID = (UsersDG.SelectedItem as DB.Пользователь).ID;
                var removeStud = DB.Connect.connection.Пользователь.FirstOrDefault(i => i.ID == removeID);
                if (removeStud != null)
                {
                    ProjectClasses.TeacherClass.adminUserEditID = removeStud.ID;
                    ProjectWin.EditUserWin win = new ProjectWin.EditUserWin();
                    win.ShowDialog();
                    Update();
                }
                else
                {
                    MessageBox.Show("Пользователь не найден");
                }
            }
            catch { }
        }

        private void UserAddButton_Click(object sender, RoutedEventArgs e)
        {
            AdminWins.AdminAddWin win = new AdminWins.AdminAddWin();
            win.ShowDialog();
            Update();
        }

        private void Update()
        {
            var search = DB.Connect.connection.Пользователь.ToList();
            search = search.Where(i => i.Фамилия.ToLower().Contains(SearchBox.Text.ToLower().Trim()) || i.Имя.ToLower().Contains(SearchBox.Text.ToLower().Trim()) || i.Почта.ToLower().Contains(SearchBox.Text.ToLower().Trim()) || i.Отчетсво.ToLower().Contains(SearchBox.Text.ToLower().Trim())).ToList();

            UsersDG.ItemsSource = search.OrderBy(i => i.Фамилия).ToList();
            UsersDG.SelectedIndex = 0;
        }

        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Update();
        }
    }
}
