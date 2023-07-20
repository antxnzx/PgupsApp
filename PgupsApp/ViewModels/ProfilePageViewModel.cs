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
        [RelayCommand]
        async void SignOut()
        {
            await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
        }
    }
}
