using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Windows;
using System.Windows.Controls;
using eCampus.Core.Models;
using System.Collections.Generic;
using System;
using eCampus.Core.ViewModels;
using eCampus.Core.Helpers;

namespace eCampus.Views
{
	public partial class MainView : PhoneApplicationPage
	{
		private readonly ProgressIndicator _progressIndicator;

		public MainView()
		{
			InitializeComponent();
			_progressIndicator = new ProgressIndicator() { IsVisible = false, IsIndeterminate = true, Text = "" };
			App.MyProfileVM.MyProfileDownloadStarted += () =>
			{
				_progressIndicator.Text = "Завантаження профілю...";
				_progressIndicator.IsVisible = true;
			};
			App.MyProfileVM.MyProfileDownloadCompleted += async () =>
			{
				_progressIndicator.IsVisible = false;
				var x = await App.MyProfileVM.DeviceRegistration(App.CurrentChannel.ChannelUri.ToString());
			};
			App.MessageVM.MyConversationsDownloadStarted += () =>
			{
				_progressIndicator.Text = "Завантаження листувань...";
				_progressIndicator.IsVisible = true;
			};
			App.MessageVM.MyConversationsDownloadCompleted += () =>
			{
				_progressIndicator.IsVisible = false;
			};

			App.MainVM.CreateGroupEvent += () =>
				{
					NavigationService.Navigate(new Uri("/Views/CreateGroupView.xaml", UriKind.Relative));
				};
			App.MainVM.AboutOpenEvent += () =>
				{
					Coding4Fun.Toolkit.Controls.AboutPrompt a = new Coding4Fun.Toolkit.Controls.AboutPrompt();
					a.Title = "eCampus v0.7";
					a.Body = "Версія CampusAPI - 1.8\n\nРозробник - Великоіваненко Вадим";
					a.VersionNumber = "0.7";
					a.Show();
					
				};
			
			SystemTray.SetProgressIndicator(this, _progressIndicator);
		}

		private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
		{
			this.DataContext = App.MainVM;
			myProfilePivotItem.DataContext = App.MyProfileVM;
			App.MyProfileVM.Load();
			profilePanel.Visibility = System.Windows.Visibility.Visible;
		}

		private void Pivot_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if (((Pivot)sender).SelectedIndex == 0)
			{

			}
			else if (((Pivot)sender).SelectedIndex == 1)
			{
				this.messagePivotItem.DataContext = App.MessageVM;
			}
			else if (((Pivot)sender).SelectedIndex == 2)
			{
				this.bulletinBoardTab.DataContext = App.BulletinBoardVM;
			}
			else if (((Pivot)sender).SelectedIndex == 3)
			{

			}
		}

		private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			var groupId = ((Conversation)(((ListBox)sender).SelectedItem)).GroupId;
			messageList.SelectionChanged -= ListBox_SelectionChanged;
			messageList.SelectedIndex = -1;
			messageList.SelectionChanged += ListBox_SelectionChanged;
			NavigationService.Navigate(new System.Uri("/Views/MessageView.xaml?groupid=" + groupId, System.UriKind.Relative));
		}

		/// <summary>
		/// TEST
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		async private void Logout_click(object sender, RoutedEventArgs e)
		{
			
			Microsoft.WindowsAzure.MobileServices.MobileServiceClient m = new Microsoft.WindowsAzure.MobileServices.MobileServiceClient(new Uri("http://campuspush.azure-mobile.net"), "bSVUJHyveDCRNafFTRXbzuJnQRcntQ23");
			Dictionary<string, string> d = new Dictionary<string, string>();
			d.Add("userid", App.MyProfileVM.UserId.ToString());
			d.Add("channel", App.CurrentChannel.ChannelUri.ToString());
			var x = await m.InvokeApiAsync<object>("logout", System.Net.Http.HttpMethod.Post, d);

			IsolatedStorageHelpers.SaveToStore<bool>(false, "cheked");
			var a = IsolatedStorageHelpers.OpenBooleanFromStore("cheked");
			IsolatedStorageHelpers.SaveToStore<string>("", "login");
			IsolatedStorageHelpers.SaveToStore<string>("", "password");
			NavigationService.Navigate(new Uri("/Views/LoginView.xaml?islogout=true", UriKind.Relative));
		}

		private void ListBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
		{
			var bul = ((Bulletin)(((ListBox)sender).SelectedItem));
			bulletinList.SelectionChanged -= ListBox_SelectionChanged_1;
			bulletinList.SelectedIndex = -1;
			bulletinList.SelectionChanged += ListBox_SelectionChanged_1;
			NavigationService.Navigate(new System.Uri("/Views/BulletinView.xaml?text=" + bul.Text + "&subject=" + bul.Subject + "&creator=" + bul.CreatorUserFullName + "&date=" + bul.DateCreate, System.UriKind.Relative));
		}

	}
}