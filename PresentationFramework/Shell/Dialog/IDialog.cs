using System;

namespace WpfExampleApplication.PresentationFramework.Shell.Dialog
{
	public interface IDialog
	{
		event Action CloseRequested;
	}
}
