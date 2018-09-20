using System;
using System.Collections.Generic;
using System.Text;

namespace App.core.trans.Models
{
    public class Cliente
    {
		public int Secuencial { get; set; }
		public int Secuencialoficina { get; set; }
		public int Secuencialpersona { get; set; }
		public int Numerocliente { get; set; }
		public DateTime Fechaingreso { get; set; }
		public string Codigousuariooficial { get; set; }
		public string Codigosectoreconomico { get; set; }
		public string Codigotipovinculacion { get; set; }
		public string Codigocalificacioninterna { get; set; }
		public int Secuencialdivisionmercado { get; set; }
		public string Codigoestadocliente { get; set; }
		public int Numeroverificador { get; set; }
	}
}
