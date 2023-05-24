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
    /// Логика взаимодействия для LessonItemEditWin.xaml
    /// </summary>
    public partial class LessonItemEditWin : Window
    {
        public LessonItemEditWin()
        {
            InitializeComponent();
            LessonItemNameBox.Text = DB.Connect.connection.Предмет.FirstOrDefault(i => i.ID == ProjectClasses.TeacherClass.selectedLessonItemID).Наименование;
        }

        private void AddLessonItem_Click(object sender, RoutedEventArgs e)
        {
            if (LessonItemNameBox.Text != "".Trim())
            {
                var lesson = DB.Connect.connection.Предмет.FirstOrDefault(i => i.ID == ProjectClasses.TeacherClass.selectedLessonItemID);
                lesson.Наименование = LessonItemNameBox.Text;
                DB.Connect.connection.SaveChanges();
                Close();
            }
            else MessageBox.Show("Заполните поле!");
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
