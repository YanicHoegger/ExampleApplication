using System;
using System.Windows;
using WpfExampleApplication.PresentationFramework.Example.ShellExample;

namespace WpfExampleApplication.PresentationFramework.Example
{
	public partial class App
	{
		public App()
		{
			var presentationFrameworkFacade = new PresentationFrameworkServiceFacade();

			var dataTemplateDictionary = new ResourceDictionary { Source = new Uri("/WpfExampleApplication.PresentationFramework.Example;component/DataTemplates.xaml", UriKind.RelativeOrAbsolute) };
			presentationFrameworkFacade.ShellServicesImplementation.AddResourceDictionary(dataTemplateDictionary);

			var viewModel = new ShellDisplayViewModel(presentationFrameworkFacade);
			presentationFrameworkFacade.ShellServicesImplementation.ShowContent(viewModel);
		}
	}
}
