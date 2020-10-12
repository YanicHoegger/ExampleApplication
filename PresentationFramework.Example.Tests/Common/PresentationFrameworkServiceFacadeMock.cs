using WpfExampleApplication.PresentationFramework;
using WpfExampleApplication.PresentationFramework.Command;
using WpfExampleApplication.PresentationFramework.Shell;
using WpfExampleApplication.PresentationFramework.Shell.Dialog;

namespace PresentationFramework.Example.Tests.Common
{
	public class PresentationFrameworkServiceFacadeMock : IPresentationFrameworkServiceFacade
	{
		public PresentationFrameworkServiceFacadeMock()
		{
			ShellServices = new ShellServicesMock();
			CommandFactory = new AsyncCommandFactory(ShellServices.FatalHandler);
			DialogFactory = new DialogFactory(CommandFactory);
		}

		public IShellServices ShellServices { get; set; }
		public AsyncCommandFactory CommandFactory { get; set; }
		public DialogFactory DialogFactory { get; set; }
	}
}
