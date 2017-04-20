using System;

using PersonalApp.Models;
using PersonalApp.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PersonalApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class InventoryPage : ContentPage
	{
		ListViewModel viewModel;

		public InventoryPage()
		{
			InitializeComponent();
		}

		public InventoryPage(ListViewModel viewModel)
		{
			InitializeComponent();

			BindingContext = this.viewModel = viewModel;
		}
	}
}
