using PersonalApp.ViewModels;
using PersonalApp.Models;
using PersonalApp.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PersonalApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class UpdateItemPage : ContentPage
	{
		ItemDetailViewModel viewModel;

		ItemsDataAccess dataAccess;

		Item item;

		// Note - The Xamarin.Forms Previewer requires a default, parameterless constructor to render a page.
		public UpdateItemPage()
		{
			InitializeComponent();
		}

		public UpdateItemPage(Item item, ItemsDataAccess dataAccess)
		{
			InitializeComponent();

			this.dataAccess = dataAccess;
			this.item = item;

			BindingContext = this;
		}

		async void UpdateItem_Clicked()
		{
			dataAccess.SaveItem(item);
			MessagingCenter.Send<ContentPage>(this, "refresh");
			await Navigation.PopAsync();
		}
	}
}


