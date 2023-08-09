using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Newtonsoft.Json;
using PgupsApp.Models;
using PgupsApp.Views;


namespace PgupsApp.ViewModels
{
    public partial class LoginPageViewModel : BaseViewModel
    {
        [ObservableProperty]
        private string emailLog;
        [ObservableProperty]
        private string password;

        private bool _isUserDataAccepted;

        #region Commands
        [RelayCommand]
        async Task Login()
        {
            if (!string.IsNullOrWhiteSpace(EmailLog) && !string.IsNullOrWhiteSpace(Password) )
            {
                
                //calling api
                if (EmailLog == "said@gmail.com" && Password == "qwer123")
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
                        Email = EmailLog,
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
