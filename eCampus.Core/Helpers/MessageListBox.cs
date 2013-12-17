using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace eCampus.Core.Helpers
{
	public class MessageListBox:ListBox
	{
		public void ScrollToBottom()
		{
			var scrollviewer = GetTemplateChild("ScrollViewer") as ScrollViewer;
			scrollviewer.ScrollToVerticalOffset(scrollviewer.ScrollableHeight);
		}
	}
}
