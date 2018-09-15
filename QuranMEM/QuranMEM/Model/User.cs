using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace QuranMEM.Model
{
    public class User : INotifyPropertyChanged
    {



        [PrimaryKey]
        [Newtonsoft.Json.JsonProperty("id")]
        public string id { get; set; }

        //[Newtonsoft.Json.JsonIgnore]
        private string email;

        [Newtonsoft.Json.JsonProperty("Email")]
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

        [Newtonsoft.Json.JsonProperty("Password")]
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

        [Newtonsoft.Json.JsonProperty("CurrentCard")]
        public int CurrentCard
        {
            get { return currentCard; }

            set
            {
                currentCard = value;
                OnPropertyChanged("CurrentCard");

            }
        }




        //public IList<int> IncorrectCards { get; set; }

        //public IList<int> SelectedCards { get; set; }

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


        [field: NonSerializedAttribute()]
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string property)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
           
        }




        public User()
        {

            ObservableCollection<int> IncorrectCards = new ObservableCollection<int>();
            ObservableCollection<int>SelectedCards = new ObservableCollection<int>();

            // IList<int> IncorrectCards = new List<int>();
            //IList<int> SelectedCards = new List<int>();

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
                try
                {

                    //User user = new User();

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
                catch (Exception eze)
                {
                    Console.WriteLine(eze);
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
