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
        public static async void Registration(Window sender, string login, string password, string confirmpassword)
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
                    if (password == confirmpassword)
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
                        dialogContent.Text = "Значение поля \"подтверждение пароля\" не сходится со значением нового пароля";
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

        public static void Login_change(string new_login, string initial_login, My_Account account)
        {
            LoginChangeReciever info = new LoginChangeReciever(new_login, initial_login, account);
            LoginStringsFilledHandler stringsFilledHandler = new LoginStringsFilledHandler();
            NoChangesHandler noChangesHandler = new NoChangesHandler();
            LoginExistsHandler loginExistsHandler = new LoginExistsHandler();
            ChangeLoginHandler changeLoginHandler = new ChangeLoginHandler();
            stringsFilledHandler.Successor = noChangesHandler;
            noChangesHandler.Successor = loginExistsHandler;
            loginExistsHandler.Successor = changeLoginHandler;
            stringsFilledHandler.Handle(info);
        }

         public static void Password_change(string new_password, string current_password, string confirmationpassword, My_Account account)
         {
            PasswordChangeReciever info = new PasswordChangeReciever(new_password, current_password, confirmationpassword, account);
            PasswordStringsFilledHandler stringsFilledHandler = new PasswordStringsFilledHandler();
            PasswordValidationHandler validationHandler = new PasswordValidationHandler();
            PasswordConfirmationHandler confirmationHandler = new PasswordConfirmationHandler();
            ChangePasswordHandler passwordHandler = new ChangePasswordHandler();
            stringsFilledHandler.Successor = validationHandler;
            validationHandler.Successor = confirmationHandler;
            confirmationHandler.Successor = passwordHandler;
            stringsFilledHandler.Handle(info);
         }

        private static async void ShowDial(Window sender, TextBlock dialogContent)
        {
            await sender.ShowDialog(dialogContent);
        }
    }
}
