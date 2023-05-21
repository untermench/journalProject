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
    /// Логика взаимодействия для LessonWinAdd.xaml
    /// </summary>
    public partial class LessonWinAdd : Window
    {
        public LessonWinAdd()
        {
            InitializeComponent();

            var group = DB.Connect.connection.Класс.FirstOrDefault(i => i.ID == ProjectClasses.TeacherClass.groupID);

            var teacher = DB.Connect.connection.Пользователь.FirstOrDefault(i => i.ID == ProjectClasses.TeacherClass.id);

            LessosThemeCB.ItemsSource = DB.Connect.connection.Тема.Where(i => i.ПредиетID == ProjectClasses.TeacherClass.selectedLessonItemID && i.Класс == group.Номер.ToString()).ToList();

            GroupTeacherCB.ItemsSource = DB.Connect.connection.Пользователь.Where(i => i.Тип == 2).ToList();

            GroupTeacherCB.SelectedItem = teacher;

            LessonCabintCB.ItemsSource = DB.Connect.connection.Кабинет.ToList();


        }

        private void LessosThemeCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            var selection_gp = LessosThemeCB.SelectedItem as DB.Тема;

        }

        private void GroupTeacherCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selection_gp = GroupTeacherCB.SelectedItem as DB.Пользователь;
        }

        private void LessonCabintCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selection = LessonCabintCB.SelectedItem as DB.Кабинет;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void AddGroupButton_Click(object sender, RoutedEventArgs e)
        {
            LessonWinEdit win = new LessonWinEdit();
            if (LessonCabintCB.Text != "".Trim() || GroupTeacherCB.Text != "".Trim() || LessosThemeCB.Text != "".Trim() || LessonDate.SelectedDate != null)
            {
                var zanat = new DB.Занятие();
                zanat.КлассID = ProjectClasses.TeacherClass.groupID;
                zanat.ПредметID = ProjectClasses.TeacherClass.selectedLessonItemID;
                zanat.КабинетID = ((DB.Кабинет)LessonCabintCB.SelectedItem).ID;
                zanat.УчительID = ((DB.Пользователь)GroupTeacherCB.SelectedItem).ID;
                zanat.ТемаID = ((DB.Тема)LessosThemeCB.SelectedItem).ID;
                zanat.Дата = (DateTime)LessonDate.SelectedDate;
                DB.Connect.connection.Занятие.Add(zanat);
                DB.Connect.connection.SaveChanges();
                var groupLesson = new DB.Занятие_ученик();
                var groupStudent = DB.Connect.connection.Ученик.Where(i => i.КлассID == ProjectClasses.TeacherClass.groupID);
                List<DB.Занятие_ученик> listik = new List<DB.Занятие_ученик> { };
                foreach (var student in groupStudent)
                {
                        groupLesson.УченикID = student.ID;
                        groupLesson.ЗанятиеID = zanat.ID;
                        groupLesson.Оценка = null;
                        groupLesson.Присутствие = "Присутствовал";
                        listik.Add(groupLesson);
                    MessageBox.Show(listik.ToString());
                }
                DB.Connect.connection.Занятие_ученик.AddRange(listik);
                try
                {
                    ProjectClasses.TeacherClass.lessonID = zanat.ID;
                    DB.Connect.connection.SaveChanges();
                    MessageBox.Show("Занятие создано");
                   // win.Show();
                    Close();
                }
                catch
                {
                    MessageBox.Show("Ошибка");
                }
            }
            else MessageBox.Show("Заполните все поля!");
        }
    }
}
