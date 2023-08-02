using PgupsApp.Models;
using PgupsApp.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PgupsApp.ViewModels.extensions.Testing
{
    internal class AllTestsPageViewModel : IQueryAttributable
    {
        public TestRepository TestRepository = new TestRepository();
        public ObservableCollection<SingleTestViewModel> AllTests { get; set; }


        public AllTestsPageViewModel() 
        {
           AllTests = new ObservableCollection<SingleTestViewModel>(((IEnumerable<Test>)TestRepository.GetAllTests()).Select(t => new SingleTestViewModel(t))); 
        }
        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            throw new NotImplementedException();
        }


    }
}
