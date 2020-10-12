using System.ComponentModel;

namespace WpfExampleApplication.PresentationFramework.Command
{
	public interface INotifyCanExecute : INotifyPropertyChanged
	{
		bool CanExecute { get; }
	}
}
