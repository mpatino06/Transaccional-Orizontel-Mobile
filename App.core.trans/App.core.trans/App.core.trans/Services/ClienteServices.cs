using System;
using System.Collections.Generic;
using System.Net.Http;
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
			client = new HttpClient();
			client.MaxResponseContentBufferSize = 256000000;
			PATHSERVER = "10.1.92.207:81";
		}

		public async Task<List<ClienteCuentas>> GetCuentasCliente(int ciente, int transaccion)
		{
			var Items = new List<ClienteCuentas>();
			string url = "http://" + PATHSERVER + "/tshirt/provider/GetProviderName?name=";
			//string uri = string.Concat(url, name);
			try
			{
				//var result = await client.GetAsync(uri);
				//if (result.IsSuccessStatusCode)
				//{
				//	var content = await result.Content.ReadAsStringAsync();
				//	Items = JsonConvert.DeserializeObject<List<ClienteCuentas>>(content);
				//}
				
					string content = "[{ 'secuencial': 45679,'codigo': '310860189','nombreCuenta': 'AHORRO PROGRAMADO','codigoTipoCuenta': '3','codigoProductoVista': '1','nombreProducto': 'Ahorros Dólares','codigoEstado': 'A', 'nombreEstado': 'ACTIVA ', 'secuencialMoneda': 1,'nombreMondea': 'DOLARES','secuencialOficina': 2,'secuencialEmpresa': 3,'nombreDivision': 'MATRIZ','codigoUsuarioOficial': 'EYUNGAN','nombreUsuario': 'YUNGAN PINDA ELIZABETH DEL ROCIO','fechaSistemaCreacion': '2016-03-01T00:00:00','fechaMaquinaCreacion': '2016-03-01T16:38:07.46','numeroLibreta': 1,'numeroLineaImprimeLibreta': 2,'esAnverso': true,'tieneSeguroActivo': false,'fechaCorte': '2018-08-01T00:00:00','bloqeadaTransaccionOperativa': false,'numeroVerificador': 102},{ 'secuencial': 45680,'codigo': '210860190','nombreCuenta': 'AHORROS A LA VISTA','codigoTipoCuenta': '2', 'codigoProductoVista': '1','nombreProducto': 'Ahorros Dólares','codigoEstado': 'A','nombreEstado': 'ACTIVA','secuencialMoneda': 1,'nombreMondea': 'DOLARES','secuencialOficina': 2,'secuencialEmpresa': 3,'nombreDivision': 'MATRIZ','codigoUsuarioOficial': 'EYUNGAN','nombreUsuario': 'YUNGAN PINDA ELIZABETH DEL ROCIO','fechaSistemaCreacion': '2016-03-01T00:00:00','fechaMaquinaCreacion': '2016-03-01T16:38:07.473','numeroLibreta': 1,'numeroLineaImprimeLibreta': 12,'esAnverso': true,'tieneSeguroActivo': false,'fechaCorte': '2018-08-01T00:00:00','bloqeadaTransaccionOperativa': false,'numeroVerificador': 1274},{ 'secuencial': 45681,'codigo': '110860191','nombreCuenta': 'CERTIFICADOS','codigoTipoCuenta': '1','codigoProductoVista': '1','nombreProducto': 'Ahorros Dólares','codigoEstado': 'A','nombreEstado': 'ACTIVA','secuencialMoneda': 1,'nombreMondea': 'DOLARES','secuencialOficina': 2,'secuencialEmpresa': 3,'nombreDivision': 'MATRIZ','codigoUsuarioOficial': 'EYUNGAN','nombreUsuario': 'YUNGAN PINDA ELIZABETH DEL ROCIO','fechaSistemaCreacion': '2016-03-01T00:00:00','fechaMaquinaCreacion': '2016-03-01T16:38:07.49','numeroLibreta': 1,'numeroLineaImprimeLibreta': 2,'esAnverso': true,'tieneSeguroActivo': false,'fechaCorte': '2018-08-01T00:00:00','bloqeadaTransaccionOperativa': false,'numeroVerificador': 6}]";
					Items =  JsonConvert.DeserializeObject<List<ClienteCuentas>>(content);
			}
			catch (Exception ex)
			{
				//Debug.WriteLine(@"				ERROR {0}", ex.Message);
			}
			return Items;
		}

		public async Task<ClienteExtend> GetCliente(int empresa, int cliente)
		{
			var Items = new ClienteExtend();
			string url = "http://" + PATHSERVER + "/OR/Cliente/GetBySecEmpresaYNumeroCliente/"+ empresa  + "/" + cliente;
			//string uri = string.Concat(url, name);
			try
			{
				//var result = await client.GetAsync(uri);
				//if (result.IsSuccessStatusCode)
				//{
				//	var content = await result.Content.ReadAsStringAsync();
				//	Items = JsonConvert.DeserializeObject<List<ClienteCuentas>>(content);
				//}

				string content = "{'secuencialCliente': 35194,'secuencialOficina': 2,'secuencialPersona': 36455,'numeroCliente': 878793,'fechaIngreso': '2016-02-23T00:00:00','codigoUsuarioOficial': 'LJEREZ','codigoSectorEconomico': 'NI','codigoTipoVinculacion': 'N','codigoCalificacionInterna': 'N','secuencialDivisionMercado': 3,'codigoEstadoCliente': 'H','numeroVerificadorCliente': 1,'codigoTipoIDentificacion': 'C','nombreTipoIdentificacion': 'CEDULA','identificacion': '1804326013','nombreUnido': 'SEVILLA MORALES MAYRA REBECA','direccionDomicilio': 'HUACHI CHICO BARRIO EL PROGRESO CLLE OLIMPO CARDENAS Y SOLIS MORAN','referenciaDomiciliaria': 'calles olimpo solis moran','email': 'mrsevilla_22@hotmail.com','secuencialTipoIdentificacion': 2,'secuencialDivPolResidencia': 1406,'codigoPaisOrigen': 'EC','numeroVerificador': 18,'secuencialDivActEcon': 5826}";
				Items = JsonConvert.DeserializeObject<ClienteExtend>(content);
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
				//var result = await client.GetAsync(uri);
				//if (result.IsSuccessStatusCode)
				//{
				//	var content = await result.Content.ReadAsStringAsync();
				//	Items = JsonConvert.DeserializeObject<List<ClienteCuentas>>(content);
				//}

				string content = "{'denominacionMoneda': [{'secuencial': 1,'secuencialempresa': 3,'denominacion': 100,'orden': 1,'estaactiva': true,'numeroverificador': 2},{'secuencial': 2,'secuencialempresa': 3,'denominacion': 50,'orden': 2,'estaactiva': true,'numeroverificador': 2},{'secuencial': 3,'secuencialempresa': 3,'denominacion': 20,'orden': 3,'estaactiva': true,'numeroverificador': 2},{'secuencial': 4,'secuencialempresa': 3,'denominacion': 10,'orden': 4,'estaactiva': true,'numeroverificador': 2},{'secuencial': 5,'secuencialempresa': 3,'denominacion': 5,'orden': 6,'estaactiva': true,'numeroverificador': 2},{'secuencial': 6,'secuencialempresa': 3,'denominacion': 1,'orden': 7,'estaactiva': true,'numeroverificador': 2},{'secuencial': 7,'secuencialempresa': 3,'denominacion': 0.5,'orden': 8,'estaactiva': true,'numeroverificador': 2},{'secuencial': 8,'secuencialempresa': 3,'denominacion': 0.25,'orden': 9,'estaactiva': true,'numeroverificador': 2},{'secuencial': 9,'secuencialempresa': 3,'denominacion': 0.1,'orden': 10,'estaactiva': true,'numeroverificador': 2},{'secuencial': 10,'secuencialempresa': 3,'denominacion': 0.05,'orden': 11,'estaactiva': true,'numeroverificador': 2},{'secuencial': 11,'secuencialempresa': 3,'denominacion': 0.01,'orden': 12,'estaactiva': true,'numeroverificador': 2}],'tipoMovimiento': [{'secuencial': 5,'secuencialTransaccion': 18,'codigotipomovimiento': 'Efectivo','estaactivo': true,'numeroverificador': 1},{'secuencial': 6,'secuencialTransaccion': 18,'codigotipomovimiento': 'Cheque','estaactivo': true,'numeroverificador': 1}]}";
				Items = JsonConvert.DeserializeObject<TransaccionMoneda>(content);
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
				//var result = await client.GetAsync(uri);
				//if (result.IsSuccessStatusCode)
				//{
				//	var content = await result.Content.ReadAsStringAsync();
				//	Items = JsonConvert.DeserializeObject<List<ClienteCuentas>>(content);
				//}

				string content = "[{'secuencial': 18,'codigo': '201','secuencialempresa': 3,'nombre': 'Depósito','siglas': 'DEP','esdebito': false,'esoperable': true,'esvisible': true,'requiereconcepto': true,'codigotipoproducto': 'Vista','usuariodefineorigen': false,'requierealmacenarpapeleta': false,'estaactiva': true,'numeroverificador': 5,'verificahuella': false,'facturarenlinea': null,'esfacturable': null,'transaccionVista': null,'movimientodetalle': [],'transaccioncomponente': [],'transaccionrangoaprobacion': []},{'secuencial': 19,'codigo': '202','secuencialempresa': 3,'nombre': 'Retiro','siglas': 'RET','esdebito': true,'esoperable': true,'esvisible': true,'requiereconcepto': false,'codigotipoproducto': 'Vista','usuariodefineorigen': false,'requierealmacenarpapeleta': false,'estaactiva': true,'numeroverificador': 2,'verificahuella': false,'facturarenlinea': null,'esfacturable': null,'transaccionVista': null,'movimientodetalle': [],'transaccioncomponente': [],'transaccionrangoaprobacion': [] }]";
				Items = JsonConvert.DeserializeObject<List<Transaccion>>(content);
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
