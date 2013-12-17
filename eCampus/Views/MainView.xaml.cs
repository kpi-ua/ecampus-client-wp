﻿using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Windows;
using System.Windows.Controls;
using eCampus.Core.Models;

namespace eCampus.Views
{
    public partial class MainView : PhoneApplicationPage
    {
        ProgressIndicator progressIndicator;

        public MainView()
        {
            InitializeComponent();
            progressIndicator = new ProgressIndicator() { IsVisible = false, IsIndeterminate = true, Text = "" };
			App.MyProfileVM.MyProfileDownloadStarted += () => 
			{ 
				progressIndicator.Text = "Завантаження профілю...";
				progressIndicator.IsVisible = true; 
			};
			App.MyProfileVM.MyProfileDownloadCompleted += () => 
			{
				progressIndicator.IsVisible = false; 
			};
			App.MessageVM.MyConversationsDownloadStarted += () =>
			{
				progressIndicator.Text = "Завантаження листувань...";
				progressIndicator.IsVisible = true;
			};
			App.MessageVM.MyConversationsDownloadCompleted += () =>
			{
				progressIndicator.IsVisible = false;
			};
            SystemTray.SetProgressIndicator(this, progressIndicator);
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
			myProfilePivotItem.DataContext = App.MyProfileVM;
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

    }
}