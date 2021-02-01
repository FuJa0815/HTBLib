using System;
using System.Windows;

namespace HTBLib.MVVM.WPF
{
    /// <inheritdoc/>
    public abstract class BaseViewModel : MVVM.BaseViewModel
    {
        protected sealed override void InvokeOnMainThread(Action action)
        {
            Application.Current.Dispatcher.Invoke(action);
        }
    }
}
