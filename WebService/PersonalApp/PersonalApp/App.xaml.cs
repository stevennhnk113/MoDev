using PersonalApp.Views;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace PersonalApp
{
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();

			SetMainPage();
		}

		public static void SetMainPage()
		{
			Current.MainPage = new TabbedPage
			{
				Children =
				{
					new NavigationPage(new AboutMePage())
					{
						Title = "About Me",
						Icon = Device.OnPlatform<string>("tab_about.png",null,null)
					},
					new NavigationPage(new GamePage())
					{
						Title = "Game",
						Icon = Device.OnPlatform<string>("tab_feed.png",null,null)
					},
				}
			};
		}
	}
}
