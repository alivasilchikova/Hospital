using System;
using System.Windows;
using System.Windows.Input;

namespace HospitalApp.Data
{
    public class DelegateCommand : DependencyObject, ICommand
    {
        private readonly Action _executeMetod = null;
        private readonly Func<bool> _canExecuteMetod = null;
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
        public DelegateCommand(Action executeMetod, Func<bool> canExecuteMetod = null)
        {
            if (executeMetod == null)
            {
                throw new ArgumentNullException("executeMethod");
            }
            _executeMetod = executeMetod;
            _canExecuteMetod = canExecuteMetod;
        }
        public void Execute(object parameter)
        {
            if (_executeMetod != null)
            {
                _executeMetod();
            }
        }

        public bool CanExecute(object parameter)
        {
            if (_canExecuteMetod != null)
            {
                return _canExecuteMetod();
            }
            return true;
        }
    }
}
