using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace Theater
{
    class DayButtonProperties
    {
        public static ImageSource GetImage(DependencyObject obj)
        {
            return (ImageSource)obj.GetValue(ImageProperty);
        }

        public static void SetImage(DependencyObject obj, ImageSource value)
        {
            obj.SetValue(ImageProperty, value);
        }

        public static readonly DependencyProperty ImageProperty =
            DependencyProperty.RegisterAttached("Image", typeof(ImageSource), typeof(DayButtonProperties), new UIPropertyMetadata((ImageSource)null));

        public static int GetOpacity(DependencyObject obj)
        {
            return (int)obj.GetValue(OpacityProperty);
        }

        public static void SetOpacity(DependencyObject obj, int value)
        {
            obj.SetValue(ImageProperty, value);
        }

        public static readonly DependencyProperty OpacityProperty =
            DependencyProperty.RegisterAttached("Opacity", typeof(int), typeof(DayButtonProperties), new UIPropertyMetadata(0));


        public static string GetDay(DependencyObject obj)
        {
            return (string)obj.GetValue(DayProperty);
        }

        public static void SetDay(DependencyObject obj, string value)
        {
            obj.SetValue(DayProperty, value);
        }

        public static readonly DependencyProperty DayProperty =
            DependencyProperty.RegisterAttached("Day", typeof(string), typeof(DayButtonProperties), new UIPropertyMetadata((string)null));


        public static string GetTime(DependencyObject obj)
        {
            return (string)obj.GetValue(TimeProperty);
        }

        public static void SetTime(DependencyObject obj, string value)
        {
            obj.SetValue(TimeProperty, value);
        }

        public static readonly DependencyProperty TimeProperty =
            DependencyProperty.RegisterAttached("Time", typeof(string), typeof(DayButtonProperties), new UIPropertyMetadata((string)null));
    }
}
