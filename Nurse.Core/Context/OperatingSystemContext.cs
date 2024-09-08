using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

using Nurse.Core.Context.Enums;

namespace Nurse.Core.Context
{
    public class OperatingSystemContext : SystemContext
    {
		private readonly Version _Version;
        private readonly string _Hostname;
        private readonly string _WindowsProductType;
		private readonly string _WindowsVersion;

        public OperatingSystemContext()
        {
			_Version = Environment.OSVersion.Version;
            _Hostname = Environment.MachineName;
			_WindowsProductType = GetWindowsProductType();
			_WindowsVersion = _Version.Major.ToString() + "." + _Version.Minor.ToString() + "." + _Version.Build.ToString();
		}

		private Version Version
		{
			get { return _Version; }
		}

		public string Hostname
        {
            get { return _Hostname; }
        }

		public string WindowsProductType
		{
			get { return _WindowsProductType; }
		}

		public string WindowsVersion
		{
			get { return _WindowsVersion; }
		}

		private string GetWindowsProductType()
        {
			if (GetProductInfo(Version.Major, Version.Minor, 0, 0, out uint productType))
			{
				// Check if productType is defined in the ProductTypes enum
				if (Enum.IsDefined(typeof(ProductTypes), productType))
				{
					// Return the name of the product type if it is defined
					return Enum.GetName(typeof(ProductTypes), productType);
				}
				else
				{
					// Return "Unknown Product Type" if the product type is not defined
					return "Unknown Product Type";
				}
			}
			else
			{
				// Return this if the GetProductInfo call fails
				return "Unknown Product Type";
			}
		}

		[DllImport("kernel32.dll")]
		private static extern bool GetProductInfo(
			int dwOSMajorVersion,
			int dwOSMinorVersion,
			int dwSpMajorVersion,
			int dwSpMinorVersion,
			out uint pdwReturnedProductType);
	}
}