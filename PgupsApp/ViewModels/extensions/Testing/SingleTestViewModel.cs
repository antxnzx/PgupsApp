using PgupsApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PgupsApp.ViewModels.extensions.Testing
{
    class SingleTestViewModel : BaseViewModel, IQueryAttributable
    {
        public Test Test { get; set; }
        public SingleTestViewModel(Test t) 
        {
            Test = t;
        }
        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            throw new NotImplementedException();
        }
    }
}
