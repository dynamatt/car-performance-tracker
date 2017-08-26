namespace Utilities
{
    using System;
    using System.Windows.Input;

    public class DelegateCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private readonly Action<object> execute;

        private readonly Func<object, bool> canExecute = (arg) => true;

        public DelegateCommand(Action<object> execute)
        {
            this.execute = execute;
        }

        public DelegateCommand(Action<object> execute, Func<object, bool> canExecute)
            :this(execute)
        {
            this.canExecute = canExecute;
        }

        public DelegateCommand(Action execute)
        {
            this.execute = obj => execute();
        }

        public DelegateCommand(Action execute, Func<bool> canExecute)
            : this(execute)
        {
            this.canExecute = (arg) => canExecute();
        }

        public void Execute(object parameter)
        {
            this.execute(parameter);
        }

        public bool CanExecute(object parameter)
        {
            return this.canExecute(parameter);
        }

        public void RaiseCanExecuteChanged()
        {
            this.CanExecuteChanged?.Invoke(this, new EventArgs());
        }
    }
}
