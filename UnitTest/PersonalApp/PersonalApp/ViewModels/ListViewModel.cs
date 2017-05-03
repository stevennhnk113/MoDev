using System;
using System.Diagnostics;
using System.Threading.Tasks;

using PersonalApp.Services;
using PersonalApp.Helpers;
using PersonalApp.Models;
using PersonalApp.Views;
using PersonalApp;

using Xamarin.Forms;

namespace PersonalApp.ViewModels
{
	public class ListViewModel : BaseViewModel
	{
		public ObservableRangeCollection<Item> Items { get; set; }
		public Command LoadItemsCommand { get; set; }

		ItemsDataAccess dataAccess;

		public ListViewModel()
		{

		}

		public ListViewModel(string title, ItemsDataAccess dataAccess)
		{
			Title = title;
			Items = new ObservableRangeCollection<Item>();
			dataAccess = new ItemsDataAccess();
			LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
			this.dataAccess = dataAccess;

			MessagingCenter.Subscribe<ContentPage>(this, "refresh", (sender) => {
				ExecuteLoadItemsCommand();
			});
		}

		async Task ExecuteLoadItemsCommand()
		{
			if (IsBusy)
				return;

			IsBusy = true;
			try
			{
				Items.Clear();
				var items = dataAccess.GetAllItem();
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

