using System.ComponentModel;

namespace WpfExampleApplication.PresentationFramework.Command
{
	public class AlwaysCanExecute : INotifyCanExecute
	{
		public event PropertyChangedEventHandler PropertyChanged { add { } remove { } }
		public bool CanExecute => true;
	}
}
