

namespace PgupsApp.Models.TestResultAnalysis
{
    public class AnalysisTestMikhelsona
    {
       
        
        public string CheckAnswers(List<Answer> userAnswers)
        {
            return GetPercentOfAnswers(userAnswers, 1) + GetPercentOfAnswers(userAnswers, 2) +
                GetPercentOfAnswers(userAnswers, 3);
        }

        private string GetPercentOfAnswers(List<Answer> userAnswers, int f)
        {
            int amountOfCorrect = userAnswers.Where(a => a.KeyForTrueAnswer == f).Count();
            int amountOfAll = userAnswers.Count();
            float percent = (amountOfCorrect * 100 / amountOfAll);

            return Math.Round(percent).ToString();
        }
    }
}
