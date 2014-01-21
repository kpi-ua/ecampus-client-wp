using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCampus.Core.Models
{

	public class UserProfile : INotifyPropertyChanged
	{
		private string userAccountId;
		public string UserAccountId
		{
			get
			{
				return userAccountId;
			}
			set
			{
				if (this.userAccountId != value)
				{
					this.userAccountId = value;
					this.RaisePropertyChanged("UserAccountId");
				}
			}
		}

		private string photo;
		public string Photo
		{
			get
			{
				return photo;
			}
			set
			{
				if (this.photo != value)
				{
					this.photo = value;
					this.RaisePropertyChanged("Photo");
				}
			}
		}


		private string fullName;
		public string FullName
		{
			get
			{
				return fullName;
			}
			set
			{
				if (this.fullName != value)
				{
					this.fullName = value;
					this.RaisePropertyChanged("FullName");
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
	public class Users : INotifyPropertyChanged
	{
		private string statusCode;
		public string StatusCode
		{
			get
			{
				return statusCode;
			}
			set
			{
				if (this.statusCode != value)
				{
					this.statusCode = value;
					this.RaisePropertyChanged("StatusCode");
				}
			}
		}

		private ObservableCollection<UserProfile> data;
		public ObservableCollection<UserProfile> Data
		{
			get
			{
				return data;
			}
			set
			{
				if (this.data != value)
				{
					this.data = value;
					this.RaisePropertyChanged("Data");
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
