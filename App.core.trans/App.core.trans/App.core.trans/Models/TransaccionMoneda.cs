using System;
using System.Collections.Generic;
using System.Text;

namespace App.core.trans.Models
{
	public class TransaccionMoneda
	{
		public List<Empresadenominacionfija> DenominacionMoneda { get; set; }
		public List<TransaccionTipoMovimiento> TipoMovimiento { get; set; }
	}
}
