using System;
using WpfExampleApplication.PresentationFramework.Command;

namespace WpfExampleApplication.PresentationFramework.Shell.Dialog
{
	public class DialogFactory
	{
		private readonly AsyncCommandFactory _commandFactory;

		public DialogFactory(AsyncCommandFactory commandFactory)
		{
			_commandFactory = commandFactory;
		}

		public DialogViewModel<T> CreateOkDialog<T>(T contentViewModel)
		{
			return new DialogViewModel<T>(contentViewModel, CreateOkButtonViewModel());
		}

		public InputDialogViewModel<T> CreateInputDialog<T>(T inputViewModel)
		{
			return new InputDialogViewModel<T>(inputViewModel, CreateOkCancelButtonViewModel());
		}

		public DialogViewModel<ExceptionDialogContentViewModel> CreateExceptionDialog(Exception ex, Action closeAppAction)
		{
			return new DialogViewModel<ExceptionDialogContentViewModel>(new ExceptionDialogContentViewModel(ex), CreateOkButtonViewModel());
		}

		private DialogCancelButtonViewModel CreateOkCancelButtonViewModel()
		{
			return new DialogCancelButtonViewModel(_commandFactory);
		}

		private DialogButtonViewModel CreateOkButtonViewModel()
		{
			return new DialogButtonViewModel(_commandFactory);
		}
	}
}
