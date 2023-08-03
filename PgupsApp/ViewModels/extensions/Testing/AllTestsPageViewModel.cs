using PgupsApp.Models;

using System.Collections.ObjectModel;

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace PgupsApp.ViewModels.extensions.Testing
{
    internal partial class AllTestsPageViewModel : BaseViewModel, IQueryAttributable
    {

        [ObservableProperty]
        private List<Test> testsInfo = new();

        

        public AllTestsPageViewModel()
        {
            LoadData();

        }

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {

        }

        public async void LoadData()
        {
            TestsInfo = await App.TestRepository.GetAllTests();
            //foreach (Test test in tests)
            //{
            //    var vm = new SingleTestViewModel(test);
            //    AllTests.Add(vm);
            //}
        }
        [RelayCommand]
        public async Task GoToTest(Test test) 
        {
            if (test != null)
            {
                await Shell.Current.GoToAsync($"{nameof(Views.extensions.Testing.SingleTest)}?load={test.Id}");
                
            }
        }

    }
}
