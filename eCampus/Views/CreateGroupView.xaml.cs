using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace eCampus.Views
{
	public partial class CreateGroupView : PhoneApplicationPage
	{
		public CreateGroupView()
		{
			InitializeComponent();
		}

		async private void RadTextBox_ActionButtonTap(object sender, EventArgs e)
		{
			if (searchbox.Text!=string.Empty)
			{
				var a = await eCampus.Core.Helpers.CampusClient.GetAllUser(searchbox.Text);
				peopleBox.ItemsSource = a.Data;
			}
		}
	}
}