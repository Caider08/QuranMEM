using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuranMEM.Model
{
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public string id { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public int CurrentCard { get; set; }

        public List<int> IncorrectCards { get; set; }

        public List<int> SelectedCards { get; set; }

        public User()
        {

            IncorrectCards = new List<int>();
            SelectedCards = new List<int>();

        }

        public static bool Login(string email, string pw)
        {

            bool isEmailEmpty = string.IsNullOrEmpty(email);
            bool isPassWordEmpty = string.IsNullOrEmpty(pw);

            if (isEmailEmpty || isPassWordEmpty)
            {

                return false;

            }
            else
            {
                //var user = await App.MobileService.GetTable<User>().Where(u => u.Email == email);

                //if( User != null)
                //{
                   // App.user = User;

               // }
                return true;

            }

            


        }

    
    }
}
