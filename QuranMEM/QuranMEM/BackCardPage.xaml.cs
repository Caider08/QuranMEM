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
	public partial class BackCardPage : ContentPage
	{
        FlashCardViewModel fcVM;

		public BackCardPage ()
		{
            try
            {
                InitializeComponent();

                fcVM = new FlashCardViewModel();

                BindingContext = fcVM;
            }
            catch(Exception loadBackCardE)
            {
                //Do Something
                System.Threading.Thread.Sleep(150);
            }
		}

        public BackCardPage(FlashCardViewModel FCvm)
        {
            
            try
            {
                InitializeComponent();

                fcVM = FCvm;

                BindingContext = fcVM;
            }
            catch (Exception loadBackCardE2)
            {
                //Do Something
                System.Threading.Thread.Sleep(150);
            }

        }

        private async void NextFlashCard_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (App.user.SelectedCards == null || App.user.SelectedCards.Count() < 1)
                {
                    //Out of Cards
                    var answer = await DisplayAlert("Out of Ayahs", "You have finished the selected Ayahs", "Surah Selection?", "Stay here");

                    if (answer == true)
                    {
                        await Navigation.PushAsync(new HomePage());
                    }
                }
                else if (App.user.SelectedCards.Count() == 1)
                {
                    App.user.CurrentCard = App.user.SelectedCards.FirstOrDefault();

                    App.user.SelectedCards.Remove(App.user.CurrentCard);

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
                    }
                    catch(Exception incrementDatabaseE)
                    {
                        await Navigation.PushAsync(new FrontCardPage());
                    }

              
                    await Navigation.PushAsync(new FrontCardPage());
                }
                else
                {
                    Random rand = new Random();

                    App.user.SelectedCards.Remove(App.user.CurrentCard);

                    App.user.CurrentCard = App.user.SelectedCards.Skip(rand.Next(App.user.SelectedCards.Count())).FirstOrDefault();


                    await Navigation.PushAsync(new FrontCardPage());

                }
            }
            catch(Exception nextAyahE)
            {
                //Do something
                System.Threading.Thread.Sleep(150);
            }

        }

        private void ArabicVerse_Clicked(object sender, EventArgs e)
        {
            try
            {

                Navigation.PushAsync(new FrontCardPage());
            }
            catch(Exception backToFrontCardE)
            {
                System.Threading.Thread.Sleep(150);
            }
        }

        private async void AddFocusList_Clicked(object sender, EventArgs e)
        {
            try
            {
                App.user.IncorrectCards.Add(App.user.CurrentCard);


                using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
                {

                    conn.CreateTable<User>();
                    var localUser = conn.Table<User>().Where(u => u.Email == App.user.Email).ToList<User>().FirstOrDefault();
                    localUser.WrongAnswer++;
                    conn.Update(localUser);

                }

                await DisplayAlert("Verse Added", "Verse added to your Focus Study List", "OK");

            }
            catch (Exception focusListE)
            {
                //Do something
            }
        }
    }
}