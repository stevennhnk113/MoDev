﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterviewTask.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace InterviewTask.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginPage : ContentPage
	{
		LoginViewModel viewModel;

		public LoginPage()
		{
			BindingContext = this.viewModel = new LoginViewModel();

			InitializeComponent ();
		}
	}
}