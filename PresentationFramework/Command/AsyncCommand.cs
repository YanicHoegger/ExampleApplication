using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using WpfExampleApplication.PresentationFramework.Properties;
using WpfExampleApplication.PresentationFramework.Shell.FatalHandler;

namespace WpfExampleApplication.PresentationFramework.Command
{
	public class AsyncCommand : AsyncCommandBase, INotifyPropertyChanged, IDisposable
	{
		private readonly Func<Task> _command;
		private readonly INotifyCanExecute _caneExecute;
		private readonly IFatalHandler _fatalHandler;
		private CommandTaskCompletion _execution;

		public AsyncCommand(Func<Task> command, INotifyCanExecute caneExecute, IFatalHandler fatalHandler)
		{
			_command = command;
			_caneExecute = caneExecute;
			_fatalHandler = fatalHandler;

			_caneExecute.PropertyChanged += CaneExecuteOnPropertyChanged;
		}

		public override bool CanExecute(object parameter)
		{
			return (Execution == null || Execution.IsCompleted) && _caneExecute.CanExecute;
		}

		public override async Task ExecuteAsync(object parameter)
		{
			Execution = new CommandTaskCompletion(_command(), _fatalHandler);
			RaiseCanExecuteChanged();
			await Execution.TaskCompletion;
			RaiseCanExecuteChanged();
		}

		public CommandTaskCompletion Execution
		{
			get => _execution;
			private set
			{
				_execution = value;
				OnPropertyChanged();
			}
		}

		public void Dispose()
		{
			_caneExecute.PropertyChanged -= CaneExecuteOnPropertyChanged;
		}

		public event PropertyChangedEventHandler PropertyChanged;

		[NotifyPropertyChangedInvocator]
		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

		private void CaneExecuteOnPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			OnPropertyChanged(nameof(CanExecute));
		}
	}
}