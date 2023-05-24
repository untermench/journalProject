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
    /// Логика взаимодействия для LessonItemAddWin.xaml
    /// </summary>
    public partial class LessonItemAddWin : Window
    {
        public LessonItemAddWin()
        {
            InitializeComponent();
        }

        private void AddLessonItem_Click(object sender, RoutedEventArgs e)
        {
            if (LessonItemNameBox.Text != "".Trim())
            {
                var lessonItem = new DB.Предмет();
                lessonItem.Наименование = LessonItemNameBox.Text;
                DB.Connect.connection.Предмет.Add(lessonItem);
                DB.Connect.connection.SaveChanges();
                MessageBox.Show("Предмет добавлен!");
                LessonItemNameBox.Text = "";
            }
            else MessageBox.Show("Заполните поле!");
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
