using System;

namespace WpfExampleApplication.PresentationFramework.Shell.Dialog
{
	public class ExceptionDialogContentViewModel
	{
		public Exception Exception { get; }

		public ExceptionDialogContentViewModel(Exception exception)
		{
			Exception = exception;
		}
	}
}
