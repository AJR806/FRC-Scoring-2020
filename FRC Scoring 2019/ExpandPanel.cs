using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;

namespace FRC_Scoring_2019 {
	public sealed class ExpandPanel : ContentControl {
		public ExpandPanel() {
			DefaultStyleKey = typeof(ExpandPanel);
		}

		private bool _UseTransitions = true;
		private VisualState _CollapsedState;
		private ToggleButton _ToggleExpander;
		private FrameworkElement _ContentElement;

		public static readonly DependencyProperty HeaderContentProperty = DependencyProperty.Register("HeaderContent", typeof(object), typeof(ExpandPanel), null);
		public static readonly DependencyProperty IsExpandedProperty = DependencyProperty.Register("IsExpanded", typeof(bool), typeof(ExpandPanel), new PropertyMetadata(true));
		public static readonly DependencyProperty CornerRadiusProperty = DependencyProperty.Register("CornerRadius", typeof(CornerRadius), typeof(ExpandPanel), null);

		public object HeaderContent {
			get {
				return GetValue(HeaderContentProperty);
			}
			set {
				SetValue(HeaderContentProperty, value);
			}
		}
		public bool IsExpanded {
			get {
				return (bool)GetValue(IsExpandedProperty);
			}
			set {
				SetValue(IsExpandedProperty, value);
			}
		}
		public CornerRadius CornerRadius {
			get {
				return (CornerRadius)GetValue(CornerRadiusProperty);
			}
			set {
				SetValue(CornerRadiusProperty, value);
			}
		}

		private void ChangeVisualState(bool useTransitions) {
			if(IsExpanded) {
				if(_ContentElement != null) {
					_ContentElement.Visibility = Visibility.Visible;
				}
				VisualStateManager.GoToState(this, "Expanded", useTransitions);
			} else {
				VisualStateManager.GoToState(this, "Collapsed", useTransitions);
				_CollapsedState = (VisualState)GetTemplateChild("Collapsed");
				if(_CollapsedState == null) {
					if(_ContentElement != null) {
						_ContentElement.Visibility = Visibility.Collapsed;
					}
				}
			}
		}

		protected override void OnApplyTemplate() {
			base.OnApplyTemplate();
			_ToggleExpander = (ToggleButton)GetTemplateChild("ExpandCollapseButton");
			if(_ToggleExpander != null) {
				_ToggleExpander.Click += (object sender, RoutedEventArgs e) => {
					IsExpanded = !IsExpanded;
					_ToggleExpander.IsChecked = IsExpanded;
					ChangeVisualState(_UseTransitions);
				};
			}
			_ContentElement = (FrameworkElement)GetTemplateChild("Content");
			if(_ContentElement != null) {
				_CollapsedState = (VisualState)GetTemplateChild("Collapsed");
				if((_CollapsedState != null) && (_CollapsedState.Storyboard != null)) {
					_CollapsedState.Storyboard.Completed += (object sender, object e) => {
						_ContentElement.Visibility = Visibility.Collapsed;
					};
				}
			}
			ChangeVisualState(false);
		}
	}
}