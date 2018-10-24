using QuranMEM.Model;
using QuranMEM.ViewModel;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace QuranMEM
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FocusListBackCardPage : ContentPage
	{
        FlashCardViewModel FlashCardViewModel;

		public FocusListBackCardPage ()
		{
			InitializeComponent ();

            FlashCardViewModel = new FlashCardViewModel();

            BindingContext = FlashCardViewModel;
		}

        public FocusListBackCardPage(FlashCardViewModel fcvm)
        {
            try
            {
                InitializeComponent();

                FlashCardViewModel = fcvm;

                BindingContext = FlashCardViewModel;
            }
            catch (Exception loadBackCardE2)
            {
                //Do Something
                System.Threading.Thread.Sleep(150);
            }
            
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            if (App.user.CurrentCard < 1 || App.user.CurrentCard > 6236)
            {

                await Navigation.PushModalAsync(new NavigationPage(new HomePage()));

            }

        }

        private async void FrontCard_Clicked(object sender, EventArgs e)
        {
            try
            {
                await Navigation.PushAsync(new FocusListFrontCardPage());
            }
            catch (Exception backToFrontCardE)
            {
                System.Threading.Thread.Sleep(150);
                await DisplayAlert("Front Card Error", "Error Navigating back to Front Card", "OK");
            }
        }

        private async void NextFlashCardFocus_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (App.user.IncorrectCards == null || App.user.IncorrectCards.Count() < 1)
                {
                    //Out of Cards
                    var answer = await DisplayAlert("Out of Ayahs", "You have finished going through your Focus List", "Ayah Selection", "Stay here");

                    if (answer == true)
                    {
                        try
                        {
                            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
                            {

                                conn.CreateTable<User>();
                                var localUser = conn.Table<User>().Where(u => u.Email == App.user.Email).ToList<User>().FirstOrDefault();

                                //Change Cloud Database since User has completed their FocusList
                                var cloudUser = (await App.MobileService.GetTable<User>().Where(u => u.Email == App.user.Email).ToListAsync()).FirstOrDefault();

                                cloudUser.id = cloudUser.id;
                                cloudUser.VersesStudied = localUser.VersesStudied;

                                await App.MobileService.GetTable<User>().UpdateAsync(cloudUser);

                                System.Threading.Thread.Sleep(150);

                            }

                        }
                        catch (Exception cloudUpdateE)
                        {
                            System.Threading.Thread.Sleep(250);
                        }

                        await Navigation.PushModalAsync(new NavigationPage(new HomePage()));
                    }
                }
                else if (App.user.IncorrectCards.Count() == 1)
                {
                    try
                    { 
                    
                        App.user.CurrentCard = App.user.IncorrectCards.FirstOrDefault();

                        App.user.IncorrectCards.Remove(App.user.CurrentCard);

                        //Update Card Tally
                        App.user.VersesStudied++;
                        //Update Database
                                   
                        using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
                        {

                            conn.CreateTable<User>();
                            var localUser = conn.Table<User>().Where(u => u.Email == App.user.Email).ToList<User>().FirstOrDefault();
                            localUser.VersesStudied++;
                            conn.Update(localUser);

                        }
                 
                        //Change Cloud Database
                        //var cloudUser = (await App.MobileService.GetTable<User>().Where(u => u.Email == App.user.Email).ToListAsync()).FirstOrDefault();

                        //cloudUser.VersesStudied++;

                        //await App.MobileService.GetTable<User>().UpdateAsync(cloudUser);

                    }
                    catch (Exception incrementDatabaseE)
                    {
                        Navigation.PopAsync();
                        await Navigation.PushAsync(new FocusListFrontCardPage());
                    }

                    Navigation.PopAsync();
                    await Navigation.PushAsync(new FocusListFrontCardPage());
                }
                else
                {
                    Random rand = new Random();

                    App.user.IncorrectCards.Remove(App.user.CurrentCard);

                    App.user.CurrentCard = App.user.IncorrectCards.Skip(rand.Next(App.user.IncorrectCards.Count())).FirstOrDefault();

                    //Update Card Tally
                    App.user.VersesStudied++;
                    //Update Database
                    try
                    {
                        using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
                        {
                            conn.CreateTable<User>();
                            var localUser = conn.Table<User>().Where(u => u.Email == App.user.Email).ToList<User>().FirstOrDefault();
                            localUser.VersesStudied++;
                            conn.Update(localUser);

                        }
                     
                        //Change Cloud Database
                        //var cloudUser = (await App.MobileService.GetTable<User>().Where(u => u.Email == App.user.Email).ToListAsync()).FirstOrDefault();

                        //cloudUser.VersesStudied++;

                        //await App.MobileService.GetTable<User>().UpdateAsync(cloudUser);

                    }
                    catch (Exception incrementDatabaseE)
                    {
                        Navigation.PopAsync();
                        await Navigation.PushAsync(new FocusListFrontCardPage());
                    }

                    Navigation.PopAsync();
                    await Navigation.PushAsync(new FocusListFrontCardPage());

                }
            }
            catch (Exception nextAyahE)
            {
                //Do something
                System.Threading.Thread.Sleep(150);
            }

        }

        private async void KeepFocusList_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (App.user.IncorrectCards == null)
                {
                    App.user.IncorrectCards = new List<int>();
                }
                else
                {

                    App.user.IncorrectCards.Add(App.user.CurrentCard);

                    App.user.WrongAnswer++;


                    using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
                    {

                        conn.CreateTable<User>();
                        var localUser = conn.Table<User>().Where(u => u.Email == App.user.Email).ToList<User>().FirstOrDefault();
                        localUser.WrongAnswer++;
                        conn.Update(localUser);

                    }

                    await DisplayAlert("Verse Added", "Ayah added again to your Focus Study List", "OK");

                }
            }
            catch (Exception focusListE)
            {
                //Do something
                System.Threading.Thread.Sleep(250);
            }

        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            try
            {
                if (App.user.IncorrectCards == null)
                {
                    App.user.IncorrectCards = new List<int>();
                }
                else
                {

                    App.user.IncorrectCards.Add(App.user.CurrentCard);

                    App.user.WrongAnswer++;


                    using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
                    {

                        conn.CreateTable<User>();
                        var localUser = conn.Table<User>().Where(u => u.Email == App.user.Email).ToList<User>().FirstOrDefault();
                        localUser.WrongAnswer++;
                        conn.Update(localUser);

                    }

                    await DisplayAlert("Verse Added", "Ayah added again to your Focus Study List", "OK");

                }
            }
            catch (Exception focusListE)
            {
                //Do something
                await DisplayAlert("Focus List Error", "Error when trying to add Ayah to your Focus Study List", "OK");
            }
        }
    }
    
}