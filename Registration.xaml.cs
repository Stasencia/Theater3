using MahApps.Metro;
using MahApps.Metro.Controls;
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
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : MetroWindow
    {
        private static Registration instance;
        public static Registration GetInstance()
        {
            if (instance == null)
                instance = new Registration();
            return instance;
        }
        protected Registration()
        {
            InitializeComponent();
            ThemeManager.ChangeAppStyle(this,
                                    ThemeManager.GetAccent("Teal"),
                                    ThemeManager.GetAppTheme("BaseLight"));
        }

        private void RegistrateBtn_Click(object sender, RoutedEventArgs e)
        {
            string Login = LoginBox.Text;
            string Password = PasswordBox.Text;
            User.Registration(this, Login, Password);
        }

        private void MetroWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            instance = null;
        }
    }
}
