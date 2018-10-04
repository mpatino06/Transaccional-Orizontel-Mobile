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
			Login login = new Login();
			string url = "http://" + PATHSERVER + "/OR/usuario/GetUsuarioByCode";
			try
			{
				login.User = code;
				login.Pass = pass;
				//var result = await client.GetAsync(url);
				//if (result.IsSuccessStatusCode)
				//{
				//	var content = await result.Content.ReadAsStringAsync();
				//	Items = JsonConvert.DeserializeObject<UsuarioExtend>(content);
				//}
				var json = JsonConvert.SerializeObject(login);
				var content = new StringContent(json, Encoding.UTF8, "application/json");

				HttpResponseMessage result = null;

				result = await client.PostAsync(url, content);

				if (result.IsSuccessStatusCode)
				{
					var content2 = await result.Content.ReadAsStringAsync();
					Items = JsonConvert.DeserializeObject<UsuarioExtend>(content2);

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
