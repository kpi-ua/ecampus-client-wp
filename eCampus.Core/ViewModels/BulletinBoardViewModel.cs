using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eCampus.Core.Helpers;
using eCampus.Core.Models;

namespace eCampus.Core.ViewModels
{
	public class BulletinBoardViewModel:INotifyPropertyChanged
	{
		public BulletinBoardViewModel()
		{
			Load();
		}

		async private void Load()
		{
			this.MyBoard = await CampusClient.GetActualBB();
		}

		private Board myBoard;
		public Board MyBoard
		{
			get
			{
				return myBoard;
			}
			set
			{
				if (this.myBoard != value)
				{
					this.myBoard = value;
					this.RaisePropertyChanged("MyBoard");
					this.RaisePropertyChanged("Bulletins");
				}
			}
		}

		public List<Bulletin> Bulletins
		{
			get
			{
				if (this.myBoard != null)
				{
					return this.myBoard.Data;
				}
				return null;
			}
			set
			{
				if (this.myBoard.Data != value)
				{
					this.myBoard.Data = value;
					this.RaisePropertyChanged("Bulletins");
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
