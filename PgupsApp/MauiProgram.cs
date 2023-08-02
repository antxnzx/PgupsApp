using Microsoft.Extensions.Logging;
using Microsoft.Maui.Storage;
using PgupsApp.Repositories;
using PgupsApp.ViewModels;
using PgupsApp.ViewModels.extensions.Testing;
using PgupsApp.Views;
using PgupsApp.Views.extensions.Testing;

namespace PgupsApp;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

#if DEBUG
		builder.Logging.AddDebug();
#endif
		//views
		builder.Services.AddSingleton<LoginPage>();
		builder.Services.AddSingleton<HomePage>();
		builder.Services.AddSingleton<LoadingPage>();
		builder.Services.AddSingleton<GamePage>();
		builder.Services.AddSingleton<ServicesPage>();
		builder.Services.AddSingleton<AllTestsPage>();

		//viewModels
		builder.Services.AddSingleton<LoginPageViewModel>();
		builder.Services.AddSingleton<HomePageViewModel>();
		builder.Services.AddSingleton<LoadingPageViewModel>();
		builder.Services.AddSingleton<GamePage>();
		builder.Services.AddSingleton<ServicesPageViewModel>();
		builder.Services.AddSingleton<AllTestsPageViewModel>();

        //databases
        string dbPath = TestRepository.DbPath;
        builder.Services.AddSingleton<TestRepository>(s => ActivatorUtilities.CreateInstance<TestRepository>(s, dbPath));


        return builder.Build();
	}
}
