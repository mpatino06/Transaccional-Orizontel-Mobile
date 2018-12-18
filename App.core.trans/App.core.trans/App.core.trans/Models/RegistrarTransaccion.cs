using System;
using System.Collections.Generic;
using System.Text;

namespace App.core.trans.Models
{
    public class RegistrarTransaccion
    {
		public string CodigoUsuario { get; set; }
		public int SecuencialTransaccion { get; set; }
		public string NombreTransaccion { get; set; }
		public string SiglasTransaccion { get; set; }
		//CLIENTE
		public int secCliente { get; set; }
		public int numCliente { get; set; }
		public int SecEmpresa { get; set; }
		public int SecOficinaUsuario { get; set; }
		//CUENTA SELECCIONADA
		public int SecuencialCuenta { get; set; }
		public string CodigoCuenta { get; set; }
		public int SecuencialMoneda { get; set; }
		public int SecuencialOficinaCuenta { get; set; }
		//MONTO TRANSACCION
		public TransaccionMoneda Transacciones { get; set; } //Efectivo - Cheque
		public List<Cheque> Cheques { get; set; }
	}
}
