using WpfExampleApplication.PresentationFramework.Command;
using WpfExampleApplication.PresentationFramework.Shell;
using WpfExampleApplication.PresentationFramework.Shell.Dialog;

namespace WpfExampleApplication.PresentationFramework
{
    public interface IPresentationFrameworkServiceFacade
    {
	    IShellServices ShellServices { get; }
	    AsyncCommandFactory CommandFactory { get; }
	    DialogFactory DialogFactory { get; }
    }
}
