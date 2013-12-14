using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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
            else
            {
                return "Бюджет";
            }
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo language)
        {
            if ((string)value=="Контракт")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
