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

        public static double GetImageOpacity(DependencyObject obj)
        {
            return (double)obj.GetValue(ImageOpacityProperty);
        }

        public static void SetImageOpacity(DependencyObject obj, double value)
        {
            obj.SetValue(ImageOpacityProperty, value);
        }

        public static readonly DependencyProperty ImageOpacityProperty =
            DependencyProperty.RegisterAttached("ImageOpacity", typeof(double), typeof(DayButtonProperties), new UIPropertyMetadata(default(double)));

        public static double GetTextOpacity(DependencyObject obj)
        {
            return (double)obj.GetValue(TextOpacityProperty);
        }

        public static void SetTextOpacity(DependencyObject obj, double value)
        {
            obj.SetValue(TextOpacityProperty, value);
        }

        public static readonly DependencyProperty TextOpacityProperty =
            DependencyProperty.RegisterAttached("TextOpacity", typeof(double), typeof(DayButtonProperties), new UIPropertyMetadata(default(double)));


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
