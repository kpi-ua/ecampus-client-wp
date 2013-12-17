using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eCampus.Core.Models;

namespace eCampus.Core.ViewModels
{
	public class MessagePageViewModel
	{
		private UserDialog conversation;
		private string groupID;
		public MessagePageViewModel(string groupId)
		{
			this.GroupID = groupId;
		}

		async public Task LoadConversation(string groupId)
		{
			this.Conversation = await eCampus.Core.Helpers.CampusClient.GetConversation(groupId);
		}

		public string GroupID
		{
			get
			{
				return groupID;
			}
			set
			{
				if (this.groupID != value)
				{
					this.groupID = value;
					this.RaisePropertyChanged("GroupID");
				}
			}
		}

		public UserDialog Conversation
		{
			get
			{
				return conversation;
			}
			set
			{
				if (this.conversation != value)
				{
					this.conversation = value;
					this.RaisePropertyChanged("Conversations");
				}
			}
		}

		public void AddMessageToDialog(Message message)
		{
			Conversation.Data.Add(message);
			this.RaisePropertyChanged("Conversations");
			this.RaisePropertyChanged("Data");
			this.RaisePropertyChanged("");
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
