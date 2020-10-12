using System;
using System.Threading.Tasks;
using WpfExampleApplication.PresentationFramework.Shell.FatalHandler;

namespace WpfExampleApplication.PresentationFramework.Tests.Commons
{
	public class FatalHandlerMock : IFatalHandler
	{
		public Task HandleFatal(Exception ex)
		{
			HandleFatalAction(ex);
			return Task.CompletedTask;
		}

		public Action<Exception> HandleFatalAction { get; set; } = exception => throw exception;
	}
}
