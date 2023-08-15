namespace PgupsApp.Views.extensions.Testing;

public partial class ResultTestMikhelsonaPage : ContentPage
{
	public ResultTestMikhelsonaPage()
	{
		InitializeComponent();
	}

    protected override bool OnBackButtonPressed()
    {
        return true;
    }

    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        OnBackButtonPressed();
    }
}