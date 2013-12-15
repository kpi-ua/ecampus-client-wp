using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using eCampus.Core.Models;

namespace eCampus.Core.Converters
{
	public sealed class ConversationPhotoWidthConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo language)
		{
			switch (System.Convert.ToInt32(parameter))
			{
				case 1:
					return "*";
				case 2:
					if (((List<User>)value).Count>=3)
						return "*";
					return "Auto";
				case 3:
					if (((List<User>)value).Count>=4)
						return "*";
					return "Auto";
				default:
					return "Auto";
			}
		}

		public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo language)
		{
			return new object();
		}
	}

}
