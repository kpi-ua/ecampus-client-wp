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
	public partial class BulletinView : PhoneApplicationPage
	{
		public BulletinView()
		{
			InitializeComponent();
		}
		protected override void OnNavigatedTo(NavigationEventArgs e)
		{
			this.subject.Text = NavigationContext.QueryString["subject"];
			this.text.Text = NavigationContext.QueryString["text"];
			this.creator.Text = NavigationContext.QueryString["creator"];
			this.date.Text = NavigationContext.QueryString["date"];

		}
	}
}