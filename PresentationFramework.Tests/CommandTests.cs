using System;
using System.Threading.Tasks;
using System.Windows.Input;
using NUnit.Framework;
using WpfExampleApplication.PresentationFramework.Command;
using WpfExampleApplication.PresentationFramework.Tests.Commons;

namespace WpfExampleApplication.PresentationFramework.Tests
{
	[TestFixture]
	public class CommandTests
	{
		[Test]
		public void CommandCanOnlyBeExecutedOnceAtATimeTest()
		{
			GivenEndlessCommand();
			WhenExecutingCommand();
			ThenCommandCanNotBeExecutedAgain();
		}

		[Test]
		public async Task FatalHandlerIsCalledWhenThrowException()
		{
			GivenExceptionThrowingCommand();
			await WhenExecutingCommandAsync();
			ThenFatalHandlerCalled();
		}

		[TearDown]
		public void CleanUp()
		{
			_isExecutingCommand = false;
		}

		private ICommand _command;
		private bool _isExecutingCommand = true;
		private readonly Exception _fatalException = new Exception("MyTestException");
		private Exception _thrownException;

		private void GivenEndlessCommand()
		{
			var commandFactory = new AsyncCommandFactory(new FatalHandlerMock());
			_command = commandFactory.CreateSyncCommand(EndlessAction);
		}

		private void GivenExceptionThrowingCommand()
		{
			var fatalHandlerMock = new FatalHandlerMock
			{
				HandleFatalAction = exception => { _thrownException = exception; }
			};
			var commandFactory = new AsyncCommandFactory(fatalHandlerMock);
			_command = commandFactory.CreateSyncCommand(() => throw _fatalException);
		}


		private void WhenExecutingCommand()
		{
			_command.Execute(null);
		}

		private async Task WhenExecutingCommandAsync()
		{
			await ((AsyncCommand) _command).ExecuteAsync(null);
		}

		private void ThenCommandCanNotBeExecutedAgain()
		{
			Assert.IsFalse(_command.CanExecute(null));
		}

		private void ThenFatalHandlerCalled()
		{
			Assert.AreEqual(_fatalException.Message, _thrownException.Message);
		}

		private void EndlessAction()
		{
			while (_isExecutingCommand) { }
		}
	}
}
