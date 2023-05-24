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
    /// Логика взаимодействия для LessonThemeAdd.xaml
    /// </summary>
    public partial class LessonThemeAdd : Window
    {
        public LessonThemeAdd()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void AddLessonItem_Click(object sender, RoutedEventArgs e)
        {
            if (LessonItemNameBox.Text != "".Trim())
            {
                var theme = new DB.Тема();
                theme.ПредиетID = ProjectClasses.TeacherClass.selectedLessonItemID;
                theme.Класс = ProjectClasses.TeacherClass.lesclasit.ToString();
                theme.Название = LessonItemNameBox.Text;
                DB.Connect.connection.Тема.Add(theme);
                try
                {
                    DB.Connect.connection.SaveChanges();
                    MessageBox.Show("Тема добавлена");
                    ProjectClasses.TeacherClass.themeID = theme.ID;
                    Close();
                }
                catch(Exception ex) { MessageBox.Show(ex.Message); }
            }
            else MessageBox.Show("Заполните поле!");

        }
    }
}
