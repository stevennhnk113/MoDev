using System;
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

		void ChangeCheckBoxStatus()
		{
			RememberPasswordCheckbox.IsVisible = !RememberPasswordCheckbox.IsVisible;
		}

		void ChangeUsernameInputBoxFocus()
		{
			UsernameInputBoxFocus.IsVisible = !UsernameInputBoxFocus.IsVisible;
		}

		void ChangePasswordInputBoxFocus()
		{
			PasswordInputBoxFocus.IsVisible = !PasswordInputBoxFocus.IsVisible;
		}

		void OnTapGestureRecognizerTapped()
		{
			//Navigation.PushAsync(new JumpLandingPage());
			//MessagingCenter.Send<ContentPage>(this, "RemoveNavigationBar");
		}

		void LogUserIn()
		{
			DisplayAlert("Invalid", "Please input or input invalid username/password", "OK");
		}

		void Exit()
		{
			DisplayAlert("Exiting", "Please press home button to exit", "OK");
		}
	}
}