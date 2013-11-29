using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            else
            {
                return "Не дозволено";
            }
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo language)
        {
            if ((string)value == "Дозволено")
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
