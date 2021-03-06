﻿using MaterialDesignThemes.Wpf;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Theater
{
    /// <summary>
    /// Логика взаимодействия для Performance.xaml
    /// </summary>
    public partial class Performance : Window
    {
        public int Month_id { get; set; }
        int perf_id;
        DataContext db = new DataContext(DB_connection.connectionString);
        public Performance(int perf_id, int Month_id)
        {
            InitializeComponent();
            this.perf_id = perf_id;
            this.Month_id = Month_id;
            Height = 450;
            Performance_Load();
        }

        private void Performance_Load()
        {
            string s;
            Button push = new Button();

            var query1 = db.GetTable<TAfisha>()
                            .Where(l => l.Id == perf_id)
                            .Select(l => new { l.Big_image, l.Small_name, l.Small_info, l.Duration, l.Age_restriction, l.Description });
            foreach (var q in query1)
            {
                s = DB_connection.current_directory + "images_afisha\\" + q.Big_image;
                Banner.Source = new BitmapImage(new Uri(s, UriKind.RelativeOrAbsolute));
                PerfAltName.Content = q.Small_name;
                Smallinfo.Text = q.Small_info;
                Duration.Content = q.Duration;
                AgeRestr.Content = q.Age_restriction;
                Decsription.Text = q.Description;
            }

            var query = db.GetTable<TAfisha_dates>()
                        .Where(l => l.Id_performance == perf_id && l.Date >= DateTime.Now)
                        .Select(l => new { l.Date.Month, l.Date.Year })
                        .Distinct();
            int i = 0;
            Months m;
            foreach (var q in query)
            {
                Button top = new Button();
                top.Style = this.FindResource("MonthStyle") as Style;
                m = (Months)q.Month;
                top.Content = m + "\n" + q.Year;
                top.Tag = q.Month + ";" + q.Year;
                if (q.Month == Month_id)
                    push = top;
                top.Click += new RoutedEventHandler(this.Button_customization);
                top.Name = "top" + (i + 1);
                month_panel.Children.Add(top);
                i++;
            }
            for (int j = 0; j < 6; j++)
            {
                for (int k = 0; k < 7; k++)
                {
                    Button b = new Button();
                    b.Style = this.FindResource("DateStyle") as Style;
                    b.MouseEnter += new MouseEventHandler(DayBtn_MouseEnter);
                    b.MouseLeave += new MouseEventHandler(DayBtn_MouseLeave);
                    b.Name = "b" + (j * 7 + k);
                    b.Click += new RoutedEventHandler(this.Day_pushed);
                    Dates_panel1.Children.Add(b);
                }
            }
            push.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
        }

        private void Button_customization(object sender, EventArgs args)
        {
            string[] words = ((Control)sender).Tag.ToString().Split(';');
            DateTime d = new DateTime(Convert.ToInt32(words[1]), Convert.ToInt32(words[0]), 1);
            DateTime d1 = new DateTime(Convert.ToInt32(words[1]), Convert.ToInt32(words[0]), 1);
            while (d.DayOfWeek != DayOfWeek.Monday)
            {
                d = d.AddDays(-1);
            }
            Button b;
            var query = db.GetTable<TAfisha>()
                        .Where(k => k.Id == perf_id)
                        .Join(db.GetTable<TAfisha_dates>(),
                              tp => tp.Id,
                              ap => ap.Id_performance,
                              (tp, ap) => new { tp.Small_image, ap.Date, ap.Cancelled })
                              .Where(k => k.Date >= d1 && k.Date >= DateTime.Now && !k.Cancelled);
            
            for (int i = 0; i < 42; i++)
            {
                b = Dates_panel1.Children.OfType<Button>().Where(x => x.Name == ("b" + i)).First();
                b.SetValue(DayButtonProperties.DayProperty, d.Day.ToString());
                b.SetValue(DayButtonProperties.ImageProperty, null);
                b.IsEnabled = false;
                b.Tag = d.Year + "-" + d.Month + "-" + d.Day;
                d = d.AddDays(1);
            }
            
            var buttons = Dates_panel1.Children.OfType<Button>().Where(k => k.Name.StartsWith("b"))
                            .Join(query,
                                button => Convert.ToDateTime(button.Tag).ToShortDateString(),
                                afisha_info => afisha_info.Date.ToShortDateString(),
                                (button, afisha_info) => new { button, afisha_info });
            string s = DB_connection.current_directory + "images_afisha\\" + query.First().Small_image;
            BitmapImage im = new BitmapImage(new Uri(s, UriKind.RelativeOrAbsolute));
            foreach (var b1 in buttons)
            {
                b1.button.SetValue(DayButtonProperties.ImageProperty, im);
                b1.button.SetValue(DayButtonProperties.TimeProperty, b1.afisha_info.Date.ToShortTimeString());
                b1.button.IsEnabled = true;
                b1.button.Tag = b1.afisha_info.Date;
            }
        }

        private void DayBtn_MouseEnter(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            var animation1 = new DoubleAnimation
            {
                To = 0.5,
                BeginTime = TimeSpan.FromSeconds(0),
                Duration = TimeSpan.FromSeconds(0.3),
                FillBehavior = FillBehavior.Stop
            };

            animation1.Completed += (s, a) => b.SetValue(DayButtonProperties.ImageOpacityProperty, 0.5);
            var animation2 = new DoubleAnimation
            {
                To = 1.0,
                BeginTime = TimeSpan.FromSeconds(0),
                Duration = TimeSpan.FromSeconds(0.3),
                FillBehavior = FillBehavior.Stop
            };

            animation2.Completed += (s, a) => b.SetValue(DayButtonProperties.TextOpacityProperty, 1.0);
            b.BeginAnimation(DayButtonProperties.ImageOpacityProperty, animation1);
            b.BeginAnimation(DayButtonProperties.TextOpacityProperty, animation2);
        }

        private void DayBtn_MouseLeave(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            var animation = new DoubleAnimation
            {
                To = 0,
                BeginTime = TimeSpan.FromSeconds(0),
                Duration = TimeSpan.FromSeconds(0.5),
                FillBehavior = FillBehavior.Stop
            };

            animation.Completed += (s, a) => { b.SetValue(DayButtonProperties.ImageOpacityProperty, 0.0); b.SetValue(DayButtonProperties.TextOpacityProperty, 0.0); };

            b.BeginAnimation(DayButtonProperties.ImageOpacityProperty, animation);
            b.BeginAnimation(DayButtonProperties.TextOpacityProperty, animation);
        }
        private void Day_pushed(object sender, EventArgs e)
        {
            if (User.CurrentUser.ID != 0)
            {
                DateTime date = Convert.ToDateTime(((Button)sender).Tag);
                var query = db.GetTable<TAfisha_dates>()
                           .Where(l => l.Id_performance == perf_id && l.Date == date)
                           .Select(l => new { l.Date, l.Id }).First();
                Ticket_purchase t = new Ticket_purchase(this, query.Id);
                t.Show();
                this.Hide();
            }
            else
            {
                TextBlock dialogContent = new TextBlock();
                dialogContent.Text = "Только авторизированные пользователи имеют доступ к покупке билетов. Пожалуйста, выполните вход в систему.";
                ShowDial(this, dialogContent);
            }
        }

        private void DialogClose(object sender, RoutedEventArgs e)
        {
            MaterialDesignThemes.Wpf.DialogHost.CloseDialogCommand.Execute(null, null);
        }

        private static async void ShowDial(Window sender, TextBlock dialogContent)
        {
            await sender.ShowDialog(dialogContent);
        }
    }
}
