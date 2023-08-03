using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PgupsApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PgupsApp.ViewModels.extensions.Testing
{
    internal partial class SingleTestViewModel : BaseViewModel, IQueryAttributable
    { 
        [ObservableProperty]
        private Question currentQuestion;

        [ObservableProperty]
        private List<Answer> varAnswers = new();

        
        private int _questionNumber;


        private List<Question> questions = new();
        [ObservableProperty]
        private List<int> userAnswers = new();
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
        public async Task AnswerTheQuestion(string answerId)
        {
            UserAnswers.Add(Convert.ToInt32(answerId));
            if (_questionNumber == questions.Count - 1)
            {
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
