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
    class PasswordStringsFilledHandler : PasswordChangeHandler
    {
        public override void Handle(PasswordChangeReciever reciever)
        {
            if (string.IsNullOrWhiteSpace(reciever.NewPassword) || string.IsNullOrEmpty(reciever.NewPassword) || string.IsNullOrWhiteSpace(reciever.CurrentPassword) || string.IsNullOrEmpty(reciever.CurrentPassword) || string.IsNullOrWhiteSpace(reciever.ConfimationPassword) || string.IsNullOrEmpty(reciever.ConfimationPassword))
            {
                TextBlock dialogContent = new TextBlock();
                dialogContent.Text = "Заполните все необходимые поля";
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
