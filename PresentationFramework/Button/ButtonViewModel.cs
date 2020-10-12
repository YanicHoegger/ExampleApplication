using System.Windows.Input;

namespace WpfExampleApplication.PresentationFramework.Button
{
	public class ButtonViewModel
	{
		public ButtonViewModel(string content, ICommand command)
		{
			Content = content;
			Command = command;
		}

		public string Content { get; }

		public ICommand Command { get; }
	}
}
