using Microsoft.UI.Composition.SystemBackdrops;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Nurse.Desktop
{
	public sealed partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();

			// Set selected item to first NavigationViewItem
			NavigationViewControl.SelectedItem = NavigationViewControl.MenuItems.OfType<NavigationViewItem>().First();

			// Set current frame to SystemPage
			ContentFrame.Navigate(typeof(Views.SystemPage), null, new Microsoft.UI.Xaml.Media.Animation.EntranceNavigationTransitionInfo());

			// Hide default Windows title bar
			ExtendsContentIntoTitleBar = true;
		}

		private void NavigationViewControl_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
		{
			if (args.IsSettingsInvoked == true)
			{
				ContentFrame.Navigate(typeof(Views.SettingsPage), null, args.RecommendedNavigationTransitionInfo);
			}
			else if (args.InvokedItemContainer != null && (args.InvokedItemContainer.Tag != null))
			{
				// Resolve the InvokedItemContainer.Tag to a Page
				Type page = Type.GetType(args.InvokedItemContainer.Tag.ToString());

				// Navigate to page that was resolved
				ContentFrame.Navigate(page, null, args.RecommendedNavigationTransitionInfo);
			}
		}

		private void NavigationViewControl_BackRequested(NavigationView sender, NavigationViewBackRequestedEventArgs args)
		{
			// If navigation history exists
			if (ContentFrame.CanGoBack)
			{
				// Navigate to previous page
				ContentFrame.GoBack();
			}
		}

		private void ContentFrame_Navigated(object sender, NavigationEventArgs e)
		{
			// User has navigated, therefore navigation history exists
			NavigationViewControl.IsBackEnabled = ContentFrame.CanGoBack;

			// Settings NavigationViewItem does not have a tag attribute
			if (ContentFrame.SourcePageType == typeof(Views.SettingsPage))
			{
				// Set selected item to Settings NavigationViewItem
				NavigationViewControl.SelectedItem = (NavigationViewItem)NavigationViewControl.SettingsItem;
			}
			else if (ContentFrame.SourcePageType != null)
			{
				// Set selected item to NavigationViewItem where tag matches page
				NavigationViewControl.SelectedItem = NavigationViewControl.MenuItems.OfType<NavigationViewItem>().First(n => n.Tag.Equals(ContentFrame.SourcePageType.FullName.ToString()));
			}

			// Set header to NaivgationViewControl string value
			NavigationViewControl.Header = ((NavigationViewItem)NavigationViewControl.SelectedItem)?.Content?.ToString();
		}
	}
}
