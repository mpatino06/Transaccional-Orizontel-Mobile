using System;
using System.Collections.Generic;
using System.Text;

namespace App.core.trans.Models
{
	public class ResultTransaccion
	{
		public bool Result { get; set; }
		public string SecuencialDocumento { get; set; }
		public Decimal Saldodeposito { get; set; }
	}
}
