using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nurse.Core
{
	public class Test
	{
		public string Name { get; set; }
		public string Description { get; set; }
		public string Path { get; set; }
		public bool IsRunning { get; set; }
		public bool? Passed { get; set; }
		public string ResultMessage { get; set; }
	}
}
