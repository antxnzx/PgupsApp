using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PgupsApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PgupsApp.ViewModels.extensions.Dictionaries
{
    internal partial class AllDictionariesViewModel : BaseViewModel, IQueryAttributable
    {
        [ObservableProperty]
        private List<Dictionary> dictionaries = new();

        public AllDictionariesViewModel()
        {
            LoadData();
        }
        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            
        }

        private async void LoadData()
        {
            Dictionaries = await App.TestRepository.GetAllDictionaries();
        }

        [RelayCommand]
        public async Task GoToDict(Dictionary dict)
        {
            if (dict != null)
            {
                await Shell.Current.GoToAsync($"{nameof(Views.extensions.Dictionaries.CurrentDictionaryPage)}?id={dict.Id}");
            }
        }
    }
}
