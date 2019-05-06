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
    class PasswordValidationHandler : PasswordChangeHandler
    {
        public override void Handle(PasswordChangeReciever reciever)
        {
            DataContext db = new DataContext(DB_connection.connectionString);
            TUsers user = db.GetTable<TUsers>().Where(k => k.Id == User.CurrentUser.ID).First();
            string RealPassword = user.Password;
            if (reciever.CurrentPassword != RealPassword)
            {
                TextBlock dialogContent = new TextBlock();
                dialogContent.Text = "Указано неправильное значение старого пароля";
                ShowDial(reciever.Account, dialogContent);
            }
            else if (Successor != null)
                Successor.Handle(reciever);
        }

        private static async void ShowDial(Window sender, TextBlock dialogContent)
        {
            await sender.ShowDialog(dialogContent);
        }
    }
}
