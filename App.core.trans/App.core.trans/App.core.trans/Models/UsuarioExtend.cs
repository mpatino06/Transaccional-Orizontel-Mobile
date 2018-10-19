using System;
using System.Collections.Generic;
using System.Text;

namespace App.core.trans.Models
{
	public class UsuarioExtend
	{
		public Usuario usuario { get; set; }
		public UsuarioComplemento usuarioComplemento { get; set; }
		public bool AccesoUsuario { get; set; }
	}
}
