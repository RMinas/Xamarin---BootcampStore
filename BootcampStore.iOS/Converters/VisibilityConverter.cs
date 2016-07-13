using System;
using MvvmCross.Platform.Converters;

namespace BootcampStore.iOS
{
	public class VisibilityConverter : MvxValueConverter
	{
		public VisibilityConverter()
		{
		}

		public override object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			var val = value as bool?;
			return !val;
		}
	}
}

