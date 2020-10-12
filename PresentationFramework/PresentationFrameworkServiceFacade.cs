using WpfExampleApplication.PresentationFramework.Command;
using WpfExampleApplication.PresentationFramework.Shell;
using WpfExampleApplication.PresentationFramework.Shell.Dialog;

namespace WpfExampleApplication.PresentationFramework
{
	public class PresentationFrameworkServiceFacade : IPresentationFrameworkServiceFacade
	{
		public PresentationFrameworkServiceFacade()
		{
			ShellServicesImplementation = new ShellServices();
			CommandFactory = new AsyncCommandFactory(ShellServices.FatalHandler);
			DialogFactory = new DialogFactory(CommandFactory);
		}

		public IShellServices ShellServices => ShellServicesImplementation;
		public ShellServices ShellServicesImplementation { get; }

		public AsyncCommandFactory CommandFactory { get; }

		public DialogFactory DialogFactory { get; }
	}
}
