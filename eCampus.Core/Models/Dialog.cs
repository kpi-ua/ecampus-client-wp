using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCampus.Core.Models
{
	public class Message:INotifyPropertyChanged
	{
		private int senderUserAccountId;
		public int SenderUserAccountId
		{
			get
			{
				return senderUserAccountId;
			}
			set
			{
				if (this.senderUserAccountId != value)
				{
					this.senderUserAccountId = value;
					this.RaisePropertyChanged("SenderUserAccountId");
				}
			}
		}
		private int messageId;
		public int MessageId
		{
			get
			{
				return messageId;
			}
			set
			{
				if (this.messageId != value)
				{
					this.messageId = value;
					this.RaisePropertyChanged("MessageId");
				}
			}
		}
		private int massageGroupId;
		public int MassageGroupId
		{
			get
			{
				return massageGroupId;
			}
			set
			{
				if (this.massageGroupId != value)
				{
					this.massageGroupId = value;
					this.RaisePropertyChanged("MassageGroupId");
				}
			}
		}
		private object messageDetail;
		public object MessageDetail
		{
			get
			{
				return messageDetail;
			}
			set
			{
				if (this.messageDetail != value)
				{
					this.messageDetail = value;
					this.RaisePropertyChanged("MessageDetail");
				}
			}
		}
		private string dateSent;
		public string DateSent
		{
			get
			{
				return dateSent;
			}
			set
			{
				if (this.dateSent != value)
				{
					this.dateSent = value;
					this.RaisePropertyChanged("DateSent");
				}
			}
		}
		private string subject;
		public string Subject
		{
			get
			{
				return subject;
			}
			set
			{
				if (this.subject != value)
				{
					this.subject = value;
					this.RaisePropertyChanged("Subject");
				}
			}
		}
		private string text;
		public string Text
		{
			get
			{
				return text;
			}
			set
			{
				if (this.text != value)
				{
					this.text = value;
					this.RaisePropertyChanged("Text");
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

	public class UserDialog:INotifyPropertyChanged
	{
		private int statusCode;
		public int StatusCode
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
		private ObservableCollection<Message> data;
		public ObservableCollection<Message> Data
		{
			get
			{
				try
				{
				return Sort(data);

				}
				catch (Exception)
				{
					return data;
					
				}
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

		private ObservableCollection<Message> Sort(ObservableCollection<Message> oc)
		{
			for (int i = 0; i < oc.Count; i++)
			{
				
			}

			Message temp;

			for (int i = 0; i < oc.Count - 1; i++)
			{
				for (int j = 0; j < oc.Count - i - 1; j++)
				{
					//DateTime.ParseExact((string)value, "MM/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture);
					//if (oc[j].DateSent > oc[j + 1])
					if (DateTime.ParseExact((string)oc[j].DateSent, "MM/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture) > DateTime.ParseExact((string)oc[j + 1].DateSent, "MM/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture))
					{
						temp = oc[j];
						oc[j] = oc[j + 1];
						oc[j + 1] = temp;
					}
				}
			}
			return oc;
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
