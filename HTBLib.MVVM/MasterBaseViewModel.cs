using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;

namespace HTBLib.MVVM
{
    /// <summary>
    ///   The base of all view models.
    /// </summary>
    public abstract class MasterBaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected abstract void InvokeOnMainThread(Action action);

        /// <summary>
        ///   Has to be called whenever a property changes
        /// </summary>
        /// <param name="property">The name of the property that updated</param>
        public void OnPropertyChanged([CallerMemberName] string property = null)
        {
            Action invokePropertyChangedAction =
                () => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));

            if (SynchronizationContext.Current == null)
                InvokeOnMainThread(invokePropertyChangedAction);
            else
                invokePropertyChangedAction();
        }

        /// <summary>
        ///   Sets a variable and calls <see cref="OnPropertyChanged(string)"/>
        /// </summary>
        /// <typeparam name="T">The type of the variable</typeparam>
        /// <param name="var">A reference to the variable to be set</param>
        /// <param name="val">The new value for the variable</param>
        /// <param name="property">The name of the property that updated</param>
        public void Set<T>(ref T var, T val, [CallerMemberName] string property = null)
        {
            var = val;
            OnPropertyChanged(property);
        }
    }
}
