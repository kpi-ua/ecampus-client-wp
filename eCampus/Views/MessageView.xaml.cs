﻿using Coding4Fun.Toolkit.Controls;
using eCampus.Core.Helpers;
using eCampus.Core.Models;
using eCampus.Core.ViewModels;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Navigation;
using System.Globalization;

namespace eCampus.Views
{
	public partial class MessageView : PhoneApplicationPage
	{
        private MessagePageViewModel _mvm;

		public MessageView()
		{
			InitializeComponent();
		}

		async protected override void OnNavigatedTo(NavigationEventArgs e)
		{
			base.OnNavigatedTo(e);
			var groupid = NavigationContext.QueryString["groupid"];
            if (!App.MessagePageVM.ContainsConversation(groupid.ToString()))
			{
                _mvm = new MessagePageViewModel(groupid.ToString());
                await _mvm.LoadConversation(groupid.ToString());
                App.MessagePageVM.Add(_mvm);
			}
			else
			{
                _mvm = (from a in App.MessagePageVM
					   where a.GroupID == groupid
					   select a).SingleOrDefault();
			}
            this.DataContext = _mvm.Conversation;
			
			Dispatcher.BeginInvoke(() =>
			{
				listBox1.ScrollToBottom();
				listBox1.UpdateLayout();
			});
		}

		private void ChatBubbleTextBox_TextChanged(object sender, TextChangedEventArgs e)
		{
            if (((ChatBubbleTextBox)sender).Text != "")
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
            _mvm.AddMessageToDialog(new Message() { DateSent = DateTime.Now.ToString("G", new CultureInfo("en-US")), SenderUserAccountId = Convert.ToInt32(CampusClient.UserID), MassageGroupId = Convert.ToInt32(NavigationContext.QueryString["groupid"]), Text = messageField.Text });
			await CampusClient.SendMessage(NavigationContext.QueryString["groupid"], messageField.Text);
			messageField.Text = string.Empty;
			Dispatcher.BeginInvoke(() =>
			{
				listBox1.ScrollToBottom();
				listBox1.UpdateLayout();
				listBox1.ScrollToBottom();
				listBox1.UpdateLayout();
			});
		}
	}
}