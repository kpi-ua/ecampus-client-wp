using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using eCampus.Core.Helpers;
using eCampus.Core.ViewModels;
using Coding4Fun.Toolkit.Controls;
using eCampus.Core.Models;

namespace eCampus.Views
{
	public partial class MessageView : PhoneApplicationPage
	{
		MessagePageViewModel mvm;
		public MessageView()
		{
			InitializeComponent();
		}

		async protected override void OnNavigatedTo(NavigationEventArgs e)
		{
			base.OnNavigatedTo(e);
			var groupid = NavigationContext.QueryString["groupid"];
			if(!App.MessagePageVM.ContainsConversation(groupid.ToString()))
			{
				mvm = new MessagePageViewModel(groupid.ToString());
				await mvm.LoadConversation(groupid.ToString());
				App.MessagePageVM.Add(mvm);
			}
			else
			{
				mvm = (from a in App.MessagePageVM
					   where a.GroupID == groupid
					   select a).SingleOrDefault();
			}
			this.DataContext = mvm.Conversation;
			
			Dispatcher.BeginInvoke(() =>
			{
				listBox1.ScrollToBottom();
				listBox1.UpdateLayout();
			});
		}

		private void ChatBubbleTextBox_TextChanged(object sender, TextChangedEventArgs e)
		{
			if (((ChatBubbleTextBox)sender).Text!="")
			{
				((ApplicationBarIconButton)ApplicationBar.Buttons[0]).IsEnabled = true;
			}
			else
			{
				((ApplicationBarIconButton)ApplicationBar.Buttons[0]).IsEnabled = false;
			}
		}

		

		private void ChatBubbleTextBox_Tap(object sender, System.Windows.Input.GestureEventArgs e)
		{
			Dispatcher.BeginInvoke(() =>
			{
				listBox1.ScrollToBottom();
				listBox1.UpdateLayout();
			});
		}

		async private void ApplicationBarIconButton_Click(object sender, EventArgs e)
		{
			mvm.AddMessageToDialog(new Message() { DateSent = DateTime.Now.ToString(), SenderUserAccountId = Convert.ToInt32(CampusClient.UserID), MassageGroupId = Convert.ToInt32(NavigationContext.QueryString["groupid"]), Text = messageField.Text });
			await CampusClient.SendMessage(NavigationContext.QueryString["groupid"], messageField.Text);
			messageField.Text = string.Empty;
			Dispatcher.BeginInvoke(() =>
			{
				listBox1.ScrollToBottom();
				listBox1.UpdateLayout();
			});
			
		}



	}
}