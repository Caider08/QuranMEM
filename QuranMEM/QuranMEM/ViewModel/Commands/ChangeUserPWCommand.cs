using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace QuranMEM.ViewModel.Commands
{
    public class ChangeUserPWCommand : ICommand
    {
        ForgotPWViewModel ForgotPWViewModel { get; set; }

        public event EventHandler CanExecuteChanged;

        public ChangeUserPWCommand(ForgotPWViewModel fpwvm)
        {
            ForgotPWViewModel = fpwvm;

        }

        public bool CanExecute(object parameter)
        {
            var pwEmail = ForgotPWViewModel.PWEmail;

            if (string.IsNullOrEmpty(pwEmail))
            {
                return false;
            }
            else
            {
                return true;
            }
            
        }


        public void Execute(object parameter)
        {
            
            ForgotPWViewModel.ResetUserPW();

        }
    }
}
