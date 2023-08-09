

namespace PgupsApp.Models.TestResultAnalysis
{
    public class AnalysisTestMikhelsona
    {
       
        
        public string CheckAnswers(string userAnswers)
        {
            return GetPercentOfAnswers(userAnswers, 1) + GetPercentOfAnswers(userAnswers, 2) +
                GetPercentOfAnswers(userAnswers, 3);
        }

        private string GetPercentOfAnswers(string userAnswers, int f)
        {
            int amountOfCorrect = userAnswers.Where(a => Convert.ToInt32(a.ToString()) == f).Count();
            int amountOfAll = userAnswers.Length;
            float percent = (amountOfCorrect * 100 / amountOfAll);
            if (percent < 10) 
            {
                return "0" + Math.Round(percent).ToString();
            }
            else if (percent == 100)
            {
                return "99";
            }
            else
            {
                return Math.Round(percent).ToString();
                
            }

        }
    }
}
