using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Net.Http;
using Acr.UserDialogs;

using Xamarin.Forms;

namespace MobileDev
{
	public partial class EnderecoPage : ContentPage
	{
		public EnderecoPage()
		{
			InitializeComponent();
		}

		async void Handle_Unfocused(object sender, Xamarin.Forms.FocusEventArgs e)
		{
			string sURL = "http://viacep.com.br/ws/{0}/json/";

			HttpClient client = new HttpClient();

			var url = new Uri(string.Format(sURL, txtCep.Text));

			var response = await client.GetAsync(url);

			CepResultModel cep = new CepResultModel();

			if (response.IsSuccessStatusCode)
			{
				string content = await response.Content.ReadAsStringAsync();

				cep = JsonConvert.DeserializeObject<CepResultModel>(content);

				txtRua.Text = cep.rua;
				txtEstado.Text = cep.uf;
				txtCidade.Text = cep.cidade;
				txtBairro.Text = cep.bairro;
				txtNumero.Focus();

				UserDialogs.Instance.ShowSuccess("Requisição ok");
			}
			else
			{
				UserDialogs.Instance.ShowSuccess("Erro de requisição");
			}
		}
	}
}

