using System;
using System.IO;

namespace Nurse.Core
{
	public class Init
	{
		public static void Main()
		{
			string RootFolder = @"C:\Nurse";
			string TestsFolder = @"C:\Nurse\Tests";
			string ReportsFolder = @"C:\Nurse\Reports";

			if (!Directory.Exists(RootFolder))
			{
				Directory.CreateDirectory(RootFolder);
			}

			if (!Directory.Exists(TestsFolder))
			{
				Directory.CreateDirectory(TestsFolder);
			}

			if (!Directory.Exists(ReportsFolder))
			{
				Directory.CreateDirectory(ReportsFolder);
			}
		}
	}
}
