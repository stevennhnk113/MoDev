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
			await Navigation.PushAsync(new CharactersListPage(new ListViewModel("Characters")));
		}

		async void ListMonsters(object sender, SelectedItemChangedEventArgs args)
		{
			await Navigation.PushAsync(new MonstersListPage(new ListViewModel("Monsters")));
		}

		async void ListItems(object sender, SelectedItemChangedEventArgs args)
		{
			await Navigation.PushAsync(new ItemsListPage(new ListViewModel("Items")));
		}

		async void ListInventory(object sender, SelectedItemChangedEventArgs args)
		{
			await Navigation.PushAsync(new InventoryPage(new ListViewModel("Inventory")));
		}

		async void GoToBattle(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new BattlePage());
		}

	}
}
