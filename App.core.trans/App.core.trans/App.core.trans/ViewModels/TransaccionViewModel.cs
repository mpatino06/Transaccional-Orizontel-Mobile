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
using System.Threading.Tasks;
using Android.Bluetooth;
using Android.Content;
using App.core.trans.Helper;

namespace App.core.trans.ViewModels
{
    public class TransaccionViewModel : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;
		private ClienteServices clienteServices;
		private PrintReport printReport;

		public TransaccionViewModel()
		{

			LoadBusquedaCliente();
			LoadTransaccion();
			IsVisibleButtons = false;
			IsvisibleLabel = false;
			IsvisiblePicker = false;
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

		private bool _isVisibleEfectivo;
		public bool IsVisibleEfectivo
		{
			get { return _isVisibleEfectivo; }
			set
			{
				_isVisibleEfectivo = value;
				RaiseOnPropertyChange();
			}
		}

		private bool _isVisibleCheque;
		public bool IsVisibleCheque
		{
			get { return _isVisibleCheque; }
			set
			{
				_isVisibleCheque = value;
				RaiseOnPropertyChange();
			}
		}

		private bool _isvisibleLabel;
		public bool IsvisibleLabel
		{
			get { return _isvisibleLabel; }
			set
			{
				_isvisibleLabel = value;
				RaiseOnPropertyChange();
			}
		}

		private bool _isvisiblePicker;
		public bool IsvisiblePicker
		{
			get { return _isvisiblePicker; }
			set
			{
				_isvisiblePicker = value;
				RaiseOnPropertyChange();
			}
		}

		private string _chequeCuenta;
		public string ChequeCuenta
		{
			get { return _chequeCuenta;  }
			set {
				_chequeCuenta = value;
				RaiseOnPropertyChange();
			}
		}

		private string _chequeNumero;
		public string ChequeNumero
		{
			get { return _chequeNumero; }
			set
			{
				_chequeNumero = value;
				RaiseOnPropertyChange();
			}
		}
		private decimal _chequeMonto;
		public decimal ChequeMonto
		{
			get { return _chequeMonto; }
			set
			{
				_chequeMonto = value;
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

		private string _nombreCliente;
		public string NombreCliente
		{
			get { return _nombreCliente; }
			set
			{
				_nombreCliente = value;
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

		private int _heightListCheque;

		public int HeightListCheque
		{
			get { return _heightListCheque; }
			set
			{
				_heightListCheque = value;
				RaiseOnPropertyChange();
			}
		}

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

		private string _codigoUsuarioVM;
		public string CodigoUsuarioVM
		{
			get { return _codigoUsuarioVM; }
			set
			{
				_codigoUsuarioVM = value;
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

		private int _secuencialOficinaVM;
		public int SecuencialOficinaVM
		{
			get { return _secuencialOficinaVM; }
			set
			{
				_secuencialOficinaVM = value;
				RaiseOnPropertyChange();
			}
		}

		private string _nombreTransaccionVM;
		public string NombreTransaccionVM
		{
			get { return _nombreTransaccionVM; }
			set
			{
				_nombreTransaccionVM = value;
				RaiseOnPropertyChange();
			}
		}

		private string _siglasTransaccionVM;
		public string SiglasTransaccionVM
		{
			get { return _siglasTransaccionVM; }
			set
			{
				_siglasTransaccionVM = value;
				RaiseOnPropertyChange();
			}
		}

		private int _numeroClienteVM;
		public int NumeroClienteVM
		{
			get { return _numeroClienteVM; }
			set
			{
				_numeroClienteVM = value;
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

		private ObservableCollection<Cheque> _chequeAdd = new ObservableCollection<Cheque>();
		public ObservableCollection<Cheque> ChequeAdd
		{
			get { return _chequeAdd; }
			set
			{
				_chequeAdd = value;
				HeightListCheque = (_chequeAdd.Count * 30) + (_chequeAdd.Count * 5);
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

		private ObservableCollection<string> _listClienteNameCollection;
		public ObservableCollection<string> ListClienteNameCollection
		{
			get { return _listClienteNameCollection; }
			set { _listClienteNameCollection = value; RaiseOnPropertyChange(); }
		}

		private ObservableCollection<TransaccionTipoMovimiento> _tipoMovimientoCollection;
		public ObservableCollection<TransaccionTipoMovimiento> TipoMovimientoCollection
		{
			get { return _tipoMovimientoCollection; }
			set { _tipoMovimientoCollection = value; RaiseOnPropertyChange(); }
		}

		private ObservableCollection<Banco> _listBancosCollection;
		public ObservableCollection<Banco> ListBancosCollection
		{
			get { return _listBancosCollection; }
			set { _listBancosCollection = value; RaiseOnPropertyChange(); }
		}

		private ObservableCollection<Banco> _listBancosSelectCollection;
		public ObservableCollection<Banco> ListBancosSelect
		{
			get { return _listBancosSelectCollection; }
			set { _listBancosSelectCollection = value; RaiseOnPropertyChange(); }
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

		private ObservableCollection<string> _bancoCollection;
		public ObservableCollection<string> BancoCollection
		{
			get { return _bancoCollection; }
			set { _bancoCollection = value; RaiseOnPropertyChange(); }
		}


		private ObservableCollection<ClienteExtend> _ListName = new ObservableCollection<ClienteExtend>();
		public ObservableCollection<ClienteExtend> ListName
		{
			get { return _ListName; }
			set { _ListName = value; RaiseOnPropertyChange(); }
		}

		private string _bancoSelect;
		public string BancoSelect
		{
			get { return _bancoSelect; }
			set { _bancoSelect = value; RaiseOnPropertyChange(); }
		}


		private string _listClienteSelect;
		public string ListClienteSelect
		{
			get { return _listClienteSelect; }
			set { _listClienteSelect = value; RaiseOnPropertyChange(); }
		}

		private string _listClienteNameSelect;
		public string ListClienteNameSelect
		{
			get { return _listClienteNameSelect; }
			set { _listClienteNameSelect = value; RaiseOnPropertyChange(); }
		}

		private string _nombreCuentaVM;
		public string NombreCuentaVM
		{
			get { return _nombreCuentaVM; }
			set { _nombreCuentaVM = value; RaiseOnPropertyChange(); }
		}

		private ClienteCuentas _selectedCuenta = new ClienteCuentas();

		public ClienteCuentas SelectedCuenta
		{
			get { return _selectedCuenta; }
			set { _selectedCuenta = value; RaiseOnPropertyChange(); }
		}

		private Cheque _selectedCheque = new Cheque();

		public Cheque SelectedCheque
		{
			get { return _selectedCheque; }
			set { _selectedCheque = value; RaiseOnPropertyChange(); }
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

		private ObservableCollection<TransaccionTipoMovimiento> _modalidadDepositoTrans3;
		public ObservableCollection<TransaccionTipoMovimiento> ModalidadDepositoTrans3 //Efectivo - Cheque
		{
			get { return _modalidadDepositoTrans3; }
			set
			{
				_modalidadDepositoTrans3 = value;
				HeightListTipoDeposito = (_modalidadDepositoTrans3.Count * 40) + (_modalidadDepositoTrans3.Count * 5);
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
			string[] busquedaCliente = { "Cuenta", "Cedula", "Nombre"};
			ListClienteCollection = new ObservableCollection<string>(busquedaCliente);
			ListClienteSelect = "Cuenta";
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

						//SecuencialTransaccionVM = TransaccionCollection.FirstOrDefault(a => a.Codigo == _valueSelect).Secuencial;

						var resultTransaccion =  TransaccionCollection.FirstOrDefault(a => a.Codigo == _valueSelect);
						SecuencialTransaccionVM = resultTransaccion.Secuencial;
						NombreTransaccionVM = resultTransaccion.Nombre;
						SiglasTransaccionVM = resultTransaccion.Siglas;

						if (SecuencialTransaccionVM > 0)
						{
							int codigoBusquega = 0;

							switch (ListClienteSelect)
							{
								case "Cuenta":
									codigoBusquega = 0;
									break;
								case "Cedula":
									codigoBusquega = 1;
									break;
								case "Nombre":
									codigoBusquega = 2;
									break;
							}
							
							IsBusy = true;
							clienteServices = new ClienteServices();

							var result = await clienteServices.GetCliente(SearchName.Trim(), codigoBusquega);
							if (result.Any())
							{
								if (codigoBusquega < 2)
								{
									IsvisibleLabel = true;
									IsvisiblePicker = false;

									var resultfirst = result.FirstOrDefault();
									SecuencialClienteVM = resultfirst.SecuencialCliente;
									SecuencialEmpresaVM = resultfirst.SecuencialEmpresa;
									NumeroClienteVM = resultfirst.NumeroCliente;
									SecuencialOficinaVM = resultfirst.SecuencialOficina;

									DatosCliente = resultfirst.Identificacion.ToString() + " " + resultfirst.NombreUnido;
									NombreCliente = resultfirst.NombreUnido;

									SearcCuenta();
								}
								else
								{
									List<string> nameList = new List<string>();
									ListName = new ObservableCollection<ClienteExtend>(result);

									foreach (var item in result)
									{
										nameList.Add(item.NombreUnido);
									}

									IsvisibleLabel = false;
									IsvisiblePicker = true;

									ListClienteNameCollection = new ObservableCollection<string>(nameList);
									ListClienteNameSelect = result.FirstOrDefault().NombreUnido;
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

		private async void SearcCuenta()
		{
			try
			{
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
			catch (Exception)
			{

			}
		}

		public async void AddCheque()
		{
			try
			{
				if (ChequeMonto == 0)
				{
					await Application.Current.MainPage.DisplayAlert("SAC - Pelileo", "EL monto ingresado debe ser Mayor a 0", "OK");
				}
				else if((ChequeCuenta != null) || (ChequeNumero != null))
				{
					
					decimal montoTotalCheque = ModalidadDepositoTrans3.FirstOrDefault(a => a.CodigoTipoMovimiento == "Cheque").ValueInsert;
					decimal montoChequeAgregados = ChequeAdd.Sum(a => a.Valor) + ChequeMonto;
					
					if (montoTotalCheque >= montoChequeAgregados)
					{
						bool montoChequeOK = (montoTotalCheque == montoChequeAgregados);

						char[] charSplit = { '-' };
						string[] bancoSeleccionado = BancoSelect.Split(charSplit);
						var _valueBancoSelect = bancoSeleccionado[0].ToString().Trim();
						var resultBancoSeleccionda = ListBancosCollection.FirstOrDefault(a => a.Codigo == _valueBancoSelect);
						var _chequeAdd = new Cheque();

						_chequeAdd.SecuencialBancoEmisor = resultBancoSeleccionda.Secuencial;
						_chequeAdd.CodigoCuentaCorriente = ChequeCuenta;
						_chequeAdd.CodigoCheque = ChequeNumero;
						_chequeAdd.Valor = ChequeMonto;
						_chequeAdd.CodigoEstadoCheque = bancoSeleccionado[1].ToString().Trim();

						int countItemsDetail = ChequeAdd.Count == 0 ? 1 : ChequeAdd.Count;

						if (ChequeAdd.Count == 1)
							HeightListCheque = (countItemsDetail * 60) + (countItemsDetail * 15);
						else
							HeightListCheque = (countItemsDetail * 40) + (countItemsDetail * 12);

						ChequeAdd.Add(_chequeAdd);
						ChequeMonto = 0;
						ChequeCuenta = null;
						ChequeNumero = null;
						BancoSelect = null;

						if (montoChequeOK)
						{
							var mod = ModalidadDepositoTrans3.Select(a => new TransaccionTipoMovimiento
							{
								CodigoTipoMovimiento = a.CodigoTipoMovimiento,
								ValueInsert = a.ValueInsert,
								Imagen = (a.CodigoTipoMovimiento =="Cheque")? "check": a.Imagen
							});

							ModalidadDepositoTrans3 = new ObservableCollection<TransaccionTipoMovimiento>(mod);
						}

					}
					else
					{
						await Application.Current.MainPage.DisplayAlert("SAC - Pelileo", "EL monto es superior al ingresado en Deposito de Cheques", "OK");
					}

				}
				else
				{
					await Application.Current.MainPage.DisplayAlert("SAC - Pelileo", "Todos los valores son obligatorios", "OK");
				}


			}
			catch (Exception ex)
			{
				await Application.Current.MainPage.DisplayAlert("SAC - Pelileo", "Error: " + ex.Message.ToString(), "OK");
			}
		}

		public async void DeleteCheque()
		{
			try
			{
				if (SelectedCheque != null)
				{
				 ChequeAdd.Remove(SelectedCheque);

					var mod = ModalidadDepositoTrans3.Select(a => new TransaccionTipoMovimiento
					{
						CodigoTipoMovimiento = a.CodigoTipoMovimiento,
						ValueInsert = a.ValueInsert - SelectedCheque.Valor,
						Imagen = "fail"
					});

					ModalidadDepositoTrans3 = new ObservableCollection<TransaccionTipoMovimiento>(mod);

				}
			}
			catch (Exception ex)
			{
				await Application.Current.MainPage.DisplayAlert("SAC - Pelileo", "Error: " + ex.Message.ToString(), "OK");
				throw;
			}
		}

		public async void CancelarTransaccion2()
		{
			try
			{
				var answer = await App.Current.MainPage.DisplayAlert("SAC - Pelileo", "Desea CANCELAR la operación, perderá los cambios realizados, Desea Continuar?", "SI", "NO");
				if (answer)
				{
					((MasterDetailPage)Application.Current.MainPage).Detail.Navigation.RemovePage(((MasterDetailPage)Application.Current.MainPage).Detail.Navigation.NavigationStack[((MasterDetailPage)Application.Current.MainPage).Detail.Navigation.NavigationStack.Count - 2]);
					App.Current.MainPage = new MainPage();
				}
			}
			catch (Exception ex)
			{
				throw;
			}
		}

		public async void CancelarTransaccion3()
		{
			try
			{
				var answer = await App.Current.MainPage.DisplayAlert("SAC - Pelileo", "Desea CANCELAR la operación, perderá los cambios realizados, Desea Continuar?", "SI", "NO");
				if (answer)
				{
					((MasterDetailPage)Application.Current.MainPage).Detail.Navigation.RemovePage(((MasterDetailPage)Application.Current.MainPage).Detail.Navigation.NavigationStack[((MasterDetailPage)Application.Current.MainPage).Detail.Navigation.NavigationStack.Count - 3]);
					App.Current.MainPage = new MainPage();
				}
			}
			catch (Exception ex)
			{
				throw;
			}
		}

		public async void GoToTrans2()
		{
			try
			{
				if (SelectedCuenta.Secuencial > 0)
				{
					NombreCuentaVM = SelectedCuenta.NombreCuenta;
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
					await Application.Current.MainPage.DisplayAlert("SAC - Pelileo", "Debe Seleccionar una cuenta", "OK");
				}
			}
			catch (Exception ex)
			{
				await Application.Current.MainPage.DisplayAlert("SAC - Pelileo", ex.Message, "OK");
				//throw;
			}
		}


		public async void GoToTrans3()
		{
			try
			{
				IsVisibleCheque = false;
				IsVisibleEfectivo = false;

				if (ModalidadDeposito.Sum(a => a.ValueInsert) > 0)
				{
					var mod = ModalidadDeposito.Select(a => new TransaccionTipoMovimiento
					{
                      CodigoTipoMovimiento = a.CodigoTipoMovimiento,
					  ValueInsert = a.ValueInsert,
					  Imagen = "fail"
					});

					ModalidadDeposito = new ObservableCollection<TransaccionTipoMovimiento>(mod);

					if (ModalidadDeposito.FirstOrDefault(a => a.CodigoTipoMovimiento == "Cheque").ValueInsert > 0)
					{
						clienteServices = new ClienteServices();
						var _bancos = await clienteServices.GetBanco();
						
						IsVisibleCheque = true;

						List<string> _termsList = new List<string>();
						if (_bancos != null)
						{
							ListBancosCollection = new ObservableCollection<Banco>(_bancos);
							foreach (var item in _bancos)
							{
								_termsList.Add(item.Codigo.ToString() + " - " + item.Nombre);
							}
						}

						string[] _collection = _termsList.ToArray();
						BancoCollection = new ObservableCollection<string>(_collection);
					}

					if (ModalidadDeposito.FirstOrDefault(a => a.CodigoTipoMovimiento == "Efectivo").ValueInsert > 0)
					{
						IsVisibleEfectivo = true;
					}


					var Transferencia3 = new Trans3() { BindingContext = this };
					Transferencia3.Title = "Transacción: " + TransaccionSelect;

					//ModalidadDeposito = new ObservableCollection<TransaccionTipoMovimiento>(ModalidadDeposito.Where(a=> a.ValueInsert > 0));
					ChequeAdd = new ObservableCollection<Cheque>(new List<Cheque>());
					ModalidadDepositoTrans3 = new ObservableCollection<TransaccionTipoMovimiento>(ModalidadDeposito.Where(a => a.ValueInsert > 0));
					await ((MasterDetailPage)Application.Current.MainPage).Detail.Navigation.PushAsync((Page)Transferencia3);
				}
				else
				{
					await Application.Current.MainPage.DisplayAlert("SAC - Pelileo", "Debe ingresar un monto para Depositar", "OK");
				}
			}
			catch (Exception ex)
			{
				await Application.Current.MainPage.DisplayAlert("SAC - Pelileo", ex.Message, "OK");
				//throw;
			}
		}


		public async void SaveTransaccion()
		{
			try
			{
				var montoTotal = ModalidadDeposito.Sum(a => a.ValueInsert);
				var montoTotalCheque = ChequeAdd.Sum(a => a.Valor);

				if (montoTotal == (TotalMoneyClic + montoTotalCheque))
				{
					if (montoTotal > 0)
					{
						var answer = await App.Current.MainPage.DisplayAlert("SAC - Pelileo", "Desea GUARDAR la operación, se generará un deposito, Desea Continuar?", "SI", "NO");
						if (answer)
						{
							RegistrarTransaccion registrarTransaccion = new RegistrarTransaccion();

							registrarTransaccion.CodigoUsuario = "ADMIN";
							registrarTransaccion.SecuencialTransaccion = SecuencialTransaccionVM;
							registrarTransaccion.NombreTransaccion = NombreTransaccionVM;
							registrarTransaccion.SiglasTransaccion = SiglasTransaccionVM;

							registrarTransaccion.secCliente = SecuencialClienteVM;
							registrarTransaccion.numCliente = NumeroClienteVM;
							registrarTransaccion.SecEmpresa = SecuencialEmpresaVM;
							registrarTransaccion.SecOficina = SecuencialOficinaVM;

							registrarTransaccion.SecuencialCuenta = SelectedCuenta.Secuencial;
							registrarTransaccion.CodigoCuenta = SelectedCuenta.Codigo;
							registrarTransaccion.SecuencialMoneda = SelectedCuenta.SecuencialMoneda;
						
							registrarTransaccion.Transacciones = GetMontoTrnasacciones();
							registrarTransaccion.Cheques = ChequeAdd.ToList();

							clienteServices = new ClienteServices();
							var resultSaveTransaccion = await clienteServices.SaveTransaccion(registrarTransaccion);

							if (resultSaveTransaccion.Result)
							{
								Device.BeginInvokeOnMainThread(async () =>
								{

									//INICIO - INPRIMIR EN IMPRESORA THERMAL
									var fechaOperacion = DateTime.Now.ToString("dd/MM/yyyy hh:mm");
									
									String dataToPrint = "$big$Cooperativa de Ahorro y Credito$intro$   Indigena SAC Pelileo Ltda.$intro$$intro$";

									dataToPrint += "$small$Operador: " + "ADMIN" + "$intro$";
									dataToPrint += "Fecha: " + fechaOperacion + "$intro$";
									dataToPrint += "Cliente: " + NombreCliente + "$intro$";
									dataToPrint += "Monto: " + montoTotal.ToString("N2") + "$intro$";
									dataToPrint += "Saldo despues de Operación: " + resultSaveTransaccion.Saldodeposito.ToString("N2") + "$intro$";
									dataToPrint += "Documento: " + resultSaveTransaccion.SecuencialDocumento.ToString() + "$intro$";
									dataToPrint += "Cliente: " + NumeroClienteVM + "$intro$";
									dataToPrint += "Cuenta: " + NombreCuentaVM + "$intro$$intro$";
									dataToPrint += "Firma: " + "_____________________" + "$intro$";
									dataToPrint += "$intro$$intro$$cut$$intro$";

									printReport = new PrintReport();

									printReport.Print(dataToPrint);

									//FIN - INPRIMIR EN IMPRESORA THERMAL

									var answerPrint = await App.Current.MainPage.DisplayAlert("SAC - Pelileo", "Desea IMPRIMIR otro recibo?", "SI", "NO");
									if (answerPrint)
									{
										String dataToPrint2 = "$big$Cooperativa de Ahorro y Credito$intro$   Indigena SAC Pelileo Ltda.$intro$$intro$";

										dataToPrint2 += "$small$Operador: " + "ADMIN" + "$intro$";
										dataToPrint2 += "Fecha: " + fechaOperacion + "$intro$";
										dataToPrint2 += "Cliente: " + NombreCliente + "$intro$";
										dataToPrint2 += "Monto: " + montoTotal.ToString("N2") + "$intro$";
										dataToPrint2 += "Saldo despues de Operación: " + resultSaveTransaccion.Saldodeposito.ToString("N2") + "$intro$";
										dataToPrint += "Documento: " + resultSaveTransaccion.SecuencialDocumento.ToString() + "$intro$";
										dataToPrint += "Cliente: " + NumeroClienteVM + "$intro$";
										dataToPrint += "Cuenta: " + NombreCuentaVM + "$intro$$intro$";
										dataToPrint2 += "Firma: " + "_____________________" + "$intro$";
										dataToPrint2 += "$intro$$intro$$cut$$intro$";

										printReport = new PrintReport();

										printReport.Print(dataToPrint2);

									}


									await Application.Current.MainPage.DisplayAlert("SAC - Pelileo", "Deposito Realizado con Exito", "OK");

									((MasterDetailPage)Application.Current.MainPage).Detail.Navigation.RemovePage(((MasterDetailPage)Application.Current.MainPage).Detail.Navigation.NavigationStack[((MasterDetailPage)Application.Current.MainPage).Detail.Navigation.NavigationStack.Count - 3]);

									App.Current.MainPage = new MainPage();
								});
							}
							else
							{
								await Application.Current.MainPage.DisplayAlert("SAC - Pelileo", "Se presentó un error al momento de Registrar la transacción", "OK");
							}

							
						}
					}					
				}
				else {
					await Application.Current.MainPage.DisplayAlert("SAC - Pelileo", "El monto de la denominación es diferente al Deposito", "OK");
				}
			}
			catch (Exception ex)
			{
				await Application.Current.MainPage.DisplayAlert("SAC - Pelileo", ex.Message, "OK");
				throw;
			}

		}

		public TransaccionMoneda GetMontoTrnasacciones()
		{
			TransaccionMoneda transaccionMoneda = new TransaccionMoneda();
			List<Empresadenominacionfija> list = new List<Empresadenominacionfija>();

			list.Add(new Empresadenominacionfija { Secuencial = 1, Denominacion = "100", ValueInsert = Money100 });
			list.Add(new Empresadenominacionfija { Secuencial = 2, Denominacion = "50", ValueInsert = Money50 });
			list.Add(new Empresadenominacionfija { Secuencial = 3, Denominacion = "20", ValueInsert = Money20 });
			list.Add(new Empresadenominacionfija { Secuencial = 4, Denominacion = "10", ValueInsert = Money10 });
			list.Add(new Empresadenominacionfija { Secuencial = 5, Denominacion = "5", ValueInsert = Money5 });
			list.Add(new Empresadenominacionfija { Secuencial = 6, Denominacion = "1", ValueInsert = Money1 });
			list.Add(new Empresadenominacionfija { Secuencial = 7, Denominacion = "0.50", ValueInsert = Money050 });
			list.Add(new Empresadenominacionfija { Secuencial = 8, Denominacion = "0.25", ValueInsert = Money025 });
			list.Add(new Empresadenominacionfija { Secuencial = 9, Denominacion = "0.10", ValueInsert = Money010 });
			list.Add(new Empresadenominacionfija { Secuencial = 10, Denominacion = "0.05", ValueInsert = Money005 });
			list.Add(new Empresadenominacionfija { Secuencial = 11, Denominacion = "0.01", ValueInsert = Money001 });

			transaccionMoneda.DenominacionMoneda = list;
			transaccionMoneda.TipoMovimiento = ModalidadDeposito.ToList();


			return transaccionMoneda;
		}




		#region "DENOMINACION MONEDA EFECTIVO"

		public async Task<bool> CheckMontoMoneda(decimal monto)
		{
			decimal montoTotalEfectivo = ModalidadDepositoTrans3.FirstOrDefault(a => a.CodigoTipoMovimiento == "Efectivo").ValueInsert;
			decimal montoEfectivoAgregado = TotalMoneyClic + monto;

			bool result = false;


			if (montoTotalEfectivo >= montoEfectivoAgregado)
			{

				if (monto > 0)
					TotalMoneyClic += monto;
				else
				{
					TotalMoneyClic += monto;
					var mod1 = ModalidadDepositoTrans3.Select(a => new TransaccionTipoMovimiento
					{
						CodigoTipoMovimiento = a.CodigoTipoMovimiento,
						ValueInsert = a.ValueInsert,
						Imagen = (a.CodigoTipoMovimiento == "Efectivo")? "fail" : a.Imagen
					});

					ModalidadDepositoTrans3 = new ObservableCollection<TransaccionTipoMovimiento>(mod1);
				}

				if (montoTotalEfectivo == montoEfectivoAgregado)
				{
					var mod = ModalidadDepositoTrans3.Select(a => new TransaccionTipoMovimiento
					{
						CodigoTipoMovimiento = a.CodigoTipoMovimiento,
						ValueInsert = a.ValueInsert,
						Imagen = (a.CodigoTipoMovimiento == "Efectivo") ? "check" : a.Imagen
					});

					ModalidadDepositoTrans3 = new ObservableCollection<TransaccionTipoMovimiento>(mod);
				}

				result = true;
			}
			else
			{
				await Application.Current.MainPage.DisplayAlert("SAC - Pelileo", "EL monto es superior al ingresado en Deposito de Efectivo", "OK");
			}


			return result;
		}

		public async void _onClicmore100()
		{
			try
			{
				
				if(await CheckMontoMoneda(100))
					Money100 += 1;
			}
			catch (Exception ex)
			{
				await Application.Current.MainPage.DisplayAlert("SAC - Pelileo", ex.Message, "OK");
				//throw;
			}
		}

		public async void _onClicmenos100()
		{
			try
			{
				if (Money100 > 0)
				{
					
					if (await CheckMontoMoneda(-100))
						Money100 -= 1;
					//TotalMoneyClic -= 100;
				}
					

			}
			catch (Exception ex)
			{
				await Application.Current.MainPage.DisplayAlert("SAC - Pelileo", ex.Message, "OK");
				//throw;
			}
		}

		public async void _onClicmore50()
		{
			try
			{			
				if(await CheckMontoMoneda(50))
					Money50 += 1;
				//TotalMoneyClic += 50;
			}
			catch (Exception ex)
			{
				await Application.Current.MainPage.DisplayAlert("SAC - Pelileo", ex.Message, "OK");
				//throw;
			}
		}

		public async void _onClicmenos50()
		{
			try
			{
				if (Money50 > 0)
				{
					
					if(await CheckMontoMoneda(-50))
						Money50 -= 1;
					//TotalMoneyClic -= 50;
				}
					

			}
			catch (Exception ex)
			{
				await Application.Current.MainPage.DisplayAlert("SAC - Pelileo", ex.Message, "OK");
				//throw;
			}
		}

		public async void _onClicmore20()
		{
			try
			{				
				if(await CheckMontoMoneda(20))
					Money20 += 1;
				//TotalMoneyClic += 20;
			}
			catch (Exception ex)
			{
				await Application.Current.MainPage.DisplayAlert("SAC - Pelileo", ex.Message, "OK");
				//throw;
			}
		}

		public async void _onClicmenos20()
		{
			try
			{
				if (Money20 > 0)
				{
					
					if(await CheckMontoMoneda(-20))
						Money20 -= 1;
					//TotalMoneyClic -= 20;
				}
				
			}
			catch (Exception ex)
			{
				await Application.Current.MainPage.DisplayAlert("SAC - Pelileo", ex.Message, "OK");
				//throw;
			}
		}

		public async void _onClicmore10()
		{
			try
			{
				
				if(await CheckMontoMoneda(10))
					Money10 += 1;
				//TotalMoneyClic += 10;
			}
			catch (Exception ex)
			{
				await Application.Current.MainPage.DisplayAlert("SAC - Pelileo", ex.Message, "OK");
				//throw;
			}
		}

		public async void _onClicmenos10()
		{
			try
			{
				if (Money10 > 0)
				{
					
					if(await CheckMontoMoneda(-10))
						Money10 -= 1;
					//TotalMoneyClic -= 10;
				}					
			}
			catch (Exception ex)
			{
				await Application.Current.MainPage.DisplayAlert("SAC - Pelileo", ex.Message, "OK");
				//throw;
			}
		}

		public async void _onClicmore5()
		{
			try
			{				
				if (await CheckMontoMoneda(5))
					Money5 += 1;
				//TotalMoneyClic += 5;
			}
			catch (Exception ex)
			{
				await Application.Current.MainPage.DisplayAlert("SAC - Pelileo", ex.Message, "OK");
				//throw;
			}
		}

		public async void _onClicmenos5()
		{
			try
			{
				if (Money5 > 0)
				{
					
					if (await CheckMontoMoneda(-5))
						Money5 -= 1;
					//TotalMoneyClic -= 5;
				}
					

			}
			catch (Exception ex)
			{
				await Application.Current.MainPage.DisplayAlert("SAC - Pelileo", ex.Message, "OK");
				//throw;
			}
		}

		public async void _onClicmore1()
		{
			try
			{
				
				if (await CheckMontoMoneda(1))
					Money1 += 1;
				//TotalMoneyClic += 1; 
			}
			catch (Exception ex)
			{
				await Application.Current.MainPage.DisplayAlert("SAC - Pelileo", ex.Message, "OK");
				//throw;
			}
		}

		public async void _onClicmenos1()
		{
			try
			{
				if (Money1 > 0)
				{					
					if (await CheckMontoMoneda(-1))
						Money1 -= 1;
					//TotalMoneyClic = TotalMoneyClic - 1;
				}
				

			}
			catch (Exception ex)
			{
				await Application.Current.MainPage.DisplayAlert("SAC - Pelileo", ex.Message, "OK");
				//throw;
			}
		}

		public async void _onClicmore050()
		{
			try
			{
				
				if (await CheckMontoMoneda(Convert.ToDecimal(0.50)))
					Money050 += 1;
				//TotalMoneyClic = TotalMoneyClic + Convert.ToDecimal(0.50);
			}
			catch (Exception ex)
			{
				await Application.Current.MainPage.DisplayAlert("SAC - Pelileo", ex.Message, "OK");
				//throw;
			}
		}

		public async void _onClicmenos050()
		{
			try
			{
				if (Money050 > 0)
				{
					
					if (await CheckMontoMoneda(Convert.ToDecimal(-0.50)))
						Money050 -= 1;
					//TotalMoneyClic = TotalMoneyClic - Convert.ToDecimal(0.50);
				}
					

			}
			catch (Exception ex)
			{
				await Application.Current.MainPage.DisplayAlert("SAC - Pelileo", ex.Message, "OK");
				//throw;
			}
		}

		public async void _onClicmore025()
		{
			try
			{
				
				if (await CheckMontoMoneda(Convert.ToDecimal(0.25)))
					Money025 += 1;
				//TotalMoneyClic = TotalMoneyClic + Convert.ToDecimal(0.25);
			}
			catch (Exception ex)
			{
				await Application.Current.MainPage.DisplayAlert("SAC - Pelileo", ex.Message, "OK");
				//throw;
			}
		}

		public async void _onClicmenos025()
		{
			try
			{
				if (Money025 > 0)
				{
					
					if (await CheckMontoMoneda(Convert.ToDecimal(-0.25)))
						Money1 -= 1;

					//TotalMoneyClic = TotalMoneyClic - Convert.ToDecimal(0.25);
				}
					

			}
			catch (Exception ex)
			{
				await Application.Current.MainPage.DisplayAlert("SAC - Pelileo", ex.Message, "OK");
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
				await Application.Current.MainPage.DisplayAlert("SAC - Pelileo", ex.Message, "OK");
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
				await Application.Current.MainPage.DisplayAlert("SAC - Pelileo", ex.Message, "OK");
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
				await Application.Current.MainPage.DisplayAlert("SAC - Pelileo", ex.Message, "OK");
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
				await Application.Current.MainPage.DisplayAlert("SAC - Pelileo", ex.Message, "OK");
				//throw;
			}
		}

		#endregion

		#region COMMANDS 


		public ICommand SearchCliente => new RelayCommand(BusquedaCliente);

		public ICommand NextTrans => new RelayCommand(GoToTrans2);

		public ICommand NextTrans2 => new RelayCommand(GoToTrans3);

		public ICommand SaveTrans => new RelayCommand(SaveTransaccion);

		public ICommand onClicCheque => new RelayCommand(AddCheque);

		public ICommand onClicDeleteCheque => new RelayCommand(DeleteCheque);

		public ICommand CancelarTrans2 => new RelayCommand(CancelarTransaccion2);

		public ICommand CancelarTrans3 => new RelayCommand(CancelarTransaccion3);

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
