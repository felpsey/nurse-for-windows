using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Nurse.Core
{
	public class Test : INotifyPropertyChanged
	{
		public string Name { get; set; }
		public string Description { get; set; }
		public string Path { get; set; }
		public bool IsRunning { get; set; }
		public bool? Passed { get; set; }
		public string ResultMessage { get; set; }

		// Command to run the test, which will bind to the button in the UI
		public ICommand RunCommand { get; }

		public Test()
		{
			// Initialize the RunCommand to call the Run method
			RunCommand = new RelayCommand(async () => await Run());
		}

		// Method to run the test
		public async Task Run()
		{
			try
			{
				// Indicate that the test is running
				IsRunning = true;
				OnPropertyChanged(nameof(IsRunning));

				// Call the TestController to run the test
				await TestController.RunTestAsync(this);

				// TestController.RunTestAsync will update 'Passed' and 'ResultMessage' directly
				// Now notify the UI of these property changes
				IsRunning = false;
				OnPropertyChanged(nameof(IsRunning));
				OnPropertyChanged(nameof(Passed));
				OnPropertyChanged(nameof(ResultMessage));

				Debug.WriteLine("Running Test " + Name);
				Debug.WriteLine("Running Test " + Description);
				Debug.WriteLine("Running Test " + ResultMessage);
			}
			catch (Exception ex)
			{
				// Handle any exceptions during test execution
				Passed = false;  // Mark test as failed in case of error
				ResultMessage = $"Error: {ex.Message}";

				// Notify the UI of the error
				IsRunning = false;
				OnPropertyChanged(nameof(IsRunning));
				OnPropertyChanged(nameof(Passed));
				OnPropertyChanged(nameof(ResultMessage));
			}
		}

		// INotifyPropertyChanged implementation to notify the UI about property changes
		public event PropertyChangedEventHandler PropertyChanged;
		protected void OnPropertyChanged(string propertyName)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
