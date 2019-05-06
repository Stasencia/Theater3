using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Theater
{
    class PasswordConfirmationHandler : PasswordChangeHandler
    {
        public override void Handle(PasswordChangeReciever reciever)
        {
            if (reciever.NewPassword != reciever.ConfimationPassword)
            {
                TextBlock dialogContent = new TextBlock();
                dialogContent.Text = "Значения в полях нового пароля и подтверждения пароля не совпадают";
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
