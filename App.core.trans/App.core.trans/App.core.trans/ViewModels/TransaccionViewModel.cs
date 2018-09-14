using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace App.core.trans.ViewModels
{
    public class TransaccionViewModel : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;


		public TransaccionViewModel()
		{
			LoadTransaccion();
		}


		#region PROPIEDADES

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
	}
}
