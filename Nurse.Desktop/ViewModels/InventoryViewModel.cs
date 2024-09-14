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
		private string _WindowsSystemRoot;
		private string _OSVersion;
		private string _BIOSVersion;
		private string _BIOSFirmwareType;
		private string _BIOSManufacturer;
		private string _BIOSReleaseDate;
		private string _WindowsDomain;
		private string _SystemManufacturer;
		private string _SystemFamily;
		private string _SystemModel;
		private string _NumberOfLogicalProcessors;
		private string _NumberOfProcessors;
		private string _SystemType;
		private string _SystemArchitecture;
		private string _TotalPhysicalMemory;
		private string _OSBootDevice;
		private string _OSSystemDevice;
		private string _OSSystemDirectory;
		private string _OSSystemDrive;
		private string _OSWindowsDirectory;
		private string _OSLastBootUpTime;
		private string _OSInstallDate;
		private string _OSLanguage;
		private string _LogonServer;

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

		public string WindowsSystemRoot
		{
			get => _WindowsSystemRoot;
			private set
			{
				_WindowsSystemRoot = value;
				OnPropertyChanged();
			}
		}

		public string OSVersion
		{
			get => _OSVersion;
			private set
			{
				_OSVersion = value;
				OnPropertyChanged();
			}
		}

		public string BIOSVersion
		{
			get => _BIOSVersion;
			private set
			{
				_BIOSVersion = value;
				OnPropertyChanged();
			}
		}

		public string BIOSFirmwareType
		{
			get => _BIOSFirmwareType;
			private set
			{
				_BIOSFirmwareType = value;
				OnPropertyChanged();
			}
		}

		public string BIOSManufacturer
		{
			get => _BIOSManufacturer;
			private set
			{
				_BIOSManufacturer = value;
				OnPropertyChanged();
			}
		}

		public string BIOSReleaseDate
		{
			get => _BIOSReleaseDate;
			private set
			{
				_BIOSReleaseDate = value;
				OnPropertyChanged();
			}
		}

		public string WindowsDomain
		{
			get => _WindowsDomain;
			private set
			{
				_WindowsDomain = value;
				OnPropertyChanged();
			}
		}

		public string SystemManufacturer
		{
			get => _SystemManufacturer;
			private set
			{
				_SystemManufacturer = value;
				OnPropertyChanged();
			}
		}

		public string SystemFamily
		{
			get => _SystemFamily;
			private set
			{
				_SystemFamily = value;
				OnPropertyChanged();
			}
		}

		public string SystemModel
		{
			get => _SystemModel;
			private set
			{
				_SystemModel = value;
				OnPropertyChanged();
			}
		}

		public string NumberOfLogicalProcessors
		{
			get => _NumberOfLogicalProcessors;
			private set
			{
				_NumberOfLogicalProcessors = value;
				OnPropertyChanged();
			}
		}

		public string NumberOfProcessors
		{
			get => _NumberOfProcessors;
			private set
			{
				_NumberOfProcessors = value;
				OnPropertyChanged();
			}
		}

		public string SystemType
		{
			get => _SystemType;
			private set
			{
				_SystemType = value;
				OnPropertyChanged();
			}
		}

		public string SystemArchitecture
		{
			get => _SystemArchitecture;
			private set
			{
				_SystemArchitecture = value;
				OnPropertyChanged();
			}
		}

		public string TotalPhysicalMemory
		{
			get => _TotalPhysicalMemory;
			private set
			{
				_TotalPhysicalMemory = value;
				OnPropertyChanged();
			}
		}

		public string OSBootDevice
		{
			get => _OSBootDevice;
			private set
			{
				_OSBootDevice = value;
				OnPropertyChanged();
			}
		}

		public string OSSystemDevice
		{
			get => _OSSystemDevice;
			private set
			{
				_OSSystemDevice = value;
				OnPropertyChanged();
			}
		}

		public string OSSystemDirectory
		{
			get => _OSSystemDirectory;
			private set
			{
				_OSSystemDirectory = value;
				OnPropertyChanged();
			}
		}

		public string OSSystemDrive
		{
			get => _OSSystemDrive;
			private set
			{
				_OSSystemDrive = value;
				OnPropertyChanged();
			}
		}

		public string OSWindowsDirectory
		{
			get => _OSWindowsDirectory;
			private set
			{
				_OSWindowsDirectory = value;
				OnPropertyChanged();
			}
		}

		public string OSLastBootUpTime
		{
			get => _OSLastBootUpTime;
			private set
			{
				_OSLastBootUpTime = value;
				OnPropertyChanged();
			}
		}

		public string OSInstallDate
		{
			get => _OSInstallDate;
			private set
			{
				_OSInstallDate = value;
				OnPropertyChanged();
			}
		}

		public string OSLanguage
		{
			get => _OSLanguage;
			private set
			{
				_OSLanguage = value;
				OnPropertyChanged();
			}
		}

		public string LogonServer
		{
			get => _LogonServer;
			private set
			{
				_LogonServer = value;
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
			WindowsSystemRoot = _inventoryContext.WindowsSystemRoot;
			OSVersion = _inventoryContext.OSVersion;
			BIOSVersion = _inventoryContext.BIOSVersion;
			BIOSFirmwareType = _inventoryContext.BIOSFirmwareType;
			BIOSManufacturer = _inventoryContext.BIOSManufacturer;
			BIOSReleaseDate = _inventoryContext.BIOSReleaseDate;
			WindowsDomain = _inventoryContext.WindowsDomain;
			SystemManufacturer = _inventoryContext.SystemManufacturer;
			SystemFamily = _inventoryContext.SystemFamily;
			SystemModel = _inventoryContext.SystemModel;
			NumberOfLogicalProcessors = _inventoryContext.NumberOfLogicalProcessors;
			NumberOfProcessors = _inventoryContext.NumberOfProcessors;
			SystemType = _inventoryContext.SystemType;
			SystemArchitecture = _inventoryContext.SystemArchitecture;
			TotalPhysicalMemory = _inventoryContext.TotalPhysicalMemory;
			OSBootDevice = _inventoryContext.OSBootDevice;
			OSSystemDevice = _inventoryContext.OSSystemDevice;
			OSSystemDirectory = _inventoryContext.OSSystemDirectory;
			OSSystemDrive = _inventoryContext.OSSystemDrive;
			OSWindowsDirectory = _inventoryContext.OSWindowsDirectory;
			OSLastBootUpTime = _inventoryContext.OSLastBootUpTime;
			OSInstallDate = _inventoryContext.OSInstallDate;
			OSLanguage = _inventoryContext.OSLanguage;
			LogonServer = _inventoryContext.LogonServer;

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