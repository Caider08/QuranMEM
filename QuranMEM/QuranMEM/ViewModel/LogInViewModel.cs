using QuranMEM.Model;
using QuranMEM.ViewModel.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Xamarin.Forms;

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

        public RegisterCommand RegisterCommand { get; set; }

        public ForgotPWCommand ForgotPWCommand { get; set; }

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

        /*private string userName;

        public string UserName
        {
            get { return userName; }

            set
            {
                userName = value;
                User = new User()
                {
                    UserName = this.UserName,
                    Email = this.Email,
                    Password = this.Password

                };
                OnPropertyChanged("UserName");
            }
        }*/

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

            RegisterCommand = new RegisterCommand(this);

            ForgotPWCommand = new ForgotPWCommand(this);
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

            bool canLogIn = await User.Login(User.Email,  User.Password);

            if (canLogIn)
            {
                if (App.user.SelectedCards != null)
                {
                    try
                    {

                        if (App.user.SelectedCards.Count() > 0)
                        {
                            await App.Current.MainPage.Navigation.PushModalAsync(new NavigationPage(new FrontCardPage()));
                        }
                        else
                        {
                            await App.Current.MainPage.Navigation.PushModalAsync(new NavigationPage(new HomePage()));
                        }
                    }
                    catch(Exception simpleNavE)
                    {
                        await App.Current.MainPage.DisplayAlert("Error Navigating", "Error Loading Home Screen", "Try again");
                    }
                }
                else
                {
                    try
                    {
                        await App.Current.MainPage.Navigation.PushModalAsync(new NavigationPage(new HomePage()));
                    }
                    catch(Exception whatE)
                    {
                       
                        await App.Current.MainPage.DisplayAlert("Error Navigating", "Error Loading Home Screen", "Try again");
                    }
                }
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Error", "Please Try Logging In again", "OK");
            }
        }

        public async void Register()
        {
            await App.Current.MainPage.Navigation.PushAsync(new RegisterPage());
        }

        public async void ForgotPW()
        {
            await App.Current.MainPage.Navigation.PushAsync(new ForgotPWPage());
        }

    }

   
}
