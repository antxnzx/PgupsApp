using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PgupsApp.Views;

namespace PgupsApp.ViewModels
{
    public partial class LoginPageViewModel : BaseViewModel
    {
        [ObservableProperty]
        private string _email;
        [ObservableProperty]
        private string _password;

        #region Commands
        [RelayCommand]
        async void Login()
        {
           await Shell.Current.GoToAsync($"//{nameof(HomePage)}");
        }
        #endregion



    }
}
