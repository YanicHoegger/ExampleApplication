using WpfExampleApplication.PresentationFramework.Shell.Dialog;
using WpfExampleApplication.PresentationFramework.Shell.FatalHandler;
using WpfExampleApplication.PresentationFramework.Shell.WaitScreen;

namespace WpfExampleApplication.PresentationFramework.Shell
{
    public interface IShellServices
    {
	    IDialogPresenter DialogPresenter { get; }
	    IWaitScreenShower WaitScreenShower { get; }
	    IFatalHandler FatalHandler { get; }
    }
}
