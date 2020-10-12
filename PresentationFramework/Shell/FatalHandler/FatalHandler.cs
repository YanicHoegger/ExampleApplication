using System;
using System.Threading.Tasks;
using WpfExampleApplication.PresentationFramework.Shell.Dialog;

namespace WpfExampleApplication.PresentationFramework.Shell.FatalHandler
{
	public class FatalHandler : IFatalHandler
	{
		private readonly IDialogPresenter _dialogPresenter;
		private readonly Action _closeAppAction;

		public FatalHandler(IDialogPresenter dialogPresenter, Action closeAppAction)
		{
			_dialogPresenter = dialogPresenter;
			_closeAppAction = closeAppAction;
		}

		public async Task HandleFatal(Exception ex)
		{
			var dialog = new DialogViewModel<ExceptionDialogContentViewModel>(new ExceptionDialogContentViewModel(ex), new FatalDialogButtonViewModel(_closeAppAction));

			await _dialogPresenter.ShowDialog(dialog);
		}
	}
}
