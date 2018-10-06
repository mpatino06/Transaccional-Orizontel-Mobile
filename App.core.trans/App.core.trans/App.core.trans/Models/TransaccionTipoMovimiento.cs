using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace App.core.trans.Models
{
	public class TransaccionTipoMovimiento
	{
		public int Secuencial { get; set; }
		public int SecuencialTransaccion { get; set; }
		public string CodigoTipoMovimiento { get; set; }
		public bool Estaactivo { get; set; }
		public int Numeroverificador { get; set; }
		public decimal ValueInsert { get; set; }
		[JsonIgnore]
		public string Imagen { get; set; }
	}
}
