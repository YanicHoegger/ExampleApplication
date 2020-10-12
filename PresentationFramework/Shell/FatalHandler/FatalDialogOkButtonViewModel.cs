using System;
using System.Windows.Input;
using WpfExampleApplication.PresentationFramework.Command;
using WpfExampleApplication.PresentationFramework.Shell.Dialog;

namespace WpfExampleApplication.PresentationFramework.Shell.FatalHandler
{
	public class FatalDialogButtonViewModel : DialogButtonViewModelBase
	{
		public FatalDialogButtonViewModel(Action closeAppAction)
		{
			OkCommand = new AlwaysExecutableRelayCommand(closeAppAction);
		}

		public override ICommand OkCommand { get; }

		//Since the whole application gets closed, this event will not be needed
		public override event Action CloseRequested { add { } remove { } }
	}
}
