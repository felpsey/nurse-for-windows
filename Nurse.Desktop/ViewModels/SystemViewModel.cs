using Nurse.Core.Context;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Nurse.Desktop.ViewModels
{
	public class SystemViewModel : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		private OperatingSystemContext _OperatingSystemContext;
		private Timer _timer;
		private string _uptime;

		public SystemViewModel()
		{
			_OperatingSystemContext = new OperatingSystemContext();

			Hostname = _OperatingSystemContext.Hostname;
			WindowsVersion = _OperatingSystemContext.WindowsVersion;
			WindowsProductType = _OperatingSystemContext.WindowsProductType;
			WindowsDomainName = _OperatingSystemContext.WindowsDomainName;

			_timer = new Timer(1000);
			_timer.Elapsed += OnTimerElapsed;
			_timer.AutoReset = true;
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
				RaisePropertyChanged("Uptime");
			}
		}

		private void OnTimerElapsed(object sender, ElapsedEventArgs e)
		{
			TimeSpan currentTime = OperatingSystemContext.GetUptime();

			Uptime = $"Days: {currentTime.Days} Hours: {currentTime.Hours} Minutes: {currentTime.Minutes} Seconds: {currentTime.Seconds}";
		}

		// Notify the view when a property changes
		protected void RaisePropertyChanged(string name)
		{
			Debug.Print("Property changed! " + name);

			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
		}
	}
}
