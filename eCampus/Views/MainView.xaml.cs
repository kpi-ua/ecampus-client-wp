using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Windows;

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