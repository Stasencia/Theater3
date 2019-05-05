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
    class StringsFilledHandler : InfoChangeHandler
    {
        public override void Handle(LoginChangeReciever reciever)
        {
            if (string.IsNullOrWhiteSpace(reciever.NewLogin) || string.IsNullOrEmpty(reciever.NewLogin))
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
