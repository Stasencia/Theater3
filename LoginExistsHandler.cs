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
    class LoginExistsHandler : LoginChangeHandler
    {
        public override void Handle(LoginChangeReciever reciever)
        {
            DataContext db = new DataContext(DB_connection.connectionString);
            var query = db.GetTable<TUsers>()
                .Any(k => k.Login == reciever.NewLogin);
            if (query)
            {
                TextBlock dialogContent = new TextBlock();
                dialogContent.Text = "Данный логин уже занят";
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
