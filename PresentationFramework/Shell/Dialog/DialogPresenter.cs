using System;
using System.Threading.Tasks;

namespace WpfExampleApplication.PresentationFramework.Shell.Dialog
{
	public class DialogPresenter : IDialogPresenter
	{
		private readonly ShellViewModel _shellViewModel;

		public DialogPresenter(ShellViewModel shellViewModel)
		{
			_shellViewModel = shellViewModel;
		}

		public Task<T> ShowDialog<T>(T dialog) where T : IDialog
		{
			_shellViewModel.DialogVm = dialog;
			var taskCompletionSource = new TaskCompletionSource<T>();

			void HandleCloseRequested()
			{
				dialog.CloseRequested -= HandleCloseRequested;
				_shellViewModel.DialogVm = null;
				taskCompletionSource.SetResult(dialog);
			}

			dialog.CloseRequested += HandleCloseRequested;

			return taskCompletionSource.Task;
		}
	}
}
