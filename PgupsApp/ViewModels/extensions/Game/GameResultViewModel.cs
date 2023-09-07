using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PgupsApp.ViewModels.extensions.Game
{
    internal partial class GameResultViewModel : BaseViewModel, IQueryAttributable
    {
        [ObservableProperty]
        private string resultOfTest;

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            if (query.ContainsKey("result"))
            {

                ResultOfTest = TimeSpan.Parse(query["result"].ToString()).ToString(@"hh\:mm\:ss\.ff");
            }
        }
        [RelayCommand]
        public async Task ExitFromGame()
        {
            await Shell.Current.GoToAsync($"../../..");
        }
    }
}
