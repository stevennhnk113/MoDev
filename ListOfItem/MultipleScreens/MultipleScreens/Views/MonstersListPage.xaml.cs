using System;

using MultipleScreens.Models;
using MultipleScreens.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MultipleScreens.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MonstersListPage : ContentPage
	{
		ListViewModel viewModel;

		public MonstersListPage ()
		{
			InitializeComponent ();
		}

		public MonstersListPage(ListViewModel viewModel)
		{
			InitializeComponent();

			BindingContext = this.viewModel = viewModel;
		}
	}
}
