namespace WpfExampleApplication.PresentationFramework.Shell.WaitScreen
{
	public class WaitScreenShower : IWaitScreenShower
	{
		private readonly ShellViewModel _shellViewModel;

		public WaitScreenShower(ShellViewModel shellViewModel)
		{
			_shellViewModel = shellViewModel;
		}

		public void ShowWaitScreen()
		{
			_shellViewModel.IsWaitScreenShown = true;
		}

		public void HideWaitScreen()
		{
			_shellViewModel.IsWaitScreenShown = false;
		}
	}
}
