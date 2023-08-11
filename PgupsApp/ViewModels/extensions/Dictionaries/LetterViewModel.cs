using CommunityToolkit.Mvvm.ComponentModel;
using PgupsApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PgupsApp.ViewModels.extensions.Dictionaries
{
    internal partial class LetterViewModel : BaseViewModel, IQueryAttributable
    {
        [ObservableProperty]
        private List<AbbreviationModel> abbreviations = new();


        public async void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            if (query.ContainsKey("letter") && query.ContainsKey("dictId"))
            {

                int dictId = Convert.ToInt32(query["dictId"].ToString());

                string letter = query["letter"].ToString();

                Abbreviations = await App.TestRepository.GetAllAbbreviations(letter, dictId);
                

            }
        }
    }
}
