using CommunityToolkit.Mvvm.ComponentModel;
using PgupsApp.Models;


namespace PgupsApp.ViewModels.extensions.Dictionaries
{
    internal partial class LetterViewModel : BaseViewModel, IQueryAttributable
    {
        [ObservableProperty]
        private List<AbbreviationModel> abbreviations = new();

        [ObservableProperty]
        private string letterName;


        public async void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            if (query.ContainsKey("letter") && query.ContainsKey("dictId"))
            {

                int dictId = Convert.ToInt32(query["dictId"].ToString());
                int letter = Convert.ToInt32(query["letter"].ToString());

                LetterName = Alphabet.Dictionary[letter];

                Abbreviations = await App.TestRepository.GetAllAbbreviations(letter, dictId);
                

            }
        }
    }
}
