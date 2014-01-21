using eCampus.Core.Helpers;
using eCampus.Core.Models;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using System;

namespace eCampus.Core.ViewModels
{
	public delegate void MyProfileDownloadEventHandler();
    public class MyProfileViewModel : INotifyPropertyChanged
	{
		public event MyProfileDownloadEventHandler MyProfileDownloadStarted;
		public event MyProfileDownloadEventHandler MyProfileDownloadCompleted;
		public event PropertyChangedEventHandler PropertyChanged;

        //public static event MyProfileDownloadEventHandler MyProfileDownloadFailed;
        
        private MyProfile _currentUser;

		public MyProfileViewModel()
		{
			//Load();
		}

		async public void Load()
		{
			if (MyProfileDownloadStarted!=null)
			{
				MyProfileDownloadStarted();
			}
			this.CurrentUser = await CampusClient.GetCurrentUser();
			if (MyProfileDownloadCompleted != null)
			{
				MyProfileDownloadCompleted();
			}

		}

		async public Task<object> DeviceRegistration(string channel)
		{
			Microsoft.WindowsAzure.MobileServices.MobileServiceClient m = new Microsoft.WindowsAzure.MobileServices.MobileServiceClient(new Uri("http://campuspush.azure-mobile.net"),"bSVUJHyveDCRNafFTRXbzuJnQRcntQ23");
			Dictionary<string, string> d = new Dictionary<string, string>();
			d.Add("operatingSystem", "windowsphone");
			d.Add("userid", this.UserId.ToString());
			string[] names = this.FullName.Split(' ');
			d.Add("firstname", names[0]);
			d.Add("lastname", names[1]);
			d.Add("channel", channel);
			var x = await m.InvokeApiAsync("deviceregistration", System.Net.Http.HttpMethod.Post, d);
			return x;
		}

        public List<Profile> Profiles
        {
            get 
            {
                if (this._currentUser!=null)
                {
                    return this._currentUser.Data.Profiles; 
                }

				return null;
            }
        }

        public List<Employee> Employees 
        { 
            get
            {
                if (this._currentUser != null)
                {
                    return this._currentUser.Data.Employees;
                }
				return null;
            }
        }
		public int UserId
		{
			get
			{
				if (this._currentUser != null)
				{
					return this._currentUser.Data.UserAccountId;
				}
				return 0;
			}
		}

        public int EmployeesPlaceCount
        {
            get
            {
                if (this._currentUser != null)
                {
                    return this._currentUser.Data.Employees.Count;
				} 
				return 0;
            }
        }

        public List<Personality> Personalities
        {
            get
            {
                if (this._currentUser != null)
                {
                    return this._currentUser.Data.Personalities;
                }
				return null;
            }
        }

        public int PersonalitiesPlaceCount
        {
            get
            {
                if (this._currentUser != null)
                {
                    return this._currentUser.Data.Personalities.Count;
                }
				return 0;
            }
        }

        public string Image 
        { 
            get 
            {
                if (this._currentUser != null)
                {
                    return this._currentUser.Data.Photo;
                }
                else
                {
                    return "";
                }
            }
        }

		public string FullName
		{
			get
			{
				if (this._currentUser != null)
				{
					return this.CurrentUser.Data.FullName;
				}
				return string.Empty;
			}
		}
        
		public MyProfile CurrentUser
		{
			get
			{
				return _currentUser;
			}
			set
			{
				if (this._currentUser != value)
				{
					this._currentUser = value;
					this.RaisePropertyChanged("CurrentUser");
					this.RaisePropertyChanged("FullName");
					this.RaisePropertyChanged("Image");
					this.RaisePropertyChanged("PersonalitiesPlaceCount");
					this.RaisePropertyChanged("Personalities");
					this.RaisePropertyChanged("EmployeesPlaceCount");
					this.RaisePropertyChanged("Employees");
					this.RaisePropertyChanged("Profiles");
				}
			}
		}

        private void RaisePropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
