using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace Theater
{
    class Ticket
    {
        public static int Ticket_purchase(List<Button> buttons, int perf_info_id, double price, Ticket_purchase form)
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
    }
}
