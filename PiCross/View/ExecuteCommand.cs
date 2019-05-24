using System;
using System.Windows.Input;

namespace View
{
    class ExecuteCommand : ICommand
    {
        private readonly Action action;
        public ExecuteCommand(Action a)
        {
            this.action = a;
        }

        public event EventHandler CanExecuteChanged { add { } remove { } }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            action();
        }
    }
}
