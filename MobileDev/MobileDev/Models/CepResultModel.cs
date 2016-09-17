using System;
using Newtonsoft.Json;

namespace MobileDev
{
	public class CepResultModel
	{
		public string cep { get; set; }
		[JsonProperty("logradouro")]
		public string rua { get; set; }
		public string complemento { get; set; }
		public string bairro { get; set; }
		[JsonProperty("localidade")]
		public string cidade { get; set; }
		public string uf { get; set; }

		public CepResultModel()
		{
			
		}
	}
}

