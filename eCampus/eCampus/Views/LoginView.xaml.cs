using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Windows.Media.Imaging;
using eCampus.Core.ViewModels;

namespace eCampus
{
    public partial class LoginView : PhoneApplicationPage
    {
        public LoginView()
        {
            InitializeComponent();
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            this.DataContext = App.LogimVM;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            App.LogimVM.Login = loginBox.Text;
            App.LogimVM.Password = passwordBox.Password;
        }
    }
}