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

namespace Theater
{
    /// <summary>
    /// Логика взаимодействия для My_Account.xaml
    /// </summary>
    public partial class My_Account : Window
    {
        MainWindow mainWindow;
        PurchasedTickets purchasedTickets;
        public My_Account(MainWindow mainWindow)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
            purchasedTickets = new PurchasedTickets();
        }

        private void HomePageBtn_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.Show();
            this.Close();
        }

        private void PersonalInfoBtn_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void PurchasedTicketsBtn_Click(object sender, RoutedEventArgs e)
        {
            ContentGrid.Children.Clear();
            purchasedTickets.TicketPanel.Children.Clear();
            List<PurchasedTicket> showTickets = Ticket.Show_tickets();
            foreach(PurchasedTicket ticket in showTickets)
            {
                purchasedTickets.TicketPanel.Children.Add(ticket);
            }
            ContentGrid.Children.Add(purchasedTickets);
        }
    }
}
