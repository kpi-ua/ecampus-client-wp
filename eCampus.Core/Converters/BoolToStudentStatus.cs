using System;
using System.Windows.Data;

namespace eCampus.Core.Converters
{
    public sealed class BoolToStudentStatus : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo language)
        {
            if ((bool)value)
            {
                return "Контракт";
            }

            return "Бюджет";
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo language)
        {
            return (string)value == "Контракт";
        }
    }
}
