using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System;
using System.Windows;
using System.Windows.Navigation;
using eCampus.Core.Helpers;
using System.Windows.Controls;

namespace eCampus.Views
{
	public partial class LoginView : PhoneApplicationPage
	{
		private readonly ProgressIndicator _progressIndicator;

		public LoginView()
		{
			InitializeComponent();
			_progressIndicator = new ProgressIndicator() { IsVisible = false, IsIndeterminate = true, Text = "Аутентифікація..." };
			SystemTray.SetProgressIndicator(this, _progressIndicator);
			loginBox.Text = IsolatedStorageHelpers.OpenStringFromStore("login");
			passwordBox.Password = IsolatedStorageHelpers.OpenStringFromStore("password");
			checkBox.IsChecked = IsolatedStorageHelpers.OpenBooleanFromStore("cheked");
		}

		protected override void OnNavigatedTo(NavigationEventArgs e)
		{
			string a;
			NavigationContext.QueryString.TryGetValue("islogout", out a);
			if (a == "true")
			{
				while (NavigationService.CanGoBack)
				{
					NavigationService.RemoveBackEntry();
				}
			}
		}

		private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
		{
			this.DataContext = App.LoginVM;

			App.LoginVM.AuthenticationCompleted += () =>
			{
				NavigationService.Navigate(new Uri("/Views/MainView.xaml", UriKind.Relative));
				_progressIndicator.IsVisible = false;
			};

			App.LoginVM.AuthenticationStarted += () =>
			{
				_progressIndicator.IsVisible = true;
			};

			App.LoginVM.AuthenticationFailed += () =>
			{
				_progressIndicator.IsVisible = false;
			};

			if (IsolatedStorageHelpers.OpenBooleanFromStore("cheked"))
			{
				button.IsEnabled = false;
				Button_Click(button, new RoutedEventArgs());
				App.LoginVM.LoginAction(new object());
			}
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			App.LoginVM.Login = loginBox.Text;
			App.LoginVM.Password = passwordBox.Password;
		}

		private void Cheked(object sender, RoutedEventArgs e)
		{
			IsolatedStorageHelpers.SaveToStore<bool>((bool)((CheckBox)sender).IsChecked, "cheked");
		}
	}
}