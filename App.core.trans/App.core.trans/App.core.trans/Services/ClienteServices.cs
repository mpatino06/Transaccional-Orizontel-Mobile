using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using App.core.trans.Models;
using Newtonsoft.Json;

namespace App.core.trans.Services
{
	public class ClienteServices
	{

		HttpClient client;
		//public List<Provider> Items { get; private set; }
		private string PATHSERVER { get; set; }

		public ClienteServices()
		{
			client = new HttpClient {
				MaxResponseContentBufferSize = 25600000,
				Timeout = TimeSpan.FromSeconds(200)
			};   
			
			//client.MaxResponseContentBufferSize = 25600000;
			//client.Timeout = TimeSpan(),
			PATHSERVER = "186.4.142.142:81";
		}

		public async Task<List<ClienteCuentas>> GetCuentasCliente(int cliente, int transaccion)
		{
			var Items = new List<ClienteCuentas>();
			string url = "http://" + PATHSERVER + "/OR/Cliente/GetCuentas/" + cliente + "/" + transaccion;
			//string uri = string.Concat(url, name);
			try
			{
				var result = await client.GetAsync(url);
				if (result.IsSuccessStatusCode)
				{
					var content = await result.Content.ReadAsStringAsync();
					Items = JsonConvert.DeserializeObject<List<ClienteCuentas>>(content);
				}
			}
			catch (Exception ex)
			{
				//Debug.WriteLine(@"				ERROR {0}", ex.Message);
			}
			return Items;
		}

		public async Task<ClienteExtend> GetCliente(int cliente, int seleccion)
		{
			var Items = new ClienteExtend();
			string url = "http://" + PATHSERVER + "/OR/Cliente/GetClienteBycode/" + cliente  + "/" + seleccion;
			try
			{
				var result = await client.GetAsync(url);
				if (result.IsSuccessStatusCode)
				{
					var content = await result.Content.ReadAsStringAsync();
					Items = JsonConvert.DeserializeObject<ClienteExtend>(content);
				}

				//string content = "{'secuencialCliente': 35194,'secuencialOficina': 2,'secuencialPersona': 36455,'numeroCliente': 878793,'fechaIngreso': '2016-02-23T00:00:00','codigoUsuarioOficial': 'LJEREZ','codigoSectorEconomico': 'NI','codigoTipoVinculacion': 'N','codigoCalificacionInterna': 'N','secuencialDivisionMercado': 3,'codigoEstadoCliente': 'H','numeroVerificadorCliente': 1,'codigoTipoIDentificacion': 'C','nombreTipoIdentificacion': 'CEDULA','identificacion': '1804326013','nombreUnido': 'SEVILLA MORALES MAYRA REBECA','direccionDomicilio': 'HUACHI CHICO BARRIO EL PROGRESO CLLE OLIMPO CARDENAS Y SOLIS MORAN','referenciaDomiciliaria': 'calles olimpo solis moran','email': 'mrsevilla_22@hotmail.com','secuencialTipoIdentificacion': 2,'secuencialDivPolResidencia': 1406,'codigoPaisOrigen': 'EC','numeroVerificador': 18,'secuencialDivActEcon': 5826}";
				//Items = JsonConvert.DeserializeObject<ClienteExtend>(content);
			}
			catch (Exception ex)
			{
				//Debug.WriteLine(@"				ERROR {0}", ex.Message);
			}
			return Items;
		}
		
		public async Task<List<TransaccionTipoMovimiento>> GetTransaccionTipoMovimiento(int secuencialTransaccion)
		{
			var Items = new List<TransaccionTipoMovimiento>();
			try
			{
				string url = "http://" + PATHSERVER + "/OR/Transaccion/GetTransaccionTipoMovimiento/" + secuencialTransaccion;
				//var result = await client.GetAsync(uri);
				//if (result.IsSuccessStatusCode)
				//{
				//	var content = await result.Content.ReadAsStringAsync();
				//	Items = JsonConvert.DeserializeObject<List<ClienteCuentas>>(content);
				//}

				string content = "[{'secuencial': 5,'secuencialTransaccion': 18,'codigotipomovimiento': 'Efectivo','estaactivo': true,'numeroverificador': 1},{'secuencial': 6,'secuencialTransaccion': 18,'codigotipomovimiento': 'Cheque','estaactivo': true,'numeroverificador': 1}]";
				Items = JsonConvert.DeserializeObject<List<TransaccionTipoMovimiento>>(content);
			}
			catch (Exception ex)
			{
				Items = null;
				throw;
			}
			return Items;			
		}

		public async Task<TransaccionMoneda> GetMonedasTransaccion(int secuencialTransaccion, int empresa)
		{
			var Items = new TransaccionMoneda();
			try
			{
				string url = "http://" + PATHSERVER + "/OR/Transaccion/GetTransaccionMoneda/" + secuencialTransaccion + "/" + empresa;
				var result = await client.GetAsync(url);
				if (result.IsSuccessStatusCode)
				{
					var content = await result.Content.ReadAsStringAsync();
					Items = JsonConvert.DeserializeObject<TransaccionMoneda>(content);
				}

				//string content = "{'denominacionMoneda': [{'secuencial': 1,'secuencialempresa': 3,'denominacion': 100,'orden': 1,'estaactiva': true,'numeroverificador': 2, 'valueInsert': 0},{'secuencial': 2,'secuencialempresa': 3,'denominacion': 50,'orden': 2,'estaactiva': true,'numeroverificador': 2, 'valueInsert': 0},{'secuencial': 3,'secuencialempresa': 3,'denominacion': 20,'orden': 3,'estaactiva': true,'numeroverificador': 2, 'valueInsert': 0},{'secuencial': 4,'secuencialempresa': 3,'denominacion': 10,'orden': 4,'estaactiva': true,'numeroverificador': 2, 'valueInsert': 0},{'secuencial': 5,'secuencialempresa': 3,'denominacion': 5,'orden': 6,'estaactiva': true,'numeroverificador': 2, 'valueInsert': 0},{'secuencial': 6,'secuencialempresa': 3,'denominacion': 1,'orden': 7,'estaactiva': true,'numeroverificador': 2, 'valueInsert': 0},{'secuencial': 7,'secuencialempresa': 3,'denominacion': 0.5,'orden': 8,'estaactiva': true,'numeroverificador': 2, 'valueInsert': 0},{'secuencial': 8,'secuencialempresa': 3,'denominacion': 0.25,'orden': 9,'estaactiva': true,'numeroverificador': 2, 'valueInsert': 0},{'secuencial': 9,'secuencialempresa': 3,'denominacion': 0.1,'orden': 10,'estaactiva': true,'numeroverificador': 2, 'valueInsert': 0},{'secuencial': 10,'secuencialempresa': 3,'denominacion': 0.05,'orden': 11,'estaactiva': true,'numeroverificador': 2, 'valueInsert': 0},{'secuencial': 11,'secuencialempresa': 3,'denominacion': 0.01,'orden': 12,'estaactiva': true,'numeroverificador': 2, 'valueInsert': 0}],'tipoMovimiento': [{'secuencial': 5,'secuencialTransaccion': 18,'codigotipomovimiento': 'Efectivo','estaactivo': true,'numeroverificador': 1, 'valueInsert': 0},{'secuencial': 6,'secuencialTransaccion': 18,'codigotipomovimiento': 'Cheque','estaactivo': true,'numeroverificador': 1, 'valueInsert': 0}]}";
				//Items = JsonConvert.DeserializeObject<TransaccionMoneda>(content);
			}
			catch (Exception ex)
			{
				Items = null;
				throw;
			}
			return Items;
		}


		public async Task<List<Transaccion>> GetTransaccion(int empresa)
		{
			var Items = new List<Transaccion>();
			try
			{
				string url = "http://" + PATHSERVER + "/OR/Transaccion/GetTransaccion/" + empresa;
				var result = await client.GetAsync(url);
				if (result.IsSuccessStatusCode)
				{
					var content = await result.Content.ReadAsStringAsync();
					Items = JsonConvert.DeserializeObject<List<Transaccion>>(content);
				}
			}
			catch (Exception ex)
			{
				Items = null;
				throw;
			}
			return Items;
		}


		public async Task<List<Banco>> GetBanco()
		{
			var Items = new List<Banco>();
			try
			{
				string url = "http://" + PATHSERVER + "/OR/Transaccion/GetBancos";
				var result = await client.GetAsync(url);
				if (result.IsSuccessStatusCode)
				{
					var content = await result.Content.ReadAsStringAsync();
					Items = JsonConvert.DeserializeObject<List<Banco>>(content);
				}
			}
			catch (Exception ex)
			{
				Items = null;
				throw;
			}
			return Items;
		}

		public async Task<bool> SaveTransaccion(RegistrarTransaccion transaccion)
		{
			bool Items = false;
			string url = "http://" + PATHSERVER + "/OR/Transaccion/SaveTransaccion";
			try
			{
				ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3;

				client.DefaultRequestHeaders.Accept.Clear();
				client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
				var json = JsonConvert.SerializeObject(transaccion);
				var content = new StringContent(json, Encoding.UTF8, "application/json");

				HttpResponseMessage result =  await client.PostAsync(url, content);

				if (result.IsSuccessStatusCode)
				{
					var content2 = await result.Content.ReadAsStringAsync();
					Items = JsonConvert.DeserializeObject<bool>(content2);
				}
			}
			catch (Exception ex)
			{
				//Debug.WriteLine(@"				ERROR {0}", ex.Message);
			}
			return Items;
		}

		public async Task<List<TransaccionmobileExtend>> GetRegistroTransacciones(string codigoUsuario)
		{
			var Items = new List<TransaccionmobileExtend>();
			try
			{
				string url = "http://" + PATHSERVER + "/OR/Transaccion/GetTransaccionMobile/" + codigoUsuario;
				var result = await client.GetAsync(url);
				if (result.IsSuccessStatusCode)
				{
					var content = await result.Content.ReadAsStringAsync();
					Items = JsonConvert.DeserializeObject<List<TransaccionmobileExtend>>(content);
				}
			}
			catch (Exception ex)
			{
				Items = null;
				throw;
			}
			return Items;
		}

	}
}
