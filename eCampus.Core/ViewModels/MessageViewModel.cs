using eCampus.Core.Helpers;
using eCampus.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace eCampus.Core.ViewModels
{
	public delegate void MyConversationsDownloadEventHandler();

	public class MessageViewModel : INotifyPropertyChanged
	{
        public static event MyConversationsDownloadEventHandler MyConversationsDownloadFailed;

		public event MyConversationsDownloadEventHandler MyConversationsDownloadStarted;
		public event MyConversationsDownloadEventHandler MyConversationsDownloadCompleted;
        public event PropertyChangedEventHandler PropertyChanged;

        private UserConversations myConversation;

        public bool isLoaded { get; set; }

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
			this.MyConversation = await CampusClient.GetUserConversations();
			isLoaded = true;
		}

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