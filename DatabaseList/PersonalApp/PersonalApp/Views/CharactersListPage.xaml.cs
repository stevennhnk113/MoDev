using System;

using PersonalApp.Models;
using PersonalApp.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PersonalApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CharactersListPage : ContentPage
	{

		ListViewModel viewModel;

		public CharactersListPage()
		{
			InitializeComponent();

			BindingContext = this.viewModel = new ListViewModel("Characters", null);
		}
	}
}
