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
			InitializeComponent ();

            fcVM = new FlashCardViewModel();

            BindingContext = fcVM;
		}

        private void NextFlashCard_Clicked(object sender, EventArgs e)
        {

        }
    }
}