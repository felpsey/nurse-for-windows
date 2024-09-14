using Nurse.Core;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;

namespace Nurse.Desktop.ViewModels
{

	public class ReportsViewModel : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;
		public ObservableCollection<ReportInfo> PdfReports { get; private set; }

		public ReportsViewModel()
		{
			PdfReports = new ObservableCollection<ReportInfo>();

			var reports = Report.GetAllReports();

			foreach (var report in reports)
			{
				PdfReports.Add(report);  // Add each report name to the ObservableCollection
			}
		}

		public void OpenPdf(string fullPath)
		{
			try
			{
				if (File.Exists(fullPath))
				{
					Process.Start(new ProcessStartInfo
					{
						FileName = fullPath,
						UseShellExecute = true // Opens the file with the default PDF reader
					});
				}
				else
				{
					Console.WriteLine("File does not exist.");
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Failed to open PDF: {ex.Message}");
			}
		}

		protected void OnPropertyChanged(string propertyName)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}