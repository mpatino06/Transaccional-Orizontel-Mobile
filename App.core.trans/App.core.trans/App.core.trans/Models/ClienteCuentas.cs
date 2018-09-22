﻿using System;
using System.Collections.Generic;
using System.Text;

namespace App.core.trans.Models
{
    public class ClienteCuentas
    {
		public int Secuencial { get; set; }
		public string Codigo { get; set; }
		public string NombreCuenta { get; set; }
		public string CodigoTipoCuenta { get; set; }
		public string CodigoProductoVista { get; set; }
		public string NombreProducto { get; set; }
		public string CodigoEstado { get; set; }
		public string NombreEstado { get; set; }
		public int SecuencialMoneda { get; set; }
		public string NombreMondea { get; set; }
		public int SecuencialOficina { get; set; }
		public int SecuencialEmpresa { get; set; }
		public string NombreDivision { get; set; }
		public string CodigoUsuarioOficial { get; set; }
		public string NombreUsuario { get; set; }
		public DateTime FechaSistemaCreacion { get; set; }
		public DateTime FechaMaquinaCreacion { get; set; }
		public int NumeroLibreta { get; set; }
		public int NumeroLineaImprimeLibreta { get; set; }
		public bool EsAnverso { get; set; }
		public bool TieneSeguroActivo { get; set; }
		public DateTime FechaCorte { get; set; }
		public bool BloqeadaTransaccionOperativa { get; set; }
		public int NumeroVerificador { get; set; }
	}
}
