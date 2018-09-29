using System;
using System.Collections.Generic;
using System.Text;

namespace App.core.trans.Models
{
    public class UsuarioComplemento
    {
		public string Codigousuario { get; set; }
		public int Secuencialpersona { get; set; }
		public DateTime Fechacreacion { get; set; }
		public string Clave { get; set; }
		public string Emailinterno { get; set; }
		public DateTime Fechaultimocambioclave { get; set; }
		public bool Cambioclaveproximoingreso { get; set; }
		public int Periodicidadcambioclave { get; set; }
		public bool Esinterno { get; set; }
		public int Numeroverificador { get; set; }
		public bool Puedeconsultarotrosusuarios { get; set; }
	}
}
