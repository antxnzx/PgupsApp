namespace PgupsApp.Views.extensions.Dictionaries;

public partial class AllDictionariesPage : ContentPage
{
	public AllDictionariesPage()
	{
		InitializeComponent();
	}

    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        dictList.SelectedItem = null;
    }
}