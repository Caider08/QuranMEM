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

        protected override async void OnAppearing()
        {

            base.OnAppearing();

            //If User tracking/storing re-Enabled
            //try
            //{
            //    using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            //    {

            //        conn.CreateTable<User>();
            //        var localUser = conn.Table<User>().Where(u => u.Email == App.user.Email).ToList<User>().FirstOrDefault();

            //        //Change Cloud Database
            //        var cloudUser = (await App.MobileService.GetTable<User>().Where(u => u.Email == App.user.Email).ToListAsync()).FirstOrDefault();

            //        cloudUser.id = cloudUser.id;
            //        cloudUser.VersesStudied = localUser.VersesStudied;

            //        await App.MobileService.GetTable<User>().UpdateAsync(cloudUser);

            //        System.Threading.Thread.Sleep(150);

            //    }
               
            //}
            //catch(Exception cloudUpdateE)
            //{
            //    //Change Cloud Database
            //    System.Threading.Thread.Sleep(250);
            //}

        }
    }
}