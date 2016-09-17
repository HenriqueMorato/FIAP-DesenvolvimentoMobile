﻿using System;
using System.Collections.Generic;
using System.Net.Http;
using Acr.UserDialogs;
using Plugin.Geolocator;
using Xamarin.Forms;
using Newtonsoft.Json;

namespace MobileDev
{
	public partial class DadosPage : ContentPage
	{
		public DadosPage()
		{
			InitializeComponent();

			geoloc();
		}

		async void geoloc()
		{
			var locator = CrossGeolocator.Current;
			locator.DesiredAccuracy = 50;

			var position = await locator.GetPositionAsync(10000);

			string testlon = position.Longitude.ToString();
			string testlac = position.Latitude.ToString();

			latitude.Text = testlac;
			longitude.Text = testlon;

			//await UserDialogs.Instance.AlertAsync(testlon + " " + testlac);

			string url = "http://api.geonames.org/findNearByWeatherJSON?lat=" + testlac + "&lng=" + testlon + "&username=deznetfiap";

			HttpClient client = new HttpClient();

			var uri = new Uri(url);
			var response = await client.GetAsync(uri);

			TempResultModel temp = new TempResultModel();

			if (response.IsSuccessStatusCode)
			{
				string content = await response.Content.ReadAsStringAsync();

				temp = JsonConvert.DeserializeObject<TempResultModel>(content);

				lblTemp.Text = temp.weatherObservation.temperature.ToString();
				lblLoc.Text = temp.weatherObservation.stationName.ToString();
			}
			else
			{
				UserDialogs.Instance.ShowSuccess("Erro de requisição");
			}
		}
	}
}

