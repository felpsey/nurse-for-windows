using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;
using System.Management.Automation;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.CodeDom.Compiler;

namespace Nurse.Core.Context
{
    public class InventoryContext : SystemContext
	{
		private PowerShell PowerShell;

		private string _OSName = "Unknown"; // Microsoft Windows 11 Pro
		private string _WindowsEdition = "Unknown"; // Professional
		private string _WindowsInstallDate = "Unknown"; // 02/04/2024 13:22:33
		private string _WindowsSystemRoot = "Unknown"; // C:\Windows
		private string _OSVersion = "Unknown"; // 10.0.22631
		private string _BIOSVersion = "Unknown"; // DELL - 1072009
		private string _BIOSFirmwareType = "Unknown"; // Uefi
		private string _BIOSManufacturer = "Unknown"; // Dell Inc.
		private string _BIOSReleaseDate = "Unknown"; // 07/04/2023 01:00:00
		private string _WindowsDomain = "Unknown"; // WORKGROUP
		private string _SystemManufacturer = "Unknown"; // Dell Inc.
		private string _SystemFamily = "Unknown"; // OptiPlex
		private string _SystemModel = "Unknown"; // OptiPlex 7060
		private string _NumberOfLogicalProcessors = "Unknown"; // 6
		private string _NumberOfProcessors = "Unknown"; // 1
		private string _SystemType = "Unknown"; // Desktop
		private string _SystemArchitecture = "Unknown"; // 64-bit
		private string _TotalPhysicalMemory = "Unknown"; // 8376160256
		private string _OSBootDevice = "Unknown"; // \Device\HarddiskVolume1
		private string _OSSystemDevice = "Unknown"; // \Device\HarddiskVolume3
		private string _OSSystemDirectory = "Unknown"; // C:\Windows\system32
		private string _OSSystemDrive = "Unknown"; // C:\
		private string _OSWindowsDirectory = "Unknown"; // C:\Windows
		private string _OSLastBootUpTime = "Unknown"; // 14/09/2024 15:36:37
		private string _OSInstallDate = "Unknown"; // 02/04/2024 14:22:33
		private string _OSLanguage = "Unknown"; // en-GB
		private string _LogonServer = "Unknown"; // \\FELPS-PCLT-01

		public InventoryContext()
		{
			PowerShell = PowerShell.Create();

			Collection<PSObject> ComputerInfo = GetComputerInfo();

			#pragma warning disable CS8601 // Possible null reference assignment.

			OSName = ComputerInfo[0].Members["OsName"].Value?.ToString();
			WindowsEdition = ComputerInfo[0].Members["WindowsEditionId"].Value?.ToString();
			WindowsInstallDate = ComputerInfo[0].Members["WindowsInstallDateFromRegistry"].Value?.ToString();
			OSVersion = ComputerInfo[0].Members["OsVersion"].Value?.ToString();
			BIOSVersion = ComputerInfo[0].Members["BiosVersion"].Value?.ToString();
			BIOSFirmwareType = ComputerInfo[0].Members["BiosFirmwareType"].Value?.ToString();
			BIOSManufacturer = ComputerInfo[0].Members["BiosManufacturer"].Value?.ToString();
			BIOSReleaseDate = ComputerInfo[0].Members["BiosReleaseDate"].Value?.ToString();
			WindowsDomain = ComputerInfo[0].Members["CsDomain"].Value?.ToString();
			SystemManufacturer = ComputerInfo[0].Members["CsManufacturer"].Value?.ToString();
			SystemFamily = ComputerInfo[0].Members["CsSystemFamily"].Value?.ToString();
			SystemModel = ComputerInfo[0].Members["CsModel"].Value?.ToString();
			NumberOfLogicalProcessors = ComputerInfo[0].Members["CsNumberOfLogicalProcessors"].Value?.ToString();
			NumberOfProcessors = ComputerInfo[0].Members["CsNumberOfProcessors"].Value?.ToString();
			SystemType = ComputerInfo[0].Members["CsPCSystemType"].Value?.ToString();
			SystemArchitecture = ComputerInfo[0].Members["OsArchitecture"].Value?.ToString();
			TotalPhysicalMemory = ComputerInfo[0].Members["CsTotalPhysicalMemory"].Value?.ToString();
			OSBootDevice = ComputerInfo[0].Members["OsBootDevice"].Value?.ToString();
			OSSystemDevice = ComputerInfo[0].Members["OsSystemDevice"].Value?.ToString();
			OSSystemDirectory = ComputerInfo[0].Members["OsSystemDirectory"].Value?.ToString();
			OSSystemDrive = ComputerInfo[0].Members["OsSystemDrive"].Value?.ToString();
			OSWindowsDirectory = ComputerInfo[0].Members["OsWindowsDirectory"].Value?.ToString();
			OSLastBootUpTime = ComputerInfo[0].Members["OsLastBootUpTime"].Value?.ToString();
			OSInstallDate = ComputerInfo[0].Members["OsInstallDate"].Value?.ToString();
			OSLanguage = ComputerInfo[0].Members["OsLanguage"].Value?.ToString();
			LogonServer = ComputerInfo[0].Members["LogonServer"].Value?.ToString();

			#pragma warning restore CS8601 // Possible null reference assignment.
		}

		public string OSName
		{
			get => _OSName;

			private set { 
				_OSName = value; 
			}
		}

		public string WindowsEdition
		{
			get => _WindowsEdition;

			private set
			{
				_WindowsEdition = value;
			}
		}

		public string WindowsInstallDate
		{
			get => _WindowsInstallDate;
			private set
			{
				_WindowsInstallDate = value;
			}
		}

		public string WindowsSystemRoot
		{
			get => _WindowsSystemRoot;
			private set
			{
				_WindowsSystemRoot = value;
			}
		}

		public string OSVersion
		{
			get => _OSVersion;
			private set
			{
				_OSVersion = value;
			}
		}

		public string BIOSVersion
		{
			get => _BIOSVersion;
			private set
			{
				_BIOSVersion = value;
			}
		}

		public string BIOSFirmwareType
		{
			get => _BIOSFirmwareType;
			private set
			{
				_BIOSFirmwareType = value;
			}
		}

		public string BIOSManufacturer
		{
			get => _BIOSManufacturer;
			private set
			{
				_BIOSManufacturer = value;
			}
		}

		public string BIOSReleaseDate
		{
			get => _BIOSReleaseDate;
			private set
			{
				_BIOSReleaseDate = value;
			}
		}

		public string WindowsDomain
		{
			get => _WindowsDomain;
			private set
			{
				_WindowsDomain = value;
			}
		}

		public string SystemManufacturer
		{
			get => _SystemManufacturer;
			private set
			{
				_SystemManufacturer = value;
			}
		}

		public string SystemFamily
		{
			get => _SystemFamily;
			private set
			{
				_SystemFamily = value;
			}
		}

		public string SystemModel
		{
			get => _SystemModel;
			private set
			{
				_SystemModel = value;
			}
		}

		public string NumberOfLogicalProcessors
		{
			get => _NumberOfLogicalProcessors;
			private set
			{
				_NumberOfLogicalProcessors = value;
			}
		}

		public string NumberOfProcessors
		{
			get => _NumberOfProcessors;
			private set
			{
				_NumberOfProcessors = value;
			}
		}

		public string SystemType
		{
			get => _SystemType;
			private set
			{
				_SystemType = value;
			}
		}

		public string SystemArchitecture
		{
			get => _SystemArchitecture;
			private set
			{
				_SystemArchitecture = value;
			}
		}

		public string TotalPhysicalMemory
		{
			get => _TotalPhysicalMemory;
			private set
			{
				_TotalPhysicalMemory = value;
			}
		}

		public string OSBootDevice
		{
			get => _OSBootDevice;
			private set
			{
				_OSBootDevice = value;
			}
		}

		public string OSSystemDevice
		{
			get => _OSSystemDevice;
			private set
			{
				_OSSystemDevice = value;
			}
		}

		public string OSSystemDirectory
		{
			get => _OSSystemDirectory;
			private set
			{
				_OSSystemDirectory = value;
			}
		}

		public string OSSystemDrive
		{
			get => _OSSystemDrive;
			private set
			{
				_OSSystemDrive = value;
			}
		}

		public string OSWindowsDirectory
		{
			get => _OSWindowsDirectory;
			private set
			{
				_OSWindowsDirectory = value;
			}
		}

		public string OSLastBootUpTime
		{
			get => _OSLastBootUpTime;
			private set
			{
				_OSLastBootUpTime = value;
			}
		}

		public string OSInstallDate
		{
			get => _OSInstallDate;
			private set
			{
				_OSInstallDate = value;
			}
		}

		public string OSLanguage
		{
			get => _OSLanguage;
			private set
			{
				_OSLanguage = value;
			}
		}

		public string LogonServer
		{
			get => _LogonServer;
			private set
			{
				_LogonServer = value;
			}
		}

		private Collection<PSObject> GetComputerInfo()
		{
			// Clear previews PowerShell input
			PowerShell.Commands.Clear();

			// Prepare PowerShell Cmdlet
			PowerShell.AddCommand("Get-ComputerInfo");

			// Invoke Powershell
			Collection<PSObject> PSOutput = PowerShell.Invoke();

			return PSOutput;
		}
	}
}
