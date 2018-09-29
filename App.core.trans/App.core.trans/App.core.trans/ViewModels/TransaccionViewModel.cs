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
using App.core.trans.Views;

namespace App.core.trans.ViewModels
{
    public class TransaccionViewModel : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;
		private ClienteServices clienteServices;

		public TransaccionViewModel()
		{
			//myList = new Dictionary<int, string>();
			//selectedIndex = -1;
			//LoadRadio();
			LoadBusquedaCliente();
			LoadTransaccion();
			IsVisibleButtons = false;
		}



		#region PROPIEDADES

		private decimal _totalMoneyClic;
		public decimal TotalMoneyClic
		{
			get { return _totalMoneyClic;  }
			set
			{
				_totalMoneyClic = value;
				RaiseOnPropertyChange();
			}
		}


		private int _money100;
		public int Money100
		{
			get { return _money100; }
			set
			{
				_money100 = value;
				RaiseOnPropertyChange();
			}
		}

		private int _money50;
		public int Money50
		{
			get { return _money50; }
			set
			{
				_money50 = value;
				RaiseOnPropertyChange();
			}
		}

		private int _money20;
		public int Money20
		{
			get { return _money20; }
			set
			{
				_money20 = value;
				RaiseOnPropertyChange();
			}
		}

		private int _money10;
		public int Money10
		{
			get { return _money10; }
			set
			{
				_money10 = value;
				RaiseOnPropertyChange();
			}
		}

		private int _money5;
		public int Money5
		{
			get { return _money5; }
			set
			{
				_money5 = value;
				RaiseOnPropertyChange();
			}
		}

		private int _money1;
		public int Money1
		{
			get { return _money1; }
			set
			{
				_money1 = value;
				RaiseOnPropertyChange();
			}
		}

		private int _money050;
		public int Money050
		{
			get { return _money050; }
			set
			{
				_money050 = value;
				RaiseOnPropertyChange();
			}
		}

		private int _money025;
		public int Money025
		{
			get { return _money025; }
			set
			{
				_money025 = value;
				RaiseOnPropertyChange();
			}
		}

		private int _money010;
		public int Money010
		{
			get { return _money010; }
			set
			{
				_money010 = value;
				RaiseOnPropertyChange();
			}
		}

		private int _money005;
		public int Money005
		{
			get { return _money005; }
			set
			{
				_money005 = value;
				RaiseOnPropertyChange();
			}
		}

		private int _money001;
		public int Money001
		{
			get { return _money001; }
			set
			{
				_money001 = value;
				RaiseOnPropertyChange();
			}
		}

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

		private ObservableCollection<string> _listClienteCollection;
		public ObservableCollection<string> ListClienteCollection
		{
			get { return _listClienteCollection; }
			set { _listClienteCollection = value; RaiseOnPropertyChange(); }
		}

		private ObservableCollection<TransaccionTipoMovimiento> _tipoMovimientoCollection;
		public ObservableCollection<TransaccionTipoMovimiento> TipoMovimientoCollection
		{
			get { return _tipoMovimientoCollection; }
			set { _tipoMovimientoCollection = value; RaiseOnPropertyChange(); }
		}

		private ObservableCollection<string> _transCollection;
		public ObservableCollection<string> TransCollection
		{
			get { return _transCollection; }
			set { _transCollection = value; RaiseOnPropertyChange(); }
		}

		private string _transaccionSelect;
		public string TransaccionSelect
		{
			get { return _transaccionSelect; }
			set { _transaccionSelect = value; RaiseOnPropertyChange(); }
		}

		private string _listClienteSelect;
		public string ListClienteSelect
		{
			get { return _listClienteSelect; }
			set { _listClienteSelect = value; RaiseOnPropertyChange(); }
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

		private void LoadBusquedaCliente()
		{
			//clienteServices = new ClienteServices();

			//List<string> termsList = new List<string>();

			//var result = await clienteServices.GetTransaccion(3); //Secuencial empresa
			//if (result != null)
			//{
			//	TransaccionCollection = new ObservableCollection<Transaccion>(result);
			//	foreach (var item in result)
			//	{
			//		termsList.Add(item.Codigo + " - " + item.Nombre);
			//	}
			//}

			string[] busquedaCliente = { "Código", "Cedula"};
			ListClienteCollection = new ObservableCollection<string>(busquedaCliente);
			ListClienteSelect = "Código";
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
					if (TransaccionSelect != null)
					{
						char[] charSplit = { '-' };
						string[] transaccionSeleccionada = TransaccionSelect.Split(charSplit);

						var _valueSelect = transaccionSeleccionada[0].ToString().Trim();

						SecuencialTransaccionVM = TransaccionCollection.FirstOrDefault(a => a.Codigo == _valueSelect).Secuencial;

						if (SecuencialTransaccionVM > 0)
						{
							int codigoBusquega = (ListClienteSelect == "Código")? 0 : 1;
							IsBusy = true;
							clienteServices = new ClienteServices();
							var result = await clienteServices.GetCliente(int.Parse(SearchName), codigoBusquega);
							if (result.SecuencialCliente > 0)
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
							else
							{
								await Application.Current.MainPage.DisplayAlert("SAC - Pelileo", "Cliente no resgitrado", "OK");
								CuentasCollection = new ObservableCollection<ClienteCuentas>(new List<ClienteCuentas>());
								DatosCliente = null;
								IsVisibleButtons = false;
							}
						}
					}
					else
					{
						await Application.Current.MainPage.DisplayAlert("SAC - Pelileo", "Debe seleccionar una Transacción", "OK");
					}


					IsBusy = false;
				}
			}
			catch (Exception)
			{
				IsBusy = false;
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

		public async void SaveTRansaccion()
		{
			try
			{
				var montoTotal = ModalidadDeposito.Sum(a => a.ValueInsert);

				if (montoTotal == TotalMoneyClic)
				{
					if (montoTotal > 0)
					{
						var answer = await App.Current.MainPage.DisplayAlert("ORIZONTEL", "Desea GUARDAR la operación, se generará un deposito, Desea Continuar?", "SI", "NO");
						if (answer)
						{
							Device.BeginInvokeOnMainThread(async () =>
							{
								await Application.Current.MainPage.DisplayAlert("ORIZONTEL", "Deposito Realizado con Exito", "OK");



								((MasterDetailPage)Application.Current.MainPage).Detail.Navigation.RemovePage(((MasterDetailPage)Application.Current.MainPage).Detail.Navigation.NavigationStack[((MasterDetailPage)Application.Current.MainPage).Detail.Navigation.NavigationStack.Count - 2]);

								//((MasterDetailPage)Application.Current.MainPage).Navigation.RemovePage(new Trans2());


								//await ((MasterDetailPage)Application.Current.MainPage).Detail.Navigation.PopAsync();


								App.Current.MainPage = new MainPage();
								//await ((MasterDetailPage)Application.Current.MainPage).Detail.Navigation.PushAsync((Page)new MainMenuDetail());
							});
							
						}
					}					
				}
				else {
					await Application.Current.MainPage.DisplayAlert("ORIZONTEL", "El monto de la denominación es diferente al Deposito", "OK");
				}
			}
			catch (Exception ex)
			{
				await Application.Current.MainPage.DisplayAlert("ORIZONTEL", ex.Message, "OK");
				throw;
			}

		}


		public async void _onClicmore100()
		{
			try
			{
				Money100 += 1;
				TotalMoneyClic += 100;
			}
			catch (Exception ex)
			{
				await Application.Current.MainPage.DisplayAlert("ORIZONTEL", ex.Message, "OK");
				//throw;
			}
		}

		public async void _onClicmenos100()
		{
			try
			{
				if (Money100 > 0)
				{
					Money100 -= 1;
					TotalMoneyClic -= 100;
				}
					

			}
			catch (Exception ex)
			{
				await Application.Current.MainPage.DisplayAlert("ORIZONTEL", ex.Message, "OK");
				//throw;
			}
		}

		public async void _onClicmore50()
		{
			try
			{
				Money50 += 1;
				TotalMoneyClic += 50;
			}
			catch (Exception ex)
			{
				await Application.Current.MainPage.DisplayAlert("ORIZONTEL", ex.Message, "OK");
				//throw;
			}
		}

		public async void _onClicmenos50()
		{
			try
			{
				if (Money50 > 0)
				{
					Money50 -= 1;
					TotalMoneyClic -= 50;
				}
					

			}
			catch (Exception ex)
			{
				await Application.Current.MainPage.DisplayAlert("ORIZONTEL", ex.Message, "OK");
				//throw;
			}
		}

		public async void _onClicmore20()
		{
			try
			{
				Money20 += 1;
				TotalMoneyClic += 20;
			}
			catch (Exception ex)
			{
				await Application.Current.MainPage.DisplayAlert("ORIZONTEL", ex.Message, "OK");
				//throw;
			}
		}

		public async void _onClicmenos20()
		{
			try
			{
				if (Money20 > 0)
				{
					Money20 -= 1;
					TotalMoneyClic -= 20;
				}
				
			}
			catch (Exception ex)
			{
				await Application.Current.MainPage.DisplayAlert("ORIZONTEL", ex.Message, "OK");
				//throw;
			}
		}

		public async void _onClicmore10()
		{
			try
			{
				Money10 += 1;
				TotalMoneyClic += 10;
			}
			catch (Exception ex)
			{
				await Application.Current.MainPage.DisplayAlert("ORIZONTEL", ex.Message, "OK");
				//throw;
			}
		}

		public async void _onClicmenos10()
		{
			try
			{
				if (Money10 > 0)
				{
					Money10 -= 1;
					TotalMoneyClic -= 10;
				}					
			}
			catch (Exception ex)
			{
				await Application.Current.MainPage.DisplayAlert("ORIZONTEL", ex.Message, "OK");
				//throw;
			}
		}

		public async void _onClicmore5()
		{
			try
			{
				Money5 += 1;
				TotalMoneyClic += 5;
			}
			catch (Exception ex)
			{
				await Application.Current.MainPage.DisplayAlert("ORIZONTEL", ex.Message, "OK");
				//throw;
			}
		}

		public async void _onClicmenos5()
		{
			try
			{
				if (Money5 > 0)
				{
					Money5 -= 1;
					TotalMoneyClic -= 5;
				}
					

			}
			catch (Exception ex)
			{
				await Application.Current.MainPage.DisplayAlert("ORIZONTEL", ex.Message, "OK");
				//throw;
			}
		}

		public async void _onClicmore1()
		{
			try
			{
				Money1 += 1;
				TotalMoneyClic += 1; 
			}
			catch (Exception ex)
			{
				await Application.Current.MainPage.DisplayAlert("ORIZONTEL", ex.Message, "OK");
				//throw;
			}
		}

		public async void _onClicmenos1()
		{
			try
			{
				if (Money1 > 0)
				{
					Money1 -= 1;
					TotalMoneyClic = TotalMoneyClic - 1;
				}
				

			}
			catch (Exception ex)
			{
				await Application.Current.MainPage.DisplayAlert("ORIZONTEL", ex.Message, "OK");
				//throw;
			}
		}

		public async void _onClicmore050()
		{
			try
			{
				Money050 += 1;
				TotalMoneyClic = TotalMoneyClic + Convert.ToDecimal(0.50);
			}
			catch (Exception ex)
			{
				await Application.Current.MainPage.DisplayAlert("ORIZONTEL", ex.Message, "OK");
				//throw;
			}
		}

		public async void _onClicmenos050()
		{
			try
			{
				if (Money050 > 0)
				{
					Money050 -= 1;
					TotalMoneyClic = TotalMoneyClic - Convert.ToDecimal(0.50);
				}
					

			}
			catch (Exception ex)
			{
				await Application.Current.MainPage.DisplayAlert("ORIZONTEL", ex.Message, "OK");
				//throw;
			}
		}

		public async void _onClicmore025()
		{
			try
			{
				Money025 += 1;
				TotalMoneyClic = TotalMoneyClic + Convert.ToDecimal(0.25);
			}
			catch (Exception ex)
			{
				await Application.Current.MainPage.DisplayAlert("ORIZONTEL", ex.Message, "OK");
				//throw;
			}
		}

		public async void _onClicmenos025()
		{
			try
			{
				if (Money025 > 0)
				{
					Money1 -= 1;
					TotalMoneyClic = TotalMoneyClic - Convert.ToDecimal(0.25);
				}
					

			}
			catch (Exception ex)
			{
				await Application.Current.MainPage.DisplayAlert("ORIZONTEL", ex.Message, "OK");
				//throw;
			}
		}

		public async void _onClicmore010()
		{
			try
			{
				Money010 += 1;
				TotalMoneyClic = TotalMoneyClic - Convert.ToDecimal(0.10);
			}
			catch (Exception ex)
			{
				await Application.Current.MainPage.DisplayAlert("ORIZONTEL", ex.Message, "OK");
				//throw;
			}
		}

		public async void _onClicmenos010()
		{
			try
			{
				if (Money010 > 0)
				{
					Money010 -= 1;
					TotalMoneyClic = TotalMoneyClic - Convert.ToDecimal(0.10);
				}
					

			}
			catch (Exception ex)
			{
				await Application.Current.MainPage.DisplayAlert("ORIZONTEL", ex.Message, "OK");
				//throw;
			}
		}

		public async void _onClicmore001()
		{
			try
			{
				Money001 += 1;
				TotalMoneyClic = TotalMoneyClic + Convert.ToDecimal(0.01);
			}
			catch (Exception ex)
			{
				await Application.Current.MainPage.DisplayAlert("ORIZONTEL", ex.Message, "OK");
				//throw;
			}
		}

		public async void _onClicmenos001()
		{
			try
			{
				if (Money001 > 0)
				{
					Money001 -= 1;
					TotalMoneyClic = TotalMoneyClic - Convert.ToDecimal(0.01);
				}
					

			}
			catch (Exception ex)
			{
				await Application.Current.MainPage.DisplayAlert("ORIZONTEL", ex.Message, "OK");
				//throw;
			}
		}
		#region COMMANDS 


		public ICommand SearchCliente => new RelayCommand(BusquedaCliente);

		public ICommand NextTrans => new RelayCommand(GoToTrans2);

		public ICommand SaveTrans => new RelayCommand(SaveTRansaccion);


		public ICommand onClicmore100 => new RelayCommand(_onClicmore100);

		public ICommand onClicmenos100 => new RelayCommand(_onClicmenos100);

		public ICommand onClicmore50 => new RelayCommand(_onClicmore50);

		public ICommand onClicmenos50 => new RelayCommand(_onClicmenos50);

		public ICommand onClicmore20 => new RelayCommand(_onClicmore20);

		public ICommand onClicmenos20 => new RelayCommand(_onClicmenos20);


		public ICommand onClicmore10 => new RelayCommand(_onClicmore10);

		public ICommand onClicmenos10 => new RelayCommand(_onClicmenos10);

		public ICommand onClicmore5 => new RelayCommand(_onClicmore5);

		public ICommand onClicmenos5 => new RelayCommand(_onClicmenos5);

		public ICommand onClicmore1 => new RelayCommand(_onClicmore1);

		public ICommand onClicmenos1 => new RelayCommand(_onClicmenos1);

		public ICommand onClicmore050 => new RelayCommand(_onClicmore050);

		public ICommand onClicmenos050 => new RelayCommand(_onClicmenos050);

		public ICommand onClicmore025 => new RelayCommand(_onClicmore025);

		public ICommand onClicmenos025 => new RelayCommand(_onClicmenos025);

		public ICommand onClicmore010 => new RelayCommand(_onClicmore010);

		public ICommand onClicmenos010 => new RelayCommand(_onClicmenos010);

		public ICommand onClicmore001 => new RelayCommand(_onClicmore001);

		public ICommand onClicmenos001 => new RelayCommand(_onClicmenos001);

		#endregion
	}
}
