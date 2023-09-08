using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PgupsApp.Views.extensions.Game;


namespace PgupsApp.ViewModels.extensions.Game
{
    internal partial class GameMenuViewModel : BaseViewModel, IQueryAttributable
    {
        [ObservableProperty]
        private int gridSize;
        [ObservableProperty]
        private int difficulty;
        [ObservableProperty]
        private bool isEnterDenied = false;
        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            
        }

        [RelayCommand]
        public async Task StartGame()
        {
            if (GridSize > 0 && Difficulty > 0)
            {
                IsEnterDenied = false;
                switch (GridSize)
                {
                    case 1:
                        await Shell.Current.GoToAsync($"{nameof(GamePage16)}?difficulty={Difficulty}&gridSize={GridSize}");
                        break;

                    case 2:
                        await Shell.Current.GoToAsync($"{nameof(GamePage25)}?difficulty={Difficulty}&gridSize={GridSize}");
                        break;

                    case 3:
                        await Shell.Current.GoToAsync($"{nameof(GamePage36)}?difficulty={Difficulty}&gridSize={GridSize}");
                        break;
                }
            }
            else
            {
               IsEnterDenied = true;
            }
        }
    }
}
