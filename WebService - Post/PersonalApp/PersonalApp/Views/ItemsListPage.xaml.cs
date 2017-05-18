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
			dataAccess = new ItemsDataAccess();
			BindingContext = this.viewModel = new ListViewModel("Items", dataAccess);
			MessagingCenter.Send<ContentPage>(this, "refresh");

			InitializeComponent();
		}

		async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
		{

			var item = args.SelectedItem as Item;
			if (item == null)
				return;

			await Navigation.PushAsync(new ItemDetailPage(item, dataAccess));

			// Manually deselect item
			ItemsListView.SelectedItem = null;
		}

		async void AddItem_Clicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new AddItemPage(dataAccess));
		}

		void Send()
		{
			viewModel.PostAndGet();
			MessagingCenter.Send<ContentPage>(this, "refresh");
		}

		void OnPickerSelectedIndexChanged(object sender, EventArgs e)
		{
			var picker = (Picker)sender;
			int selectedIndex = picker.SelectedIndex;

			if (selectedIndex != -1)
			{
				viewModel.Character.Type = picker.Items[selectedIndex];
			}
		}

	}
}