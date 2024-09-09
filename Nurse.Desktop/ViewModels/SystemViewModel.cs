using Nurse.Core.Context;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nurse.Desktop.ViewModels
{
	public class SystemViewModel : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		private OperatingSystemContext _OperatingSystemContext;

		public SystemViewModel()
		{
			_OperatingSystemContext = new OperatingSystemContext();

			Hostname = _OperatingSystemContext.Hostname;
			WindowsVersion = _OperatingSystemContext.WindowsVersion;
			WindowsProductType = _OperatingSystemContext.WindowsProductType;
			WindowsDomainName = _OperatingSystemContext.WindowsDomainName;
		}

		public string Hostname { get; }
		public string WindowsVersion { get; }
		public string WindowsProductType { get; }
		public string WindowsDomainName { get; }

		// Notify the view when a property changes
		protected void OnPropertyChanged(string propertyName)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
