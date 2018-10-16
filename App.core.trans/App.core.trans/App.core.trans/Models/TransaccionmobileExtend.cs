using System;
using System.Collections.Generic;
using System.Text;

namespace App.core.trans.Models
{
	public class TransaccionmobileExtend
	{
		public int Secuencial { get; set; }
		public string CodigoUsuario { get; set; }
		public int NumeroCliente { get; set; }
		public string NombreCliente { get; set; }
		public DateTime Fecha { get; set; }
		public decimal Monto { get; set; }
		public decimal Longitud { get; set; }
		public decimal Latitud { get; set; }
	}
}
