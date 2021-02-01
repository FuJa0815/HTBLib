using System;
using System.Windows;

namespace HTBLib.MVVM.WPF
{
    /// <inheritdoc/>
    public abstract class BaseViewModel : MasterBaseViewModel
    {
        protected sealed override void InvokeOnMainThread(Action action)
        {
            Application.Current.Dispatcher.Invoke(action);
        }
    }
}
