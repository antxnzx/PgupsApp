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

        [ObservableProperty]
        private int currentNumber;
        
        private int _questionNumber;


        private List<Question> questions = new();
    
        public string userAnswers;
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
                CurrentNumber = _questionNumber + 1;
                await GetAnswers();

            }
        }

        private async Task GetAnswers()
        {
            CurrentQuestion = questions[_questionNumber];
            VarAnswers = await App.TestRepository.GetAnswersForCurrent(TestId, CurrentNumber);
        }

        [RelayCommand]
        public async Task AnswerTheQuestion(Answer answer)
        {
            userAnswers = userAnswers + answer.KeyForTrueAnswer;
            if (_questionNumber == questions.Count - 1)
            {
                
                await Shell.Current.GoToAsync($"{TestResultRedirect.RoutesToResult[TestId]}?result={userAnswers}");
                return;
            }
            else
            {
                _questionNumber++;
                CurrentNumber = _questionNumber + 1;
                await GetAnswers();

            }
        }
    }
}
