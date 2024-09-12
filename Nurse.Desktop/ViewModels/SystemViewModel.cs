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
	public class SystemViewModel : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		private OperatingSystemContext _OperatingSystemContext;
		private DispatcherTimer _timer;

		private string _uptime;

		public SystemViewModel()
		{
			_OperatingSystemContext = new OperatingSystemContext();

			Hostname = _OperatingSystemContext.Hostname;
			WindowsVersion = _OperatingSystemContext.WindowsVersion;
			WindowsProductType = _OperatingSystemContext.WindowsProductType;
			WindowsDomainName = _OperatingSystemContext.WindowsDomainName;

			_timer = new DispatcherTimer();
			_timer.Tick += (s, e) => { UpdateUptime(); };
			_timer.Start();

		}

		public string Hostname { get; }
		public string WindowsVersion { get; }
		public string WindowsProductType { get; }
		public string WindowsDomainName { get; }
		public string Uptime
		{
			get => _uptime;
			private set
			{
				_uptime = value;

				OnPropertyChanged();
			}
		}

		private void UpdateUptime()
		{
			TimeSpan currentTime = OperatingSystemContext.GetUptime();

			Uptime = $"Days: {currentTime.Days} Hours: {currentTime.Hours} Minutes: {currentTime.Minutes} Seconds: {currentTime.Seconds}";
		}

		// Notify the view when a property changes
		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
