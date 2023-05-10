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
    /// Логика взаимодействия для FrameWin.xaml
    /// </summary>
    public partial class FrameWin : Window
    {
        public FrameWin()
        {
            InitializeComponent();
        }

        private void Sidebar_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                var selected = Sidebar.SelectedItem as NavButton;

                

                if(selected.NavLink.ToString() == "/ProjectPages/MyClassPage.xaml")
                {
                    var myclass = DB.Connect.connection.Класс.FirstOrDefault(i => i.Класс_рукID == ProjectClasses.TeacherClass.id);
                    if (myclass != null)
                    {
                        pagesFrame.Navigate(new ProjectPages.MyClassPage());
                    }
                    else
                    {
                        MessageBox.Show("Класс не найден");
                    }
                }
                else
                {
                    pagesFrame.Navigate(selected.NavLink);
                }
            }
            catch
            {

            }
        }

        private void NavButton_Selected(object sender, RoutedEventArgs e)
        {
            MainWindow win = new MainWindow();
            win.Show();
            this.Close();
        }

        //private void classbutton_click(object sender, routedeventargs e)
        //{
        //    var myclass = db.connect.connection.класс.firstordefault(i => i.учительid == projectclasses.teacherclass.id);
        //    if (myclass != null)
        //    {
        //        pagesframe.visibility = visibility.visible;
        //        pagesframe.navigate(new projectpages.myclasspage());
        //    }
        //    else
        //    {
        //        messagebox.show("класс не найден");
        //    }
        //}

    }
}
