using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PgupsApp.Models;
using PgupsApp.Views.extensions.Game;
using System.Windows.Input;

namespace PgupsApp.ViewModels.extensions.Game
{
    internal partial class NumberGameViewModel : BaseViewModel, IQueryAttributable
    {
        [ObservableProperty]
        private bool isGameStarted;
        [ObservableProperty]
        private int[] buttons;
        private NumberGameModel Game;
        private bool isGameFinished;
        private DateTime startTime;
        private DateTime endTime;

        public NumberGameViewModel()
        {
            
        }
        [RelayCommand]
        private void StartGame()
        {
            if (!IsGameStarted)
            {
                startTime = DateTime.Now;
                IsGameStarted = true;
                Game.RefreshNumbers();
                Buttons = Game.GetNumbers(); 
            }

        }
        [RelayCommand]
        private async Task NextStep(string number)
        {
            if (IsGameStarted)
            {
                isGameFinished = Game.CheckAnswer(number);
                Buttons = Game.GetNumbers();
                if (isGameFinished)
                {
                    endTime = DateTime.Now;
                    var playingTime = endTime - startTime;
                    await Shell.Current.GoToAsync($"{nameof(GameResultPage)}?result={playingTime}");
                }
            }
        }


        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            if (query.ContainsKey("difficulty") && query.ContainsKey("gridSize"))
            {
                int gridSize = Convert.ToInt32(query["gridSize"]);
                int difficulty = Convert.ToInt32(query["difficulty"]);
                IsGameStarted = false;
                switch (gridSize)
                {
                    case 1:
                        Game = new NumberGameModel(16, difficulty);
                        Buttons = new int[16];
                        break;
                    case 2:
                        Game = new NumberGameModel(25, difficulty);
                        Buttons = new int[25];
                        break;
                    case 3:
                        Game = new NumberGameModel(36, difficulty);
                        Buttons = new int[36];
                        break;
                    default:
                        break;
                }

            }
        }
    }
}
