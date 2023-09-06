using Microsoft.Extensions.Logging;

using PgupsApp.Repositories;
using PgupsApp.ViewModels;
using PgupsApp.ViewModels.extensions.Dictionaries;
using PgupsApp.ViewModels.extensions.Game;
using PgupsApp.ViewModels.extensions.Testing;
using PgupsApp.Views;
using PgupsApp.Views.extensions.Dictionaries;
using PgupsApp.Views.extensions.Game;
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
		builder.Services.AddSingleton<ServicesPage>();

		builder.Services.AddSingleton<GameMenu>();
		builder.Services.AddSingleton<GamePage16>();
		builder.Services.AddSingleton<GamePage25>();
		builder.Services.AddSingleton<GamePage36>();
		builder.Services.AddSingleton<GameResultPage>();

		builder.Services.AddSingleton<AllTestsPage>();
		builder.Services.AddSingleton<SingleTest>();
		builder.Services.AddSingleton<ResultTestMikhelsonaPage>();
		builder.Services.AddSingleton<TestWithOneCorrectAnswerPage>();

		builder.Services.AddSingleton<AllDictionariesPage>();
		builder.Services.AddSingleton<CurrentDictionaryPage>();
		builder.Services.AddSingleton<LetterPage>();

		//viewModels
		builder.Services.AddSingleton<LoginPageViewModel>();
		builder.Services.AddSingleton<HomePageViewModel>();
		builder.Services.AddSingleton<LoadingPageViewModel>();
		builder.Services.AddSingleton<ServicesPageViewModel>();

		builder.Services.AddSingleton<GameMenuViewModel>();
		builder.Services.AddTransient<NumberGameViewModel>();
		builder.Services.AddSingleton<GameResultViewModel>();
		
		builder.Services.AddSingleton<AllTestsPageViewModel>();
		builder.Services.AddTransient<SingleTestViewModel>();
		builder.Services.AddSingleton<ResultTestMikhelsonaViewModel>();
		builder.Services.AddSingleton<TestWithOneCorrectAnswerViewModel>();

        builder.Services.AddSingleton<AllDictionariesViewModel>();
        builder.Services.AddTransient<CurrentDictionaryViewModel>();
        builder.Services.AddTransient<LetterViewModel>();

        //databases
        builder.Services.AddTransient<TestRepository>((services) =>
        {
            var filenameDb = Path.Combine(FileSystem.AppDataDirectory, "apptests.db");
			if (!File.Exists(filenameDb))
			{
				
				using var stream = FileSystem.OpenAppPackageFileAsync("presetdata.db").GetAwaiter().GetResult();
                using (var memoryStream = new MemoryStream())
                {
                    stream.CopyTo(memoryStream);
                    File.WriteAllBytes(filenameDb, memoryStream.ToArray());
                }
            }
            return new TestRepository(filenameDb);
        });

        return builder.Build();
	}
}
