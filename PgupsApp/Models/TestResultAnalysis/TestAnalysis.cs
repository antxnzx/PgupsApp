using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PgupsApp.Models.TestResultAnalysis
{
    public class TestAnalysis
    {
     
        public string CheckAnswers(string userAnswers)
        {
            int numberOfAnswers = userAnswers.Length;
            int correct = userAnswers.Where(e => e.ToString() == "1").Count();
            if (correct < 10)
            {
                return "0" + correct + numberOfAnswers;
            }
            return correct.ToString() + numberOfAnswers.ToString();
        }
            
    }
}
