using CommunityToolkit.Mvvm.Input;
using PgupsApp.Views;


namespace PgupsApp.ViewModels
{
    public partial class ServicesPageViewModel : BaseViewModel
    {
        [RelayCommand]
        async void GoToGamePage()
        {
            await Shell.Current.GoToAsync($"{nameof(GamePage)}");
        }
    }
}
