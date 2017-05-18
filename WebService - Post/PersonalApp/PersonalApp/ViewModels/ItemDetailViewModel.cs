using PersonalApp.Models;

namespace PersonalApp.ViewModels
{
	public class ItemDetailViewModel : BaseViewModel
	{
		public Item Item { get; set; }
		public ItemDetailViewModel(Item item = null)
		{
			Title = "Item Detail";
			Item = item;
		}

		int quantity = 1;
		public int Quantity
		{
			get { return quantity; }
			set { SetProperty(ref quantity, value); }
		}
	}
}
