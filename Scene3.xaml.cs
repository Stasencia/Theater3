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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Theater
{
    /// <summary>
    /// Логика взаимодействия для Scene3.xaml
    /// </summary>
    public partial class Scene3 : UserControl
    {
        List<Button> seats = new List<Button>();
        DataContext db = new DataContext(DB_connection.connectionString);
        TAfisha_SeatsPrices afisha_SeatsPrices;
        public Scene3(int perf_info_id)
        {
            InitializeComponent();
            int id_perf = db.GetTable<TAfisha_dates>().Where(k => k.Id == perf_info_id).Select(k => k.Id_performance).First();
            afisha_SeatsPrices = db.GetTable<TAfisha_SeatsPrices>().Where(k => k.Performance_Id == id_perf).First();
        }
        private void MyRootDragDelta(object sender, DragDeltaEventArgs e)
        {
            translateTransform.X += e.HorizontalChange;
            translateTransform.Y += e.VerticalChange;
        }

        public List<Button> GetSelectedSeats()
        {
            return seats;
        }

        private void SeatBtn_Click(object sender, RoutedEventArgs e)
        {
            Button b = sender as Button;
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
            if (b.Background == Brushes.Tomato)
            {
                b.Background = Brushes.DarkRed;
                OnSeatClicked(new SeatClickedEventArgs(price));
                seats.Add(b);
            }
            else
            {
                b.Background = Brushes.Tomato;
                OnSeatClicked(new SeatClickedEventArgs(-price));
                seats.Remove(b);
            }
        }

        protected virtual void OnSeatClicked(SeatClickedEventArgs e)
        {
            SeatClicked?.Invoke(this, e);
        }

        public event EventHandler<SeatClickedEventArgs> SeatClicked;
    }
}
