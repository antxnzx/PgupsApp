namespace PgupsApp.Views.extensions.Game;

public partial class GameResultPage : ContentPage
{
	public GameResultPage()
	{
		InitializeComponent();
	}

    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        OnBackButtonPressed();
    }
    protected override bool OnBackButtonPressed()
    {
        return true;
    }
}