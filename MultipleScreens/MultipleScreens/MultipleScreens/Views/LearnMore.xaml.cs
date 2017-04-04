using System;
using System.Diagnostics;
using System.Threading.Tasks;

using MultipleScreens.Helpers;
using MultipleScreens.Models;
using MultipleScreens.Views;

using Xamarin.Forms;

namespace MultipleScreens.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LearnMore : ContentPage
	{
		LearnMoreViewModel learnMoreViewModel;

		public LearnMore ()
		{
			InitializeComponent ();

			BindingContext = learnMoreViewModel = new LearnMoreViewModel();
		}
	}
}
