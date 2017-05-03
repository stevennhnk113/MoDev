using System;

using PersonalApp.Models;
using PersonalApp.ViewModels;
using PersonalApp.Services;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PersonalApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class GamePage : ContentPage
	{
		public GamePage()
		{
			InitializeComponent();
		}

		async void GoToSeeScore(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new SeeScorePage());
		}

		async void ListCharacters(object sender, SelectedItemChangedEventArgs args)
		{
			await Navigation.PushAsync(new CharactersListPage());
		}

		async void ListMonsters(object sender, SelectedItemChangedEventArgs args)
		{
			await Navigation.PushAsync(new MonstersListPage());
		}

		async void ListItems(object sender, SelectedItemChangedEventArgs args)
		{
			await Navigation.PushAsync(new ItemsListPage());
		}

		async void ListInventory(object sender, SelectedItemChangedEventArgs args)
		{
			await Navigation.PushAsync(new InventoryPage());
		}

		async void GoToBattle(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new BattlePage());
		}

	}
}

