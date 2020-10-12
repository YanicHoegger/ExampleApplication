namespace WpfExampleApplication.PresentationFramework.Shell.Dialog
{
	public class InputDialogViewModel<T> : DialogViewModel<T>
	{
		private readonly DialogCancelButtonViewModel _cancelButtonViewModel;

		public InputDialogViewModel(T inputViewModel, DialogCancelButtonViewModel cancelButtonViewModel)
			: base(inputViewModel, cancelButtonViewModel)
		{
			_cancelButtonViewModel = cancelButtonViewModel;
		}

		public bool InputAccepted => _cancelButtonViewModel.IsOkPressed;
	}
}
