using Microsoft.UI.Xaml;
using Nurse.Core.Context;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Windows.Networking;

namespace Nurse.Desktop.ViewModels
{
	public class InventoryViewModel : INotifyPropertyChanged
	{
		private string _OSName;
		private string _WindowsEdition;
		private string _WindowsInstallDate;

		private bool _isLoading;
	
		private Visibility _loadingVisibility;
		private Visibility _resultVisibility;
		
		private InventoryContext _inventoryContext;

		public event PropertyChangedEventHandler PropertyChanged;

		public InventoryViewModel()
		{
			// Initially show the loading spinner and hide the result
			IsLoading = true;
			LoadingVisibility = Visibility.Visible;
			ResultVisibility = Visibility.Collapsed;

			// Load hostname asynchronously
			GetInventory();
		}

		public string OSName
		{
			get => _OSName;
			private set
			{
				_OSName = value;
				OnPropertyChanged();
			}
		}
		public string WindowsEdition
		{
			get => _WindowsEdition;
			private set
			{
				_WindowsEdition = value;
				OnPropertyChanged();
			}
		}

		public string WindowsInstallDate
		{
			get => _WindowsInstallDate;
			private set
			{
				_WindowsInstallDate = value;
				OnPropertyChanged();
			}
		}

		public bool IsLoading
		{
			get => _isLoading;
			private set
			{
				_isLoading = value;
				OnPropertyChanged();
			}
		}

		public Visibility LoadingVisibility
		{
			get => _loadingVisibility;
			private set
			{
				_loadingVisibility = value;
				OnPropertyChanged();
			}
		}

		public Visibility ResultVisibility
		{
			get => _resultVisibility;
			private set
			{
				_resultVisibility = value;
				OnPropertyChanged();
			}
		}

		// Asynchronously load the inventory using PowerShell
		private async void GetInventory()
		{
			// Initialise instance asynchronously to avoid blocking UI thread
			_inventoryContext = await Task.Run(() => new InventoryContext());

			OSName = _inventoryContext.OSName;
			WindowsEdition = _inventoryContext.WindowsEdition;
			WindowsInstallDate = _inventoryContext.WindowsInstallDate;

			// After Inventory is retrieved, update the loading state and visibility
			IsLoading = false;
			LoadingVisibility = Visibility.Collapsed;
			ResultVisibility = Visibility.Visible;
		}

		// Helper method to raise property changed events
		private void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}