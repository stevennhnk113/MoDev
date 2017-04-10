using System;
using System.Diagnostics;
using System.Threading.Tasks;

using MultipleScreens.Helpers;
using MultipleScreens.Models;
using MultipleScreens.Views;

using Xamarin.Forms;

namespace MultipleScreens.ViewModels
{
	public class ListViewModel : BaseViewModel
	{
		public ObservableRangeCollection<Item> Items { get; set; }
		public Command LoadItemsCommand { get; set; }

		public ListViewModel()
		{

		}

		public ListViewModel (string title)
		{
			Title = title;
			Items = new ObservableRangeCollection<Item>();
			LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
		}

		async Task ExecuteLoadItemsCommand()
		{
			if (IsBusy)
				return;

			IsBusy = true;
			try
			{
				Items.Clear();
				var items = await DataStore.GetItemsAsync(true);
				Items.ReplaceRange(items);
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex);
				MessagingCenter.Send(new MessagingCenterAlert
				{
					Title = "Error",
					Message = "Unable to load items.",
					Cancel = "OK"
				}, "message");
			}
			finally
			{
				IsBusy = false;
			}
		}
	}

}
