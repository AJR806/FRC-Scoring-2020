    using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace FRC_Scoring_2019.Converter {
	public class SandstormBonusVisibilityConverter : IValueConverter {
		public object Convert(object value, Type targetType, object parameter, string language) {
			byte count = byte.Parse(value.ToString());
			byte level = byte.Parse(parameter.ToString());
			return count < level ? Visibility.Collapsed : Visibility.Visible;
		}

		public object ConvertBack(object value, Type targetType, object parameter, string langauge) {
			throw new NotImplementedException();
		}
	}
}
