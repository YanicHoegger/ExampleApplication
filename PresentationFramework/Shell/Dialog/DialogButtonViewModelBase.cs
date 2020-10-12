using System;
using System.Windows.Input;

namespace WpfExampleApplication.PresentationFramework.Shell.Dialog
{
	//Can't be interface since DataTemplates are not able to use interfaces --> use abstract class instead
	public abstract class DialogButtonViewModelBase
	{
		//Every Dialog should have at least an Ok Button
		public abstract ICommand OkCommand { get; }

		public abstract event Action CloseRequested;
	}
}
