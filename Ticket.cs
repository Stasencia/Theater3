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
        public static int Ticket_purchase(List<TTickets> tickets)
        {
            DataContext db = new DataContext(DB_connection.connectionString);
            foreach (TTickets ticket in tickets)
            {
                TTickets t = new TTickets() { User_Id = ticket.User_Id, Performance_info_id = ticket.Performance_info_id, Price = ticket.Price, HallPart = ticket.HallPart, Left = ticket.Left, Sector = ticket.Sector, Seat = ticket.Seat };
                db.GetTable<TTickets>().InsertOnSubmit(t);
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

        public static IQueryable<TicketSellInfo> FindTickets()
        {
            DataContext db = new DataContext(DB_connection.connectionString);
            IQueryable<TicketSellInfo> q = db.GetTable<TTickets>().Where(k => k.User_Id == User.CurrentUser.ID)
                                            .GroupBy(x => x.Performance_info_id)
                                            .Join(db.GetTable<TAfisha_dates>(),
                                            tp => tp.Key,
                                            ap => ap.Id,
                                            (tp, ap) => new { Id = ap.Id_performance, ap.Date, ap.Cancelled, Tickets = tp.Select(x => x) })
                                            .Join(db.GetTable<TAfisha>(),
                                            tp => tp.Id,
                                            ap => ap.Id,
                                            (tp, ap) => new { ap.Name, ap.Small_image, tp.Date, tp.Cancelled, tp.Tickets })
                                            .OrderByDescending(x => x.Date)
                                            .Select(x => new TicketSellInfo() { Name = x.Name, Small_image = x.Small_image, Date = x.Date, Cancelled = x.Cancelled, Tickets  = x.Tickets });
            return q;
        }

        public static List<PurchasedTicket> ShowTickets()
        {
            List<PurchasedTicket> purchasedTickets = new List<PurchasedTicket>();
            IQueryable<TicketSellInfo> ticket_Sell_Info = FindTickets();
            string path = "";
            foreach(TicketSellInfo t in ticket_Sell_Info)
            {
                string st = "Места: " + Environment.NewLine;
                PurchasedTicket purchasedTicket = new PurchasedTicket();
                purchasedTicket.PerformanceName.Text = t.Name;
                purchasedTicket.PerformanceDate.Text = t.Date.ToShortDateString() + " " + t.Date.ToShortTimeString();
                path = DB_connection.current_directory + "images_afisha\\" + t.Small_image;
                purchasedTicket.PerformanceImage.Source = new BitmapImage(new Uri(path, UriKind.RelativeOrAbsolute));
                if (t.Cancelled)
                    purchasedTicket.CancelledText.Visibility = System.Windows.Visibility.Visible;

                var seats = t.Tickets.GroupBy(x => new { x.HallPart, x.Left, x.Sector })
                                    .OrderBy(x => x.Key.HallPart)
                                    .ThenBy(x =>x.Key.Left)
                                    .ThenBy(x => x.Key.Sector);
                foreach(var s in seats)
                {
                    HallPart o = null;
                    switch(s.Key.HallPart)
                    {
                        case "Beljetazh":
                            o = new Beljetazh(s.Key.Left, s.Key.Sector);
                            break;
                        case "Benuar":
                            o = new Benuar(s.Key.Left, s.Key.Sector);
                            break;
                        case "Parter":
                            o = new Parter(s.Key.Left, s.Key.Sector);
                            break;
                    }
                    st += $"{o.ToString()}{String.Join(", ", s.Select(x => x.Seat).OrderBy(x => x))})" + Environment.NewLine;
                }
                purchasedTicket.Seats.Text = st;
                purchasedTicket.Margin = new System.Windows.Thickness(5);
                DockPanel.SetDock(purchasedTicket, Dock.Top);
                purchasedTickets.Add(purchasedTicket);
            }
            return purchasedTickets;
        }
    }
}
