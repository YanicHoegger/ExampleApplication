using System;
using System.Windows.Input;
using WpfExampleApplication.PresentationFramework.Command;

namespace WpfExampleApplication.PresentationFramework.Shell.Dialog
{
	public class DialogButtonViewModel : DialogButtonViewModelBase
	{
		public DialogButtonViewModel(AsyncCommandFactory commandFactory)
		{
			OkCommand = commandFactory.CreateSyncCommand(OkPressed);
		}

		public override ICommand OkCommand { get; }

		public override event Action CloseRequested;

		public bool IsOkPressed { get; private set; }

		protected void OnCloseRequested()
		{
			CloseRequested?.Invoke();
		}

		private void OkPressed()
		{
			IsOkPressed = true;
			OnCloseRequested();
		}
	}
}
