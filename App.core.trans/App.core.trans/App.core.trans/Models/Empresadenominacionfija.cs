using System;
using System.Collections.Generic;
using System.Text;

namespace App.core.trans.Models
{
	public partial class Empresadenominacionfija
	{
		public int Secuencial { get; set; }
		public int Secuencialempresa { get; set; }
		public decimal Denominacion { get; set; }
		public int Orden { get; set; }
		public bool Estaactiva { get; set; }
		public int Numeroverificador { get; set; }
	}
}
