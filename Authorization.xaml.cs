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
    /// Логика взаимодействия для Authorization.xaml
    /// </summary>
    public partial class Authorization : MetroWindow
    {
        private static Authorization instance;
        public static Authorization GetInstance()
        {
            if (instance == null)
                instance = new Authorization();
            return instance;
        }
        protected Authorization()
        {
            InitializeComponent();
            ThemeManager.ChangeAppStyle(this,
                                    ThemeManager.GetAccent("Teal"),
                                    ThemeManager.GetAppTheme("BaseLight"));
        }

        private void Button_ClickAsync(object sender, RoutedEventArgs e)
        {
            string Login = LoginBox.Text;
            string Password = PasswordBox.Password;
            User.Authorization(this, Login, Password);
        }

        private void MetroWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            instance = null;
        }
    }
}
