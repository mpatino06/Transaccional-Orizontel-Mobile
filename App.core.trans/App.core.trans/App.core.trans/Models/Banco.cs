using System;
using System.Collections.Generic;
using System.Text;

namespace App.core.trans.Models
{
    public class Banco
    {
		public int Secuencial { get; set; }
		public string Codigo { get; set; }
		public string Nombre { get; set; }
		public string CodigoTipoBanco { get; set; }
		public bool Estaactivo { get; set; }
		public int NumeroVerificador { get; set; }
	}
}
