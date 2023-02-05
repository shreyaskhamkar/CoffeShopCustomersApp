using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WiredBrainCoffee.CustomersApp.ViewModel;

namespace WiredBrainCoffee.CustomersApp.Command
{
    public class DelegateCommand : ICommand
    {
        private Action<object?> _execute;
        private Func<object?, bool>? _canExecute;
        private DelegateCommand? deleteCommand;

        public ViewModelBase? SelecteViewModel { get; }

        public DelegateCommand(Action<object?> execute, Func<object?, bool>? canExecute = null)

        {
            ArgumentNullException.ThrowIfNull(execute);
            _execute = execute;
            _canExecute = canExecute;
        }

        public DelegateCommand(DelegateCommand? deleteCommand)
        {
            this.deleteCommand = deleteCommand;
        }

        public DelegateCommand(ViewModelBase? selecteViewModel)
        {
            SelecteViewModel = selecteViewModel;
        }

        public void RaiseCanExecuteChanged() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter) => _canExecute is null || _canExecute(parameter);

        //clean execute method
        public void Execute(object? parameter) => _execute(parameter);
    }


}
