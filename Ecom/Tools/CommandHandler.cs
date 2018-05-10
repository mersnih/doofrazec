using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Ecom.Tools
{
    class CommandHandler : ICommand
    {
        private bool _canExecute;
        private System.Action _action;

        public CommandHandler(System.Action action, bool canExecute)
        {
            _action = action;
            _canExecute = canExecute;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return _canExecute;
        }

        public void Execute(object parameter)
        {
            _action();
        }
    }
}
