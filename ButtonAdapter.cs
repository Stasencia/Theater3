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
    }
}
