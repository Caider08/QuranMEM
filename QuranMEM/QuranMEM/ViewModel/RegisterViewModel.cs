using QuranMEM.Model;
using QuranMEM.ViewModel.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace QuranMEM.ViewModel
{
    class RegisterViewModel : INotifyPropertyChanged
    {
        public RegisterUserCommand RegisterUserCommand { get; set; }

        private User user;

        public User User
        {
            get { return user; }

            set { user = value;
                OnPropertyChanged("User");
            }
        }

        private string email;

        public string Email
        {
            get { return email; }

            set { email = value;
                 User = new User()
                {
                    id = Guid.NewGuid().ToString(),
                    Email = this.Email,
                    UserName = this.UserName,
                    Password = this.Password,
                    ConfirmPassword = this.ConfirmPassword,

                };

                OnPropertyChanged("Email");
            }
        }

        private string userName;

        public string UserName
        {
            get { return userName; }

            set
            {
                userName = value;
                User = new User()
                {
                    id = Guid.NewGuid().ToString(),
                    Email = this.Email,
                    UserName = this.UserName,
                    Password = this.Password,
                    ConfirmPassword = this.ConfirmPassword,

                };

                OnPropertyChanged("UserName");
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
                    id = Guid.NewGuid().ToString(),
                    Email = this.Email,
                    UserName = this.UserName,
                    Password = this.Password,
                    ConfirmPassword = this.ConfirmPassword,

                };
                OnPropertyChanged("Password");
            }
        }

        private string confirmPassword;

        public string ConfirmPassword
        {
            get { return confirmPassword; }

            set
            {
                confirmPassword = value;
                User = new User()
                {
                    id = Guid.NewGuid().ToString(),
                    Email = this.Email,
                    UserName = this.UserName,
                    Password = this.Password,
                    ConfirmPassword = this.ConfirmPassword,
                };
                OnPropertyChanged("ConfirmPassword");
            }
        }



        public RegisterViewModel ()
        {
            RegisterUserCommand = new RegisterUserCommand(this);

            User = new User()
            {
                IncorrectCards = new List<int>(),
                SelectedCards = new List<int>(),
                
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public async void RegisterUser(User usa)
        {          
                bool registerSucess = await User.RegisterUserU(usa);

                if (registerSucess)
                {
                    try
                    {
                        await App.Current.MainPage.Navigation.PushModalAsync(new NavigationPage(new HomePage()));
                    }
                    catch(Exception successRegistrationE)
                    {
                        await App.Current.MainPage.DisplayAlert("Navigation Error", "Error Loading Home Page", "Ok");
                    }
                }
                else
                {
                    await App.Current.MainPage.DisplayAlert("Registration Error", "Registration Failed...Please Try Again", "OK");
                }
        
        }
    }

}
