using System;
using System.Windows.Input;
using eCampus.Core.Helpers;

namespace eCampus.Core.ViewModels
{
	public delegate void MainEventHandler();
	public class MainViewModel
	{
		public event MainEventHandler CreateGroupEvent;
		public event MainEventHandler AboutOpenEvent;

		private ICommand _createGroupCommand;
		private ICommand _aboutOpenCommand;
		public MainViewModel()
		{
			this._createGroupCommand = new DelegateCommand(this.CreateGroupAction);
			this._aboutOpenCommand = new DelegateCommand(this.AboutOpenAction);
		}


		public ICommand AboutOpenCommand
		{
			get { return this._aboutOpenCommand; }
		}

		public ICommand CreateGroupCommand
		{
			get { return this._createGroupCommand; }
		}

		async private void CreateGroupAction(object obj)
		{
			if (CreateGroupEvent != null)
			{
				CreateGroupEvent();
			}
		}

		async private void AboutOpenAction(object obj)
		{
			if (AboutOpenEvent != null)
			{
				AboutOpenEvent();
			}
		}
	}
}
