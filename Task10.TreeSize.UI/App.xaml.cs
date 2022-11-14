using System.Windows;
using Task10.TreeSize.UI.Views;
using Prism.Ioc;
using Task10.TreeSize.FileSystem.Factories.DirectoryInfo;
using Task10.TreeSize.UI.Services.MainThreadDispatcher;

namespace Task10.TreeSize.UI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    //public partial class App : PrismApplication
    public partial class App 
    {

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<IMainThreadDispatcher, MainThreadDispatcher>();
            containerRegistry.Register<IDirectoryInfoFactory, DirectoryInfoFactory>();
        }
        
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }
    }
}