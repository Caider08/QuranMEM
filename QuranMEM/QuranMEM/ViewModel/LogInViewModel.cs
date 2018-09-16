using QuranMEM.Model;
using QuranMEM.ViewModel.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace QuranMEM.ViewModel
{
    public class LogInViewModel : INotifyPropertyChanged
    {

        private User user;

        public User User
        {
            get { return user; }

            set {
                user = value;
                OnPropertyChanged("User");
            }
        
        }


        public LogInCommand LogInCommand { get; set; }

        private string email;

        public string Email
        {
            get { return email; }

            set
            {
                email = value;
                User = new User()
                {
                    Email = this.Email,
                    Password = this.Password,
                };
                OnPropertyChanged("Email");
            }
        }

        private string password;

       

        public string Password
        {
            get { return password; }

            set
            {

                password = value;

                User = new User()
                {
                    Email = this.Email,
                    Password = this.Password,
                };



                OnPropertyChanged("Password");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string property)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }


        public LogInViewModel()
        {
            User = new User();

            LogInCommand = new LogInCommand(this);
        }

        public  async void LogIn()
        {
            /*if (string.IsNullOrEmpty(User.Email))
            {
                await App.Current.MainPage.DisplayAlert("Email Error", "Please Enter a Valid Email", "OK");

            }
            if (string.IsNullOrEmpty(User.Password))
            {
                await App.Current.MainPage.DisplayAlert("Password Error", "Please Enter a Password", "OK");
            }*/

            bool canLogIn = await User.Login(User.Email, User.Password);

            if (canLogIn)
            {
                await App.Current.MainPage.Navigation.PushAsync(new HomePage());

            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Error", "Please Try Logging In again", "OK");
            }
        }

    }

   
}
