using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    class User
    {
        public static User CurrentUser = new User();
        public int ID { get; private set; } = 0;
        public int Right { get; private set; } = 0;
        private User()
        {
            
        }
        public static async void Registration(MetroWindow sender, string login, string password)
        {
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
                        await sender.ShowMessageAsync("", "Вы были успешно зарегистрированы!", MessageDialogStyle.Affirmative);
                        CurrentUser.ID = user.Id;
                        sender.Close();
                    }
                    catch (Exception e)
                    {
                        await sender.ShowMessageAsync("", e.Message, MessageDialogStyle.Affirmative);
                    }
                }
                else
                    await sender.ShowMessageAsync("Значение логина", "Данный логин уже занят",  MessageDialogStyle.Affirmative);
            }
            else
                await sender.ShowMessageAsync("Ошибка заполнения", "Заполните все необходимые поля", MessageDialogStyle.Affirmative);
        }

        public static async void Authorization(MetroWindow sender, string login, string password)
        {
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
                    await sender.ShowMessageAsync("", "Добро пожаловать!"); 
                    sender.Close();
                }
                else
                    await sender.ShowMessageAsync("Ошибка авторизации", "Пользователя с таким логином и паролем нет в базе данных");
            }
            else
                await sender.ShowMessageAsync("Ошибка заполнения", "Заполните все необходимые поля");
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
    }
}
