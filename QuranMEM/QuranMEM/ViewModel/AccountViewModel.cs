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

        private User user;

        public string Email
        {
            get { return user.Email; }


        }

        public int CurrentCard
        {

            get { return user.CurrentCard; }

        }

        public AccountViewModel()
        {
            SignOutCommand = new SignOutCommand(this);

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
                var answer = await App.Current.MainPage.DisplayAlert("Sign Out?", "Sign Out?", "Yes", "No");

                if(answer == true)
                {
                    App.user = new User();

                    await App.Current.MainPage.Navigation.PushAsync(new MainPage());
                }
            }
        }


    }
}
