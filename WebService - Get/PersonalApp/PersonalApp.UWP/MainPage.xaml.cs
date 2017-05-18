namespace PersonalApp.UWP
{
	public sealed partial class MainPage
	{
		public MainPage()
		{
			this.InitializeComponent();
			LoadApplication(new PersonalApp.App());
		}
	}
}