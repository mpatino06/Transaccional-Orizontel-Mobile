using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using App.core.trans.Models;
using App.core.trans.Services;
using Xamarin.Forms;

using GalaSoft.MvvmLight.Command;

namespace App.core.trans.ViewModels
{
    public class TransaccionViewModel : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;
		private ClienteServices clienteServices;

		public TransaccionViewModel()
		{
			LoadTransaccion();
		}


		#region PROPIEDADES


		private string _searchName;
		public string SearchName
		{
			get { return _searchName; }
			set
			{
				_searchName = value;
				RaiseOnPropertyChange();
			}
		}

		private string _datosCliente;
		public string DatosCliente
		{
			get { return _searchName; }
			set
			{
				_datosCliente = value;
				RaiseOnPropertyChange();
			}
		}

		private int _heightList;

		public int HeightList
		{
			get { return _heightList; }
			set
			{
				_heightList = value;
				RaiseOnPropertyChange();
			}
		}

		private bool _enableButtonSiguiente;
		public bool EnableButtonSiguiente
		{
			get { return _enableButtonSiguiente; }
			set
			{
				_enableButtonSiguiente = value;
				RaiseOnPropertyChange();
			}
		}

		private int _secuencialClienteVM;
		public int SecuencialClienteVM
		{
			get { return _secuencialClienteVM; }
			set
			{
				_secuencialClienteVM = value;
				RaiseOnPropertyChange();
			}
		}

		private int _secuencialEmpresaVM;
		public int SecuencialEmpresaVM
		{
			get { return _secuencialEmpresaVM; }
			set
			{
				_secuencialEmpresaVM = value;
				RaiseOnPropertyChange();
			}
		}

		private ObservableCollection<ClienteCuentas> _cuentasCollection;
		public ObservableCollection<ClienteCuentas> CuentasCollection
		{
			get { return _cuentasCollection; }
			set
			{
				_cuentasCollection = value;
				HeightList = (_cuentasCollection.Count * 40) + (_cuentasCollection.Count * 5);
				RaiseOnPropertyChange();
			}
		}


		private ObservableCollection<string> _transaccionCollection;
		public ObservableCollection<string> TransaccionCollection
		{
			get { return _transaccionCollection; }
			set { _transaccionCollection = value; RaiseOnPropertyChange(); }
		}

		private string _transaccionSelect;
		public string TransaccionSelect
		{
			get { return _transaccionSelect; }
			set { _transaccionSelect = value; RaiseOnPropertyChange(); }
		}


		private ClienteCuentas _selectedCuenta = new ClienteCuentas();

		public ClienteCuentas _SelectedCuenta
		{
			get { return _selectedCuenta; }
			set { _selectedCuenta = value; RaiseOnPropertyChange(); }
		}

		#endregion

		#region METODOS

		private async void LoadTransaccion()
		{

			string[] transacciones = { "201-DEPOSITO", "58-RETIRO" };
			TransaccionCollection = new ObservableCollection<string>(transacciones);
		}

		public void RaiseOnPropertyChange([CallerMemberName] string propertyName = null)
		{
			if (PropertyChanged != null)
			{
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		#endregion


		public async void BusquedaCliente()
		{
			try
			{
				EnableButtonSiguiente = false;
				if (!string.IsNullOrEmpty(SearchName))
				{
					clienteServices = new ClienteServices();
					var result = await clienteServices.GetCliente(SecuencialEmpresaVM, int.Parse(SearchName));
					if (result != null)
					{
						SecuencialClienteVM = result.SecuencialCliente;
						DatosCliente = result.Identificacion.ToString() + " " + result.NombreUnido;

						var cuentasCliente = await clienteServices.GetCuentasCliente(SecuencialClienteVM, result.NumeroVerificador);
						if (cuentasCliente != null)
						{

							Device.BeginInvokeOnMainThread(() =>
							{
								EnableButtonSiguiente = true;
								CuentasCollection = new ObservableCollection<ClienteCuentas>(cuentasCliente);
							});
						}
					}
				}
			}
			catch (Exception)
			{

				throw;
			}
		}

		#region COMMANDS 


		public ICommand SearchCliente => new RelayCommand(BusquedaCliente);


		#endregion
	}
}
