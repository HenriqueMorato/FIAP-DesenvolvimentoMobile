using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Acr.UserDialogs;

using Xamarin.Forms;

namespace MobileDev
{
	public partial class LoginPage : ContentPage
	{
		public LoginPage()
		{
			InitializeComponent();
		}

		async void Handle_Clicked(object sender, System.EventArgs e)
		{
			UserDialogs.Instance.ShowLoading("Logando como " + txtLogin.Text);

			await Task.Delay(3000);

			UserDialogs.Instance.HideLoading();

			Navigation.InsertPageBefore(new TabbedMainPage(), this);
			await Navigation.PopAsync();
			
			//DisplayAlert(txtLogin.Text, txtPassword.Text, "OK", "Cancelar");
		}
	}
}

