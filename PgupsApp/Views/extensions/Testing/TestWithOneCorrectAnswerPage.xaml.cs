namespace PgupsApp.Views.extensions.Testing;

public partial class TestWithOneCorrectAnswerPage : ContentPage
{
	public TestWithOneCorrectAnswerPage()
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