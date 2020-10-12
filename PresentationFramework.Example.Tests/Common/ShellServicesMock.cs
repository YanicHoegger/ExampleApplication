using Moq;
using WpfExampleApplication.PresentationFramework.Shell;
using WpfExampleApplication.PresentationFramework.Shell.Dialog;
using WpfExampleApplication.PresentationFramework.Shell.FatalHandler;
using WpfExampleApplication.PresentationFramework.Shell.WaitScreen;
using WpfExampleApplication.PresentationFramework.Tests.Commons;

namespace PresentationFramework.Example.Tests.Common
{
	public class ShellServicesMock : IShellServices
	{
		public ShellServicesMock()
		{
			WaitScreenShower = new Mock<IWaitScreenShower>().Object;
		}

		public IDialogPresenter DialogPresenter { get; set; } = new DialogPresenterMock();
		public IWaitScreenShower WaitScreenShower { get; set; }
		public IFatalHandler FatalHandler { get; set; } = new FatalHandlerMock();
	}
}
