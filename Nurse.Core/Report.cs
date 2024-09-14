using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nurse.Core
{
	public class Report
	{
		public static ReportInfo[] GetAllReports()
		{
			try
			{
				// Check if the folder exists
				if (Directory.Exists(@"C:\Nurse\Reports"))
				{
					// Get all PDF files in the folder and subdirectories
					string[] pdfFiles = Directory.GetFiles(@"C:\Nurse\Reports", "*.pdf", SearchOption.AllDirectories);

					// Create a ReportInfo array with both file name and full path
					var reportInfos = new ReportInfo[pdfFiles.Length];
					for (int i = 0; i < pdfFiles.Length; i++)
					{
						reportInfos[i] = new ReportInfo
						{
							Name = Path.GetFileName(pdfFiles[i]), // Extract file name from full path
							FullPath = pdfFiles[i]                // Store the full path
						};
					}

					return reportInfos;
				}
				else
				{
					Console.WriteLine("The specified folder does not exist.");
					return Array.Empty<ReportInfo>();
				}
			}
			catch (UnauthorizedAccessException ex)
			{
				Console.WriteLine($"Access denied: {ex.Message}");
				return Array.Empty<ReportInfo>();
			}
			catch (DirectoryNotFoundException ex)
			{
				Console.WriteLine($"Directory not found: {ex.Message}");
				return Array.Empty<ReportInfo>();
			}
			catch (Exception ex)
			{
				Console.WriteLine($"An error occurred: {ex.Message}");
				return Array.Empty<ReportInfo>();
			}
		}
	}
}
