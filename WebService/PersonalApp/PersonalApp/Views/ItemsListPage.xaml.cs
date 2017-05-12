using System;

using PersonalApp.Models;
using PersonalApp.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PersonalApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ItemsListPage : ContentPage
	{
		ListViewModel viewModel;
		ItemsDataAccess dataAccess;

		public ItemsListPage()
		{
			InitializeComponent();

			dataAccess = new ItemsDataAccess();

			BindingContext = this.viewModel = new ListViewModel("Items", dataAccess);

			MessagingCenter.Send<ContentPage>(this, "refresh");
		}

		async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
		{

			var item = args.SelectedItem as Item;
			if (item == null)
				return;

			await Navigation.PushAsync(new ItemDetailPage(item, dataAccess));

			// Manually deselect item
			ItemsListView1.SelectedItem = null;
			ItemsListView2.SelectedItem = null;
			ItemsListView3.SelectedItem = null;
		}

		async void AddItem_Clicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new AddItemPage(dataAccess));
		}
	}
}