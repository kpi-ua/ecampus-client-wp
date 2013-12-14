using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using eCampus.Core.Models;

namespace eCampus.Core.Converters
{
	 public sealed class UserListToConversationTitleConverter : IValueConverter
	 {
		 public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo language)
		 {
			 if (((List<User>)value).Count==2)
			 {
				 return ((List<User>)value)[1].FullName;
			 }
			 else
			 {
				 return "Співрозмовників: " + ((List<User>)value).Count;
			 }
		 }
		 public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo language)
		 {
			 return new object();
		 }
	 }
}
