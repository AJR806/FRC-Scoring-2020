using FRC_Scoring_2019.ViewModel;
using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace FRC_Scoring_2019.Converter {
	public class BoolToVisibilityConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, string language) {
			return (value as bool?).Value ? Visibility.Visible : Visibility.Collapsed;
		}

		public object ConvertBack(object value, Type targetType, object parameter, string language) {
			throw new NotImplementedException();
		}
	}
}
