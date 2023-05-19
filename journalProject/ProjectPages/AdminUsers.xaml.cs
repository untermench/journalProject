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
            UsersDG.ItemsSource = DB.Connect.connection.Пользователь.ToList();
            UsersDG.SelectedIndex = 0;

            System.Windows.Threading.DispatcherTimer timer = new System.Windows.Threading.DispatcherTimer();

            timer.Tick += new EventHandler(timerTick);
            timer.Interval = new TimeSpan(0, 0, 15);
            timer.Start();
        }

        private void timerTick(object sender, EventArgs e)
        {
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
            UsersDG.ItemsSource = DB.Connect.connection.Пользователь.ToList();
        }

        private void Update()
        {
            ICollectionView dataView = CollectionViewSource.GetDefaultView(UsersDG.ItemsSource);
            dataView.Filter = item =>
            {
                DB.Пользователь user = item as DB.Пользователь;
                if (user != null)
                {
                    string searchText = SearchBox.Text.Trim().ToLower();
                    return user.Имя.ToLower().Contains(searchText) || user.Фамилия.ToLower().Contains(searchText);
                }
                return false;
            };
        }
        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Update();
        }
    }
}
