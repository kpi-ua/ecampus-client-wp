using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.Windows.Controls;


namespace eCampus.Core.Models
{
	public class Message : INotifyPropertyChanged
	{
		private ConversationViewMessageType type;
		public ConversationViewMessageType Type
		{
			get
			{
				return type;
			}
			set
			{
				if (this.type != value)
				{
					this.type = value;
					this.RaisePropertyChanged("Type");
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

		private string massageGroupId;
		public string MassageGroupId
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
		private string senderUserAccountId;
		public string SenderUserAccountId
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

		private string senderUserAccountPhoto;
		public string SenderUserAccountPhoto
		{
			get
			{
				return senderUserAccountPhoto;
			}
			set
			{
				if (this.senderUserAccountPhoto != value)
				{
					this.senderUserAccountPhoto = value;
					this.RaisePropertyChanged("SenderUserAccountPhoto");
				}
			}
		}

		private string senderUserAccountFullName;
		public string SenderUserAccountFullName
		{
			get
			{
				return senderUserAccountFullName;
			}
			set
			{
				if (this.senderUserAccountFullName != value)
				{
					this.senderUserAccountFullName = value;
					this.RaisePropertyChanged("SenderUserAccountFullName");
				}
			}
		}

		private string messageId;
		public string MessageId
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

	public class UserDialog : INotifyPropertyChanged
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
			Message temp;

			for (int i = 0; i < oc.Count - 1; i++)
			{
				for (int j = 0; j < oc.Count - i - 1; j++)
				{
					//DateTime.ParseExact((string)value, "MM/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture);
					//if (oc[j].DateSent > oc[j + 1])
					if (DateTime.ParseExact((string)oc[j].DateSent, "M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture) > DateTime.ParseExact((string)oc[j + 1].DateSent, "M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture))
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
