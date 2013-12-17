using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using eCampus.Core.Models;
using eCampus.Core.Helpers;
using System.Windows;
using Coding4Fun.Toolkit.Controls;

namespace eCampus.Core.Converters
{
	public sealed class MessageToHorizontalAlignment : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo language)
		{
			if (parameter.ToString() == "direction")
			{
				if (((eCampus.Core.Models.Message)value).SenderUserAccountId.ToString() == CampusClient.UserID)
					return ChatBubbleDirection.LowerRight;
				return ChatBubbleDirection.UpperLeft;
			}
			else
			{
				if (((eCampus.Core.Models.Message)value).SenderUserAccountId.ToString() == CampusClient.UserID)
					return HorizontalAlignment.Right;
				return HorizontalAlignment.Left;
			}
		}

		public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo language)
		{
			return new object();
		}
	}
}
