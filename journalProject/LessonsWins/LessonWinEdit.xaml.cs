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

namespace journalProject.LessonsWins
{
    /// <summary>
    /// Логика взаимодействия для LessonWinEdit.xaml
    /// </summary>
    public partial class LessonWinEdit : Window
    {
        public LessonWinEdit()
        {
            InitializeComponent();
            
            UsersDG.ItemsSource = DB.Connect.connection.Занятие_ученик.Where(i => i.ЗанятиеID == ProjectClasses.TeacherClass.lessonID).ToList();

            var group = DB.Connect.connection.Класс.FirstOrDefault(i => i.ID == ProjectClasses.TeacherClass.groupID);

            var lesson = DB.Connect.connection.Занятие.FirstOrDefault(i => i.ID == ProjectClasses.TeacherClass.lessonID);

            var teacher = DB.Connect.connection.Пользователь.FirstOrDefault(i => i.ID == lesson.УчительID);

            LessosThemeCB.ItemsSource = DB.Connect.connection.Тема.Where(i => i.ПредиетID == ProjectClasses.TeacherClass.selectedLessonItemID && i.Класс == group.Номер.ToString()).ToList();

            LessosThemeCB.SelectedItem = DB.Connect.connection.Тема.FirstOrDefault(i => i.ID == lesson.ТемаID);

            LessonCabintCB.ItemsSource = DB.Connect.connection.Кабинет.ToList();

            LessonCabintCB.SelectedItem = DB.Connect.connection.Кабинет.FirstOrDefault(i => i.ID == lesson.КабинетID);
            
            GroupTeacherCB.ItemsSource = DB.Connect.connection.Пользователь.Where(i => i.Тип == 2).ToList();

            GroupTeacherCB.SelectedItem = teacher;

            LessonDate.SelectedDate = lesson.Дата;

        }

        private void UsersDG_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }

        private void NoScore_Click(object sender, RoutedEventArgs e)
        {
            var scoreID = (UsersDG.SelectedItem as DB.Занятие_ученик).ID;
            var score = DB.Connect.connection.Занятие_ученик.FirstOrDefault(i => i.ID == scoreID);
            score.Оценка = null;
            DB.Connect.connection.SaveChanges();
            UsersDG.ItemsSource = DB.Connect.connection.Занятие_ученик.Where(i => i.ЗанятиеID == ProjectClasses.TeacherClass.lessonID).ToList();

        }

        private void BadScore_Click(object sender, RoutedEventArgs e)
        {
            var scoreID = (UsersDG.SelectedItem as DB.Занятие_ученик).ID;
            var score = DB.Connect.connection.Занятие_ученик.FirstOrDefault(i => i.ID == scoreID);
            score.Оценка = 2;
            DB.Connect.connection.SaveChanges();
            UsersDG.ItemsSource = DB.Connect.connection.Занятие_ученик.Where(i => i.ЗанятиеID == ProjectClasses.TeacherClass.lessonID).ToList();
        }

        private void SadScore_Click(object sender, RoutedEventArgs e)
        {
            var scoreID = (UsersDG.SelectedItem as DB.Занятие_ученик).ID;
            var score = DB.Connect.connection.Занятие_ученик.FirstOrDefault(i => i.ID == scoreID);
            score.Оценка = 3;
            DB.Connect.connection.SaveChanges();
            UsersDG.ItemsSource = DB.Connect.connection.Занятие_ученик.Where(i => i.ЗанятиеID == ProjectClasses.TeacherClass.lessonID).ToList();
        }

        private void GoodScore_Click(object sender, RoutedEventArgs e)
        {
            var scoreID = (UsersDG.SelectedItem as DB.Занятие_ученик).ID;
            var score = DB.Connect.connection.Занятие_ученик.FirstOrDefault(i => i.ID == scoreID);
            score.Оценка = 4;
            DB.Connect.connection.SaveChanges();
            UsersDG.ItemsSource = DB.Connect.connection.Занятие_ученик.Where(i => i.ЗанятиеID == ProjectClasses.TeacherClass.lessonID).ToList();
        }

        private void ExScore_Click(object sender, RoutedEventArgs e)
        {
            var scoreID = (UsersDG.SelectedItem as DB.Занятие_ученик).ID;
            var score = DB.Connect.connection.Занятие_ученик.FirstOrDefault(i => i.ID == scoreID);
            score.Оценка = 5;
            DB.Connect.connection.SaveChanges();
            UsersDG.ItemsSource = DB.Connect.connection.Занятие_ученик.Where(i => i.ЗанятиеID == ProjectClasses.TeacherClass.lessonID).ToList();
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            var scoreID = (UsersDG.SelectedItem as DB.Занятие_ученик).ID;
            var score = DB.Connect.connection.Занятие_ученик.FirstOrDefault(i => i.ID == scoreID);

            if (score.Присутствие == "Присутствовал")
            {
                score.Присутствие = "Отсутствовал";
            }
            else
            {
                score.Присутствие = "Присутствовал";
            }
            DB.Connect.connection.SaveChanges();
            UsersDG.ItemsSource = DB.Connect.connection.Занятие_ученик.Where(i => i.ЗанятиеID == ProjectClasses.TeacherClass.lessonID).ToList();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void GroupTeacherCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selection_gp = GroupTeacherCB.SelectedItem as DB.Пользователь;

        }

        private void LessonCabintCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selection = LessonCabintCB.SelectedItem as DB.Кабинет;

        }

        private void LessosThemeCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selection_gp = LessosThemeCB.SelectedItem as DB.Тема;

        }

        private void AddGroupButton_Click(object sender, RoutedEventArgs e)
        {
            var lesson = DB.Connect.connection.Занятие.FirstOrDefault(i => i.ID == ProjectClasses.TeacherClass.lessonID);
            lesson.КабинетID = ((DB.Кабинет)LessonCabintCB.SelectedItem).ID;
            lesson.УчительID = ((DB.Пользователь)GroupTeacherCB.SelectedItem).ID;
            lesson.ТемаID = ((DB.Тема)LessosThemeCB.SelectedItem).ID;
            DB.Connect.connection.SaveChanges();
            Close();

        }

        private void AddTheme_Click(object sender, RoutedEventArgs e)
        {
            ProjectClasses.TeacherClass.lesclasit = DB.Connect.connection.Класс.FirstOrDefault(i => i.ID == ProjectClasses.TeacherClass.groupID).Номер;
            AdminWins.LessonThemeAdd win = new AdminWins.LessonThemeAdd();
            win.ShowDialog();
            LessosThemeCB.SelectedItem = null;
            var group = DB.Connect.connection.Класс.FirstOrDefault(i => i.ID == ProjectClasses.TeacherClass.groupID);
            LessosThemeCB.ItemsSource = DB.Connect.connection.Тема.Where(i => i.ПредиетID == ProjectClasses.TeacherClass.selectedLessonItemID && i.Класс == group.Номер.ToString()).ToList();
            var item = DB.Connect.connection.Тема.FirstOrDefault(i => i.ID == ProjectClasses.TeacherClass.themeID);
            if (item != null) LessosThemeCB.SelectedItem = item;
        }
    }
}
