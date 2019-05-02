using System;
using System.Collections.Generic;
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
    /// Логика взаимодействия для Scene2.xaml
    /// </summary>
    public partial class Scene2 : UserControl
    {
        public Scene2()
        {
            InitializeComponent();
        }
        private void MyRootDragDelta(object sender, DragDeltaEventArgs e)
        {
            translateTransform.X += e.HorizontalChange;
            translateTransform.Y += e.VerticalChange;
        }
        /* Point anchorPoint;
         Point currentPoint;
         bool isInDrag = false;
         private TranslateTransform transform = new TranslateTransform();

         private void root_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
         {
             var element = sender as FrameworkElement;
             anchorPoint = e.GetPosition(null);
             element.CaptureMouse();
             isInDrag = true;
             e.Handled = true;
         }

         private void root_MouseMove(object sender, MouseEventArgs e)
         {
             if (isInDrag)
             {
                 var element = sender as FrameworkElement;
                 currentPoint = e.GetPosition(null);

                 transform.X += currentPoint.X - anchorPoint.X;
                 transform.Y += (currentPoint.Y - anchorPoint.Y);
                 this.RenderTransform = transform;
                 anchorPoint = currentPoint;
             }
         }

         private void root_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
         {
             if (isInDrag)
             {
                 var element = sender as FrameworkElement;
                 element.ReleaseMouseCapture();
                 isInDrag = false;
                 e.Handled = true;
             }
         }
     }*/

    }
}
