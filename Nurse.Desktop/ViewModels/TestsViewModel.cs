using Microsoft.UI.Dispatching;
using Microsoft.UI.Xaml;
using Nurse.Core.Context;
using Nurse.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using static System.Net.Mime.MediaTypeNames;
using System.Collections.ObjectModel;
using System.Windows.Input;
using PdfSharpCore.Drawing;
using System.IO;
using Windows.Storage.Pickers;
using Windows.Storage;
using PdfSharpCore.Pdf;

namespace Nurse.Desktop.ViewModels
{
	public class TestsViewModel : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		// ObservableCollection to store the list of tests
		public ObservableCollection<Test> Tests { get; private set; }

		// Boolean to control the visibility of the loading spinner
		public bool IsLoading { get; private set; }

		private bool _isRunningAllTests;

		public bool IsRunningAllTests
		{
			get => _isRunningAllTests;
			set
			{
				_isRunningAllTests = value;
				OnPropertyChanged(nameof(IsRunningAllTests));
			}
		}

		public TestsViewModel()
		{
			// Initialize the ObservableCollection
			Tests = new ObservableCollection<Test>();

			// Load tests asynchronously
			LoadTestsAsync();
		}

		// Method to load tests asynchronously and update the loading state
		private async void LoadTestsAsync()
		{
			IsLoading = true;  // Start loading
			OnPropertyChanged(nameof(IsLoading));  // Notify the UI to show the spinner

			// Call the asynchronous method to retrieve tests
			Test[] testArray = await TestController.GetAllTestsAsync();

			// Clear any existing tests in the ObservableCollection
			Tests.Clear();

			// Add the tests from the array to the ObservableCollection
			foreach (var test in testArray)
			{
				Tests.Add(test);
			}

			IsLoading = false;  // Stop loading
			OnPropertyChanged(nameof(IsLoading));  // Notify the UI to hide the spinner
		}

		// Method to run all tests
		public async Task RunAllTestsAsync()
		{
			IsRunningAllTests = true;

			// Run all tests in parallel
			var testTasks = new List<Task>();
			foreach (var test in Tests)
			{
				testTasks.Add(test.Run()); // Call Run method on each test
			}

			await Task.WhenAll(testTasks); // Wait for all tests to complete
			IsRunningAllTests = false;
		}

		public void ExportTestResultsToPdfAsync()
		{
			try
			{
				// Ensure the directory exists
				string reportDirectory = @"C:\Nurse\Reports";
				if (!Directory.Exists(reportDirectory))
				{
					Directory.CreateDirectory(reportDirectory);
				}

				// Get the current time and format it for the filename
				string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss"); // Example format: 20240915_133000
				string fileName = $"Report_{timestamp}.pdf"; // Construct the file name with the timestamp

				// Create a PDF document
				PdfDocument document = new PdfDocument();
				document.Info.Title = "Test Results Report";

				// Create a PDF page
				PdfPage page = document.AddPage();
				XGraphics gfx = XGraphics.FromPdfPage(page);
				XFont fontTitle = new XFont("Verdana", 16, XFontStyle.Bold);
				XFont fontBody = new XFont("Verdana", 8, XFontStyle.Regular);

				// Write the title
				gfx.DrawString("Test Results", fontTitle, XBrushes.Black, new XRect(0, 0, page.Width, 40), XStringFormats.TopCenter);

				double yOffset = 60; // Change yOffset to double for precise control
				double margin = 40;
				double contentWidth = page.Width - margin * 2;  // Width to fit text into

				foreach (var test in Tests)
				{
					// Build the text with description and result message
					string resultText = $"Test: {test.Name}\nDescription: {test.Description}\nResult: {(test.Passed == true ? "Passed" : test.Passed == false ? "Failed" : "Not Run")}\nMessage: {test.ResultMessage}";

					// Split the text by newlines and handle each line separately
					string[] lines = resultText.Split('\n');

					foreach (var line in lines)
					{
						gfx.DrawString(line, fontBody, XBrushes.Black, new XRect(margin, yOffset, contentWidth, page.Height), XStringFormats.TopLeft);
						yOffset += gfx.MeasureString(line, fontBody).Height; // No conversion needed, yOffset is now double
					}

					yOffset += 20; // Add some space between tests
				}

				// Save the PDF to C:\Nurse\Reports with the dynamic filename
				string filePath = Path.Combine(reportDirectory, fileName);
				using (var stream = File.Create(filePath))
				{
					document.Save(stream);
				}

				Console.WriteLine($"PDF saved to {filePath}");
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error exporting PDF: {ex.Message}");
			}
		}

		protected void OnPropertyChanged(string propertyName)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}