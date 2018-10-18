using QuranMEM.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace QuranMEM.ViewModel.Commands
{
    public class LogInCommand : ICommand
    {
        public LogInViewModel LoginViewModel { get; set; }

        public LogInCommand(LogInViewModel lVM)
        {
            LoginViewModel = lVM;

        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            var user = (User)parameter;
            
            if (user == null)
            {
                return false;
            }

            if(string.IsNullOrEmpty(user.Email))
            {
                
                return false;
            }
            if(string.IsNullOrEmpty(user.Password))
            {
                
                return false;
            }

            return true;
        }

        public void Execute(object parameter)
        {

            LoginViewModel.LogIn();

        }

    }
}
