using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using Acr.UserDialogs;

using Xamarin.Forms;

namespace MobileDev
{
	public partial class PasswordRecoverPage : ContentPage
	{
		public PasswordRecoverPage()
		{
			InitializeComponent();
		}

		void Handle_Clicked(object sender, System.EventArgs e)
		{
			UserDialogs.Instance.Alert("Enviando senha para " + txtEmail.Text);
		}

		async void Cancel_Clicked(object sender, System.EventArgs e)
		{
			await Navigation.PopModalAsync();
		}
	}
}

