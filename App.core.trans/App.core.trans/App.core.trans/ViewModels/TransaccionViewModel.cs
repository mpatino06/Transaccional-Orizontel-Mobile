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
using App.core.trans.Views.Transaccion;
using System.Linq;

namespace App.core.trans.ViewModels
{
    public class TransaccionViewModel : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;
		private ClienteServices clienteServices;

		public TransaccionViewModel()
		{
			LoadTransaccion();
			IsVisibleButtons = false;
		}


		#region PROPIEDADES

		private bool _isBusy;
		public bool IsBusy
		{
			get { return _isBusy; }
			set
			{
				_isBusy = value;
				RaiseOnPropertyChange();
			}
		}

		private bool _isVisibleButtons;
		public bool IsVisibleButtons
		{
			get { return _isVisibleButtons; }
			set
			{
				_isVisibleButtons = value;
				RaiseOnPropertyChange();
			}
		}

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
			get { return _datosCliente; }
			set
			{
				_datosCliente = value;
				RaiseOnPropertyChange();
			}
		}

		private string _datosCuentaSeleccionada;
		public string DatosCuentaSeleccionada
		{
			get { return _datosCuentaSeleccionada; }
			set
			{
				_datosCuentaSeleccionada = value;
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
		//

		private int _heightListDenominacion;

		public int HeightListDenominacion
		{
			get { return _heightListDenominacion; }
			set
			{
				_heightListDenominacion = value;
				RaiseOnPropertyChange();
			}
		}

		private int _heightListTipoDeposito;

		public int HeightListTipoDeposito
		{
			get { return _heightListTipoDeposito; }
			set
			{
				_heightListTipoDeposito = value;
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

		private int _secuencialTransaccionVM;
		public int SecuencialTransaccionVM
		{
			get { return _secuencialTransaccionVM; }
			set
			{
				_secuencialTransaccionVM = value;
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


		private ObservableCollection<Transaccion> _transaccionCollection;
		public ObservableCollection<Transaccion> TransaccionCollection
		{
			get { return _transaccionCollection; }
			set { _transaccionCollection = value; RaiseOnPropertyChange(); }
		}

		private ObservableCollection<string> _transCollection;
		public ObservableCollection<string> TransCollection
		{
			get { return _transCollection; }
			set { _transCollection = value; RaiseOnPropertyChange(); }
		}

		private ObservableCollection<TransaccionTipoMovimiento> _tipoMovimientoCollection;
		public ObservableCollection<TransaccionTipoMovimiento> TipoMovimientoCollection
		{
			get { return _tipoMovimientoCollection; }
			set { _tipoMovimientoCollection = value; RaiseOnPropertyChange(); }
		}


		private string _transaccionSelect;
		public string TransaccionSelect
		{
			get { return _transaccionSelect; }
			set { _transaccionSelect = value; RaiseOnPropertyChange(); }
		}


		private ClienteCuentas _selectedCuenta = new ClienteCuentas();

		public ClienteCuentas SelectedCuenta
		{
			get { return _selectedCuenta; }
			set { _selectedCuenta = value; RaiseOnPropertyChange(); }
		}

		private ObservableCollection<TransaccionTipoMovimiento> _modalidadDeposito;
		public ObservableCollection<TransaccionTipoMovimiento> ModalidadDeposito //Efectivo - Cheque
		{
			get { return _modalidadDeposito; }
			set
			{
				_modalidadDeposito = value;
				HeightListTipoDeposito = (_modalidadDeposito.Count * 40) + (_modalidadDeposito.Count * 5);
				RaiseOnPropertyChange();
			}
		}

		private ObservableCollection<Empresadenominacionfija> _denominacionMoneda;
		public ObservableCollection<Empresadenominacionfija> DenominacionMoneda //Denominacion de moneda - billetes
		{
			get { return _denominacionMoneda; }
			set
			{
				_denominacionMoneda = value;
				HeightListDenominacion = (_denominacionMoneda.Count * 40) + (_denominacionMoneda.Count * 5);
				RaiseOnPropertyChange();
			}
		}

		#endregion

		#region METODOS

		private async void LoadTransaccion()
		{
			clienteServices = new ClienteServices();
			//string[] transacciones = { "201-DEPOSITO", "58-RETIRO" };
			//string[] transacciones = { "201-DEPOSITO", "58-RETIRO" };

			List<string> termsList = new List<string>();
			var result = await clienteServices.GetTransaccion(3); //Secuencial empresa
			if (result != null)
			{
				TransaccionCollection = new ObservableCollection<Transaccion>(result);
				foreach (var item in result)
				{
					termsList.Add(item.Codigo + " - " + item.Nombre);
				}
			}

			string[] transacciones = termsList.ToArray();
			TransCollection = new ObservableCollection<string>(transacciones);
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
				if (!string.IsNullOrEmpty(SearchName))
				{
					char[] charSplit = {'-'};
					string[] transaccionSeleccionada = TransaccionSelect.Split(charSplit);

					var _valueSelect = transaccionSeleccionada[0].ToString().Trim();

					SecuencialTransaccionVM = TransaccionCollection.FirstOrDefault(a => a.Codigo == _valueSelect).Secuencial;

					if (SecuencialTransaccionVM > 0)
					{

						IsBusy = true;
						clienteServices = new ClienteServices();
						var result = await clienteServices.GetCliente(SecuencialEmpresaVM, int.Parse(SearchName));
						if (result != null)
						{
							SecuencialClienteVM = result.SecuencialCliente;
							DatosCliente = result.Identificacion.ToString() + " " + result.NombreUnido;

							var cuentasCliente = await clienteServices.GetCuentasCliente(SecuencialClienteVM, SecuencialTransaccionVM);
							if (cuentasCliente != null)
							{
								Device.BeginInvokeOnMainThread(() =>
								{
									IsVisibleButtons = true;
									CuentasCollection = new ObservableCollection<ClienteCuentas>(cuentasCliente);
								});
							}
						}
					}

					IsBusy = false;
				}
			}
			catch (Exception)
			{
				IsBusy = false;
				throw;
			}
		}

		public async void GoToTrans2()
		{
			try
			{
				if (SelectedCuenta.Secuencial > 0)
				{
					DatosCuentaSeleccionada = SelectedCuenta.Codigo + " " + SelectedCuenta.NombreCuenta;
					var GetListMonedas = await clienteServices.GetMonedasTransaccion(SecuencialTransaccionVM, SelectedCuenta.SecuencialEmpresa);
					if(GetListMonedas != null)
					{
						Device.BeginInvokeOnMainThread(async () =>
						{
							DenominacionMoneda = new ObservableCollection<Empresadenominacionfija>(GetListMonedas.DenominacionMoneda);
							ModalidadDeposito = new ObservableCollection<TransaccionTipoMovimiento>(GetListMonedas.TipoMovimiento);
							var Transferencia2 = new Trans2() { BindingContext = this };
							Transferencia2.Title = "Transacción: " + TransaccionSelect;
							await ((MasterDetailPage)Application.Current.MainPage).Detail.Navigation.PushAsync((Page)Transferencia2);
						});
					}
					
				}
				else
				{
					await Application.Current.MainPage.DisplayAlert("TSHIRT", "Debe Seleccionar una cuenta", "OK");
				}
			}
			catch (Exception ex)
			{
				await Application.Current.MainPage.DisplayAlert("TSHIRT", ex.Message, "OK");
				//throw;
			}
		}


		#region COMMANDS 


		public ICommand SearchCliente => new RelayCommand(BusquedaCliente);

		public ICommand NextTrans => new RelayCommand(GoToTrans2);

		

		#endregion
	}
}
