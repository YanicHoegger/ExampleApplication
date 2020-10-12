using System;
using System.Threading.Tasks;

namespace WpfExampleApplication.PresentationFramework.Shell.FatalHandler
{
	public interface IFatalHandler
	{
		Task HandleFatal(Exception ex);
	}
}
