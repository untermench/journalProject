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

namespace journalProject.LessonsPages
{
    /// <summary>
    /// Логика взаимодействия для LessonsGroupPage.xaml
    /// </summary>
    public partial class LessonsGroupPage : Page
    {
        public LessonsGroupPage()
        {
            InitializeComponent();

            var dostup = DB.Connect.connection.Доступ.Where(i => i.УчительID == ProjectClasses.TeacherClass.id).ToList();

            foreach (var dp in dostup)
            {
                
            }
            //UsersDG.ItemsSource = ;
        }

        private void UsersDG_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
