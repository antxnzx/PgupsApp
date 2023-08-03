using PgupsApp.Models;
using PgupsApp.Repositories;
using System.Collections.ObjectModel;

namespace PgupsApp.Views.extensions.Testing;

public partial class AllTestsPage : ContentPage
{
	
	public AllTestsPage()
	{
		InitializeComponent();
		
	}

    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
		testList.SelectedItem = null;
    }
}