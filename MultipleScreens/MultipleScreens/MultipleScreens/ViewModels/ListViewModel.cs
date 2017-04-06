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
		public ListViewModel()
		{

		}

		public ListViewModel (string title)
		{
			Title = title;
		}
	}

}
