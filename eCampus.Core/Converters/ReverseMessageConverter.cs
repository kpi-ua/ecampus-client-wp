using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using eCampus.Core.Models;

namespace eCampus.Core.Converters
{
	public sealed class ReverseMessageConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo language)
		{
			return ((ObservableCollection<Message>)value).Reverse();
		}

		public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo language)
		{
			return new NotImplementedException();
		}
	}
}
