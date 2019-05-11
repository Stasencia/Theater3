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
        public List<TTickets> seats = new List<TTickets>();
        DataContext db = new DataContext(DB_connection.connectionString);
        public Scene3(int perf_info_id)
        {
            InitializeComponent();
            this.perf_info_id = perf_info_id;
            this.DataContext = perf_info_id;
        }
        private void MyRootDragDelta(object sender, DragDeltaEventArgs e)
        {
            translateTransform.X += e.HorizontalChange;
            translateTransform.Y += e.VerticalChange;
        }

        public List<TTickets> GetSeats()
        {
            return seats;
        }

        private void SeatBtn_Click(object sender, RoutedEventArgs e)
        {
            Button b = sender as Button;
            ButtonAdapter ba = new ButtonAdapter(b);
            if (b.Background == Brushes.Tomato)
            {
                b.Background = Brushes.DarkRed;
                OnSeatClicked(new SeatClickedEventArgs(ba.Price));
                seats.Add(ba);
            }
            else
            {
                b.Background = Brushes.Tomato;
                OnSeatClicked(new SeatClickedEventArgs(-ba.Price));
                seats.Remove(ba);
            }
        }

        protected virtual void OnSeatClicked(SeatClickedEventArgs e)
        {
            SeatClicked?.Invoke(this, e);
        }

        public event EventHandler<SeatClickedEventArgs> SeatClicked;
    }
}
