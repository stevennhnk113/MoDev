using System;

using PersonalApp.Models;
using PersonalApp.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PersonalApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MonstersListPage : ContentPage
	{
		ListViewModel viewModel;

		public MonstersListPage()
		{
			InitializeComponent();
		}

		public MonstersListPage(ListViewModel viewModel)
		{
			InitializeComponent();

			BindingContext = this.viewModel = viewModel;
		}
	}
}
