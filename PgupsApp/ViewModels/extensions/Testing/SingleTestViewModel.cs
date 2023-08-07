using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Newtonsoft.Json;
using PgupsApp.Models;
using PgupsApp.Models.TestResultAnalysis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace PgupsApp.ViewModels.extensions.Testing
{
    internal partial class SingleTestViewModel : BaseViewModel, IQueryAttributable
    { 
        [ObservableProperty]
        private Question currentQuestion;

        [ObservableProperty]
        private List<Answer> varAnswers = new();

        private AnalysisTestMikhelsona analysis = new();
        
        private int _questionNumber;


        private List<Question> questions = new();
    
        public List<Answer> userAnswers = new();
        public int TestId { get; set; }

        //public SingleTestViewModel(Test t) 
        //{
        //    Test = t;
        //}
        public SingleTestViewModel()
        {
            
        }
        public async void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            if (query.ContainsKey("load"))
            {

                TestId = Convert.ToInt32(query["load"]);
                questions = await App.TestRepository.GetAllQuestions(TestId);
                _questionNumber = 0;
                await GetAnswers();

            }
        }

        private async Task GetAnswers()
        {
            CurrentQuestion = questions[_questionNumber];
            VarAnswers = await App.TestRepository.GetAnswersForCurrent(TestId, CurrentQuestion.Id);
        }

        [RelayCommand]
        public async Task AnswerTheQuestion(Answer answer)
        {
            userAnswers.Add(answer);
            if (_questionNumber == questions.Count - 1)
            {
                analysis.CheckAnswers(userAnswers);
                int[] answers = new int[3] { analysis.Zavis, analysis.Competent, analysis.Agressive };
                await Shell.Current.GoToAsync($"{nameof(Views.extensions.Testing.ResultTestMikhelsonaPage)}?result={answers}");
                return;
            }
            else
            {
                _questionNumber++;
                await GetAnswers();

            }
        }
    }
}
