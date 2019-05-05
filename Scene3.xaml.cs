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
        int perf_info_id;
        List<Button> seats = new List<Button>();
        DataContext db = new DataContext(DB_connection.connectionString);
        public Scene3(int perf_info_id)
        {
            InitializeComponent();
            this.perf_info_id = perf_info_id;
        }
        private void MyRootDragDelta(object sender, DragDeltaEventArgs e)
        {
            translateTransform.X += e.HorizontalChange;
            translateTransform.Y += e.VerticalChange;
        }

        public List<Button> GetSeats()
        {
            return seats;
        }

        private void SeatBtn_Click(object sender, RoutedEventArgs e)
        {
            Button b = sender as Button;
            TTickets t = Ticket.GetTicketInfo(b, perf_info_id);
            if (b.Background == Brushes.Tomato)
            {
                b.Background = Brushes.DarkRed;
                OnSeatClicked(new SeatClickedEventArgs(t.Price));
                seats.Add(b);
            }
            else
            {
                b.Background = Brushes.Tomato;
                OnSeatClicked(new SeatClickedEventArgs(-t.Price));
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
