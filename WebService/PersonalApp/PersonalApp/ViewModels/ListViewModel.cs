using System;
using System.Diagnostics;
using System.Threading.Tasks;

using PersonalApp.Services;
using PersonalApp.Helpers;
using PersonalApp.Models;
using System.Collections.Generic;
using PersonalApp.Views;
using PersonalApp;

using Xamarin.Forms;

namespace PersonalApp.ViewModels
{
	public class ListViewModel : BaseViewModel
	{
		public ObservableRangeCollection<Item> Items1 { get; set; }
		public ObservableRangeCollection<Item> Items2 { get; set; }
		public ObservableRangeCollection<Item> Items3 { get; set; }
		public Command LoadItemsCommand { get; set; }

		ItemsDataAccess dataAccess;

		public ListViewModel()
		{

		}

		public ListViewModel(string title, ItemsDataAccess dataAccess)
		{
			Title = title;
			Items1 = new ObservableRangeCollection<Item>();
			Items2 = new ObservableRangeCollection<Item>();
			Items3 = new ObservableRangeCollection<Item>();
			this.dataAccess = dataAccess;
			LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
			this.dataAccess = dataAccess;

			MessagingCenter.Subscribe<ContentPage>(this, "refresh", (sender) => {
				ExecuteLoadItemsCommand();
			});
		}

		public async Task ExecuteLoadItemsCommand()
		{
			if (IsBusy)
				return;

			IsBusy = true;
			try
			{
				Items1.Clear();
				Items2.Clear();
				Items3.Clear();
				var items = dataAccess.GetDataFromServer("1");
				Items1.ReplaceRange(items);
				items = dataAccess.GetDataFromServer("2");
				Items2.ReplaceRange(items);
				items = dataAccess.GetDataFromServer("3");
				Items3.ReplaceRange(items);
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

