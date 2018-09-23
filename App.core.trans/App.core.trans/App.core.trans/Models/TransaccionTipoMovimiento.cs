using System;
using System.Collections.Generic;
using System.Text;

namespace App.core.trans.Models
{
	public class TransaccionTipoMovimiento
	{
		public int Secuencial { get; set; }
		public int SecuencialTransaccion { get; set; }
		public string CodigoTipoMovimiento { get; set; }
		public bool Estaactivo { get; set; }
		public int Numeroverificador { get; set; }
		public int ValueInsert { get; set; }
	}
}
