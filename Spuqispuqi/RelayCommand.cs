using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Spuqispuqi
{
    public class RelayCommand : ICommand
    {
        protected Action _execute = () => { };
        protected Func<bool> _canExecute = () => true;

        public RelayCommand() { }

        public RelayCommand(Action execute)
        {
            _execute = execute;
        }

        public RelayCommand(Action execute, Func<bool> canExecute)
        {
            if (execute == null)
            {
                throw new ArgumentNullException("Execute");
            }

            if (canExecute == null)
            {
                throw new ArgumentNullException("CanExecute");
            }

            _execute = execute;
            _canExecute = canExecute;
        }

        public virtual bool CanExecute(object parameter = null)
        {
            return _canExecute();
        }

        public virtual void Execute(object parameter = null)
        {
            _execute();
        }

        public bool IsEnabled { get => CanExecute(); }

        public event EventHandler CanExecuteChanged;

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
