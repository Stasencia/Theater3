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
        DataContext db = new DataContext(DB_connection.connectionString);
        public Ticket_purchase1(Performance perf, int info)
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

        private void Ticket_purchase_Load()
        {
            var query1 = db.GetTable<TAfisha_dates>()
                        .Where(l => l.Id == perf_info_id)
                        .Join(db.GetTable<TAfisha>(),
                            a => a.Id_performance,
                            b => b.Id,
                            (a, b) => new { a.Date, b.Duration, b.Image, b.Id, b.Price, b.Name }).First();
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
                g = Scene.FindName(gridname) as Grid;
                seat = g.Children.OfType<Button>().Where(k => k.Content.ToString() == q.Seat.ToString()).First();
                seat.IsEnabled = false;
            }
        }
    }
}
