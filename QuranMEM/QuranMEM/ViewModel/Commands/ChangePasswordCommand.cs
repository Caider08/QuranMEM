using QuranMEM.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace QuranMEM.ViewModel.Commands
{
    public class ChangePasswordCommand : ICommand
    {
       
        
            public AccountViewModel AccountViewModel { get; set; }

            public ChangePasswordCommand(AccountViewModel avm)
            {
                AccountViewModel = avm;
            }

            public event EventHandler CanExecuteChanged;

            public bool CanExecute(object parameter)
            {
                //var user = (User)parameter;      

                //if (string.IsNullOrEmpty(user.Email))
                //{

                //    return false;
                //}
                //if (string.IsNullOrEmpty(user.Password))
                //{

                //    return false;
                //}
          
                return true;

            }

            public void Execute(object parameter)
            {
                var user = (User)parameter;

  

                AccountViewModel.ChangePassword();

            }


        
    }
}
