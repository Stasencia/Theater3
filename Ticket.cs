using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Theater
{
    class Ticket
    {
        public static int Ticket_purchase(List<Button> buttons, int perf_info_id, decimal price, Ticket_purchase form)
        {
            var chosenbuttons = buttons.Where(k => k.Background != Brushes.WhiteSmoke).ToList();
            TTickets ticket;
            DataContext db = new DataContext(DB_connection.connectionString);
            foreach(Button b in chosenbuttons)
            {
                ticket = new TTickets() { User_Id = User.CurrentUser.ID, Performance_info_id = perf_info_id, Seat = buttons.IndexOf(b), Price = price };
                db.GetTable<TTickets>().InsertOnSubmit(ticket);
                b.Background = Brushes.Gray;
                b.IsEnabled = false;
            }
            try
            {
                db.SubmitChanges();
            }
            catch (Exception)
            {
                return 1;
            }
            return 0;
        }

        public static IQueryable<TicketSellInfo> Find_tickets()
        {
            DataContext db = new DataContext(DB_connection.connectionString);

            IQueryable<TicketSellInfo> ticket_Sell_Infos = db.GetTable<TTickets>()
                    .Join(db.GetTable<TAfisha_dates>(),
                        tp => tp.Performance_info_id,
                        ap => ap.Id,
                        (tp, ap) => new { Id = ap.Id_performance, ap.Date, tp.Seat, tp.User_Id, ap.Cancelled })
                    .Join(db.GetTable<TAfisha>(),
                      tp => tp.Id,
                      ap => ap.Id,
                      (tp, ap) => new { ap.Name, tp.Date, tp.Seat, ap.Small_image, tp.User_Id, tp.Cancelled })
                  .Where(k => k.User_Id == User.CurrentUser.ID)
                  .GroupBy(x => new { x.Name, x.Date, x.Small_image, x.Cancelled })
                  .OrderByDescending(x => x.Key.Date)
                  .Select(x => new TicketSellInfo { Name = x.Key.Name, Date = x.Key.Date, Small_image = x.Key.Small_image, Cancelled = x.Key.Cancelled, Count = x.Select(d => d.Seat).Count(), Seats = x.Select(d => d.Seat) });

            return ticket_Sell_Infos;
        }

        public static List<PurchasedTicket> Show_tickets()
        {
            List<PurchasedTicket> purchasedTickets = new List<PurchasedTicket>();
            IQueryable<TicketSellInfo> ticket_Sell_Info = Find_tickets();
            string st = "Места: " + Environment.NewLine;
            string path = "";
            foreach (var q in ticket_Sell_Info)
            {
                PurchasedTicket purchasedTicket = new PurchasedTicket();
                path = DB_connection.current_directory + "images_afisha\\" + q.Small_image;
                purchasedTicket.PerformanceImage.Source = new BitmapImage(new Uri(path, UriKind.RelativeOrAbsolute));
                purchasedTicket.PerformanceName.Text = q.Name;
                if (q.Cancelled)
                    purchasedTicket.CancelledText.Visibility = System.Windows.Visibility.Visible;
                purchasedTicket.PerformanceDate.Text = q.Date.ToShortDateString() + " " + q.Date.ToShortTimeString();
                var seats = q.Seats.Where(d => Convert.ToInt32(d) < 50);
                if (seats.ToArray().Count() != 0)
                    st += "Партер: ";
                var seats1 = seats.Where(d => Convert.ToInt32(d) < 14);
                if (seats1.ToArray().Length != 0)
                    st += "(1 ряд: " + String.Join(", ", seats1) + ")";
                var seats2 = seats.Where(d => Convert.ToInt32(d) >= 14 && Convert.ToInt32(d) < 30);
                if (seats2.ToArray().Count() != 0)
                    st += "(2 ряд: " + String.Join(", ", seats2) + ")";
                var seats3 = seats.Where(d => Convert.ToInt32(d) >= 30);
                if (seats3.ToArray().Count() != 0)
                    st += "(3 ряд: " + String.Join(", ", seats3) + ")";

                seats = q.Seats.Where(d => Convert.ToInt32(d) >= 50).Select(d => d - 50);
                if (seats.ToArray().Length != 0)
                    st += "Бельэтаж: ";
                seats1 = seats.Where(d => Convert.ToInt32(d) < 16);
                if (seats1.ToArray().Count() != 0)
                    st += "(1 ряд: " + String.Join(", ", seats1) + ")";
                seats2 = seats.Where(d => Convert.ToInt32(d) >= 16 && Convert.ToInt32(d) < 30);
                if (seats2.ToArray().Count() != 0)
                    st += "(2 ряд: " + String.Join(", ", seats2) + ")";
                seats3 = seats.Where(d => Convert.ToInt32(d) >= 30);
                if (seats3.ToArray().Count() != 0)
                    st += "(3 ряд: " + String.Join(", ", seats3) + ")";
                purchasedTicket.Seats.Text = st;
                purchasedTicket.Margin = new System.Windows.Thickness(5);
                DockPanel.SetDock(purchasedTicket, Dock.Top);
                purchasedTickets.Add(purchasedTicket);
            }
            return purchasedTickets;
        }
    }
}
