using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuranMEM.Model
{
    public class User : INotifyPropertyChanged
    {

        private string id;

        [PrimaryKey]
        public string Id
        {
            get { return id; }

            set
            {
                id = value;
                OnPropertyChanged("Id");
            }
        }

        private string email;


        public string Email
        {
            get { return email; }

            set
            {
                email = value;
                OnPropertyChanged("Email");
            }
        }

        private string password;

        public string Password
        {
            get { return password; }

            set
            {
                password = value;
                OnPropertyChanged("Password");
            }

        }

        private int currentCard;


        public int CurrentCard
        {
            get { return currentCard; }

            set
            {
                currentCard = value;
                OnPropertyChanged("CurrentCard");

            }
        }

        private ObservableCollection<int> _incorrectCards;

        public ObservableCollection<int> IncorrectCards
        {
            get { return _incorrectCards; }

            set
            {
                _incorrectCards = value;
                OnPropertyChanged("IncorrectCards");
            }
        }


        private ObservableCollection<int> _selectedCards;

        public ObservableCollection<int> SelectedCards
        {
            get { return _selectedCards; }

            set
            {
                _selectedCards = value;
                OnPropertyChanged("SelectedCards");
            }
        }



        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string property)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(property));
        }


        public User()
        {

            ObservableCollection<int> IncorrectCards = new ObservableCollection<int>();
            ObservableCollection<int> SelectedCards = new ObservableCollection<int>();

        }

        public async static Task<bool> Login(string email, string pw)
        {

            bool isEmailEntry = string.IsNullOrEmpty(email);
            bool isPasswordEntry = string.IsNullOrEmpty(pw);

            if (isEmailEntry || isPasswordEntry)
            {
                if (isEmailEntry)
                {
                    //await DisplayAlert("Blank Email", "Please enter a Valid Email", "Ok");
                    return false;
                }
                else
                {
                    //await DisplayAlert("Blank Password", "Please enter a Valid Password", "Ok");
                    return false;
                }

            }
            else
            {
                var user = (await App.MobileService.GetTable<User>().Where(u => u.Email == email).ToListAsync()).FirstOrDefault();

                if (user != null)
                {
                    App.user = user;

                    if (user.Password == pw)
                    {

                        return true;
                        //await Navigation.PushAsync(new NavigationPage(new HomePage()));
                    }
                    else
                    {
                        return false;
                        //await DisplayAlert("Incorrect Password", "Incorrect Password for this Email", "OK");
                    }


                }
                else
                {
                    //await DisplayAlert("No User Exists with that Email", "No User Exists with that Email", "OK");
                    // await Navigation.PushAsync(new NavigationPage(new RegisterPage()));
                    return false;
                }


            }




        }

        public async static Task<bool> RegisterUser(User usa)
        {
            try
            {

                await App.MobileService.GetTable<User>().InsertAsync(usa);

                return true;

            }
            catch (Exception ez)
            {
                //Console.WriteLine(ez);
                //Maybe store this in the cloud Database?

                return false;
            }
        }


    }
}

  
