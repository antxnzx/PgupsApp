﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PgupsApp.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PgupsApp.ViewModels
{
    public partial class ProfilePageViewModel : BaseViewModel
    {
        [ObservableProperty]
        private string _name;
        [ObservableProperty]
        private string _surname;

        public ProfilePageViewModel() 
        {
            Name = App.UserDetails.Name;
            Surname = App.UserDetails.Surname;
        }

        [RelayCommand]
        async void SignOut()
        {
            if (Preferences.ContainsKey(nameof(App.UserDetails)))
            {
                Preferences.Remove(nameof(App.UserDetails));
            }

            await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
        }
    }
}
