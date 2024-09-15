using Microsoft.UI.Xaml.Data;
using System;

namespace Nurse.Desktop
{
	public class BooleanToPassFailConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, string language)
		{
			if (value is bool boolValue)
			{
				return boolValue ? "Passed" : "Failed";
			}
			return "Not Run";
		}

		public object ConvertBack(object value, Type targetType, object parameter, string language)
		{
			throw new NotImplementedException();
		}
	}
}