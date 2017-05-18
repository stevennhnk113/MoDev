using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PersonalApp.Services;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PersonalApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Reset : ContentPage
	{
		ItemsDataAccess dataAccess;

		public Reset()
		{
			BindingContext = this;
			dataAccess = new ItemsDataAccess();
			InitializeComponent();
		}

		void ResetDb()
		{
			dataAccess.DeleteAllItems();
		}

		private void Button_Clicked(object sender, EventArgs e)
		{

		}
	}
}