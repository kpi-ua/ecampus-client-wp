using eCampus.Core.Helpers;
using eCampus.Core.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCampus.Core.ViewModels
{
	public delegate void MyProfileDownloadEventHandler();
    public class MyProfileViewModel : INotifyPropertyChanged
	{
		public event MyProfileDownloadEventHandler MyProfileDownloadStarted;
		public event MyProfileDownloadEventHandler MyProfileDownloadCompleted;
		public static event MyProfileDownloadEventHandler MyProfileDownloadFailed;

		public MyProfileViewModel()
		{
			Load();
		}

		async public void Load()
		{
			if (MyProfileDownloadStarted!=null)
			{
				MyProfileDownloadStarted();
			}
			this.CurrentUser = await CampusAPI.GetCurrentUser();
			if (MyProfileDownloadCompleted != null)
			{
				MyProfileDownloadCompleted();
			}
		}

        public List<Profile> Profiles
        {
            get 
            {
                if (this.currentUser!=null)
                {
                    return this.currentUser.Data.Profiles; 
                }
				return null;
            }
        }


        public List<Employee> Employees 
        { 
            get
            {
                if (this.currentUser != null)
                {
                    return this.currentUser.Data.Employees;
                }
				return null;
            }
        }

        public int EmployeesPlaceCount
        {
            get
            {
                if (this.currentUser != null)
                {
                    return this.currentUser.Data.Employees.Count;
				} 
				return 0;
            }
        }

        public List<Personality> Personalities
        {
            get
            {
                if (this.currentUser != null)
                {
                    return this.currentUser.Data.Personalities;
                }
				return null;
            }
        }

        public int PersonalitiesPlaceCount
        {
            get
            {
                if (this.currentUser != null)
                {
                    return this.currentUser.Data.Personalities.Count;
                }
				return 0;
            }
        }

        public string Image 
        { 
            get 
            {
                if (this.currentUser != null)
                {
                    return this.currentUser.Data.Photo;
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
				if (this.currentUser != null)
				{
					return this.CurrentUser.Data.FullName;
				}
				return string.Empty;
			}
		}

		private MyProfile currentUser;
		public MyProfile CurrentUser
		{
			get
			{
				return currentUser;
			}
			set
			{
				if (this.currentUser != value)
				{
					this.currentUser = value;
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


        public event PropertyChangedEventHandler PropertyChanged;
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
