using MaterialDesignThemes.Wpf;
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

namespace Theater
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            UserBox.Visibility = Visibility.Collapsed;
        }

        private void AuthorizationBtn_Click(object sender, RoutedEventArgs e)
        {
            Authorization authorization = Authorization.GetInstance(this);
            authorization.Show();
            this.Hide();
        }

        private void RegistrationBtn_Click(object sender, RoutedEventArgs e)
        {
            Registration registration = Registration.GetInstance(this);
            registration.Show();
            this.Hide();
        }

        public void CurrentUserCheck()
        {
            if (User.CurrentUser.ID == 0)
            {
                AuthorizationBtn.Visibility = Visibility.Visible;
                RegistrationBtn.Visibility = Visibility.Visible;
                UserBox.Visibility = Visibility.Collapsed;
            }
            else
            {
                AuthorizationBtn.Visibility = Visibility.Collapsed;
                RegistrationBtn.Visibility = Visibility.Collapsed;
                UserBox.Visibility = Visibility.Visible;
            }
        }

        private void AfishaButton_Click(object sender, RoutedEventArgs e)
        {
            Afisha afisha = new Afisha();
            afisha.Show();
        }

        private void My_AccountBtn_Click(object sender, RoutedEventArgs e)
        {
            My_Account my_Account = new My_Account(this);
            my_Account.Show();
        }

        private void SignOutBtn_Click(object sender, RoutedEventArgs e)
        {
            User.SignOut();
            CurrentUserCheck();
        }
    }
}
