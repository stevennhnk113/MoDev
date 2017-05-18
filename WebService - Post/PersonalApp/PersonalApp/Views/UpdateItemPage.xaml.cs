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

		public Item Item { get; set; }

		// Note - The Xamarin.Forms Previewer requires a default, parameterless constructor to render a page.
		public UpdateItemPage()
		{
			InitializeComponent();
		}

		public UpdateItemPage(Item item, ItemsDataAccess dataAccess)
		{
			if (!dataAccess.TestMode)
			{
				InitializeComponent();
				BindingContext = this;
			}

			this.dataAccess = dataAccess;
			this.Item = item;
		}

		async void UpdateItem_Clicked()
		{
			dataAccess.SaveItem(Item);
			MessagingCenter.Send<ContentPage>(this, "refresh");
			await Navigation.PopAsync();
		}

		public void TestUpdateItem_Clicked()
		{
			dataAccess.SaveItem(Item);
		}
	}
}


