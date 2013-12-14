using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace eCampus.Core.Models
{
	public class UserConversations
	{
		public int StatusCode { get; set; }
		public string TimeStamp { get; set; }
		public List<Conversation> Data { get; set; }
	}
	public class User
	{
		public int UserAccountId { get; set; }
		public string Photo { get; set; }
		public string FullName { get; set; }
	}

	public class Conversation
	{
		public string Subject { get; set; }
		public List<User> Users { get; set; }
		public string LastMessageText { get; set; }
		public string LastMessageDate { get; set; }
		public int GroupId { get; set; }
	}

	
}
