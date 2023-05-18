using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Логика взаимодействия для MyGroupsPage.xaml
    /// </summary>
    public partial class MyGroupsPage : Page
    {
        public MyGroupsPage()
        {
            InitializeComponent();

            var userObs = DB.Connect.connection.Пользователь.FirstOrDefault(i => i.ID == ProjectClasses.TeacherClass.id);
            if (userObs.Тип == 1)
            {
                UsersDG.ItemsSource = DB.Connect.connection.Класс.ToList();
                UsersDG.SelectedIndex = 0;

                System.Windows.Threading.DispatcherTimer timer = new System.Windows.Threading.DispatcherTimer();

                timer.Tick += new EventHandler(timerTick);
                timer.Interval = new TimeSpan(0, 0, 2);
                timer.Start();
            }
            else
            {
                UsersDG.ItemsSource = DB.Connect.connection.Класс.Where(i => i.Класс_рукID == ProjectClasses.TeacherClass.id).ToList();
                UsersDG.SelectedIndex = 0;
            }
        }

        private void timerTick(object sender, EventArgs e)
        {
            
        }

        private void Update()
        {
            ICollectionView dataView = CollectionViewSource.GetDefaultView(UsersDG.ItemsSource);
            dataView.Filter = item =>
            {
                DB.Класс user = item as DB.Класс;
                if (user != null)
                {
                    string searchText = SearchBox.Text.Trim().ToLower();
                    return user.Номер.ToString().ToLower().Contains(searchText) || user.Префикс.ToLower().Contains(searchText);
                }
                return false;
            };
        }

        private void UsersDG_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
