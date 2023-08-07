using PgupsApp.Views;
using PgupsApp.Views.extensions.Testing;

namespace PgupsApp;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		Routing.RegisterRoute(nameof(HomePage), typeof(HomePage));
		Routing.RegisterRoute(nameof(GamePage), typeof(GamePage));
		Routing.RegisterRoute(nameof(AllTestsPage), typeof(AllTestsPage));
		Routing.RegisterRoute(nameof(SingleTest), typeof(SingleTest));
        Routing.RegisterRoute(nameof(ResultTestMikhelsonaPage), typeof(ResultTestMikhelsonaPage));
    }
}
