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
			if (!dataAccess.TestMode)
			{
				InitializeComponent();
				BindingContext = this;
			}

			this.dataAccess = dataAccess;

			Item = new Item
			{
				ItemName = "Item name",
				Strength = 0,
				Dexterity = 0,
				Speed = 0,
				Defense = 0
			};

			
		}

		async void Save_Clicked()
		{
			dataAccess.SaveItem(Item);
			MessagingCenter.Send<ContentPage>(this, "refresh");
			await Navigation.PopAsync();
		}

		public void TestSave_Clicked()
		{
			dataAccess.SaveItem(Item);
		}
	}
}
