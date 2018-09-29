using System;
using System.Collections.Generic;
using System.Text;

namespace App.core.trans.Models
{
    public class Usuario
    {
		public string Codigo { get; set; }
		public string Nombre { get; set; }
		public int Secuencialoficina { get; set; }
		public bool Estaactivo { get; set; }
		public int Numeroverificador { get; set; }
	}
}
