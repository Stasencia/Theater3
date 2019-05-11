using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Theater
{
    public class ButtonAdapter : TTickets
    {
        Button button;
       /* public int Id { get; set; }
        public int User_Id { get; set; }
        public int Performance_info_id { get; set; }
        public decimal Price { get; set; }
        public string HallPart { get; set; }
        public bool Left { get; set; }
        public int Sector { get; set; }
        public int Seat { get; set; }*/
        public ButtonAdapter(Button button)
        {
            this.button = button;

            DataContext db = new DataContext(DB_connection.connectionString);
            int id_perf = db.GetTable<TAfisha_dates>().Where(k => k.Id == (int)button.Tag).Select(k => k.Id_performance).First();
            TAfisha_SeatsPrices afisha_SeatsPrices = db.GetTable<TAfisha_SeatsPrices>().Where(k => k.Performance_Id == id_perf).First();
            string[] s = (button.Parent as Grid).Name.Split('_');
            bool left = true;
            if (s[0] == "Right")
                left = false;
            string hallpart = s[1];
            int sector = int.Parse(s[2]);
            int seat = Convert.ToInt32(button.Content);
            decimal price;
            if (hallpart == "Beljetazh")
                price = afisha_SeatsPrices.BeljetazhPrice;
            else if (hallpart == "Benuar")
                price = afisha_SeatsPrices.BenuarPrice;
            else
                price = afisha_SeatsPrices.ParterPrice;
            this.User_Id = User.CurrentUser.ID;
            this.Performance_info_id = (int)button.Tag;
            this.Price = price;
            this.HallPart = hallpart;
            this.Left = left;
            this.Sector = sector;
            this.Seat = seat;
        }

        public override Button GetButton()
        {
            return button;
        }

        /*public override TTickets GetTicket()
        {
            DataContext db = new DataContext(DB_connection.connectionString);
            int id_perf = db.GetTable<TAfisha_dates>().Where(k => k.Id == ()button.Tag).Select(k => k.Id_performance).First();
            TAfisha_SeatsPrices afisha_SeatsPrices = db.GetTable<TAfisha_SeatsPrices>().Where(k => k.Performance_Id == id_perf).First();
            string[] s = (b.Parent as Grid).Name.Split('_');
            bool left = true;
            if (s[0] == "Right")
                left = false;
            string hallpart = s[1];
            int sector = int.Parse(s[2]);
            int seat = Convert.ToInt32(b.Content);
            decimal price;
            if (hallpart == "Beljetazh")
                price = afisha_SeatsPrices.BeljetazhPrice;
            else if (hallpart == "Benuar")
                price = afisha_SeatsPrices.BenuarPrice;
            else
                price = afisha_SeatsPrices.ParterPrice;
            TTickets t = new TTickets() { User_Id = User.CurrentUser.ID, Performance_info_id = perf_info_id, Price = price, HallPart = hallpart, Left = left, Sector = sector, Seat = seat };
            return t;
        }*/
    }
}
