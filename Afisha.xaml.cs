using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Theater
{
    /// <summary>
    /// Логика взаимодействия для Afisha.xaml
    /// </summary>
    public enum Months
    {
        Январь = 1, Февраль, Март, Апрель, Май, Июнь, Июль, Август, Сентябрь, Октябрь, Ноябрь, Декабрь
    }
    public partial class Afisha
    {
        private int Month_id { get; set; }
        public Afisha()
        {
            InitializeComponent();
            Month_buttons();
        }

        private void Month_buttons()
        {
            Months m;
            DataContext db = new DataContext(DB_connection.connectionString);
            var query2 = db.GetTable<TAfisha_dates>()
                         .Where(k => k.Date >= DateTime.Now && !k.Cancelled)
                         .GroupBy(row =>
                            new
                            {
                                Year = row.Date.Year,
                                Month = row.Date.Month
                            },
                            (key, group) => new
                            {
                                key1 = key.Year,
                                key2 = key.Month
                            })
                            .OrderBy(k => k.key1).ThenBy(k => k.key2)
                            .Take(4);
            if(query2.Any())
            {
                Month_id = query2.First().key2;
            }
            foreach (var q in query2)
            {
                Button b = new Button();
                m = (Months)q.key2;
                b.Content = m + Environment.NewLine + q.key1;
                b.Style = this.FindResource("MonthStyle") as Style;
                b.Tag = q.key2;
                b.Click += new RoutedEventHandler(this.MonthBtn_Click);
                month_panel.Children.Add(b);
            }
        }

        private void MonthBtn_Click(object sender, EventArgs e)
        {
            Refresh(Convert.ToInt32(((Control)sender).Tag));
        }

        public void Refresh(int month)
        {
            performancelist_panel.Children.Clear();
            Month_id = month;
            DataContext db = new DataContext(DB_connection.connectionString);
            var query2 = db.GetTable<TAfisha_dates>()
                        .Where(k => k.Date.Month == Month_id && k.Date >= DateTime.Now && !k.Cancelled)
                        .Select(k => k.Id_performance)
                        .Distinct().ToArray();
            var query1 = db.GetTable<TAfisha>()
                        .Where(k => query2.Contains(k.Id))
                        .Select(k => new { k.Image, k.Name, k.Duration, k.Age_restriction, k.Description, k.Id });
            foreach (var q in query1)
            {
                Performance_list p = new Performance_list();
                string s = DB_connection.current_directory + "images_afisha\\" + q.Image;
                p.PerfImage.Source = new BitmapImage(new Uri(s, UriKind.RelativeOrAbsolute));
                p.PerfName.Content = q.Name;
                p.Duration.Content = q.Duration;
                p.AgeRestriction.Content = q.Age_restriction;
                p.Description.Text = q.Description;
                p.LearnMoreBtn.Tag = q.Id;
                p.LearnMoreBtn.Click += new RoutedEventHandler(this.LearnMoreBtn_Click);
                performancelist_panel.Children.Add(p);
            }
        }

        private void LearnMoreBtn_Click(object sender, EventArgs e)
        {
            Performance f = new Performance(Convert.ToInt32(((Control)sender).Tag), Month_id);
            f.Show();
        }
    }
}
