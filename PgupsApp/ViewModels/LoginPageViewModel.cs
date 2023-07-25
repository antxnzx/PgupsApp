using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Newtonsoft.Json;
using PgupsApp.Models;
using PgupsApp.Views;
using System.Text.Json.Serialization;

namespace PgupsApp.ViewModels
{
    public partial class LoginPageViewModel : BaseViewModel
    {
        [ObservableProperty]
        private string _email;
        [ObservableProperty]
        private string _password;

        private bool _isUserDataAccepted;

        #region Commands
        [RelayCommand]
        async void Login()
        {
            if (!string.IsNullOrWhiteSpace(Email) && !string.IsNullOrWhiteSpace(Password) )
            {
                
                //calling api
                if (Email == "said@gmail.com" && Password == "qwer123")
                {
                    _isUserDataAccepted = true;
                } 
                else
                {
                    _isUserDataAccepted = false;
                }

               
                
                // saving state of login

                if (_isUserDataAccepted)
                {
                    var userDetails = new UserBasicInfo()
                    {
                        Email = Email,
                        Name = "Anton",
                        Surname = "Balmasov"
                    };

                    if (Preferences.ContainsKey(nameof(App.UserDetails)))
                    {
                        Preferences.Remove(nameof(App.UserDetails));
                    }
                    string userDetailStr = JsonConvert.SerializeObject(userDetails);
                    Preferences.Set(nameof(App.UserDetails), userDetailStr);
                    App.UserDetails = userDetails;
                    await Shell.Current.GoToAsync($"//{nameof(HomePage)}");
                }
            }



        }
        #endregion



    }
}
