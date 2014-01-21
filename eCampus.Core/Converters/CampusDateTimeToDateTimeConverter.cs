using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace eCampus.Core.Converters
{
	public sealed class CampusDateTimeToDateTimeConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo language)
		{
			var a = DateTime.ParseExact((string)value, "M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture);
			if (DateTime.Now.Date == a.Date)
			{
				var q = a.ToString("H:mm");
				return a.ToString("H:mm");
			}
			var q1 = a.ToString("dd/MM H:mm");
			return a.ToString("dd/MM H:mm");
		}

		public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo language)
		{
			throw new NotImplementedException();
		}
	}
}
