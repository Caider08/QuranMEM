using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace QuranMEM.ViewModel.Commands
{
    public class ResetLISTSCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public AccountViewModel AccountViewModel { get; set; }

        public ResetLISTSCommand(AccountViewModel avm)
        {
            AccountViewModel = avm;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            AccountViewModel.ResetLists();
        }
    }
}
