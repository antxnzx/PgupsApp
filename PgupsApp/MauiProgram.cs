using Microsoft.Extensions.Logging;
using PgupsApp.ViewModels;
using PgupsApp.Views;

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

		//viewModels
		builder.Services.AddSingleton<LoginPageViewModel>();
		builder.Services.AddSingleton<HomePageViewModel>();
		builder.Services.AddSingleton<LoadingPageViewModel>();
		builder.Services.AddSingleton<GamePage>();

		return builder.Build();
	}
}
