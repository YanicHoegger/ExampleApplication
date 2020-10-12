using System.Windows;
using WpfExampleApplication.PresentationFramework.Shell.Dialog;
using WpfExampleApplication.PresentationFramework.Shell.FatalHandler;
using WpfExampleApplication.PresentationFramework.Shell.WaitScreen;

namespace WpfExampleApplication.PresentationFramework.Shell
{
	public class ShellServices : IShellServices
	{
		public ShellServices()
		{
			ShellViewModel = new ShellViewModel();
			Shell = new Shell { DataContext = ShellViewModel };
			DialogPresenter = new DialogPresenter(ShellViewModel);
			WaitScreenShower = new WaitScreenShower(ShellViewModel);
			FatalHandler = new FatalHandler.FatalHandler(DialogPresenter, CloseApp);
		}

		public void AddResourceDictionary(ResourceDictionary resourceDictionary)
		{
			Shell.Resources.MergedDictionaries.Add(resourceDictionary);
		}

		public void ShowContent(object content)
		{
			ShellViewModel.Content = content;
			Shell.Show();
		}

		public IDialogPresenter DialogPresenter { get; }
		public IWaitScreenShower WaitScreenShower { get; }
		public IFatalHandler FatalHandler { get; }

		public Shell Shell { get; }

		public ShellViewModel ShellViewModel { get; }

		private static void CloseApp()
		{
			//Application can only be shutdown from UI thread
			if (!Application.Current.Dispatcher.CheckAccess())
			{
				Application.Current.Dispatcher.Invoke(CloseApp);
				return;
			}

			Application.Current.Shutdown();
		}
	}
}
