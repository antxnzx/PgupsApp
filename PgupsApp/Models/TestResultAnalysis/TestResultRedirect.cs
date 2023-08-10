using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PgupsApp.Models.TestResultAnalysis
{
    public static class TestResultRedirect
    {
        public static readonly Dictionary<int, string> RoutesToResult = new Dictionary<int, string>()
        {
            {1, $"{nameof(Views.extensions.Testing.ResultTestMikhelsonaPage)}" },
            {2, $"{nameof(Views.extensions.Testing.TestWithOneCorrectAnswerPage)}" }
        };

    }
}
