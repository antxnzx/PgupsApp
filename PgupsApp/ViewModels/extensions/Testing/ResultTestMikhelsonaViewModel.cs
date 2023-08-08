using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Newtonsoft.Json;
using PgupsApp.Models;
using PgupsApp.Models.TestResultAnalysis;
using PgupsApp.Views;

namespace PgupsApp.ViewModels.extensions.Testing
{
    internal partial class ResultTestMikhelsonaViewModel : BaseViewModel, IQueryAttributable
    { 
        private string userAnswers;

        [ObservableProperty]
        private string percentZavis;

        [ObservableProperty]
        private string percentCompetent;

        [ObservableProperty]
        private string percentAgressive;

        [ObservableProperty]
        private string gradeZavis;

        [ObservableProperty]
        private string gradeCompetent;

        [ObservableProperty]
        private string gradeAgressive;

        public ResultTestMikhelsonaViewModel()
        {
                        
        }
        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            if (query.ContainsKey("result"))
            {
                userAnswers = query["result"].ToString();


                CalculatePercentAndGrade();
            }
        }

        [RelayCommand]
        public async Task ExitFromTest()
        {
            await Shell.Current.GoToAsync($"../..");
        }
        private void CalculatePercentAndGrade()
        {
            string zavis = userAnswers[0].ToString() + userAnswers[1].ToString();
            string compet = userAnswers[2].ToString() + userAnswers[3].ToString();
            string agr = userAnswers[4].ToString() + userAnswers[5].ToString();

            GradeZavis = CalculateGrade(zavis);
            GradeCompetent = CalculateGrade(compet);
            GradeAgressive = CalculateGrade(agr);

            PercentZavis = zavis + "%";
            PercentCompetent = compet + "%";
            PercentAgressive = agr + "%";
        }

        private string CalculateGrade(string stringgrade)
        {
            int s = Convert.ToInt32(stringgrade);
            if ( s >= 74 && s <= 100) 
            {
                return "Выскоий уровень";
            }
            else if (s >= 66 && s < 74)
            {
                return "Выше среднего";
            }
            else if (s >= 51 && s < 66)
            {
                return "Средний уровень";
            }
            else if (s >= 40 && s < 51)
            {
                return "Ниже среднего";
            } 
            else if(s >= 0 && s < 40)
            {
                return "Низкий уровень";
            }
            else
            {
                return "Не определено";
            }
        }
    }
}
