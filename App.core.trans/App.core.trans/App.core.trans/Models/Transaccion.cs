using System;
using System.Collections.Generic;
using System.Text;

namespace App.core.trans.Models
{
    public class Transaccion
    {
		//public int SecuencialTransaccion { get; set; }
		//public int CodigoTransaccion { get; set; }
		//public string NombreTransaccion { get; set; }
		//public string CodigoCuenta { get; set; } 
		//public int SecuencialCuentaSeleccionada { get; set; }
		//public string NombreCuenta { get; set; }
		//public int SecuencialEmpresa { get; set; }
		//public int SecuencialCliente { get; set; }
		//public string NombreCliente { get; set; }
		//public int SecuencialOficina { get; set; }
		//public string NombreOficina { get; set; }
		//public DateTime FechaApertura { get; set; }
		//public int SecuencialMoneda { get; set; }
		//public string NombreMoneda { get; set; }
		//public int CodigoUsuarioOficial { get; set; }
		//public string NombreUsuarioOficial { get; set; }
		//      public DateTime UltimaTRansaccion { get; set; }

		public int Secuencial { get; set; }
		public string Codigo { get; set; }
		public int Secuencialempresa { get; set; }
		public string Nombre { get; set; }
		public string Siglas { get; set; }
		public bool Esdebito { get; set; }
		public bool Esoperable { get; set; }
		public bool Esvisible { get; set; }
		public bool Requiereconcepto { get; set; }
		public string Codigotipoproducto { get; set; }
		public bool Usuariodefineorigen { get; set; }
		public bool Requierealmacenarpapeleta { get; set; }
		public bool Estaactiva { get; set; }
		public int Numeroverificador { get; set; }
		public bool? Verificahuella { get; set; }
		public bool? Facturarenlinea { get; set; }
		public bool? Esfacturable { get; set; }
	}
}
