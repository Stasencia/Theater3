using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Theater
{
    /// <summary>
    /// Логика взаимодействия для Scene.xaml
    /// </summary>
    public partial class Scene : UserControl
    {
        public Scene()
        {
            InitializeComponent();
        }

        private void SeatClicked(object sender, RoutedEventArgs e)
        {
            Button b = sender as Button;
            if (b.Background == Brushes.WhiteSmoke)
            {
                b.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF00BCD4"));
            }
            else
                b.Background = Brushes.WhiteSmoke;
            (Window.GetWindow(this) as Ticket_purchase).Price_count();
        }
    }
}
