using System;

namespace RecipeCalculator.UI.ViewModel
{
    public class Command : System.Windows.Input.ICommand
    {
        public event EventHandler CanExecuteChanged;
        private Action<object> _action;

        public Command(Action<object> action)
        {
            _action = action;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _action(parameter);
        }
    }
}
