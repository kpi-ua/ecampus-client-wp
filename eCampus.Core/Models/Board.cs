using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCampus.Core.Models
{
	public class Bulletin
	{
		public string Text { get; set; }
		public string DateCreate { get; set; }
		public int CreatorUserAccountId { get; set; }
		public string CreatorUserFullName { get; set; }
		public int BulletinBoardSubjectId { get; set; }
		public int BulletinBoardId { get; set; }
		public object BulletinBoardLinkRecipients { get; set; }
		public string Subject { get; set; }
	}

	public class Board
	{
		public int StatusCode { get; set; }
		public List<Bulletin> Data { get; set; }
	}
}
