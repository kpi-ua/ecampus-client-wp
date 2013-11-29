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
    public class MyProfileViewModel : INotifyPropertyChanged
    {
        async public static Task<MyProfileViewModel> BuildViewModelAsync()
        {
            MyProfile tmpData = new MyProfile();
            try
            {
                tmpData = await CampusAPI.GetCurrentUser();
            }
            catch (Exception)
            {
                
            }
            return new MyProfileViewModel(tmpData);
        }

        private MyProfileViewModel(MyProfile tmpData)
        {
            this.profile = tmpData;
        }


        

        public List<Profile> Profiles
        {
            get 
            {
                if (this.profile!=null)
                {
                    return this.profile.Data.Profiles; 
                }
                else
                {
                    return null;
                }
            }
        }


        public List<Employee> Employees 
        { 
            get
            {
                if (this.profile != null)
                {
                    return this.profile.Data.Employees;
                }
                else
                {
                    return null;
                }
            }
        }

        public int EmployeesPlaceCount
        {
            get
            {
                if (this.profile != null)
                {
                    return this.profile.Data.Employees.Count;
                }
                else
                {
                    return 0;
                }
            }
        }

        public List<Personality> Personalities
        {
            get
            {
                if (this.profile != null)
                {
                    return this.profile.Data.Personalities;
                }
                else
                {
                    return null;
                }
            }
        }

        public int PersonalitiesPlaceCount
        {
            get
            {
                if (this.profile != null)
                {
                    return this.profile.Data.Personalities.Count;
                }
                else
                {
                    return 0;
                }
            }
        }

        public string Image 
        { 
            get 
            {
                if (this.profile != null)
                {
                    return this.profile.Data.Photo;
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
                if (this.profile != null)
                {
                    return this.profile.Data.FullName;
                }
                else
                {
                    return "";
                }
            }
        }

        private MyProfile profile;
        public MyProfile Profile
        {
            get { return profile; }
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
