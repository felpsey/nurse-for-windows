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

namespace Nurse.Desktop.ViewModels
{
	public class TestsViewModel : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		// ObservableCollection to store the list of tests
		public ObservableCollection<Test> Tests { get; private set; }

		// Boolean to control the visibility of the loading spinner
		public bool IsLoading { get; private set; }

		// ICommand to run a test
		public ICommand RunTestCommand { get; private set; }

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

		// Method to run an individual test asynchronously
		private async Task RunTestAsync(Test test)
		{
			if (test != null)
			{
				test.IsRunning = true; // Update the test state to running
				OnPropertyChanged(nameof(test.IsRunning)); // Notify the UI

				// Run the test asynchronously via the TestController
				await TestController.RunTestAsync(test);

				test.IsRunning = false; // Test is done running
				OnPropertyChanged(nameof(test.IsRunning)); // Notify the UI
			}
		}

		protected void OnPropertyChanged(string propertyName)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}