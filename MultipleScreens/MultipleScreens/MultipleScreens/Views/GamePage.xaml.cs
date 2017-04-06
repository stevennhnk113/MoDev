using System;

using MultipleScreens.Models;
using MultipleScreens.ViewModels;

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

		async void GoToSeeScore(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new SeeScorePage());
		}

		async void ListCharacters(object sender, SelectedItemChangedEventArgs args)
		{
			await Navigation.PushAsync(new ListPage(new ListViewModel("Characters")));
		}

		async void ListMonsters(object sender, SelectedItemChangedEventArgs args)
		{
			await Navigation.PushAsync(new ListPage(new ListViewModel("Monsters")));
		}

		async void ListItems(object sender, SelectedItemChangedEventArgs args)
		{
			await Navigation.PushAsync(new ListPage(new ListViewModel("Items")));
		}

		async void ListInventory(object sender, SelectedItemChangedEventArgs args)
		{
			await Navigation.PushAsync(new ListPage(new ListViewModel("Inventory")));
		}
	}
}
