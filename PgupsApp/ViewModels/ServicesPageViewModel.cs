using CommunityToolkit.Mvvm.Input;
using PgupsApp.Views;
using PgupsApp.Views.extensions.Dictionaries;
using PgupsApp.Views.extensions.Testing;

namespace PgupsApp.ViewModels
{
    public partial class ServicesPageViewModel : BaseViewModel
    {
        [RelayCommand]
        async Task GoToGamePage()
        {
            await Shell.Current.GoToAsync($"{nameof(GamePage)}");
        }

        [RelayCommand]
        async Task GoToTestPage()
        {
            await Shell.Current.GoToAsync($"{nameof(AllTestsPage)}");
        } 
        [RelayCommand]
        async Task GoToDictPage()
        {
            await Shell.Current.GoToAsync($"{nameof(AllDictionariesPage)}");
        }
    }
}
