using System;

namespace Task10.TreeSize.UI.Services.MainThreadDispatcher;

public interface IMainThreadDispatcher
{
    void Dispatch(Action action);
}