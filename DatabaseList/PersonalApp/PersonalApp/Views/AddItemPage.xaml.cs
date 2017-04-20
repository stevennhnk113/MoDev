using PersonalApp.Services;
using PersonalApp.Models;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PersonalApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AddItemPage : ContentPage
	{
		public Item Item { get; set; }

		ItemsDataAccess dataAccess;

		public AddItemPage(ItemsDataAccess dataAccess)
		{
			InitializeComponent();

			this.dataAccess = dataAccess;

			Item = new Item
			{
				ItemName = "Item name",
				Strength = 0,
				Health = 0,
				Speed = 0,
				Defense = 0
			};

			BindingContext = this;
		}

		async void Save_Clicked()
		{
			dataAccess.SaveItem(Item);
			MessagingCenter.Send<ContentPage>(this, "refresh");
			await Navigation.PopAsync();
		}
	}
}
