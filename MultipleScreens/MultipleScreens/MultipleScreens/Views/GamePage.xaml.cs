using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MultipleScreens.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class GamePage : ContentPage
	{
		public GamePage ()
		{
			InitializeComponent ();
		}

		async void GoToLearnMore(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new LearnMore());
		}
	}
}
