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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            ThemeManager.ChangeAppStyle(this,
                                   ThemeManager.GetAccent("Teal"),
                                   ThemeManager.GetAppTheme("BaseLight"));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Authorization authorization = Authorization.GetInstance();
            authorization.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Registration registration = Registration.GetInstance();
            registration.Show();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
           
        }

        private void AfishaButton_Click(object sender, RoutedEventArgs e)
        {
            Afisha afisha = new Afisha();
            afisha.Show();
        }
    }
}
