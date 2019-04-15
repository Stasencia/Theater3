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
    public partial class Afisha
    {
        public enum Months
        {
            Январь = 1, Февраль, Март, Апрель, Май, Июнь, Июль, Август, Сентябрь, Октябрь, Ноябрь, Декабрь
        }
        public Afisha()
        {
            InitializeComponent();
            performancelist_panel.Children.Add(new Performance_list());
            performancelist_panel.Children.Add(new Performance_list());
            performancelist_panel.Children.Add(new Performance_list());
            Month_buttons();
        }

        private void Month_buttons()
        {
            int i = 0;
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

            foreach (var q in query2)
            {
                Button b = new Button();
                m = (Months)q.key2;
                b.Content = m + Environment.NewLine + q.key1;
                b.Style = this.FindResource("MonthStyle") as Style;
                b.Tag = q.key2;
                //b.Click += new System.EventHandler(this.button1_Click);
                month_panel.Children.Add(b);
                i++;
            }
        }
    }
}
