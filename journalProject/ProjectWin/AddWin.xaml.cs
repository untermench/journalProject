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
    /// Логика взаимодействия для AddWin.xaml
    /// </summary>
    public partial class AddWin : Window
    {
        public AddWin()
        {
            InitializeComponent();
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var addUch = new DB.Ученик();
                addUch.Фамилия = _famBox.Text;
                addUch.Имя = _nameBox.Text;
                addUch.Отчество = _patrBox.Text;
                addUch.Дата_рождения = Convert.ToDateTime(_birthDate.Text);
                var clasUch = DB.Connect.connection.Класс.FirstOrDefault(i => i.Класс_рукID == ProjectClasses.TeacherClass.id);
                addUch.КлассID = clasUch.ID;
                DB.Connect.connection.Ученик.Add(addUch);
                DB.Connect.connection.SaveChanges();
                MessageBox.Show("Ученик добавлен");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }
        }
    }
}
