using FRC_Scoring_2019.ViewModel;
using System;
using Windows.Foundation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;

namespace FRC_Scoring_2019 {
    public sealed partial class MainPage : Page {
		public MainViewModel ViewModel;

		public MainPage() {
			InitializeComponent();
			ViewModel = new MainViewModel();
		}

		private void StartMatch() {
			ViewModel.StartMatch();
		}
		private void StopMatch() {
			ViewModel.StopMatch();
		}
		private void Reset() {
			ViewModel.Reset();
		}

		private void FoulInc() {
			if(ViewModel.Foul + 3 <= ushort.MaxValue) {
				ViewModel.Foul += 3;
			}
		}
		private void FoulDec() {
			if(ViewModel.Foul >= 3) {
				ViewModel.Foul -= 3;
			}
		}
	
		private void TechFoulInc() {
			if(ViewModel.TechFoul + 15 <= ushort.MaxValue) {
				ViewModel.TechFoul += 15;
			}
		}
		private void TechFoulDec() {
			if(ViewModel.TechFoul >= 15) {
				ViewModel.TechFoul -= 15;
			}
		}

		private void CrossedHablineInc()
		{
			if(ViewModel.CrossedHabline < 5)
			{
				ViewModel.CrossedHabline += 5;
			}
		}
		private void CrossedHablineDec()
		{
			if (ViewModel.CrossedHabline > 0)
			{
				ViewModel.CrossedHabline -= 5;
			}
		}
		private void AutonLevel1PowerCellsInc()
		{
			if(ViewModel.AutonLevel1PowerCells < 100)
			{
				ViewModel.AutonLevel1PowerCells++;
			}
		}
		private void AutonLevel1PowerCellsDec()
		{
			if(ViewModel.AutonLevel1PowerCells > 0)
			{
				ViewModel.AutonLevel1PowerCells--;
			}
		}
		private void AutonLevel2PowerCellsInc()
		{
			if(ViewModel.AutonLevel2PowerCells < 100)
			{
				ViewModel.AutonLevel2PowerCells++;
			}
		}
		private void AutonLevel2PowerCellsDec()
		{
			if(ViewModel.AutonLevel2PowerCells > 0)
			{
				ViewModel.AutonLevel2PowerCells--;
			}
		}
		private void AutonLevel3PowerCellsInc()
		{
			if(ViewModel.AutonLevel3PowerCells < 100)
			{
				ViewModel.AutonLevel3PowerCells++;
			}
		}
		private void AutonLevel3PowerCellsDec()
		{
			if(ViewModel.AutonLevel3PowerCells > 0)
			{
				ViewModel.AutonLevel3PowerCells--;
			}
		}
		private void Level1PowerCellsInc() {
			if(ViewModel.Level1PowerCells < 100) {
				ViewModel.Level1PowerCells++;
			}
		}
		private void Level1PowerCellsDec() {
			if(ViewModel.Level1PowerCells > 0) {
				ViewModel.Level1PowerCells--;
			}
		}
		private void Level2PowerCellsInc() {
			if(ViewModel.Level2PowerCells <100) {
				ViewModel.Level2PowerCells++;
			}
		}
		private void Level2PowerCellsDec() {
			if(ViewModel.Level2PowerCells > 0) {
				ViewModel.Level2PowerCells--;
			}
		}
		private void Level3PowerCellsInc() {
			if(ViewModel.Level3PowerCells< 100) {
				ViewModel.Level3PowerCells++;
			}
		}
		private void Level3PowerCellsDec() {
			if(ViewModel.Level3PowerCells > 0) {
				ViewModel.Level3PowerCells--;
			}
		}
		private void RotationControlSpinnerInc()
		{
			if (ViewModel.RotationControlSpinner < 10)
			{
				ViewModel.RotationControlSpinner += 10;
			}
		}
		private void RotationControlSpinnerDec()
		{
			if(ViewModel.RotationControlSpinner > 0)
			{
				ViewModel.RotationControlSpinner -= 10;

			}
		}

		private void PositionControlSpinnerInc() { 
		
		if (ViewModel.PositionControlSpinner < 20)
		{
			ViewModel.PositionControlSpinner += 20;
		}
	}
		private void PositionControlSpinnerDec() {
			if (ViewModel.PositionControlSpinner > 0)
			{
				ViewModel.PositionControlSpinner -= 20;
			}
		}

		private void RobotsClimbedInc()
		{
			if (ViewModel.RobotsClimbed < 3)
			{
				ViewModel.RobotsClimbed++;
			}
		}

		private void RobotsClimbedDec()
		{
			if(ViewModel.RobotsClimbed > 0)
			{
				ViewModel.RobotsClimbed--;
			}
		}

		private void RobotsParkedInc()
		{
			if(ViewModel.RobotsParked < 3)
			{
				ViewModel.RobotsParked++;
			}
		}

		private void RobotsParkedDec()
		{
			if(ViewModel.RobotsParked > 0)
			{
				ViewModel.RobotsParked--;
			}
		}

		private void IsLeveledInc()
		{
			if(ViewModel.IsLeveled < 1)
			{
				ViewModel.IsLeveled += 15;
			}
		}

		private void IsLeveledDec()
		{
			if(ViewModel.IsLeveled > 0)
			{
				ViewModel.IsLeveled -= 15;
			}
		}
		private void ScrollBlueExtra(KeyboardAccelerator sender, KeyboardAcceleratorInvokedEventArgs args) {
			ScrollToElement(ExtraScrollViewer, BlueExtraElement);
		}
		private void ScrollRedExtra(KeyboardAccelerator sender, KeyboardAcceleratorInvokedEventArgs args) {
			ScrollToElement(ExtraScrollViewer, RedExtraElement);
		}
		private void ScrollAction(KeyboardAccelerator sender, KeyboardAcceleratorInvokedEventArgs args) {
			DispatcherTimer scrollTimer = new DispatcherTimer() {
				Interval = (ViewModel.AutonomousExpanded || ViewModel.TeleopExpanded) ? TimeSpan.FromMilliseconds(200) : TimeSpan.Zero
			};
			ViewModel.AutonomousExpanded = false;
			ViewModel.TeleopExpanded = false;
			scrollTimer.Tick += (object s, object e) => {
				ScrollToElement(MainScrollViewer, ActionElement);
				scrollTimer.Stop();
			};
			scrollTimer.Start();
			args.Handled = true;
		}
		private void ScrollSandstorm(KeyboardAccelerator sender, KeyboardAcceleratorInvokedEventArgs args) {
			ViewModel.AutonomousExpanded = true;
			ViewModel.TeleopExpanded = false;
			DispatcherTimer scrollTimer = new DispatcherTimer() {
				Interval = TimeSpan.FromMilliseconds(200)
			};
			scrollTimer.Tick += (object s, object e) => {
				ScrollToElement(MainScrollViewer, SandstormElement);
				scrollTimer.Stop();
			};
			scrollTimer.Start();
			args.Handled = true;
		}
		private void ScrollTeleop(KeyboardAccelerator sender, KeyboardAcceleratorInvokedEventArgs args) {
			ViewModel.AutonomousExpanded = false;
			ViewModel.TeleopExpanded = true;
			DispatcherTimer scrollTimer = new DispatcherTimer() {
				Interval = TimeSpan.FromMilliseconds(200)
			};
			scrollTimer.Tick += (object s, object e) => {
				ScrollToElement(MainScrollViewer, EndgameElement);
				scrollTimer.Stop();
			};
			scrollTimer.Start();
			args.Handled = true;
		}
		private void ScrollGamePieces(KeyboardAccelerator sender, KeyboardAcceleratorInvokedEventArgs args) {
			DispatcherTimer scrollTimer = new DispatcherTimer() {
				Interval = (ViewModel.AutonomousExpanded || ViewModel.TeleopExpanded) ? TimeSpan.FromMilliseconds(200) : TimeSpan.Zero
			};
			ViewModel.AutonomousExpanded = false;
			ViewModel.TeleopExpanded = false;
			scrollTimer.Tick += (object s, object e) => {
				ScrollToElement(MainScrollViewer, GamePiecesElement);
				scrollTimer.Stop();
			};
			scrollTimer.Start();
			args.Handled = true;
		}

		private static void ScrollToElement(ScrollViewer scrollViewer, UIElement element, bool isVerticalScrolling = true, bool smoothScrolling = true, float? zoomFactor = null) {
			GeneralTransform transform = element.TransformToVisual((UIElement)scrollViewer.Content);
			Point position = transform.TransformPoint(new Point(0, 0));
			if(isVerticalScrolling) {
				scrollViewer.ChangeView(null, position.Y, zoomFactor, !smoothScrolling);
			}
			else {
				scrollViewer.ChangeView(position.X, null, zoomFactor, !smoothScrolling);
			}
		}

		private void NumericTextBox_BeforeTextChanging(TextBox sender, TextBoxBeforeTextChangingEventArgs args) {
			if(args.NewText.Length > 0) {
				bool parsible = ushort.TryParse(args.NewText, out ushort result);
				if(!parsible) {
					args.Cancel = true;
				}
			}
		}

		
		private void MainScrollViewer_ViewChanged(object sender, ScrollViewerViewChangedEventArgs e)
		{

		}

		private void TextBlock_SelectionChanged(object sender, RoutedEventArgs e)
		{

		}
	}	
	

}
