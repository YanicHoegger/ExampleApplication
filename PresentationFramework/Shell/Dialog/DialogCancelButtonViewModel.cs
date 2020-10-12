using System.Windows.Input;
using WpfExampleApplication.PresentationFramework.Command;

namespace WpfExampleApplication.PresentationFramework.Shell.Dialog
{
	public class DialogCancelButtonViewModel : DialogButtonViewModel
	{
		public DialogCancelButtonViewModel(AsyncCommandFactory commandFactory) 
			: base(commandFactory)
		{
			CancelCommand = commandFactory.CreateSyncCommand(CancelPressed);
		}


		public ICommand CancelCommand { get; }
		
		public bool IsCancelPressed { get; private set; }

		private void CancelPressed()
		{
			IsCancelPressed = false;
			OnCloseRequested();
		}
	}
}
