using System;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfExampleApplication.PresentationFramework.Shell.FatalHandler;

namespace WpfExampleApplication.PresentationFramework.Command
{
	public class AsyncCommandFactory
	{
		private readonly IFatalHandler _fatalHandler;

		public AsyncCommandFactory(IFatalHandler fatalHandler)
		{
			_fatalHandler = fatalHandler;
		}

		public ICommand CreateAsyncCommand(Func<Task> command)
		{
			return new AsyncCommand(command, new AlwaysCanExecute(), _fatalHandler);
		}

		public ICommand CreateSyncCommand(Action command)
		{
			return new AsyncCommand(() => Task.Factory.StartNew(command), new AlwaysCanExecute(), _fatalHandler);
		}

		public ICommand CreateAsyncCommand(Func<Task> command, INotifyCanExecute notifyCanExecute)
		{
			return new AsyncCommand(command, notifyCanExecute, _fatalHandler);
		}

		public ICommand CreateSyncCommand(Action command, INotifyCanExecute notifyCanExecute)
		{
			return new AsyncCommand(() => new Task(command), notifyCanExecute, _fatalHandler);
		}
	}
}
