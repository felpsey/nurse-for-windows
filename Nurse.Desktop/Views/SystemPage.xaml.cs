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

			this.InitializeComponent();
		}

		private OperatingSystemContext _OperatingSystemContext;
		
		private readonly string _Hostname;

		public string Hostname
		{
			get
			{
				return this._Hostname;
			}
		}
	}
}
