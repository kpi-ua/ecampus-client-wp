using System;
using System.Windows.Data;

namespace eCampus.Core.Converters
{
    public sealed class BoolToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo language)
        {
            if ((bool)value)
            {
                return "Дозволено";
            }

            return "Не дозволено";
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo language)
        {
            return (string)value == "Дозволено";
        }
    }

}
