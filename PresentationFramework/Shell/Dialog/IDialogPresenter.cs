using System.Threading.Tasks;

namespace WpfExampleApplication.PresentationFramework.Shell.Dialog
{
	public interface IDialogPresenter
	{
		Task<T> ShowDialog<T>(T dialog) where T : IDialog;
	}
}
