using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Nurse.Core.Context;
using Nurse.Desktop.ViewModels;

namespace Nurse.Desktop.Views
{
	public sealed partial class SystemPage : Page
	{
		public SystemViewModel ViewModel { get; set; }

		public SystemPage()
		{
			this.InitializeComponent();

			ViewModel = new SystemViewModel();
		}
	}
}
