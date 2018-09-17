using QuranMEM.Model;
using QuranMEM.ViewModel.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

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
                    Email = this.Email,
                    Password = this.Password,
                    ConfirmPassword = this.ConfirmPassword,

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
                    Email = this.Email,
                    Password = this.Password,
                    ConfirmPassword = this.ConfirmPassword,
                };
                OnPropertyChanged("ConfirmPassword");
            }
        }



        public RegisterViewModel ()
        {
            RegisterUserCommand = new RegisterUserCommand(this);

            User = new User();
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
                    await App.Current.MainPage.Navigation.PushAsync(new HomePage());

                }
                else
                {
                    await App.Current.MainPage.DisplayAlert("Registration Error", "Registration Failed...Please Try Again", "OK");
                }

         
        }
    }

}
