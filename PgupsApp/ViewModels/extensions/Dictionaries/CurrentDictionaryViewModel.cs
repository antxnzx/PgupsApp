using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PgupsApp.Models;
using PgupsApp.Views.extensions.Dictionaries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PgupsApp.ViewModels.extensions.Dictionaries
{
    internal partial class CurrentDictionaryViewModel : BaseViewModel, IQueryAttributable
    {
        [ObservableProperty]
        string name;

        private int dictId;


        [RelayCommand]
        public async Task GoToLetterPage(string letter)
        {
            await Shell.Current.GoToAsync($"{nameof(LetterPage)}?letter={letter}&dictId={dictId}");
        }

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            if (query.ContainsKey("id"))
            {

                dictId = Convert.ToInt32(query["id"].ToString());

                if(query.ContainsKey("name"))
                {
                    Name = query["name"].ToString();
                }

            }
        }
    }
}
