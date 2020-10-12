using System;
using System.Threading.Tasks;
using WpfExampleApplication.PresentationFramework.Shell.Dialog;

namespace PresentationFramework.Example.Tests.Common
{
	public class DialogPresenterMock : IDialogPresenter
	{
		public Task<T> ShowDialog<T>(T dialog) where T : IDialog
		{
			return Task.FromResult((T)ManipulateDialogFunc(dialog));
		}

		public Func<object, object> ManipulateDialogFunc { get; set; } = dialog => dialog;
	}
}
