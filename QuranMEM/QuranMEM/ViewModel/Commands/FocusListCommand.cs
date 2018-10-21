using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace QuranMEM.ViewModel.Commands
{
    public class FocusListCommand : ICommand
    {
        public AccountViewModel AccountViewModel { get; set; }

        public FocusListCommand(AccountViewModel avm)
        {
            AccountViewModel = avm;

        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            AccountViewModel.FocusList();
        }
    }
}
        