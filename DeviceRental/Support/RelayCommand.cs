using System;
using System.Windows.Input;

namespace DeviceRentalManagement.Support
{
    public class RelayCommand<T> : ICommand
    {
        private Action<T> ExecuteMethod;
        private Func<T, bool> CanExecuteMethod;
        public event EventHandler CanExecuteChanged = delegate { };
        public RelayCommand(Action<T> executeMethod) 
        {
            ExecuteMethod = executeMethod; 
        }

        public RelayCommand(Action<T> executeMethod, Func<T, bool> canExecuteMethod) 
        {
            ExecuteMethod = executeMethod;
            CanExecuteMethod = canExecuteMethod; 
        }

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged(this, EventArgs.Empty);
        } 
		
        bool ICommand.CanExecute(object parameter) 
        { 
            if (CanExecuteMethod != null) 
            { 
                T tparm = (T)parameter; 
                return CanExecuteMethod(tparm); 
            } 

            if (ExecuteMethod != null) 
            { 
                return true; 
            } 
			
            return false; 
        }

        void ICommand.Execute(object parameter)
        { 
            if (ExecuteMethod != null) 
            {
                ExecuteMethod((T)parameter); 
            } 
        } 
    }
}
