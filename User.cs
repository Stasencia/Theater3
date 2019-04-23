using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Theater
{
    class User
    {
        public static User CurrentUser = new User();
        public int ID { get; private set; } = 0;
        public int Right { get; private set; } = 0;
        private User()
        {
            
        }
        public static async void Registration(Window sender, string login, string password)
        {
            TextBlock dialogContent = new TextBlock();
            if (!string.IsNullOrWhiteSpace(login) && !string.IsNullOrEmpty(login) &&
           !string.IsNullOrWhiteSpace(password) && !string.IsNullOrEmpty(password))
            {
                DataContext db = new DataContext(DB_connection.connectionString);
                var query = db.GetTable<TUsers>()
                    .Any(k => k.Login == login);
                if (!query)
                {
                    TUsers user = new TUsers() { Login = login, Password = password };
                    db.GetTable<TUsers>().InsertOnSubmit(user);
                    try
                    {
                        db.SubmitChanges();
                        dialogContent.Text = "Вы были успешно зарегистрированы!";
                        await sender.ShowDialog(dialogContent);
                        CurrentUser.ID = user.Id;
                        sender.Close();
                    }
                    catch (Exception e)
                    {
                        dialogContent.Text = e.Message;
                        ShowDial(sender, dialogContent);
                    }
                }
                else
                {
                    dialogContent.Text = "Данный логин уже занят";
                    ShowDial(sender, dialogContent);
                }
            }
            else
            {
                dialogContent.Text = "Заполните все необходимые поля";
                ShowDial(sender, dialogContent);
            }
        }

        public static async void Authorization(Window sender, string login, string password)
        {
            TextBlock dialogContent = new TextBlock();
            if (!string.IsNullOrWhiteSpace(login) && !string.IsNullOrEmpty(login) &&
            !string.IsNullOrWhiteSpace(password) && !string.IsNullOrEmpty(password))
            {
                DataContext db = new DataContext(DB_connection.connectionString);
                var query = db.GetTable<TUsers>()
                            .FirstOrDefault(k => k.Login == login && string.Compare(k.Password, password, false) == 0);
                if (query != null)
                {
                    CurrentUser.ID = query.Id;
                    CurrentUser.Right = query.Rights;
                    dialogContent.Text = "Добро пожаловать!";
                    await sender.ShowDialog(dialogContent);
                    sender.Close();
                }
                else
                {
                    dialogContent.Text = "Пользователя с таким логином и паролем нет в базе данных";
                    ShowDial(sender, dialogContent);
                }
            }
            else
            {
                dialogContent.Text = "Заполните все необходимые поля";
                ShowDial(sender, dialogContent);
            }
        }

        public static void SignOut()
        {
            CurrentUser.ID = 0;
        }

        /* public void Login_change(string new_login, string initial_login, My_Account account)
         {
             if (!string.IsNullOrWhiteSpace(new_login) && !string.IsNullOrEmpty(new_login))
             {
                 if (new_login != initial_login)
                 {
                     DataContext db = new DataContext(DB_connection.connectionString);
                     var query = db.GetTable<TUsers>()
                         .Any(k => k.Login == new_login);
                     if (!query)
                     {
                         TUsers user = db.GetTable<TUsers>().Where(k => k.Id == Program.user.ID).First();
                         user.Login = new_login;
                         try
                         {
                             db.SubmitChanges();
                         }
                         catch (Exception e)
                         {
                             MetroMessageBox.Show(account, e.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error, 100);
                         }
                         MetroMessageBox.Show(account, "Изменения были успешно внесены", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, 120);
                     }
                     else
                         MetroMessageBox.Show(account, "Данный логин уже занят", "Значение логина", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, 120);
                 }
             }
             else
                 MetroMessageBox.Show(account, "Неправильно введено значение логина", "", MessageBoxButtons.OK, MessageBoxIcon.Error, 120);
             account.Fields_fill();
         }

         public void Password_change(string new_password, string initial_password, My_Account account)
         {
             if (!string.IsNullOrWhiteSpace(new_password) && !string.IsNullOrEmpty(new_password))
             {
                 if (new_password != initial_password)
                 {
                     DataContext db = new DataContext(DB_connection.connectionString);
                     TUsers user = db.GetTable<TUsers>().Where(k => k.Id == Program.user.ID).First();
                     user.Password = new_password;
                     try
                     {
                         db.SubmitChanges();
                     }
                     catch (Exception e)
                     {
                         MetroMessageBox.Show(account, e.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error, 100);
                     }
                     MetroMessageBox.Show(account, "Изменения были успешно внесены", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, 120);
                 }
             }
             else
                 MetroMessageBox.Show(account, "Неправильно введено значение пароля", "", MessageBoxButtons.OK, MessageBoxIcon.Error, 120);
             account.Fields_fill();
         }*/

        private static async void ShowDial(Window sender, TextBlock dialogContent)
        {
            await sender.ShowDialog(dialogContent);
        }
    }
}
