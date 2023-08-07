

namespace PgupsApp.Models.TestResultAnalysis
{
    public class AnalysisTestMikhelsona
    {
       
        public int Zavis;
        public int Competent;
        public int Agressive;
        public void CheckAnswers(List<Answer> userAnswers)
        {
            int percent = userAnswers.Count * 100;
            Zavis = userAnswers.Where(a => a.KeyForTrueAnswer == 1).Count();
            Competent = userAnswers.Where(a => a.KeyForTrueAnswer == 2).Count();
            Agressive = userAnswers.Where(a => a.KeyForTrueAnswer == 3).Count();
        }
    }
}
