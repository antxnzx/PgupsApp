using Microsoft.Extensions.Logging;
using Microsoft.Maui.Storage;
using PgupsApp.Repositories;
using PgupsApp.ViewModels;
using PgupsApp.ViewModels.extensions.Testing;
using PgupsApp.Views;
using PgupsApp.Views.extensions.Testing;
using System.Reflection;

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
		builder.Services.AddSingleton<SingleTest>();
		builder.Services.AddSingleton<ResultTestMikhelsonaPage>();

		//viewModels
		builder.Services.AddSingleton<LoginPageViewModel>();
		builder.Services.AddSingleton<HomePageViewModel>();
		builder.Services.AddSingleton<LoadingPageViewModel>();
		builder.Services.AddSingleton<GamePage>();
		builder.Services.AddSingleton<ServicesPageViewModel>();
		builder.Services.AddSingleton<AllTestsPageViewModel>();
		builder.Services.AddSingleton<SingleTestViewModel>();
		builder.Services.AddSingleton<ResultTestMikhelsonaViewModel>();

        //databases
        builder.Services.AddTransient<TestRepository>((services) =>
        {
            var filenameDb = Path.Combine(FileSystem.AppDataDirectory, "apptests.db");
			if (!File.Exists(filenameDb))
			{
				
				using var stream = FileSystem.OpenAppPackageFileAsync("tests.db").GetAwaiter().GetResult();
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
