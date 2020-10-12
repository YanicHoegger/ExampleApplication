using System;
using System.Threading.Tasks;
using WpfExampleApplication.PresentationFramework.Shell.FatalHandler;

namespace WpfExampleApplication.PresentationFramework.Command
{
	public class CommandTaskCompletion
	{
		private readonly IFatalHandler _fatalHandler;

		public CommandTaskCompletion(Task task, IFatalHandler fatalHandler)
		{
			_fatalHandler = fatalHandler;
			TaskCompletion = WatchTaskAsync(task);
		}

		private async Task WatchTaskAsync(Task task)
		{
			try
			{
				await task;
				IsCompleted = true;
			}
			catch (Exception e)
			{
				await _fatalHandler.HandleFatal(e);
			}
		}

		public bool IsCompleted { get; private set; }
		public Task TaskCompletion { get; }
	}
}
