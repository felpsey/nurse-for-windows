using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Nurse.Desktop.ViewModels;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Nurse.Desktop.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ReportsPage : Page
    {
		public ReportsViewModel ViewModel { get; set; }

		public ReportsPage()
		{
			// Initialise Page component
			this.InitializeComponent();

			// Initialise ViewModel
			ViewModel = new ReportsViewModel();

			// Set the data context of UI elements to the ViewModel
			this.DataContext = ViewModel;
		}

		private void OpenPdf_Click(object sender, RoutedEventArgs e)
		{
			// Get the full path of the PDF from the Button's Tag property
			var button = sender as Button;
			var fullPath = button?.Tag as string;

			if (!string.IsNullOrEmpty(fullPath))
			{
				ViewModel.OpenPdf(fullPath);  // Call the ViewModel's method to open the PDF
			}
		}
	}
}
