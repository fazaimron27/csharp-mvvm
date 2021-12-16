using System;
using System.Windows.Input;

namespace RetailerApp.Setup
{
    public class RelayCommand : ICommand
    {
        private readonly Action cmdactone;
        public event EventHandler CanExecuteChanged;
        
        public RelayCommand(Action cmdactone)
        {
            this.cmdactone = cmdactone;
        }
        
        public bool CanExecute(object parameter)
        {
            return true;
        }
        
        public void Execute(object parameter)
        {
            cmdactone();
        }
    }
}