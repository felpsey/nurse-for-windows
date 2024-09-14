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

		public InventoryContext()
		{
			PowerShell = PowerShell.Create();

			Collection<PSObject> ComputerInfo = GetComputerInfo();

			#pragma warning disable CS8601 // Possible null reference assignment.

			OSName = ComputerInfo[0].Members["OsName"].Value?.ToString();
			WindowsEdition = ComputerInfo[0].Members["WindowsEditionId"].Value?.ToString();
			WindowsInstallDate = ComputerInfo[0].Members["WindowsInstallDateFromRegistry"].Value?.ToString();

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
