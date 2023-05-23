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
    /// Логика взаимодействия для DostupAddWin.xaml
    /// </summary>
    public partial class DostupAddWin : Window
    {
        public DostupAddWin()
        {
            InitializeComponent();

            GroupTeacherCB.ItemsSource = DB.Connect.connection.Пользователь.Where(i => i.Тип == 2).ToList();

            LessonItemCB.ItemsSource = DB.Connect.connection.Предмет.ToList();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void GroupTeacherCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selection_gp = GroupTeacherCB.SelectedItem as DB.Пользователь;
        }

        private void LessonItemCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selection_gp = LessonItemCB.SelectedItem as DB.Предмет;
        }

        private void AddDostupButton_Click(object sender, RoutedEventArgs e)
        {
            if (GroupTeacherCB.Text != null || LessonItemCB.Text != null)
            {
                var dostup = new DB.Доступ();
                dostup.КлассID = ProjectClasses.TeacherClass.groupID;
                dostup.УчительID = ((DB.Пользователь)GroupTeacherCB.SelectedItem).ID;
                dostup.ПредметID = ((DB.Предмет)LessonItemCB.SelectedItem).ID;
                DB.Connect.connection.Доступ.Add(dostup);

                try
                {
                    DB.Connect.connection.SaveChanges();
                    MessageBox.Show("Доступ создан!");
                    Close();
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
            else MessageBox.Show("Выберите все данные!");   
        }
    }
}
