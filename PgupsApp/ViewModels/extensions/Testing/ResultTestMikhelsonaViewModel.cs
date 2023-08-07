using CommunityToolkit.Mvvm.ComponentModel;
using Newtonsoft.Json;
using PgupsApp.Models;
using PgupsApp.Models.TestResultAnalysis;

namespace PgupsApp.ViewModels.extensions.Testing
{
    internal partial class ResultTestMikhelsonaViewModel : BaseViewModel, IQueryAttributable
    { 
        private int[] userAnswers = new int[3] ;

        private AnalysisTestMikhelsona analysis = new();

        [ObservableProperty]
        private string percentZavis;

        [ObservableProperty]
        private string percentCompetent;

        [ObservableProperty]
        private string percentAgressive;

        public ResultTestMikhelsonaViewModel()
        {
            //analysis.CheckAnswers(userAnswers);
            //percentAgressive = analysis.Agressive + "%";
            //percentCompetent = analysis.Competent + "%";
            //percentZavis = analysis.Zavis + "%";
            PercentAgressive = userAnswers[2]+"%";
        }
        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            if (query.ContainsKey("result"))
            {
                userAnswers = query["result"] as int[];
                
            }
        }
    }
}
