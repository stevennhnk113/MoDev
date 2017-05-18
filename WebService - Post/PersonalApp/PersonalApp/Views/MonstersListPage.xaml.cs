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

			BindingContext = this.viewModel = new ListViewModel("Monsters", null);
		}
	}
}
