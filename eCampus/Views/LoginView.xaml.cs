using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System;
using System.Windows;
using System.Windows.Navigation;

namespace eCampus.Views
{
    public partial class LoginView : PhoneApplicationPage
    {
        ProgressIndicator progressIndicator;

        public LoginView()
        {
            InitializeComponent();
            progressIndicator = new ProgressIndicator() { IsVisible = false, IsIndeterminate = true, Text = "Аутентифікація..." };
            SystemTray.SetProgressIndicator(this, progressIndicator);
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            this.DataContext = App.LoginVM;
            App.LoginVM.AuthenticationCompleted += () => 
            {
                NavigationService.Navigate(new Uri("/Views/MainView.xaml", UriKind.Relative));
                progressIndicator.IsVisible = false;
            };
            App.LoginVM.AuthenticationStarted += () => 
            {
                progressIndicator.IsVisible = true;
            };
            App.LoginVM.AuthenticationFailed += () =>
            {
                progressIndicator.IsVisible = false;
            };
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            App.LoginVM.Login = loginBox.Text;
            App.LoginVM.Password = passwordBox.Password;
        }
    }
}