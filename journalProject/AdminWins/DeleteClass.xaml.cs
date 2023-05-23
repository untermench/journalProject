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
    /// Логика взаимодействия для DeleteClass.xaml
    /// </summary>
    public partial class DeleteClass : Window
    {
        public DeleteClass()
        {
            InitializeComponent();
        }

        private void RemoveGroupButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (MessageBox.Show($"Данный функционал удалит группу вместе с ее учениками. Вы действительно уверены в этом?",
                        "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    var studID = DB.Connect.connection.Ученик.FirstOrDefault(i => i.КлассID == ProjectClasses.TeacherClass.groupID);

                    var student = DB.Connect.connection.Ученик.Where(i => i.КлассID == ProjectClasses.TeacherClass.groupID);
                    var group = DB.Connect.connection.Класс.Where(i => i.ID == ProjectClasses.TeacherClass.groupID);
                    var studLesson = DB.Connect.connection.Занятие_ученик.Where(i => i.УченикID == studID.ID);
                    var lesson = DB.Connect.connection.Занятие.Where(i => i.КлассID == ProjectClasses.TeacherClass.groupID);
                    var dostup = DB.Connect.connection.Доступ.Where(i => i.КлассID == ProjectClasses.TeacherClass.groupID);
                    DB.Connect.connection.Занятие_ученик.RemoveRange(studLesson);
                    DB.Connect.connection.Занятие.RemoveRange(lesson);
                    DB.Connect.connection.Ученик.RemoveRange(student);
                    DB.Connect.connection.Доступ.RemoveRange(dostup);
                    DB.Connect.connection.Класс.RemoveRange(group);
                    DB.Connect.connection.SaveChanges();
                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void RasformGroupButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (MessageBox.Show($"Данный класс будет расформирован. Вы действительно уверены в этом?",
                        "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    var group = DB.Connect.connection.Класс.FirstOrDefault(i => i.ID == ProjectClasses.TeacherClass.groupID);
                    var student = DB.Connect.connection.Ученик.Where(i => i.КлассID == ProjectClasses.TeacherClass.groupID);
                    foreach(var item in student)
                    item.КлассID = null;
                    DB.Connect.connection.Класс.Remove(group);
                    DB.Connect.connection.SaveChanges();
                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка", ex.Message);
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
