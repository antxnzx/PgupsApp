using PgupsApp.Views;
using PgupsApp.Views.extensions.Testing;
using PgupsApp.Views.extensions.Dictionaries;
using PgupsApp.Views.extensions.Game;

namespace PgupsApp;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		Routing.RegisterRoute(nameof(HomePage), typeof(HomePage));
		Routing.RegisterRoute(nameof(GamePage16), typeof(GamePage16));
		Routing.RegisterRoute(nameof(GamePage25), typeof(GamePage25));
		Routing.RegisterRoute(nameof(GamePage36), typeof(GamePage36));
		Routing.RegisterRoute(nameof(GameMenu), typeof(GameMenu));
		Routing.RegisterRoute(nameof(GameResultPage), typeof(GameResultPage));
		Routing.RegisterRoute(nameof(AllTestsPage), typeof(AllTestsPage));
		Routing.RegisterRoute(nameof(SingleTest), typeof(SingleTest));
        Routing.RegisterRoute(nameof(ResultTestMikhelsonaPage), typeof(ResultTestMikhelsonaPage));
		Routing.RegisterRoute(nameof(TestWithOneCorrectAnswerPage), typeof(TestWithOneCorrectAnswerPage));
		Routing.RegisterRoute(nameof(AllDictionariesPage), typeof(AllDictionariesPage));
		Routing.RegisterRoute(nameof(CurrentDictionaryPage), typeof(CurrentDictionaryPage));
		Routing.RegisterRoute(nameof(LetterPage), typeof(LetterPage));
    }
}
