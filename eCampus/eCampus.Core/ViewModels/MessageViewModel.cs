using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eCampus.Core;
using eCampus.Core.Models;
using eCampus.Core.Helpers;

namespace eCampus.Core.ViewModels
{
	public delegate void MyConversationsDownloadEventHandler();
	public class MessageViewModel : INotifyPropertyChanged
	{
		public event MyConversationsDownloadEventHandler MyConversationsDownloadStarted;
		public event MyConversationsDownloadEventHandler MyConversationsDownloadCompleted;
		public static event MyConversationsDownloadEventHandler MyConversationsDownloadFailed;
		public MessageViewModel()
		{
			try
			{
				if (MyConversationsDownloadStarted != null)
				{
					MyConversationsDownloadStarted();
				}
				Load();
				if (MyConversationsDownloadCompleted != null)
				{
					MyConversationsDownloadCompleted();
				}
			}
			catch (Exception)
			{
				if (MyConversationsDownloadFailed != null)
				{
					MyConversationsDownloadFailed();
				}
			}
		}

		async private void Load()
		{
			isLoaded = false;
			this.MyConversation = await CampusAPI.GetUserConversations();
			isLoaded = true;
		}

		public bool isLoaded { get; set; }

		public List<Conversation> Conversations
		{
			get
			{
				if (this.myConversation != null)
				{
					return this.myConversation.Data;
				}
				return null;
			}
			set
			{
				if (this.myConversation.Data != value)
				{
					this.myConversation.Data = value;
					this.RaisePropertyChanged("Conversations");
				}
			}
		}

		private UserConversations myConversation;
		public UserConversations MyConversation
		{
			get
			{
				return myConversation;
			}
			set
			{
				if (this.myConversation != value)
				{
					this.myConversation = value;
					this.RaisePropertyChanged("MyConversation");
					this.RaisePropertyChanged("Conversations");
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
