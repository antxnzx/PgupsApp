using PgupsApp.Models;
using PgupsApp.Repositories;
using System.Reflection;

namespace PgupsApp;

public partial class App : Application
{
	public static UserBasicInfo UserDetails;
	public static TestRepository TestRepository {  get; private set; }
	public App(TestRepository repo)
	{
		InitializeComponent();

		MainPage = new AppShell();

		TestRepository = repo;

		Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping(nameof(Entry), (handler, view) =>
		{
#if __ANDROID__
			handler.PlatformView.SetBackgroundColor(Android.Graphics.Color.Transparent);
#elif __IOS__
			handler.PlatformView.BackgroundColor = UIKit.UIColor.Clear;
			handler.PlatformView.BorderStyle = UIKit.UITextBorderStyle.None;
#endif
		});
		
			
		
	}
}
