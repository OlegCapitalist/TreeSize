using System;
using System.Threading.Tasks;
using Prism.Commands;
using Prism.Mvvm;
using System.Windows.Input;
using System.Threading;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Forms;
using System.Xaml;
using Task10.TreeSize.FileSystem.Factories.DirectoryInfo;
using Task10.TreeSize.FileSystem.Wrappers.DirectoryInfoWrappers;
using Task10.TreeSize.UI.Services.MainThreadDispatcher;

namespace Task10.TreeSize.UI.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        #region Private Fields

        private readonly IMainThreadDispatcher _mainThreadDispatcher;
        private readonly IDirectoryInfoFactory _directoryInfoFactory;

        private string? _path;
        private CancellationTokenSource? _cancellationTokenSource;

        #endregion

        #region Constructor

        public MainWindowViewModel(IMainThreadDispatcher mainThreadDispatcher, IDirectoryInfoFactory directoryInfoFactory)
        {
            _mainThreadDispatcher = mainThreadDispatcher;
            _directoryInfoFactory = directoryInfoFactory;
        }

        #endregion

        #region Properties

        public ObservableCollection<FileSystemItemViewModel> FileSystemItems { get; private set; } = new();
        public Visibility ProgressVisibility { get; private set; } = Visibility.Hidden;

        #endregion

        #region Commands

        public ICommand ChooseDirCommand => new DelegateCommand(ChooseDirCommandHandler);

        public ICommand StopScanCommand => new DelegateCommand(StopScanCommandHandler);

        public ICommand RefreshCommand => new DelegateCommand(RefreshCommandHandler);

        #endregion

        #region Command Handlers

        private async void ChooseDirCommandHandler()
        {
            var dialog = new FolderBrowserDialog();

            if (dialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            _path = dialog.SelectedPath;

            ProgressVisibility = Visibility.Visible;

            try
            {
                await LoadFileSystemItemsAsync();
            }
            catch (OperationCanceledException exception)
            {
                Debug.WriteLine(exception);
            }

            ProgressVisibility = Visibility.Hidden;
        }

        private void StopScanCommandHandler()
        {
            _cancellationTokenSource?.Cancel();
        }

        private async void RefreshCommandHandler()
        {
            await LoadFileSystemItemsAsync();
        }

        #endregion

        #region Private Methods

        private async Task LoadFileSystemItemsAsync()
        {
            if (string.IsNullOrEmpty(_path))
            {
                return;
            }

            FileSystemItems.Clear();

            _cancellationTokenSource = new CancellationTokenSource();

            var directoryInfo = _directoryInfoFactory.CreateDirectoryInfo(_path);
            await LoadFileSystemItemsRecursiveAsync(directoryInfo);
        }

        private async Task LoadFileSystemItemsRecursiveAsync(IDirectoryInfo directoryInfo, DirectoryItemViewModel? parentNode = null)
        {
            _cancellationTokenSource?.Token.ThrowIfCancellationRequested();

            await Task.Run(async () =>
            {
                var subDirectoryInfos = directoryInfo.GetDirectories();
                var fileInfos = directoryInfo.GetFiles();

                var directoryViewModel = new DirectoryItemViewModel(directoryInfo, _mainThreadDispatcher, parentNode);

                var fileItemViewModels = fileInfos.Select(fileInfo => new FileItemViewModel(fileInfo, _mainThreadDispatcher, directoryViewModel));
                directoryViewModel.AddChildNodes(fileItemViewModels);

                if (parentNode == null)
                {
                    _mainThreadDispatcher.Dispatch(() => FileSystemItems.Add(directoryViewModel));
                }
                else
                {
                    parentNode.AddChildNode(directoryViewModel);
                }

                foreach (var subDirectoryInfo in subDirectoryInfos)
                {
                    await LoadFileSystemItemsRecursiveAsync(subDirectoryInfo, directoryViewModel);
                }
            });
        }

        #endregion
    }
}


