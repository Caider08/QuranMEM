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

        //[PrimaryKey]
        [Newtonsoft.Json.JsonProperty("id")]
        public string id { get; set; }

        //[Newtonsoft.Json.JsonIgnore]
        //private string email;

        //[Newtonsoft.Json.JsonProperty("Email")]
        //public string Email
        //{
        //    get { return email; }

        //    set
        //    {
        //        email = value;
        //        OnPropertyChanged("Email");
        //    }
        //}

        //private string userName;

        //[Newtonsoft.Json.JsonProperty("UserName")]
        //public string UserName
        //{
        //    get { return userName; }

        //    set
        //    {
        //        userName = value;
        //        OnPropertyChanged("UserName");
        //    }
        //}

        //[Newtonsoft.Json.JsonProperty(PropertyName = "Version")]

        //public string Version { get; set; }


        //private string password;

        //[Newtonsoft.Json.JsonProperty("Password")]
        //public string Password
        //{
        //    get { return password; }

        //    set
        //    {
        //        password = value;
        //        OnPropertyChanged("Password");
        //    }
        //}

        //private string confirmPassword;

        //[Newtonsoft.Json.JsonProperty("ConfirmPassword")]
        //public string ConfirmPassword
        //{
        //    get { return confirmPassword; }

        //    set
        //    {
        //        confirmPassword = value;
        //        OnPropertyChanged("ConfirmPassword");
        //    }
        //}

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

        private int versesStudied;

        [Newtonsoft.Json.JsonProperty("VersesStudied")]
        public int VersesStudied
        {
            get { return versesStudied; }

            set
            {
                versesStudied = value;
                OnPropertyChanged("VersesStudied");

            }
        }


        //public IList<int> IncorrectCards { get; set; }

        //public IList<int> SelectedCards { get; set; }

        private List<int> _incorrectCards;

        [Ignore]
        [JsonIgnore]
        public List<int> IncorrectCards
        {
            get { return _incorrectCards; }

            set
            {
                _incorrectCards = value;
                OnPropertyChanged("IncorrectCards");
            }
        }

        private int wrongAnswer;

        [Newtonsoft.Json.JsonProperty("WrongAnswer")]
        public int WrongAnswer
        {
            get { return wrongAnswer; }

            set
            {
                wrongAnswer = value;
                OnPropertyChanged("WrongAnswer");
            }
        }


        private List<int> _selectedCards;

        [Ignore]
        [JsonIgnore]
        public List<int> SelectedCards
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

            List<int> IncorrectCards = new List<int>();
            List<int>SelectedCards = new List<int>();

            // IList<int> IncorrectCards = new List<int>();
            //IList<int> SelectedCards = new List<int>();
        }

        //public async static Task<bool> Login(string email, string pw)
        //{

        //    bool isEmailEntry = string.IsNullOrEmpty(email);
        //    bool isPasswordEntry = string.IsNullOrEmpty(pw);

        //    if (isEmailEntry || isPasswordEntry)
        //    {
        //        if (isEmailEntry)
        //        {
        //            //await DisplayAlert("Blank Email", "Please enter a Valid Email", "Ok");
        //            return false;
        //        }
        //        else
        //        {
        //            //await DisplayAlert("Blank Password", "Please enter a Valid Password", "Ok");
        //            return false;
        //        }
        //    }
        //    else
        //    {
        //        try
        //        {

        //            //User user = new User();
        //            //see if User Exists on LocalDb
        //            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
        //            {

        //                conn.CreateTable<User>();
        //                var user = conn.Table<User>().Where(u => u.Email == email).ToList<User>().FirstOrDefault();

        //                if (user != null && !String.IsNullOrEmpty(user.Email))
        //                {
        //                    App.user = user;

        //                    if (user.Password == pw)
        //                    {

        //                        return true;
        //                        //await Navigation.PushAsync(new NavigationPage(new HomePage()));
        //                    }
        //                    else
        //                    {
                                
        //                        await App.Current.MainPage.DisplayAlert("Incorrect Password", "Incorrect Password for this Email", "Try Again");
        //                        return false;
        //                    }

        //                }                     
                        //else
                        //{
                            
                            //await App.Current.MainPage.DisplayAlert("No User Exists with that Email", "No User Exists with that Email..Try registering a new free Account", "OK");
                            //return false;

                            //For Cloud Functionality
                            //await Navigation.PushAsync(new NavigationPage(new RegisterPage()));

                            //See if user exists on Cloud Database
                            //var user2 = (await App.MobileService.GetTable<User>().Where(u => u.Email == email).ToListAsync()).FirstOrDefault();

                            //if (user2 != null)
                            //{
                            //App.user = user2;

                            //if (user2.Password == pw)
                            //{
                            //return true;
                            //}
                            //else
                            //{
                            // false;
                            //}
                            //}
                            //else
                            //{
                            //return false;
                            //}

                        //}

                    //}
                //}
                //catch (Exception eze)
                //{
                    //Console.WriteLine(eze);
                    //return false;
                //}

            //}


        //}

        //public async static Task<bool> ChangePassword(string newPW, User usa)       
        //{
        //    try
        //    {
        //        //Cloud functionality if Customer decides wants it
        //        //Change Cloud Database
        //        //var cloudUser = (await App.MobileService.GetTable<User>().Where(u => u.Email == usa.Email).ToListAsync()).FirstOrDefault();

        //        //cloudUser.id = cloudUser.id;
        //        //cloudUser.Password = newPW;
        //        //cloudUser.ConfirmPassword = newPW;
                
        //        //await App.MobileService.GetTable<User>().UpdateAsync(cloudUser);

        //        //System.Threading.Thread.Sleep(250);

        //        //Change LocalDB
        //        using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
        //        {
        //            conn.CreateTable<User>();
        //            var localUser = conn.Table<User>().Where(u => u.Email == usa.email).ToList<User>().FirstOrDefault();
        //            localUser.Password = newPW;
        //            localUser.ConfirmPassword = newPW;
        //            conn.Update(localUser);

        //        }

        //        return true;

        //    }
        //    catch (Exception ez)
        //    {
        //        //Console.WriteLine(ez);
        //        //Maybe store this in the cloud Database?

        //        return false;
        //    }

        //}

        //public async static Task<bool> RegisterUserU(User usa)
        //{
        //    try
        //    {
        //        //Cloud Functionality (if Customer decicdes to reimplement this)
        //        //See if User already exists
        //        //var cloudUser = (await App.MobileService.GetTable<User>().Where(u => u.Email == usa.Email).ToListAsync()).FirstOrDefault();

        //        //if (cloudUser == null || string.IsNullOrEmpty(cloudUser.Email))
        //        //{

        //        //Insert into Cloud Database
        //        //await App.MobileService.GetTable<User>().InsertAsync(usa);

        //        //Insert into Localdb

        //        //}
        //        // else
        //        //{
        //        // await App.Current.MainPage.DisplayAlert("Registered Email", "This Email has already been used to Register with us", "OK");
        //        // return false;

        //        //}

        //        using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
        //        {
        //            conn.CreateTable<User>();
        //            conn.Insert(usa);
        //            conn.Close();

        //        }

        //        System.Threading.Thread.Sleep(250);

        //        App.user = usa;

        //        System.Threading.Thread.Sleep(250);

        //        return true;

        //    }
        //    catch (Exception ez)
        //    {
        //        //Console.WriteLine(ez);
             

        //        return false;
        //    }
        //}



    }

}
