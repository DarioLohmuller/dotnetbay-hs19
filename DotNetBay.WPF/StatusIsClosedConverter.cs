using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace DotNetBay.WPF
{
    public class StatusIsClosedConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((bool)value)
            {
                return "Closed";
            }
            else
            {
                return "Running";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}