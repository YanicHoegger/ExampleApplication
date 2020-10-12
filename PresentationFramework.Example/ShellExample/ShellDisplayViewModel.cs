using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfExampleApplication.PresentationFramework.Example.Annotations;
using WpfExampleApplication.PresentationFramework.Shell.Dialog;
using WpfExampleApplication.PresentationFramework.Shell.WaitScreen;

namespace WpfExampleApplication.PresentationFramework.Example.ShellExample
{
    public class ShellDisplayViewModel : INotifyPropertyChanged
    {
	    private readonly IWaitScreenShower _waitScreenShower;
	    private readonly IDialogPresenter _dialogPresenter;
	    private readonly DialogFactory _dialogFactory;
	    private string _dialogInput;

	    public ShellDisplayViewModel(IPresentationFrameworkServiceFacade presentationFrameworkServiceFacade)
	    {
		    _waitScreenShower = presentationFrameworkServiceFacade.ShellServices.WaitScreenShower;
		    _dialogPresenter = presentationFrameworkServiceFacade.ShellServices.DialogPresenter;
		    _dialogFactory = presentationFrameworkServiceFacade.DialogFactory;

			ShowWaitScreenCommand = presentationFrameworkServiceFacade.CommandFactory.CreateAsyncCommand(ShowWaitScreen);
		    ShowInputDialogCommand = presentationFrameworkServiceFacade.CommandFactory.CreateAsyncCommand(ShowInputDialog);
		    ShowMessageDialogCommand = presentationFrameworkServiceFacade.CommandFactory.CreateAsyncCommand(ShowMessageDialog);
		    ShowExceptionCommand = presentationFrameworkServiceFacade.CommandFactory.CreateSyncCommand(ShowException);
	    }

	    public ICommand ShowWaitScreenCommand { get; }
		public ICommand ShowInputDialogCommand { get; }
		public ICommand ShowMessageDialogCommand { get; }
		public ICommand ShowExceptionCommand { get; }

		public string DialogInput
		{
			get => _dialogInput;
			private set
			{
				_dialogInput = value;
				OnPropertyChanged();
			}
		}

		private async Task ShowWaitScreen()
	    {
		    _waitScreenShower.ShowWaitScreen();

		    await Task.Delay(5000);

		    _waitScreenShower.HideWaitScreen();
	    }

		private async Task ShowInputDialog()
		{
			var inputDialog = await _dialogPresenter.ShowDialog(_dialogFactory.CreateInputDialog(new InputDialogDisplayViewModel()));

			if (inputDialog.InputAccepted)
			{
				DialogInput = inputDialog.ContentViewModel.Input;
			}
		}

		private async Task ShowMessageDialog()
		{
			var messageDialog = _dialogFactory.CreateOkDialog(new MessageDialogDisplayViewModel());
			await _dialogPresenter.ShowDialog(messageDialog);
		}

		private static void ShowException()
		{
			throw new Exception("This is some exception thrown");
		}

		public event PropertyChangedEventHandler PropertyChanged;

		[NotifyPropertyChangedInvocator]
		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
    }
}
