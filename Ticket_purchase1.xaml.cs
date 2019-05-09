using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Theater
{
    /// <summary>
    /// Логика взаимодействия для Ticket_purchase1.xaml
    /// </summary>
    public partial class Ticket_purchase1 : Window
    {
        int perf_info_id;
        Performance perf;
        Scene3 scene;
        decimal discount;
        DataContext db = new DataContext(DB_connection.connectionString);
        decimal initialprice = 0;
        public Ticket_purchase1(Performance perf, int info)
        {
            InitializeComponent();
            perf_info_id = info;
            this.perf = perf;
            scene = new Scene3(info);
            scene.Name = "Scene";
            MainGrid.Children.Add(scene);
            Ticket_purchase_Load();
            scene.SeatClicked += Scene_SeatClicked;
            CalculateDiscount();
        }

        private void CalculateDiscount()
        {
            var x = db.GetTable<TTickets>().Where(k => k.User_Id == User.CurrentUser.ID);
            if (x.Any())
            {
                discount = x.Sum(k => k.Price) / 200;
                if (discount > 50)
                    discount = 50;
            }      
            Discount.Content = $"Скидка: {discount}%";
        }     

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            perf.Show();
        }

        private void Ticket_purchase_Load()
        {
            var query1 = db.GetTable<TAfisha_dates>()
                        .Where(l => l.Id == perf_info_id)
                        .Join(db.GetTable<TAfisha>(),
                            a => a.Id_performance,
                            b => b.Id,
                            (a, b) => new { a.Date, b.Duration, b.Image, b.Id, b.Name }).First();
            AfishaLabel.Content = query1.Name;
            AfishaDate.Content = query1.Date.ToShortDateString() + " " + query1.Date.ToShortTimeString();
            string s = DB_connection.current_directory + "images_afisha\\" + query1.Image;
            AfishaImg.Source = new BitmapImage(new Uri(s, UriKind.RelativeOrAbsolute));

            var query = db.GetTable<TTickets>()
                    .Where(k => k.Performance_info_id == perf_info_id)
                    .Select(k => new { k.HallPart, k.Left, k.Sector, k.Seat});
            string gridname;
            Grid g;
            Button seat;
            foreach (var q in query)
            {
                gridname = $"{(q.Left ==true?"Left":"Right")}_{q.HallPart}_{q.Sector}";
                g = scene.FindName(gridname) as Grid;
                seat = g.Children.OfType<Button>().Where(k => k.Content.ToString() == q.Seat.ToString()).First();
                seat.IsEnabled = false;
            }
        }

        private void CalculatePrices()
        {
            InitialPrice.Content = $"Цена: {initialprice} грн.";
            OverallPrice.Content = $"Всего: {initialprice * (100 - discount) / 100:f2} грн.";
            CalculateDiscount();
        }

        private void Scene_SeatClicked(object sender, SeatClickedEventArgs e)
        {
            initialprice += e.Price;
            if (initialprice == 0)
                PurchaseBtn.IsEnabled = false;
            else
                PurchaseBtn.IsEnabled = true;
            InitialPrice.Content = $"Цена: {initialprice} грн.";
            OverallPrice.Content = $"Всего: {initialprice * (100 - discount) / 100:f2} грн.";
        }

        private async void PurchaseBtn_Click(object sender, RoutedEventArgs e)
        {
            List<Button> seats = scene.GetSeats();
            List<TTickets> tickets = new List<TTickets>();
            TextBox dialogContent = new TextBox();
            foreach (Button seat in seats)
            {
                seat.IsEnabled = false;
                seat.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFBC6BC"));
                tickets.Add(Ticket.GetTicketInfo(seat, perf_info_id));
            }
            if (Ticket.Ticket_purchase(tickets) == 0)
            {
                dialogContent.Text = "Билеты были успешно заказаны!" + Environment.NewLine + "Благодарим за покупку.";
                initialprice = 0;
                CalculatePrices();
                seats.Clear();
                tickets.Clear();
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
