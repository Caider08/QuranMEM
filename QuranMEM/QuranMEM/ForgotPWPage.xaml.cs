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
	public partial class ForgotPWPage : ContentPage
	{
        //ForgotPWViewModel ForgotPWViewModel;

		public ForgotPWPage ()
		{
			InitializeComponent ();

            //ForgotPWViewModel = new ForgotPWViewModel();

            //BindingContext = ForgotPWViewModel;

		}

	}
}