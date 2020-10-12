using System.ComponentModel;
using System.Runtime.CompilerServices;
using WpfExampleApplication.PresentationFramework.Properties;
using WpfExampleApplication.PresentationFramework.Shell.WaitScreen;

namespace WpfExampleApplication.PresentationFramework.Shell
{
	public class ShellViewModel : INotifyPropertyChanged
	{
		private string _title;
		private object _content;
		private bool _isWaitScreenShown;
		private object _dialogVm;

		public object DialogVm
		{
			get => _dialogVm;
			internal set
			{
				_dialogVm = value;
				OnPropertyChanged();
				OnPropertyChanged(nameof(IsDialogShown));
				OnPropertyChanged(nameof(IsOverlayShown));
			}
		}

		public bool IsDialogShown => DialogVm != null;

		public WaitScreenVm WaitScreen { get; } = new WaitScreenVm();

		public bool IsWaitScreenShown
		{
			get => _isWaitScreenShown;
			internal set
			{
				_isWaitScreenShown = value;
				OnPropertyChanged();
				OnPropertyChanged(nameof(IsOverlayShown));
			}
		}

		public bool IsOverlayShown => IsDialogShown || IsWaitScreenShown;

		public string Title
		{
			get => _title;
			set
			{
				_title = value;
				OnPropertyChanged();
			}
		}

		public object Content
		{
			get => _content;
			set
			{
				_content = value;
				OnPropertyChanged();
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;

		[NotifyPropertyChangedInvocator]
		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
