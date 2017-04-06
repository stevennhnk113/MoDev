using System;

using MultipleScreens.Models;
using MultipleScreens.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MultipleScreens.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ItemsListPage : ContentPage
	{
		ListViewModel viewModel;

		public ItemsListPage ()
		{
			InitializeComponent ();
		}

		public ItemsListPage(ListViewModel viewModel)
		{
			InitializeComponent();

			BindingContext = this.viewModel = viewModel;
		}
	}
}
