using QuranMEM.Model;
using QuranMEM.ViewModel.Commands;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuranMEM.ViewModel
{
    public class ForgotPWViewModel
    {

            public BackToLogInCommand BackToLogInCommand { get; set; }

            public ChangeUserPWCommand ChangeUserPWCommand{ get; set; }

            private string email;

            public string PWEmail
            {
                get { return email; }

                set
                {
                    email = value;                 
                
                }
            }

            public ForgotPWViewModel()
            {
                ChangeUserPWCommand = new ChangeUserPWCommand(this);

                BackToLogInCommand = new BackToLogInCommand(this);
            }

            public async void LogIn()
            {

            await App.Current.MainPage.Navigation.PushAsync(new LogInPage());

            }

            public async void ResetUserPW()
            {
            if (!string.IsNullOrEmpty(PWEmail))
            {


                try
                {
                    //Change Cloud Database
                    var cloudUser = (await App.MobileService.GetTable<User>().Where(u => u.Email == PWEmail).ToListAsync()).FirstOrDefault();

                    if (cloudUser != null && !string.IsNullOrEmpty(cloudUser.Email))
                    {
                        var answer = await App.Current.MainPage.DisplayAlert("Reset PW?", "Are you sure you want to reset PW?", "Yes", "No");

                        if (answer)
                        {
                            cloudUser.id = cloudUser.id;
                            cloudUser.Password = "QuranTest";
                            cloudUser.ConfirmPassword = "QuranTest";

                            await App.MobileService.GetTable<User>().UpdateAsync(cloudUser);

                            System.Threading.Thread.Sleep(250);

                            //Change LocalDB
                            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
                            {
                                conn.CreateTable<User>();
                                var localUser = conn.Table<User>().Where(u => u.Email == email).ToList<User>().FirstOrDefault();

                                localUser.Password = "QuranTest";
                                localUser.ConfirmPassword = "QuranTest";
                                conn.Update(localUser);

                            }

                            await App.Current.MainPage.DisplayAlert("New PW = QuranTest", "Be sure to visit your Account page and change PW from 'QuranTest' to your desired PW", "OK");
                        }
                        else
                        {
                            await App.Current.MainPage.Navigation.PushAsync(new LogInPage());
                        }

                    }
                    else
                    {
                        await App.Current.MainPage.DisplayAlert("No Account Exists", "No registered account exists for the given email", "OK");
                    }

                }
                catch (Exception resetPWE)
                {

                    await App.Current.MainPage.DisplayAlert("PW Reset Error", "Error resetting your PW..try again please", "OK");

                }
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Enter Email", "Please enter a valid Email", "OK");
            }
               
            }


    }
}
