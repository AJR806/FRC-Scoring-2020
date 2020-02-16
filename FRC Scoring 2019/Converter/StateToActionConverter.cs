using FRC_Scoring_2019.ViewModel;
using System;
using Windows.UI.Xaml.Data;

namespace FRC_Scoring_2019.Converter {
	public class StateToActionConverter : IValueConverter {
		public object Convert(object value, Type targetType, object parameter, string language) {
			MainViewModel.State state = (MainViewModel.State)Enum.Parse(typeof(MainViewModel.State), value.ToString());
			switch(state) {
				case MainViewModel.State.Prematch:
					return "Start Match";
				case MainViewModel.State.Match:
					return "Stop Match";
				case MainViewModel.State.Postmatch:
					return "Reset";
				default:
					return null;
			}
		}

		public object ConvertBack(object value, Type targetType, object parameter, string language) {
			throw new NotImplementedException();
		}
	}
}
