using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using Task10.TreeSize.UI.Views;
using Task10.TreeSize.FileSystem.Services;
using Task10.TreeSize.FileSystem.Factories;
using Prism.Unity;
using Prism.Ioc;

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
            containerRegistry.Register<IDirectoryInfoFactory, DirectoryInfoFactory>();
            containerRegistry.Register<IFileSystemService, FileSystemService>();
        }
        
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }


        private void TestService()
        {
            var service = new FileSystemService(new DirectoryInfoFactory());
            var cancellationTokenSource = new CancellationTokenSource();

            try
            {
                Task.Run(async () => await service.GetFileSystemItemsAsync("D:\\", cancellationTokenSource.Token));

                cancellationTokenSource.Cancel();

                Thread.Sleep(5000);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }
    }
}