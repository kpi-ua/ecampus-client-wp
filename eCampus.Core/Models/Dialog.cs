using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCampus.Core.Models
{
    public class Message : INotifyPropertyChanged
	{
        private int _senderUserAccountId;
        private int _messageId;
        private int _massageGroupId;
        private object _messageDetail;
        private string _dateSent;

		public int SenderUserAccountId
		{
			get
			{
                return _senderUserAccountId;
			}
			set
			{
                if (this._senderUserAccountId != value)
				{
                    this._senderUserAccountId = value;
					this.RaisePropertyChanged("SenderUserAccountId");
				}
			}
		}

		public int MessageId
		{
			get
			{
                return _messageId;
			}
			set
			{
                if (this._messageId != value)
				{
                    this._messageId = value;
					this.RaisePropertyChanged("MessageId");
				}
			}
		}

		public int MassageGroupId
		{
			get
			{
                return _massageGroupId;
			}
			set
			{
                if (this._massageGroupId != value)
				{
                    this._massageGroupId = value;
					this.RaisePropertyChanged("MassageGroupId");
				}
			}
		}
        
		public object MessageDetail
		{
			get
			{
                return _messageDetail;
			}
			set
			{
                if (this._messageDetail != value)
				{
                    this._messageDetail = value;
					this.RaisePropertyChanged("MessageDetail");
				}
			}
		}
        
		public string DateSent
		{
			get
			{
                return _dateSent;
			}
			set
			{
                if (this._dateSent != value)
				{
                    this._dateSent = value;
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

    public class UserDialog : INotifyPropertyChanged
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
