using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace MobileDev
{
	public partial class LoginPage : ContentPage
	{
		public LoginPage()
		{
			InitializeComponent();
		}

		void Handle_Clicked(object sender, System.EventArgs e)
		{
			DisplayAlert(txtLogin.Text, txtPassword.Text, "OK", "Cancelar");
		}
	}
}

