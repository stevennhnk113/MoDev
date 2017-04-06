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
		public Item Item { get; set; }
		public ListViewModel()
		{

		}

		public ListViewModel (string title)
		{
			Title = title;
			switch (title)
			{
				case "Characters":
					Item.description = "Show all the characters that you have.";
					break;
				case "Monsters":
					Item.description = "Show all the monsters that you have encounter.";
					break;
				case "Inventory":
					Item.description = "Show all the items that you have.";
					break;
				case "Items":
					Item.description = "Show all the item that you have encounter.";
					break;
			}
		}
	}
}
