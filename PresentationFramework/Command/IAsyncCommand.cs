using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfExampleApplication.PresentationFramework.Command
{
	public interface IAsyncCommand : ICommand
	{
		Task ExecuteAsync(object parameter);
	}
}