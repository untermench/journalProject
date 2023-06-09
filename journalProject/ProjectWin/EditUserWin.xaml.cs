﻿using System;
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
    /// Логика взаимодействия для EditUserWin.xaml
    /// </summary>
    public partial class EditUserWin : Window
    {
        public EditUserWin()
        {
            InitializeComponent();
            var user = DB.Connect.connection.Пользователь.FirstOrDefault(i => i.ID == ProjectClasses.TeacherClass.adminUserEditID);

            NameBox.Text = user.Имя;
            SurnameBox.Text = user.Фамилия;
            PatronymicBox.Text = user.Отчетсво;
            MailBox.Text = user.Почта;
            PasBox.Password = user.Пароль;
            LoginBox.Text = user.Логин;

        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                if (NameBox.Text == " ".Trim() || SurnameBox.Text == " ".Trim() || PatronymicBox.Text == " ".Trim() || LoginBox.Text == " ".Trim() || PasBox.Password == " ".Trim() || MailBox.Text == " ".Trim())
                {
                    MessageBox.Show("Заполните пустые поля!");
                }
                else
                {
                    var user = DB.Connect.connection.Пользователь.FirstOrDefault(i => i.ID == ProjectClasses.TeacherClass.adminUserEditID);

                    user.Имя = NameBox.Text;
                    user.Фамилия = SurnameBox.Text;
                    user.Отчетсво = PatronymicBox.Text;
                    user.Почта = MailBox.Text;
                    user.Пароль = PasBox.Password;
                    user.Логин = LoginBox.Text;

                    var loginTest = DB.Connect.connection.Пользователь.FirstOrDefault(i => i.Логин == LoginBox.Text && i.ID != ProjectClasses.TeacherClass.adminUserEditID);
                    if (loginTest != null)
                    {
                        MessageBox.Show("Данный логин занят!");
                    }
                    else
                    {
                        var mailText = DB.Connect.connection.Пользователь.FirstOrDefault(i => i.Почта == MailBox.Text && i.ID != ProjectClasses.TeacherClass.adminUserEditID);
                        if (mailText != null)
                        {
                            MessageBox.Show("Данная почта занята!");
                        }
                        else
                        {
                            DB.Connect.connection.SaveChanges();
                            MessageBox.Show("Ваши данные были изменены");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ощибка", ex.Message, MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void DelButton_Click(object sender, RoutedEventArgs e)
        {
            int removeID = ProjectClasses.TeacherClass.adminUserEditID;
            var prov = DB.Connect.connection.Пользователь.FirstOrDefault(i => i.ID == removeID);
            var del = DB.Connect.connection.Пользователь.FirstOrDefault(i => i.ID == ProjectClasses.TeacherClass.id);
            if (prov.ID != del.ID)
            {
                
                    if (MessageBox.Show($"Вы действительно хотите удалить данного пользователя?",
                            "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        var removeUser = DB.Connect.connection.Пользователь.FirstOrDefault(i => i.ID == removeID);
                        var dostupGroup = DB.Connect.connection.Доступ.Where(i => i.УчительID == removeID).ToList();
                        var zanatGroup = DB.Connect.connection.Занятие.Where(i => i.УчительID == removeID).ToList();
                    if(zanatGroup != null)
                    {
                        foreach (var rem in zanatGroup) rem.УчительID = null;
                    }
                    if (dostupGroup != null)
                    {
                        var remListDostup = new List<DB.Доступ> { };
                        foreach (var rem in dostupGroup) remListDostup.Add(rem);
                        DB.Connect.connection.Доступ.RemoveRange(remListDostup);
                    }
                        var teacherGroup = DB.Connect.connection.Класс.Where(i => i.Класс_рукID == removeID).ToList();
                        if(teacherGroup != null)
                    {
                        foreach (var rem in teacherGroup) rem.Класс_рукID = null;
                    }
                        DB.Connect.connection.Пользователь.Remove(removeUser);
                        DB.Connect.connection.SaveChanges();
                        MessageBox.Show("Пользователь удален");
                        Close();
                    }
                
            }
            else
            {
                MessageBox.Show("Вы не можете удалить свой аккаунт!");
            }
        }
    }
}