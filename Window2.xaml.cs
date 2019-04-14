using MahApps.Metro;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using System;
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

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для Window2.xaml
    /// </summary>
    public partial class Window2 : MetroWindow
    {
        public Window2()
        {
            InitializeComponent();
            ThemeManager.ChangeAppStyle(this,
                                    ThemeManager.GetAccent("Crimson"),
                                    ThemeManager.GetAppTheme("BaseLight"));
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            var mySettings = new MetroDialogSettings()
            {
                AffirmativeButtonText = "Quit",
                NegativeButtonText = "Cancel",
                AnimateShow = true,
                AnimateHide = true
            };
            var loginset = new LoginDialogSettings()
            {
                ColorScheme = MetroDialogColorScheme.Theme
            };
 
            await this.ShowMessageAsync("LAlalaalal", "Lolololo", MessageDialogStyle.AffirmativeAndNegative, mySettings);
           // await this.ShowLoginAsync("LAlalaalal", "Lolololo", loginset);
        }
    }
}
