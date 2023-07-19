using CommunityToolkit.Mvvm.Input;
using PgupsApp.Views;

namespace PgupsApp.ViewModels
{
    public partial class LoginPageViewModel : BaseViewModel
    {
        #region Commands
        [RelayCommand]
        async void Login()
        {
           await Shell.Current.GoToAsync($"//{nameof(HomePage)}");
        }
        #endregion



    }
}
