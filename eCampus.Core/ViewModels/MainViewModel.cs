using System;
using System.Windows.Input;
using eCampus.Core.Helpers;

namespace eCampus.Core.ViewModels
{
	public delegate void MainEventHandler();
    public class MainViewModel
	{
		public event MainEventHandler CreateGroupEvent;

		private ICommand _createGroupCommand;
		public MainViewModel()
		{
			this._createGroupCommand = new DelegateCommand(this.CreateGroupAction);
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
    }
}
