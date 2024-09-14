using Microsoft.UI.Dispatching;
using Microsoft.UI.Xaml;
using Nurse.Core.Context;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Nurse.Desktop.ViewModels
{
	public class MainViewModel : INotifyPropertyChanged
	{
		public InventoryContext InventoryContext { get; }

		public MainViewModel()
		{
			// Initialize InventoryContext only once
			InventoryContext = new InventoryContext();
		}

		public event PropertyChangedEventHandler PropertyChanged;

		protected void OnPropertyChanged(string propertyName)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}