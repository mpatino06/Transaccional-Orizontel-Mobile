using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using App.core.trans.Helper;
using App.core.trans.Models;
using App.core.trans.Services;
using GalaSoft.MvvmLight.Command;
using Xamarin.Forms;

namespace App.core.trans.ViewModels
{
	public class RegistrosViewModel : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;
		private ClienteServices clienteServices;
		private PrintReport printReport;

		public RegistrosViewModel(string codigoUsuario)
		{
			CodigoUsuario = codigoUsuario;
			MaxDate = DateTime.Now;
			SelectedDate = DateTime.Now;
			LoadRegistros();			
		}

		private string _codigoUsuario;
		public string CodigoUsuario
		{
			get { return _codigoUsuario; }
			set
			{
				_codigoUsuario = value;
				RaiseOnPropertyChange();
			}
		}

		private DateTime _maxDate;
		public DateTime MaxDate {
			get { return _maxDate; }
			set { _maxDate = value;
				RaiseOnPropertyChange();
			}
		}
		private bool _isVisibleButtons;
		public bool IsVisibleButtons
		{
			get { return  _isVisibleButtons;  }
			set { _isVisibleButtons = value;
				RaiseOnPropertyChange();
			}
		}

		private DateTime _selectedDate;
		public DateTime SelectedDate
		{
			get { return _selectedDate; }
			set
			{
				_selectedDate = value;
				RaiseOnPropertyChange();
			}
		}
		public async void LoadRegistros()
		{
			clienteServices = new ClienteServices();
			var result = await clienteServices.GetRegistroTransacciones(CodigoUsuario, SelectedDate);
			if (result.Count > 0)
			{
				IsVisibleButtons = true;
				TransacccionCollection = new ObservableCollection<TransaccionmobileExtend>(result.OrderByDescending(a => a.Fecha));
			}
			else {
				IsVisibleButtons = false;
				TransacccionCollection = new ObservableCollection<TransaccionmobileExtend>(new List<TransaccionmobileExtend>());
			}
			
		}

		private ObservableCollection<TransaccionmobileExtend> _transacccionCollection = new ObservableCollection<TransaccionmobileExtend>();
		public ObservableCollection<TransaccionmobileExtend> TransacccionCollection
		{
			get { return _transacccionCollection; }
			set
			{
				_transacccionCollection = value;
				HeightListCollection = (_transacccionCollection.Count * 30) + (_transacccionCollection.Count * 5);
				RaiseOnPropertyChange();
			}
		}

		private int _heightListCollection;
		public int HeightListCollection
		{
			get { return _heightListCollection; }
			set { _heightListCollection = value;
				RaiseOnPropertyChange();
			}
		}


		public void RaiseOnPropertyChange([CallerMemberName] string propertyName = null)
		{
			if (PropertyChanged != null)
			{
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}

		public ICommand OnDateSelected => new RelayCommand(DateSelected);
		public ICommand Imprimir => new RelayCommand(PrinList);

		public object resultSaveTransaccion { get; private set; }

		public void DateSelected()
		{
			try
			{
				LoadRegistros();
			}
			catch (Exception ex)
			{

				throw;
			}
		}

		public async void PrinList()
		{
			try
			{

				decimal totSaldoReporte = 0;
				var fechaOperacion = SelectedDate.ToString("dd/MM/yyyy HH:mm:ss");

				String dataToPrint = "$big$Cooperativa de Ahorro y Credito$intro$   Indigena SAC Pelileo Ltda.$intro$$intro$";

				dataToPrint += "$small$Usuario: " + CodigoUsuario + "$intro$";
				dataToPrint += "$small$Fecha: " + fechaOperacion + "$intro$";

				foreach (var item in TransacccionCollection.ToList())
				{
					totSaldoReporte += item.Monto;
					dataToPrint += "$small$" + item.NombreCliente + " " + item.Monto.ToString("N2") + "$intro$"; 
				}

				dataToPrint += "$intro$Total Operacion: " + totSaldoReporte.ToString("N2");
				dataToPrint += "$intro$$intro$$cut$$intro$";

				printReport = new PrintReport();

				printReport.Print(dataToPrint);

			}
			catch (Exception)
			{

				throw;
			}
		}

	}

}
