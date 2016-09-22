using System;
using System.Collections.Generic;
using System.Diagnostics;
using Xamarin.Forms;

namespace MeuDB
{
	public partial class MyPage : ContentPage
	{
		public MyPage ()
		{
			InitializeComponent ();

			using(var dados = new AcessoDados())
			{
				this.Lista.ItemsSource = dados.Listar ();
			}
		}

		//protected override void OnAppearing()
		//{
		//	//base.OnAppearing();
		//	using (var dados = new AcessoDados())
		//	{
		//		this.Lista.ItemsSource = dados.Listar();
		//	}
		//}

		protected void SalvarClicked(object sender, EventArgs e)
		{
			var contato = new Contato {
				Nome = this.Nome.Text,
				Email = this.Email.Text,
				Telefone = this.Telefone.Text
			};

			using(var dados = new AcessoDados())
			{
				dados.Insert (contato);
				this.Lista.ItemsSource = dados.Listar ();
			}
		}

		void Handle_ItemTapped(object sender, Xamarin.Forms.ItemTappedEventArgs e)
		{
			//if (e == null) return; // has been set to null, do not 'process' tapped event
			//Debug.WriteLine("Tapped: " + e.Item);

			//int teste = ((Contato)e.Item).Id;

			Navigation.PushModalAsync(new NavigationPage(new DetalhesPage((Contato)e.Item)));
		}

		void Handle_Clicked(object sender, System.EventArgs e)
		{
			using (var dados = new AcessoDados())
			{

				var visit = (sender as Xamarin.Forms.MenuItem).BindingContext as Contato;

				dados.Delete(visit);
				this.Lista.ItemsSource = dados.Listar();
			}
		}
	}
}