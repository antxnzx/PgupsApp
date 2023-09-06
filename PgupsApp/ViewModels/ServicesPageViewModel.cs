using CommunityToolkit.Mvvm.Input;
using PgupsApp.Views.extensions.Dictionaries;
using PgupsApp.Views.extensions.Game;
using PgupsApp.Views.extensions.Testing;

namespace PgupsApp.ViewModels
{
    public partial class ServicesPageViewModel : BaseViewModel
    {
        [RelayCommand]
        async Task GoToGamePage()
        {
            await Shell.Current.GoToAsync($"{nameof(GameMenu)}");
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
