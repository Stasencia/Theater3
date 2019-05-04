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
        public Scene3()
        {
            InitializeComponent();
        }
        private void MyRootDragDelta(object sender, DragDeltaEventArgs e)
        {
            translateTransform.X += e.HorizontalChange;
            translateTransform.Y += e.VerticalChange;
        }

        private void SeatBtn_Click(object sender, RoutedEventArgs e)
        {
            Button b = sender as Button;
            string[] s = (b.Parent as Grid).Name.Split('_');
            bool left = true;
            if (s[0] == "Right")
                left = false;
            string hallpart = s[1];
            int sector = int.Parse(s[3]);
            int seat = Convert.ToInt32(b.Content);
        }
    }
}
