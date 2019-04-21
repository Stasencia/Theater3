using MaterialDesignThemes.Wpf;
using System;
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
using System.Windows.Shapes;

namespace Theater
{
    /// <summary>
    /// Логика взаимодействия для Ticket_purchase.xaml
    /// </summary>
    public partial class Ticket_purchase : Window
    {
        int perf_info_id;
        Performance perf;
        double initial_price;
        double price;
        DataContext db = new DataContext(DB_connection.connectionString);
        public Ticket_purchase(Performance perf, int info)
        {
            InitializeComponent();
            perf_info_id = info;
            this.perf = perf;
            Ticket_purchase_Load();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            perf.Show();
        }

        public void Price_count()
        {
            var bu = Scene.MainGrid.Children.OfType<Button>().ToList();
            var buttons = Scene.MainGrid.Children.OfType<Button>().Where(k => k.Background != Brushes.WhiteSmoke).ToList();
            price = 0;
            foreach(var b in buttons)
            {
                if (bu.IndexOf(b) < 50)
                    price += initial_price;
                else
                    price += initial_price - 50;
                if (Discount.IsChecked == true)
                    price = price * (float)0.75;
            }
            PriceLabel.Content = "Цена: " + price + " грн.";
            if (price == 0)
                PurchaseBtn.IsEnabled = false;
            else
                PurchaseBtn.IsEnabled = true;
        }

        private void Ticket_purchase_Load()
        {
            var query1 = db.GetTable<TAfisha_dates>()
                        .Where(l => l.Id == perf_info_id)
                        .Join(db.GetTable<TAfisha>(),
                            a => a.Id_performance,
                            b => b.Id,
                            (a, b) => new { a.Date, b.Duration, b.Image, b.Id, b.Price }).First();
            Date.Content = "Дата: " + query1.Date.ToShortDateString();
            Beginning.Content = "Начало: " + query1.Date.ToShortTimeString();
            Duration.Text = "Продолжительность:" + Environment.NewLine + query1.Duration;
            string s = DB_connection.current_directory + "images_afisha\\" + query1.Image;
            AfishaImg.Source = new BitmapImage(new Uri(s, UriKind.RelativeOrAbsolute));
            initial_price = query1.Price;

            var query = db.GetTable<TTickets>()
                    .Where(k => k.Performance_info_id == perf_info_id)
                    .Select(k => k.Seat);
            var seats = Scene.MainGrid.Children.OfType<Button>().ToList();
            foreach (var q in query)
            {
                seats.ElementAt(q).IsEnabled = false;
            }
        }

        private void Discount_Click(object sender, RoutedEventArgs e)
        {
            Price_count();
        }

        private async void PurchaseBtn_Click(object sender, RoutedEventArgs e)
        {
            List<Button> buttons = Scene.MainGrid.Children.OfType<Button>().ToList();
            TextBox dialogContent = new TextBox();
            if (Ticket.Ticket_purchase(buttons, perf_info_id, price, this) == 0)
            {
                dialogContent.Text = "Билеты были успешно заказаны!" + Environment.NewLine + "Благодарим за покупку.";
                PriceLabel.Content = "Цена: 0 грн.";
                PurchaseBtn.IsEnabled = false;
            }
            else
                dialogContent.Text = "При сохранении данных произошла ошибка." + Environment.NewLine + "Попробуйте пожалуйста позже.";
            await this.ShowDialog(dialogContent);
        }
        private void DialogClose(object sender, RoutedEventArgs e)
        {
            MaterialDesignThemes.Wpf.DialogHost.CloseDialogCommand.Execute(null, null);
        }
    }
}
