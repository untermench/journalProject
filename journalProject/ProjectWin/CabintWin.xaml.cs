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
    /// Логика взаимодействия для CabintWin.xaml
    /// </summary>
    public partial class CabintWin : Window
    {
        public CabintWin()
        {
            InitializeComponent();
            UsersDG.ItemsSource = DB.Connect.connection.Кабинет.ToList();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void rem_Click(object sender, RoutedEventArgs e)
        {
            var cabId = UsersDG.SelectedItem as DB.Кабинет;
            var test = DB.Connect.connection.Занятие.Where(i => i.КабинетID == cabId.ID);
            foreach(var rem in test)
            {
                rem.КабинетID = null;
            }
            DB.Connect.connection.Кабинет.Remove(cabId);
            DB.Connect.connection.SaveChanges();
            UsersDG.ItemsSource = DB.Connect.connection.Кабинет.ToList();
        }

        private void addMnogo_Click(object sender, RoutedEventArgs e)
        {
            var cab = new List<DB.Кабинет> { };
            for (int i = Convert.ToInt32(otTB.Text); i != Convert.ToInt32(doTB.Text) + 1; i++)
            {
                var dsa = new DB.Кабинет();
                dsa.Номер = i;
                cab.Add(dsa);
            }
            DB.Connect.connection.Кабинет.AddRange(cab);
            DB.Connect.connection.SaveChanges();
            UsersDG.ItemsSource = DB.Connect.connection.Кабинет.ToList();
        }

        private void addMalo_Click(object sender, RoutedEventArgs e)
        {
            var cab = new DB.Кабинет();
            cab.Номер = Convert.ToInt32(cabTB.Text);
            DB.Connect.connection.Кабинет.Add(cab);
            DB.Connect.connection.SaveChanges();
            UsersDG.ItemsSource = DB.Connect.connection.Кабинет.ToList();
        }

        private void UsersDG_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
