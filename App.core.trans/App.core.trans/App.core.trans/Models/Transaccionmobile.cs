using System;
using System.Collections.Generic;
using System.Text;

namespace App.core.trans.Models
{
	public class Transaccionmobile
	{
		public int Secuencial { get; set; }
		public string CodigoUsuario { get; set; }
		public int NumeroCliente { get; set; }
		public DateTime Fecha { get; set; }
		public decimal Monto { get; set; }
		public int Longitud { get; set; }
		public int Latitud { get; set; }
	}
}
