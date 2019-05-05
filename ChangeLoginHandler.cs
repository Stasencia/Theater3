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
    class ChangeLoginHandler : InfoChangeHandler
    {
        DataContext db = new DataContext(DB_connection.connectionString);
        public override void Handle(LoginChangeReciever reciever)
        {
            TextBlock dialogContent = new TextBlock();
            TUsers user = db.GetTable<TUsers>().Where(k => k.Id == User.CurrentUser.ID).First();
            user.Login = reciever.NewLogin;
            try
            {
                db.SubmitChanges();
            }
            catch (Exception e)
            {
                dialogContent.Text = e.Message;
                ShowDial(reciever.Account, dialogContent);
            }
            dialogContent.Text = "Изменения были успешно внесены";
            ShowDial(reciever.Account, dialogContent);
        }
        private static async void ShowDial(Window sender, TextBlock dialogContent)
        {
            await sender.ShowDialog(dialogContent);
        }
    }
}
