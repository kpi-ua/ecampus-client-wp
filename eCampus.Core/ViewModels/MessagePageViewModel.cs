using eCampus.Core.Models;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace eCampus.Core.ViewModels
{
	public class MessagePageViewModel : INotifyPropertyChanged
	{
		#region MyRegion
		//public event PropertyChangedEventHandler PropertyChanged;

		//private UserDialog _conversation;
		//private string _groupID;

		//public MessagePageViewModel(string groupId)
		//{
		//	this.GroupID = groupId;
		//}

		//async public Task LoadConversation(string groupId)
		//{
		//	this.Conversation = await eCampus.Core.Helpers.CampusClient.GetConversation(groupId);
		//}

		//public string GroupID
		//{
		//	get
		//	{
		//		return _groupID;
		//	}
		//	set
		//	{
		//		if (this._groupID != value)
		//		{
		//			this._groupID = value;
		//			this.RaisePropertyChanged("GroupID");
		//		}
		//	}
		//}

		//public UserDialog Conversation
		//{
		//	get
		//	{
		//		return _conversation;
		//	}
		//	set
		//	{
		//		if (this._conversation != value)
		//		{
		//			this._conversation = value;
		//			this.RaisePropertyChanged("Conversations");
		//		}
		//	}
		//}

		//public ObservableCollection<Message> Data
		//{
		//	get
		//	{
		//		return Conversation.Data;
		//	}
		//	set
		//	{
		//		if (this.Conversation.Data != value)
		//		{
		//			this.Conversation.Data = value;
		//			this.RaisePropertyChanged("Data");
		//		}
		//	}
		//}

		//public void AddMessageToDialog(Message message)
		//{
		//	this.Data.Add(message);
		//	this.RaisePropertyChanged("Conversations");
		//	this.RaisePropertyChanged("Data");
		//}

		//private void RaisePropertyChanged(string propertyName)
		//{
		//	PropertyChangedEventHandler handler = this.PropertyChanged;

		//	if (handler != null)
		//	{
		//		handler(this, new PropertyChangedEventArgs(propertyName));
		//	}
		//} 
		#endregion
		private string _groupID;
		private UserDialog _conversation;

		public MessagePageViewModel(string groupId)
		{
			this.GroupID = groupId;
		}

		public string GroupID
		{
			get
			{
				return _groupID;
			}
			set
			{
				if (this._groupID != value)
				{
					this._groupID = value;
					this.RaisePropertyChanged("GroupID");
				}
			}
		}

		public UserDialog Conversation
		{
			get
			{
				return _conversation;
			}
			set
			{
				if (this._conversation != value)
				{
					this._conversation = value;
					this.RaisePropertyChanged("Conversations");
				}
			}
		}

		public ObservableCollection<Message> Data
		{
			get
			{
				return Conversation.Data;
			}
			set
			{
				if (this.Conversation.Data != value)
				{
					this.Conversation.Data = value;
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

		async public Task LoadConversation()
		{
			this.Conversation = await eCampus.Core.Helpers.CampusClient.GetConversation(GroupID);
			foreach (var item in this.Conversation.Data)
			{
				if (item.SenderUserAccountId==eCampus.Core.Helpers.CampusClient.UserID)
				{
					item.Type = Telerik.Windows.Controls.ConversationViewMessageType.Outgoing;
				}
				else
				{
					item.Type = Telerik.Windows.Controls.ConversationViewMessageType.Incoming;
				}
			}

		}
	}
}
