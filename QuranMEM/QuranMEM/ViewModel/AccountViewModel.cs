using QuranMEM.Model;
using QuranMEM.ViewModel.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuranMEM.ViewModel
{
    public class AccountViewModel
    {
        public SignOutCommand SignOutCommand { get; set; }

        public ChangePasswordCommand ChangePasswordCommand { get; set; }

        private User user;


        public string Email
        {
            get { return user.Email; }

        }

        public int CurrentCard
        {

            get { return user.CurrentCard; }

        }

        public string UserName
        {
            get { return user.UserName; }
        }

        public int VersesStudied
        {
            get { return user.VersesStudied; }
        }

        public string VerseSuccessRate
        {
            get
            {
                var sRate = (user.WrongAnswer / VersesStudied).ToString();
                sRate += "%";
                return sRate;
            }
        }

        public string ChangePasswordNew { get; set; }

        public string ChangeConfirmPassword { get; set; }

        public AccountViewModel()
        {
            SignOutCommand = new SignOutCommand(this);

            ChangePasswordCommand = new ChangePasswordCommand(this);

            user = App.user;

        }

        public async void SignOut(User usa)
        {
            if (string.IsNullOrEmpty(usa.Email) || string.IsNullOrEmpty(usa.Password))
            {
                await App.Current.MainPage.Navigation.PushAsync(new MainPage());
            }
            else
            {
                try
                {
                    var answer = await App.Current.MainPage.DisplayAlert("Sign Out?", "Sign Out?", "Yes", "No");

                    if (answer == true)
                    {
                        App.user = new User();

                        await App.Current.MainPage.Navigation.PushAsync(new MainPage());
                    }
                }
                catch(Exception SignOutE)
                {
                    await App.Current.MainPage.DisplayAlert("Error Signing Out", "Sorry, Error Signing User Out", "OK");
                    await App.Current.MainPage.Navigation.PushAsync(new AccountPage());
                }
            }
        }

        public async void ChangePassword()
        {
        
            if (string.IsNullOrEmpty(ChangePasswordNew) || string.IsNullOrEmpty(ChangeConfirmPassword))
            {
                await App.Current.MainPage.DisplayAlert("Missing PW", "Please fill in New PW and Confirm New PW", "OK");
                await App.Current.MainPage.Navigation.PushAsync(new AccountPage());
            }
            else
            {
                try
                {
                    if (ChangePasswordNew != ChangeConfirmPassword)
                    {
                        await App.Current.MainPage.DisplayAlert("New Password MisMatch", "New Password doesn't Match", "Fix Password");
                    }
                    else
                    {
                        var answer = await App.Current.MainPage.DisplayAlert("Change Password?", "Change Password?", "Yes", "No");

                        if (answer == true)
                        {
                            var changed = await User.ChangePassword(ChangePasswordNew, user);

                            if (changed)
                            {
                                await App.Current.MainPage.DisplayAlert("Successful Password Change", "Password Changed Successfully", "OK");
                                await App.Current.MainPage.Navigation.PushAsync(new AccountPage());
                            }
                            else
                            {
                                await App.Current.MainPage.DisplayAlert("UnSuccessful Password Change", "Unable to Change Password...Try again later", "OK");
                                await App.Current.MainPage.Navigation.PushAsync(new AccountPage());
                            }

                        }
                    }

                }
                catch(Exception ChangePWExceptionE)
                {
                    await App.Current.MainPage.DisplayAlert("Error Changing PW", "Sorry, Error Changing your password", "OK");
                    await App.Current.MainPage.Navigation.PushAsync(new AccountPage());
                }
            }
        }


    }
}
