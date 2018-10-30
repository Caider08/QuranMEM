using QuranMEM.Model;
using QuranMEM.ViewModel.Commands;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Xamarin.Forms;

namespace QuranMEM.ViewModel
{
    public class AccountViewModel
    {
        public SignOutCommand SignOutCommand { get; set; }

        public ChangePasswordCommand ChangePasswordCommand { get; set; }

        public FocusListCommand FocusListCommand { get; set; }

        public ResetLISTSCommand ResetLISTSCommand { get; set; }

        public ResetSTATSCommand ResetSTATSCommand { get; set; }

        public AboutPageCommand AboutPageCommand { get; set; }

        private User user;
      
        public AccountViewModel()
        {
            SignOutCommand = new SignOutCommand(this);

            ChangePasswordCommand = new ChangePasswordCommand(this);

            FocusListCommand = new FocusListCommand(this);

            ResetLISTSCommand = new ResetLISTSCommand(this);

            ResetSTATSCommand = new ResetSTATSCommand(this);

            AboutPageCommand = new AboutPageCommand(this);

            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                try
                {
                     conn.CreateTable<User>();
                    var localUser = conn.Table<User>().Where(u => u.Email == App.user.Email).ToList<User>().FirstOrDefault();

                    user = localUser;
                }
                catch(Exception localUserE)
                {
                    user = App.user;
                }                           
            }
        }

        public string Email
        {
            get { return user.Email; }

        }

        public int CurrentCard
        {

            get { return user.CurrentCard; }

        }

        public int WrongAnswer
        {
            get
            {
                try
                {

                    //using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
                    //{

                    //    conn.CreateTable<User>();
                    //    var localUser = conn.Table<User>().Where(u => u.Email == user.Email).ToList<User>().FirstOrDefault();

                    //    return localUser.WrongAnswer;

                    //}

                    return user.WrongAnswer;
                }
                catch (Exception getWrongAnswerE)
                {
                    return 0;
                }
            }
        }

        public string UserName
        {
            get { return user.UserName; }
        }

        public int VersesStudied
        {
            get
            {
                try
                {

                    //using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
                    //{

                    //    conn.CreateTable<User>();
                    //    var localUser = conn.Table<User>().Where(u => u.Email == App.user.Email).ToList<User>().FirstOrDefault();

                    //    return localUser.VersesStudied;

                    //}

                    return user.VersesStudied;
                }
                catch (Exception getVersesStudiedE)
                {
                    return 0;
                }
            }
        }

        public string VerseSuccessRate
        {
            get
            {
                try
                {
                    string sRate = "";
                    decimal wrongAnswer = (decimal)WrongAnswer;
                    decimal versesStudied = (decimal)VersesStudied;
                    if (WrongAnswer == 0 || VersesStudied == 0)
                    {
                        return sRate += "100%";
                    }

                    else
                    {
                        //sRateD = (WrongAnswer / VersesStudied) * 100;
                        //sRate = Math.Round(sRateD, 2).ToString();
                        sRate = Math.Round(100-((wrongAnswer/versesStudied) * 100), 2).ToString();
                        sRate += "%";
                        return sRate;
                    }
                }
                catch(Exception VSE)
                {
                    return "100%";
                }
               
            }
        }

        public string ChangePasswordNew { get; set; }

        public string ChangeConfirmPassword { get; set; }

        public async void ResetSTATS()
        {
            try
            {
                var answer = await App.Current.MainPage.DisplayAlert("Reset Stats?", "Are you sure you'd like to reset your Stats(this will not reset your Verses Studied)", "Yes", "No");

                if(answer)
                {
                    App.user.WrongAnswer = 0;

                    //Update Local Database             
                    using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
                    {
                        conn.CreateTable<User>();
                        var localUser = conn.Table<User>().Where(u => u.Email == user.Email).ToList<User>().FirstOrDefault();
                        localUser.WrongAnswer = 0;
                        conn.Update(localUser);

                    }

                    await App.Current.MainPage.DisplayAlert("Stats Reset", "Stats reset successfully", "OK");

                    App.Current.MainPage.Navigation.PopAsync();

                    await App.Current.MainPage.Navigation.PushModalAsync(new NavigationPage(new HomePage()));
               
                }
                    
            }
            catch(Exception resetE)
            {
                await App.Current.MainPage.DisplayAlert("Stat Error", "Error Resetting your STATS...try again soon", "OK");

                await App.Current.MainPage.Navigation.PopAsync();
            }
        }

        public async void ResetLists()
        {
            try
            {
                var answer = await App.Current.MainPage.DisplayAlert("Reset Lists?", "Are you sure you'd like to empty your SelectedCards and FocusList?", "Yes", "No");

                if (answer)
                {
                    App.user.SelectedCards = new List<int>();
                    App.user.IncorrectCards = new List<int>();

                    await App.Current.MainPage.DisplayAlert("Lists Reset", "Lists reset successfully", "OK");

                    App.Current.MainPage.Navigation.PopAsync();

                    await App.Current.MainPage.Navigation.PushModalAsync(new NavigationPage(new HomePage()));
                }

            }
            catch (Exception resetE)
            {
                await App.Current.MainPage.DisplayAlert("List Error", "Error Resetting your LISTS...try again soon", "OK");
                await App.Current.MainPage.Navigation.PopAsync();
            }
        }

        public async void AboutPage()
        {
            try
            {               
                //App.Current.MainPage.Navigation.PopAsync();
                await App.Current.MainPage.Navigation.PushModalAsync(new NavigationPage(new AboutPage()));
            }
            catch(Exception aboutPageE)
            {
                //Do something
                System.Threading.Thread.Sleep(150);
            }
        }

        public async void FocusList()
        {
            try
            {
                if (App.user.IncorrectCards == null || App.user.IncorrectCards.Count() < 1)
                {
                    await App.Current.MainPage.DisplayAlert("Empty Focus List", "You have 0 Ayahs in your Focus List", "Ok");
                }
                else
                {
                    App.user.CurrentCard = App.user.IncorrectCards.Take(1).FirstOrDefault();

                    //App.Current.MainPage.Navigation.PopAsync();

                    await App.Current.MainPage.Navigation.PushModalAsync(new NavigationPage(new FocusListFrontCardPage()));
                 
                }
            }
            catch(Exception focusListE)
            {
                try
                {

                    App.user.CurrentCard = App.user.IncorrectCards.Take(1).FirstOrDefault();

                    
                    await App.Current.MainPage.Navigation.PushModalAsync(new NavigationPage(new FocusListFrontCardPage()));

                    App.Current.MainPage.Navigation.PopAsync();
                }
                catch (Exception focusList2)
                {

                    await App.Current.MainPage.Navigation.PopAsync();
                }


            }
           
        }
 
        public async void SignOut(User usa)
        {
            if (string.IsNullOrEmpty(usa.Email) || string.IsNullOrEmpty(usa.Password))
            {
                await App.Current.MainPage.Navigation.PopAsync();

                Application.Current.MainPage = new NavigationPage(new MainPage());

            }
            else
            {
                try
                {
                    var answer = await App.Current.MainPage.DisplayAlert("Sign Out?", "Sign Out?", "Yes", "No");

                    if (answer == true)
                    {
                        App.user = new User();

                        Application.Current.MainPage = new NavigationPage(new MainPage());

                        App.Current.MainPage.Navigation.PopAsync();
                     
                        //await App.Current.MainPage.Navigation.PushModalAsync(new NavigationPage(new MainPage()));

                    }
                }
                catch(Exception SignOutE)
                {
                    await App.Current.MainPage.DisplayAlert("Error Signing Out", "Sorry, Error Signing User Out", "OK");
                    App.Current.MainPage.Navigation.PopAsync();
                    await App.Current.MainPage.Navigation.PushModalAsync(new NavigationPage(new HomePage()));
                }
            }
        }

        public async void ChangePassword()
        {
        
            if (string.IsNullOrEmpty(ChangePasswordNew) || string.IsNullOrEmpty(ChangeConfirmPassword))
            {
                await App.Current.MainPage.DisplayAlert("Missing PW", "Please fill in New PW and Confirm New PW", "OK");
                //await App.Current.MainPage.Navigation.PushAsync(new AccountPage());
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
                                App.Current.MainPage.Navigation.PopAsync();
                                await App.Current.MainPage.Navigation.PushModalAsync(new NavigationPage(new HomePage()));
                            }
                            else
                            {
                                await App.Current.MainPage.DisplayAlert("UnSuccessful Password Change", "Unable to Change Password...Try again later", "OK");
                               // await App.Current.MainPage.Navigation.PopAsync();
                            }

                        }
                    }

                }
                catch(Exception ChangePWExceptionE)
                {
                    await App.Current.MainPage.DisplayAlert("Error Changing PW", "Sorry, Error Changing your password", "OK");
                   // await App.Current.MainPage.Navigation.PopAsync();
                }
            }
        }


    }
}
