using System;
using System.Windows.Input;

namespace HTBLib.MVVM
{
    /// <summary>
    ///   A command where the function take no parameters
    /// </summary>
    public class RelayCommand : RelayCommand<object>
    {
        public RelayCommand(Action action, Func<bool> canExecute = null)
            : base(p => action(), p => (canExecute ?? (() => true)).Invoke())
        {
        }
    }

    /// <summary>
    ///   A command where the function takes one parameter of type T
    /// </summary>
    /// <typeparam name="T">The type of the action parameter</typeparam>
    public class RelayCommand<T> : ICommand
    {
        private readonly Action<T> _action;
        private readonly Func<T, bool> _canExecute;
        public RelayCommand(Action<T> action, Func<T, bool> canExecute = null)
        {
            _action = action;
            _canExecute = canExecute ?? (p => true);
        }

        /// <inheritdoc/>
        public event EventHandler CanExecuteChanged;

        /// <inheritdoc/>
        public bool CanExecute(object parameter) => _canExecute((T)parameter);

        /// <inheritdoc/>
        public void Execute(object parameter) => _action((T)parameter);
    }
}
