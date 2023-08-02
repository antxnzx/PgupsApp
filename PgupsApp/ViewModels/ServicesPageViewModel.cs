using CommunityToolkit.Mvvm.Input;
using PgupsApp.Views;
using PgupsApp.Views.extensions.Testing;

namespace PgupsApp.ViewModels
{
    public partial class ServicesPageViewModel : BaseViewModel
    {
        [RelayCommand]
        async void GoToGamePage()
        {
            await Shell.Current.GoToAsync($"{nameof(GamePage)}");
        }
        [RelayCommand]
        async Task GoToTestPage()
        {
            await Shell.Current.GoToAsync($"{nameof(AllTestsPage)}");
        }
    }
}
