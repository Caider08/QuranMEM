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
	public partial class AccountPage : ContentPage
	{
        //User User;
        AccountViewModel AccountVM;

		public AccountPage ()
		{
			InitializeComponent ();

            // User = App.user;
            //UserDisplayStackLayout.BindingContext = User;

            AccountVM = new AccountViewModel();

            BindingContext = AccountVM;

		}
	}
}