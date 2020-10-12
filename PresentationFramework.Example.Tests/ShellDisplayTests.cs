using System;
using NUnit.Framework;
using PresentationFramework.Example.Tests.Common;
using WpfExampleApplication.PresentationFramework.Example.ShellExample;
using WpfExampleApplication.PresentationFramework.Shell.Dialog;

namespace PresentationFramework.Example.Tests
{
	[TestFixture]
	public class ShellDisplayTests
	{
		private readonly PresentationFrameworkServiceFacadeMock _serviceFacadeMock = new PresentationFrameworkServiceFacadeMock();
		private ShellDisplayViewModel _shellDisplayViewModel;
		private const string InputString = "This is a test input";

		[SetUp]
		public void SetUp()
		{
			_shellDisplayViewModel = new ShellDisplayViewModel(_serviceFacadeMock);
		}

		[Test]
		public void ShowInputWhenInputDialogGetsAccepted()
		{
			GivenDialogBehavior(InputGetsAccepted);
			WhenExecuteDialog();
			ThenInputShownInShellDisplay();
		}

		[Test]
		public void ShowNoInputWhenInputDialogGetsNotAccepted()
		{
			GivenDialogBehavior(InputGetsNotAccepted);
			WhenExecuteDialog();
			ThenInputNotShownInShellDisplay();
		}

		private void GivenDialogBehavior(Func<InputDialogViewModel<InputDialogDisplayViewModel>, InputDialogViewModel<InputDialogDisplayViewModel>> manipulateDialogFunc)
		{
			((DialogPresenterMock) _serviceFacadeMock.ShellServices.DialogPresenter).ManipulateDialogFunc 
				= o =>
				{
					var dialog = (InputDialogViewModel<InputDialogDisplayViewModel>) o;
					dialog.ContentViewModel.Input = InputString;
					return manipulateDialogFunc(dialog);
				};
		}

		private static InputDialogViewModel<InputDialogDisplayViewModel> InputGetsAccepted(InputDialogViewModel<InputDialogDisplayViewModel> dialog)
		{
			dialog.ButtonViewModel.OkCommand.Execute(null);
			return dialog;
		}

		private static InputDialogViewModel<InputDialogDisplayViewModel> InputGetsNotAccepted(InputDialogViewModel<InputDialogDisplayViewModel> dialog)
		{
			((DialogCancelButtonViewModel)dialog.ButtonViewModel).CancelCommand.Execute(null);
			return dialog;
		}

		private void WhenExecuteDialog()
		{
			_shellDisplayViewModel.ShowInputDialogCommand.Execute(null);
		}

		private void ThenInputShownInShellDisplay()
		{
			Assert.AreEqual(InputString, _shellDisplayViewModel.DialogInput);
		}

		private void ThenInputNotShownInShellDisplay()
		{
			Assert.True(string.IsNullOrEmpty(_shellDisplayViewModel.DialogInput));
		}
	}
}
