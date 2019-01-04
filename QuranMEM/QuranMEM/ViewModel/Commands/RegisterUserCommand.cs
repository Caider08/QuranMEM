using QuranMEM.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace QuranMEM.ViewModel.Commands
{
    //class RegisterUserCommand : ICommand
    //{

    //    public RegisterViewModel RegisterViewModel { get; set; }

    //    public RegisterUserCommand(RegisterViewModel rvm)
    //    {
    //        RegisterViewModel = rvm;
    //    }

    //    public event EventHandler CanExecuteChanged;


    //    public bool CanExecute(object parameter)
    //    {
    //        var user = (User)parameter;

    //        if(user == null)
    //        {
    //            return false;
    //        }

    //        if(string.IsNullOrEmpty(user.Email) || string.IsNullOrEmpty(user.Password) || string.IsNullOrEmpty(user.ConfirmPassword))
    //        {
    //            return false;
    //        }
    //        if (user.ConfirmPassword != user.Password)
    //        {

    //            return false;
    //        }

    //        return true;

    //    }



    //    public void Execute(object parameter)
    //    {
    //        User user = (User)parameter;

    //        RegisterViewModel.RegisterUser(user);

    //    }
    //}
}
