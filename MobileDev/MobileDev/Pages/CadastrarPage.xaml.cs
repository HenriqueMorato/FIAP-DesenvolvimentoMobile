using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace MobileDev
{
	public partial class CadastrarPage : ContentPage
	{
		public CadastrarPage()
		{
			InitializeComponent();
		}

		async void Handle_Clicked(object sender, System.EventArgs e)
		{
			App.Current.MainPage = new LoginPage();
			//Navigation.PushModalAsync(new NavigationPage(new LoginPage()));
		}

		async void Cancel_click(object sender, System.EventArgs e)
		{
			//await Navigation.PopModalAsync(true);
			Navigation.PushModalAsync(new NavigationPage(new LoginPage()));
		}
	}
}

