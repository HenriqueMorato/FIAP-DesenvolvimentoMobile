using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace MeuDB
{
	public partial class DetalhesPage : ContentPage
	{
		public DetalhesPage(Contato dados)
		{
			InitializeComponent();

			txtId.Text = dados.Id.ToString();
			txtNome.Text = dados.Nome;
			txtEmail.Text = dados.Email;
			txtTelefone.Text = dados.Telefone;
		}

		void savar_Clicked(object sender, System.EventArgs e)
		{
			var contato = new Contato
			{
				Nome = txtNome.Text,
				Telefone = txtTelefone.Text,
				Id = int.Parse(txtId.Text),
				Email = txtEmail.Text
				                
			};

			using (var dados = new AcessoDados())
			{
				dados.Update(contato);
			}
			Navigation.PopModalAsync();
			Navigation.PopModalAsync();
			Navigation.PushModalAsync(new NavigationPage(new MyPage()));
		}

		void cancelar_Clicked(object sender, System.EventArgs e)
		{
			Navigation.PopModalAsync();
		}
	}
}

