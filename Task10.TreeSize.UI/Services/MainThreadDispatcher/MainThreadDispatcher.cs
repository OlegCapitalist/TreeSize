using System;
using System.Diagnostics.CodeAnalysis;
using System.Windows;

namespace Task10.TreeSize.UI.Services.MainThreadDispatcher
{
    [ExcludeFromCodeCoverage]
    public class MainThreadDispatcher : IMainThreadDispatcher
    {
        public void Dispatch(Action action)
        {
            Application.Current.Dispatcher.Invoke(action);
        }
    }
}
