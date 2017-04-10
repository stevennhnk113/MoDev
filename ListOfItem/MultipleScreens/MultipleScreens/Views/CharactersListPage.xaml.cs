using System;

using MultipleScreens.Models;
using MultipleScreens.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MultipleScreens.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CharactersListPage : ContentPage
	{

		ListViewModel viewModel;

		public CharactersListPage ()
		{
			InitializeComponent ();
		}

		public CharactersListPage(ListViewModel viewModel)
		{
			InitializeComponent();

			BindingContext = this.viewModel = viewModel;
		}
	}
}
