﻿using System;
using System.Collections.Generic;
using System.Data.Linq;
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
    /// Логика взаимодействия для ChangePersonalInfoControl.xaml
    /// </summary>
    public partial class ChangePersonalInfoControl : UserControl
    {
        string New_Login;
        string Initial_Login;
        public My_Account account { get; set; }
        TUsers user;
        DataContext db = new DataContext(DB_connection.connectionString);
        public ChangePersonalInfoControl(My_Account acc)
        {
            InitializeComponent();
            account = acc;
            RenewLoginData();
        }

        private void RenewLoginData()
        {
            DataContext db = new DataContext(DB_connection.connectionString);
            user = db.GetTable<TUsers>().Where(k => k.Id == User.CurrentUser.ID).First();
            Initial_Login = user.Login;
            InitLogin.Text = Initial_Login;
            NLogin.Text = Initial_Login;
        }

        private void LoginChange_Click(object sender, RoutedEventArgs e)
        {
            if (LoginChange.Content.ToString() == "Изменить")
            {
                NLogin.Visibility = Visibility.Visible;
                InitLogin.Visibility = Visibility.Collapsed;
                LoginChange.Content = "Подтвердить";
            }
            else
            {
                New_Login = NLogin.Text;
                User.Login_change(New_Login, Initial_Login, account);
                NLogin.Visibility = Visibility.Collapsed;
                InitLogin.Visibility = Visibility.Visible;
                RenewLoginData();
                LoginChange.Content = "Изменить";
            }
        }

        private void PasswordChange_Click(object sender, RoutedEventArgs e)
        {
            User.Password_change(NewPassword.Password, CurrentPassword.Password, ConfirmPassword.Password, account);
        }
    }
}
