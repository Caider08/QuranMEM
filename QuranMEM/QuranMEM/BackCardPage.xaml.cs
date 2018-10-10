using QuranMEM.Model;
using QuranMEM.ViewModel;
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
    }
}