using System;
using System.Windows.Input;

namespace WpfExampleApplication.PresentationFramework.Command
{
	public class AlwaysExecutableRelayCommand : ICommand
	{
		private readonly Action _executeAction;

		public AlwaysExecutableRelayCommand(Action executeAction)
		{
			_executeAction = executeAction;
		}

		public bool CanExecute(object parameter)
		{
			return true;
		}

		public void Execute(object parameter)
		{
			_executeAction();
		}

		public event EventHandler CanExecuteChanged { add { } remove { } }
	}
}
