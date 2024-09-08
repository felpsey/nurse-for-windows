using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Nurse.Core.Context;

namespace Nurse.Desktop.Views
{
	public sealed partial class SystemPage : Page
	{
		public SystemPage()
		{
			this._OperatingSystemContext = new OperatingSystemContext();

			this._Hostname = _OperatingSystemContext.Hostname;
			this._WindowsVersion = _OperatingSystemContext.WindowsVersion;
			this._WindowsProductType = _OperatingSystemContext.WindowsProductType;

			this.InitializeComponent();
		}

		private OperatingSystemContext _OperatingSystemContext;

		private readonly string _Hostname;
		private readonly string _WindowsVersion;
		private readonly string _WindowsProductType;

		public string Hostname { get { return this._Hostname; } }

		public string WindowsVersion { get { return this._WindowsVersion; } }

		public string WindowsProductType { get { return this._WindowsProductType; } }
	}
}
