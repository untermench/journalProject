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
    /// Логика взаимодействия для StudentEdit.xaml
    /// </summary>
    public partial class StudentEdit : Window
    {
        public StudentEdit()
        {
            InitializeComponent();
            StudClass.ItemsSource = DB.Connect.connection.Класс.ToList();
            var student = DB.Connect.connection.Ученик.FirstOrDefault(i => i.ID == ProjectClasses.TeacherClass.selectedStudID);

            StudClass.SelectedItem = student.Класс;

            NameBox.Text = student.Имя;
            PatronymicBox.Text = student.Отчество;
            SurnameBox.Text = student.Фамилия;

            BirthBox.SelectedDate = student.Дата_рождения;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            var student = DB.Connect.connection.Ученик.FirstOrDefault(i => i.ID == ProjectClasses.TeacherClass.selectedStudID);

            if (NameBox.Text == "".Trim() || PatronymicBox.Text == "".Trim() || SurnameBox.Text == "".Trim() || BirthBox.SelectedDate == null || StudClass.Text == "".Trim())
                MessageBox.Show("Заполните все поля!");
            else
            {
                student.Имя = NameBox.Text;
                student.Отчество = PatronymicBox.Text;
                student.Фамилия = SurnameBox.Text;

                student.Дата_рождения = (DateTime)BirthBox.SelectedDate;

                student.КлассID = ((DB.Класс)StudClass.SelectedItem).ID;

                DB.Connect.connection.SaveChanges();
                MessageBox.Show("Данные изменены");
            }

        }

        private void DelButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (MessageBox.Show($"Вы действитель хотите удалить данного ученика?",
                        "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    var student = DB.Connect.connection.Ученик.FirstOrDefault(i => i.ID == ProjectClasses.TeacherClass.selectedStudID);
                    var studLesson = DB.Connect.connection.Занятие_ученик.Where(i => i.УченикID == student.ID);
                    DB.Connect.connection.Занятие_ученик.RemoveRange(studLesson);
                    DB.Connect.connection.Ученик.Remove(student);
                    DB.Connect.connection.SaveChanges();
                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void StudClass_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selection_gp = StudClass.SelectedItem as DB.Класс;
        }
    }
}
