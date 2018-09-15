using QuranMEM.ViewModel.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuranMEM.ViewModel
{
    public class HomeViewModel
    {

        public NavigationCommand NavCommand { get; set; }


        public HomeViewModel()
        {
            NavCommand = new NavigationCommand(this);

        }

        public void Navigate()
        {

        }
    }
}
