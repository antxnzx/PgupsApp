using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PgupsApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PgupsApp.ViewModels
{
    internal class NumberGameViewModel : ObservableObject
    {
        public int[] Buttons { get; set; }
        NumberGameModel Game { get; set; }
        public ICommand StartGameCommand { get; }
        public ICommand NextStepCommand { get; }

        public NumberGameViewModel()
        {
            Game = new NumberGameModel(16);
            NextStepCommand = new RelayCommand<string>(NextStep);
            StartGameCommand = new RelayCommand(StartGame);
            Buttons = new int[16];
        }

        private void StartGame()
        {
            Game.RefreshNumbers();
            Buttons = Game.numbers;
            Game.CorrectAnswer = 1;
            OnPropertyChanged(nameof(Buttons));
        }

        private void NextStep(string number)
        {
            Game.CheckAnswer(number);
            Buttons = Game.numbers;
            OnPropertyChanged(nameof(Buttons));
        }
    }
}
