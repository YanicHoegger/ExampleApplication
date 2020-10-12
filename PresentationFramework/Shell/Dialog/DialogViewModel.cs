using System;

namespace WpfExampleApplication.PresentationFramework.Shell.Dialog
{
	public class DialogViewModel<TContent> : DialogViewModel
	{
		public DialogViewModel(TContent contentViewModel, DialogButtonViewModelBase buttonViewModel)
			: base(contentViewModel)
		{
			ContentViewModel = contentViewModel;
			ButtonViewModel = buttonViewModel;
		}

		public new TContent ContentViewModel { get; }

		public override event Action CloseRequested
		{
			add => ButtonViewModel.CloseRequested += value;
			remove => ButtonViewModel.CloseRequested -= value;
		}
	}

	//class needed since xaml cant use generic types
	public abstract class DialogViewModel : IDialog
	{
		protected DialogViewModel(object contentViewModel)
		{
			ContentViewModel = contentViewModel;
		}

		public DialogButtonViewModelBase ButtonViewModel { get; protected set; }


		public abstract event Action CloseRequested;

		public object ContentViewModel { get; }
	}
}
