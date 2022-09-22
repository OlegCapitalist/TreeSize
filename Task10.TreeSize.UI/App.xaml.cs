using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using Task10.TreeSize.FileSystem.Services;
using Prism.Unity;

namespace Task10.TreeSize.UI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    //public partial class App : PrismApplication
    public partial class App : Application
    {
        public App()
        {
            
        }

        private void TestService()
        {
            var service = new FileSystemService();
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