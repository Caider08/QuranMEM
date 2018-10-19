using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace QuranMEM.ViewModel.Commands
{
    public class ForgotPWCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public LogInViewModel LogInViewModel { get; set; }

        public ForgotPWCommand(LogInViewModel lvm)
        {
            LogInViewModel = lvm;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            LogInViewModel.ForgotPW();
        }

    }
}
