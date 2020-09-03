using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace Associate.Services.Converters
{
    class StringToTimeSpanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string valueString = value.ToString();
            TimeSpan timeSpanToReturn = TimeSpan.Parse(valueString
                );
            return timeSpanToReturn;
        }
    }
}
