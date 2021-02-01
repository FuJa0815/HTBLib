using System;
using Xamarin.Forms;

namespace HTBLib.MVVM.Xamarin
{
    /// <inheritdoc/>
    public abstract class BaseViewModel : MasterBaseViewModel
    {
        protected sealed override void InvokeOnMainThread(Action action)
        {
            Device.BeginInvokeOnMainThread(action);
        }
    }
}
