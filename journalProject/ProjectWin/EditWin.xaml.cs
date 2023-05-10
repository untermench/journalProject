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
    /// Логика взаимодействия для EditWin.xaml
    /// </summary>
    public partial class EditWin : Window
    {
        DB.journalDBEntities context = new DB.journalDBEntities();
        public EditWin()
        {
            InitializeComponent();
            var a = context.Ученик.FirstOrDefault(i => i.ID == ProjectClasses.TeacherClass.schoID);
            _famBox.Text = a.Фамилия;
            _nameBox.Text = a.Имя;
            _patrBox.Text = a.Отчество;
            _birthDate.Text = a.Дата_рождения.ToString();

        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var addProd = DB.Connect.connection.Ученик.FirstOrDefault(i => i.ID == ProjectClasses.TeacherClass.schoID);
                addProd.Фамилия = _famBox.Text;
                addProd.Имя = _nameBox.Text;
                addProd.Отчество = _patrBox.Text;
                addProd.Дата_рождения = Convert.ToDateTime(_birthDate.Text);
                DB.Connect.connection.SaveChanges();
                MessageBox.Show("Данные изменены");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }
        }

        private void removeButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Нажмите ОК чтобы подтвердить удаление", "Удаление", MessageBoxButton.OKCancel);
            var rem = DB.Connect.connection.Ученик.FirstOrDefault(i => i.ID == ProjectClasses.TeacherClass.schoID);
            var remJor = DB.Connect.connection.Дневник.FirstOrDefault(i => i.УченикID == rem.ID);
            DB.Connect.connection.Дневник.Remove(remJor);
            DB.Connect.connection.Ученик.Remove(rem);
            DB.Connect.connection.SaveChanges();
        }
    }
}
