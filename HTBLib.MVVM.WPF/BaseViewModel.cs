using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace HTBLib.MVVM.WPF
{
    /// <summary>
    ///   The base of all view models.
    /// </summary>
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        ///   Has to be called whenever a property changes
        /// </summary>
        /// <param name="property">The name of the property that updated</param>
        public void OnPropertyChanged([CallerMemberName] string property = null)
        {
            Action invokePropertyChangedAction =
                () => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));

            // Invoke on UI Thread
            Application.Current.Dispatcher.Invoke(invokePropertyChangedAction);
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
