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
using eCampus.Core.Models;
using Newtonsoft.Json;

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
				progressIndicator.Text = "Завантаження..."; 
				progressIndicator.IsVisible = true; 
			};
			App.MyProfileVM.MyProfileDownloadCompleted += () => 
			{
				progressIndicator.IsVisible = false; 
			};
            SystemTray.SetProgressIndicator(this, progressIndicator);
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
			myProfilePivotItem.DataContext = App.MyProfileVM;
			//App.MyProfileVM.Load();
            profilePanel.Visibility = System.Windows.Visibility.Visible;
        }
    }
}