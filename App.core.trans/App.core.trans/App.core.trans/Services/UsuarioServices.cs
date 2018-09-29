using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using App.core.trans.Models;
using Newtonsoft.Json;

namespace App.core.trans.Services
{
    public class UsuarioServices
    {
		HttpClient client;
		//public List<Provider> Items { get; private set; }
		private string PATHSERVER { get; set; }

		public UsuarioServices()
		{
			client = new HttpClient();
			client.MaxResponseContentBufferSize = 256000000;
			PATHSERVER = "186.4.142.142:81";
		}

		public async Task<UsuarioExtend> GetUsuario(string code, string pass)
		{
			var Items = new UsuarioExtend();
			string url = "http://" + PATHSERVER + "/OR/usuario/GetUsuarioByCode/" + code + "/" + pass;
			try
			{
				var result = await client.GetAsync(url);
				if (result.IsSuccessStatusCode)
				{
					var content = await result.Content.ReadAsStringAsync();
					Items = JsonConvert.DeserializeObject<UsuarioExtend>(content);
				}
			}
			catch (Exception ex)
			{
				//Debug.WriteLine(@"				ERROR {0}", ex.Message);
			}
			return Items;
		}

	}
}
