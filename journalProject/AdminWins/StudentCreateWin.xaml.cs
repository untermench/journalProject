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
    /// Логика взаимодействия для StudentCreateWin.xaml
    /// </summary>
    public partial class StudentCreateWin : Window
    {
        public StudentCreateWin()
        {
            InitializeComponent();
            StudClass.ItemsSource = DB.Connect.connection.Класс.ToList();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (NameBox.Text == "".Trim() || PatronymicBox.Text == "".Trim() || SurnameBox.Text == "".Trim() || BirthBox.SelectedDate == null || StudClass.Text == "".Trim())
                MessageBox.Show("Заполните все поля!");
            else
            {
                var student = new DB.Ученик();

                student.Имя = NameBox.Text;
                student.Отчество = PatronymicBox.Text;
                student.Фамилия = SurnameBox.Text;

                student.Дата_рождения = (DateTime)BirthBox.SelectedDate;

                student.КлассID = ((DB.Класс)StudClass.SelectedItem).ID;

                DB.Connect.connection.Ученик.Add(student);
                DB.Connect.connection.SaveChanges();
                MessageBox.Show("Ученик создан!");
            }
        }

        private void StudClass_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selection_gp = StudClass.SelectedItem as DB.Класс;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
