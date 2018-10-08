using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using App.core.trans.Models;
using App.core.trans.Services;

namespace App.core.trans.ViewModels
{
	public class RegistrosViewModel : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;
		private ClienteServices clienteServices;
		public RegistrosViewModel(string codigoUsuario)
		{
			CodigoUsuario = codigoUsuario;
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

		public async void LoadRegistros()
		{
			clienteServices = new ClienteServices();
			var result = await clienteServices.GetRegistroTransacciones(CodigoUsuario);
			TransacccionCollection = new ObservableCollection<TransaccionmobileExtend>(result.OrderByDescending(a=> a.Fecha));
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
			set { _heightListCollection = value;  }
		}


		public void RaiseOnPropertyChange([CallerMemberName] string propertyName = null)
		{
			if (PropertyChanged != null)
			{
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}

}
