using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PgupsApp.Models.TestResultAnalysis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PgupsApp.ViewModels.extensions.Testing
{
    internal partial class TestWithOneCorrectAnswerViewModel : BaseViewModel, IQueryAttributable
    {
        private TestAnalysis analysis = new();

        [ObservableProperty]
        private string correctAnswers;

        [ObservableProperty]
        private string allQuestionsCount;
        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            if (query.ContainsKey("result"))
            {

                string answers = query["result"].ToString();

                string userAnswers = analysis.CheckAnswers(answers);

                FillResults(userAnswers);

            }
        }

        private void FillResults(string a)
        {
            CorrectAnswers = a[0].ToString() + a[1].ToString();
            AllQuestionsCount = a[2].ToString() + a[3].ToString();
        }

        [RelayCommand]
        public async Task ExitFromTest()
        {
            await Shell.Current.GoToAsync($"../..");
        }
    }
}
