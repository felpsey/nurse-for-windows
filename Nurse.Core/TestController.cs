using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Linq;
using System.Diagnostics;
using System.Management.Automation;
using Newtonsoft.Json.Linq;

namespace Nurse.Core
{
	public class TestController
	{
		public static async Task<Test[]> GetAllTestsAsync()
		{
			return await Task.Run(() =>
			{
				// Define the directory to search for PowerShell module files (.psm1)
				string testDirectory = @"C:\Nurse\Tests";

				// Check if the directory exists
				if (!Directory.Exists(testDirectory))
				{
					Console.WriteLine("Directory does not exist.");
					return Array.Empty<Test>();
				}

				try
				{
					// Get all PowerShell module files (e.g., .psm1) in the directory
					string[] testFiles = Directory.GetFiles(testDirectory, "*.psm1", SearchOption.TopDirectoryOnly);

					// Initialize a list to store Test objects
					var tests = new List<Test>();

					// Loop through the list of test files and create a Test object for each
					foreach (var testFile in testFiles)
					{
						// Create a new PowerShell instance for each test file
						using (PowerShell psInstance = PowerShell.Create())
						{
							// Set the execution policy to Bypass for the current process
							psInstance.AddCommand("Set-ExecutionPolicy")
									  .AddArgument("Bypass")
									  .AddParameter("Scope", "Process")
									  .AddParameter("Force");
							psInstance.Invoke();
							psInstance.Commands.Clear();

							// Import the module
							psInstance.AddCommand("Import-Module").AddArgument(testFile).Invoke();
							psInstance.Commands.Clear();

							// Get-Name cmdlet
							psInstance.AddCommand("Get-Name");
							var nameResult = psInstance.Invoke();
							string testName = (nameResult.Count > 0) ? nameResult[0].ToString() : Path.GetFileNameWithoutExtension(testFile);

							// Get-Description cmdlet
							psInstance.Commands.Clear();
							psInstance.AddCommand("Get-Description");
							var descriptionResult = psInstance.Invoke();
							string testDescription = (descriptionResult.Count > 0) ? descriptionResult[0].ToString() : "No description available.";

							// Add the Test object to the list
							tests.Add(new Test
							{
								Name = testName,
								Description = testDescription,
								Path = testFile,
								IsRunning = false
							});
						}
					}

					return tests.ToArray();
				}
				catch (Exception ex)
				{
					Console.WriteLine($"Error while retrieving tests: {ex.Message}");
					return Array.Empty<Test>();
				}
			});
		}

		// Async method to run the test
		public static async Task RunTestAsync(Test test)
		{
			await Task.Run(() =>
			{
				try
				{
					using (PowerShell psInstance = PowerShell.Create())
					{
						// Set the execution policy to Bypass for the current process
						psInstance.AddCommand("Set-ExecutionPolicy")
								  .AddArgument("Bypass")
								  .AddParameter("Scope", "Process")
								  .AddParameter("Force");
						psInstance.Invoke();
						psInstance.Commands.Clear();

						// Import the PowerShell module (assuming test.Path holds the module path)
						psInstance.AddCommand("Import-Module").AddArgument(test.Path).Invoke();
						psInstance.Commands.Clear();

						// Invoke the PowerShell script that runs the test and outputs JSON
						psInstance.AddCommand("Invoke-Test");  // Assuming the test script uses Invoke-Test to run
						var result = psInstance.Invoke();

						// Ensure there are no errors in the PowerShell execution
						if (psInstance.Streams.Error.Count > 0)
						{
							Console.WriteLine("Errors occurred during test execution:");
							foreach (var error in psInstance.Streams.Error)
							{
								Console.WriteLine(error.ToString());
							}
						}
						else if (result.Count > 0)
						{
							// Assuming the result is in JSON format, parse it
							string jsonResponse = result[0].ToString();
							JObject json = JObject.Parse(jsonResponse);

							// Parse the JSON object to get the status and message
							string status = json["status"]?.ToString();
							string message = json["message"]?.ToString();

							// Update the Test object with the result
							test.Passed = (status == "passed");
							test.ResultMessage = message;
						}
					}
				}
				catch (Exception ex)
				{
					Console.WriteLine($"Error running test {test.Name}: {ex.Message}");
					test.Passed = false;  // Assume the test failed if there was an error
					test.ResultMessage = $"Error: {ex.Message}";
				}
			});
		}
	}
}
