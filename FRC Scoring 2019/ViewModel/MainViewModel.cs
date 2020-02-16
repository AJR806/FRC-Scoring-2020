using GalaSoft.MvvmLight;
using System;
using System.Diagnostics;
using Windows.UI.Xaml;

namespace FRC_Scoring_2019.ViewModel {
	public class MainViewModel : ViewModelBase {
		public enum State : byte {
			Prematch = 0, Match = 1, Postmatch = 2
		}
		
		private Stopwatch _MatchStopwatch = new Stopwatch();
		private DispatcherTimer _MatchTimer = new DispatcherTimer() {
			Interval = TimeSpan.FromMilliseconds(1)
		};
		public readonly TimeSpan MatchLength = new TimeSpan(0, 2, 30);
		public TimeSpan MatchTime => _MatchStopwatch.Elapsed;
		public TimeSpan MatchTimeRemaining => TimeSpan.FromSeconds(Math.Max((MatchLength - MatchTime).TotalSeconds, 0));
		private State _CurrentState;
		public State CurrentState {
			get {
				return _CurrentState;
			}
			set {
				Set(() => CurrentState, ref _CurrentState, value);
				Set(() => PrematchState, ref _PrematchState, CurrentState == State.Prematch);
				Set(() => MatchState, ref _MatchState, CurrentState == State.Match);
				Set(() => PostmatchState, ref _PostmatchState, CurrentState == State.Postmatch);
			}
		}
		private bool _PrematchState;
		public bool PrematchState {
			get {
				return _PrematchState;
			}
		}
		private bool _MatchState;
		public bool MatchState {
			get {
				return _MatchState;
			}
		}
		private bool _PostmatchState;
		public bool PostmatchState {
			get {
				return _PostmatchState;
			}
		}
		private bool _MatchRunning;
		public bool MatchRunning {
			get {
				return _MatchRunning;
			}
			set {
				Set(() => MatchRunning, ref _MatchRunning, value);
			}
		}
		private bool AutonomousPeriod;
		public bool SandstormPeriod {
			get {
				return AutonomousPeriod;
			}
			set {
				Set(() => SandstormPeriod, ref AutonomousPeriod, value);
			}
		}
		private bool _TeleopPeriod;
		public bool TeleopPeriod {
			get {
				return _TeleopPeriod;
			}
			set {
				Set(() => TeleopPeriod, ref _TeleopPeriod, value);
			}
		}
		private bool _Endgame;
		public bool Endgame {
			get {
				return _Endgame;
			}
			set {
				Set(() => Endgame, ref _Endgame, value);
			}
		}
		private string _MatchTimeRemainingString;
		public string MatchTimeRemainingString {
			get {
				return _MatchTimeRemainingString;
			}
			set {
				Set(() => MatchTimeRemainingString, ref _MatchTimeRemainingString, value);
			}
		}
		private int _Score;
		public int BlueScore {
			get {
				return _Score;
			}
			set {
				Set(() => BlueScore, ref _Score, value);
			}
		}
		private int _RedScore;
		public int RedScore {
			get {
				return _RedScore;
			}
			set {
				Set(() => RedScore, ref _RedScore, value);
			}
		}
		private ushort _Foul;
		public ushort Foul {
			get {
				return _Foul;
			}
			set {
				Set(() => Foul, ref _Foul, value);
				Set(() => FoulString, ref _FoulString, value.ToString());
				UpdateBlueScore();
			}
		}
		private string _FoulString;
		public string FoulString {
			get {
				return _FoulString;
			}
			set {
				ushort.TryParse(value, out ushort parsedValue);
				Set(() => FoulString, ref _FoulString, value);
				Set(() => Foul, ref _Foul, parsedValue);
				UpdateBlueScore();
			}
		}
		private ushort _TechFoul;
		public ushort TechFoul {
			get {
				return _TechFoul;
			}
			set {
				Set(() => TechFoul, ref _TechFoul, value);
				Set(() => TechFoulString, ref _TechFoulString, value.ToString());
				UpdateBlueScore();
			}
		}
		private string _TechFoulString;
		public string TechFoulString {
			get {
				return _TechFoulString;
			}
			set {
				ushort.TryParse(value, out ushort parsedValue);
				Set(() => TechFoulString, ref _TechFoulString, value);
				Set(() => TechFoul, ref _TechFoul, parsedValue);
				UpdateBlueScore();
			}
		}
		private ushort _BlueCorrection;
		public ushort BlueCorrection {
			get {
				return _BlueCorrection;
			}
			set {
				Set(() => BlueCorrection, ref _BlueCorrection, value);
				Set(() => BlueCorrectionString, ref _BlueCorrectionString, value.ToString());
				UpdateBlueScore();
			}
		}
		private string _BlueCorrectionString;
		public string BlueCorrectionString {
			get {
				return _BlueCorrectionString;
			}
			set {
				ushort.TryParse(value, out ushort parsedValue);
				Set(() => BlueCorrectionString, ref _BlueCorrectionString, value);
				Set(() => BlueCorrection, ref _BlueCorrection, parsedValue);
				UpdateBlueScore();
			}
		}
		//private ushort _RedCorrection;
		//public ushort RedCorrection {
		//	get {
		//		return _RedCorrection;
		//	}
		//	set {
		//		Set(() => RedCorrection, ref _RedCorrection, value);
		//		Set(() => RedCorrectionString, ref _RedCorrectionString, value.ToString());
		//		UpdateBlueScore();
		//	}
		//}
		//private string _RedCorrectionString;
		//public string RedCorrectionString {
		//	get {
		//		return _RedCorrectionString;
		//	}
		//	set {
		//		ushort.TryParse(value, out ushort parsedValue);
		//		Set(() => RedCorrectionString, ref _RedCorrectionString, value);
		//		Set(() => RedCorrection, ref _RedCorrection, parsedValue);
		//		UpdateBlueScore();
		//	}
		//}
		private bool _AutonomousExpanded;
		public bool AutonomousExpanded {
			get {
				return _AutonomousExpanded;
			}
			set {
				Set(() => AutonomousExpanded, ref _AutonomousExpanded, value);
			}
		}
		private bool _TeleopExpanded;
		public bool TeleopExpanded {
			get {
				return _TeleopExpanded;
			}
			set {
				Set(() => TeleopExpanded, ref _TeleopExpanded, value);
			}
		}
		private byte _SandstormNoBonusBlue;
		public byte SandstormNoBonusBlue {
			get {
				return _SandstormNoBonusBlue;
			}
			set {
				Set(() => SandstormNoBonusBlue, ref _SandstormNoBonusBlue, value);
			}
		}
		private byte _SandstormBonus1Blue;
		public byte SandstormBonus1Blue {
			get {
				return _SandstormBonus1Blue;
			}
			set {
				Set(() => SandstormBonus1Blue, ref _SandstormBonus1Blue, value);
				UpdateBlueScore();
			}
		}
		private byte _SandstormBonus2Blue;
		public byte SandstormBonus2Blue {
			get {
				return _SandstormBonus2Blue;
			}
			set {
				Set(() => SandstormBonus2Blue, ref _SandstormBonus2Blue, value);
				UpdateBlueScore();
			}
		}
		private byte _SandstormNoBonusRed;
		public byte SandstormNoBonusRed {
			get {
				return _SandstormNoBonusRed;
			}
			set {
				Set(() => SandstormNoBonusRed, ref _SandstormNoBonusRed, value);
			}
		}
		//private byte _SandstormBonus1Red;
		//public byte SandstormBonus1Red {
		//	get {
		//		return _SandstormBonus1Red;
		//	}
		//	set {
		//		Set(() => SandstormBonus1Red, ref _SandstormBonus1Red, value);
		//		UpdateRedScore();
		//	}
		//}
		//private byte _SandstormBonus2Red;
		//public byte SandstormBonus2Red {
		//	get {
		//		return _SandstormBonus2Red;
		//	}
		//	set {
		//		Set(() => SandstormBonus2Red, ref _SandstormBonus2Red, value);
		//		UpdateRedScore();
		//	}
		//}
		private byte _ClimbBonusNoneBlue;
		public byte ClimbBonusNoneBlue {
			get {
				return _ClimbBonusNoneBlue;
			}
			set {
				Set(() => ClimbBonusNoneBlue, ref _ClimbBonusNoneBlue, value);
			}
		}
		private byte _ClimbBonus1Blue;
		public byte ClimbBonus1Blue {
			get {
				return _ClimbBonus1Blue;
			}
			set {
				Set(() => ClimbBonus1Blue, ref _ClimbBonus1Blue, value);
				UpdateBlueScore();
			}
		}
		private byte _ClimbBonus2Blue;
		public byte ClimbBonus2Blue {
			get {
				return _ClimbBonus2Blue;
			}
			set {
				Set(() => ClimbBonus2Blue, ref _ClimbBonus2Blue, value);
				UpdateBlueScore();
			}
		}
		private byte _ClimbBonus3Blue;
		public byte ClimbBonus3Blue {
			get {
				return _ClimbBonus3Blue;
			}
			set {
				Set(() => ClimbBonus3Blue, ref _ClimbBonus3Blue, value);
				UpdateBlueScore();
			}
		}
		private byte _ClimbBonusNoneRed;
		public byte ClimbBonusNoneRed {
			get {
				return _ClimbBonusNoneRed;
			}
			set {
				Set(() => ClimbBonusNoneRed, ref _ClimbBonusNoneRed, value);
			}
		}
		//private byte _ClimbBonus1Red;
		//public byte ClimbBonus1Red {
		//	get {
		//		return _ClimbBonus1Red;
		//	}
		//	set {
		//		Set(() => ClimbBonus1Red, ref _ClimbBonus1Red, value);
		//		UpdateRedScore();
		//	}
		//}
		//private byte _ClimbBonus2Red;
		//public byte ClimbBonus2Red {
		//	get {
		//		return _ClimbBonus2Red;
		//	}
		//	set {
		//		Set(() => ClimbBonus2Red, ref _ClimbBonus2Red, value);
		//		UpdateRedScore();
		//	}
		//}
		//private byte _ClimbBonus3Red;
		//public byte ClimbBonus3Red {
		//	get {
		//		return _ClimbBonus3Red;
		//	}
		//	set {
		//		Set(() => ClimbBonus3Red, ref _ClimbBonus3Red, value);
		//		UpdateRedScore();
		//	}
		//}
		private byte _Level2PowerCells;
		public byte Level2PowerCells {
			get {
				return _Level2PowerCells;
			}
			set {
				Set(() => Level2PowerCells, ref _Level2PowerCells, value);
				UpdateBlueScore();
			}
		}
		private byte _Level1PowerCells;
		public byte Level1PowerCells {
			get {
				return _Level1PowerCells;
			}
			set {
				Set(() => Level1PowerCells, ref _Level1PowerCells, value);
				UpdateBlueScore();
			}
		}
		private byte _Level3PowerCells;
		public byte Level3PowerCells {
			get {
				return _Level3PowerCells;
			}
			set {
				Set(() => Level3PowerCells, ref _Level3PowerCells, value);
				UpdateBlueScore();
			}
		}
		// Variables for Autonomous Power Cell Scoring.
		private byte _AutonLevel1PowerCells;

		public byte AutonLevel1PowerCells	{
			get
			{
				return _AutonLevel1PowerCells;
			}
			set
			{
				Set(() => AutonLevel1PowerCells, ref _AutonLevel1PowerCells, value);
				UpdateBlueScore();
			}
		}
		private byte _AutonLevel2PowerCells;

		public byte AutonLevel2PowerCells	{
			get
			{
				return _AutonLevel2PowerCells;
			}
			set
			{
				Set(() => AutonLevel2PowerCells, ref _AutonLevel2PowerCells, value);
				UpdateBlueScore();
 			}
		}
		private byte _AutonLevel3PowerCells;

		public byte AutonLevel3PowerCells	{
			get
			{
				return _AutonLevel3PowerCells;
			}
			set
			{
				Set(() => AutonLevel3PowerCells, ref _AutonLevel3PowerCells, value);
				UpdateBlueScore();
			}
		}

		private byte _RotationControlSpinner;
		public byte RotationControlSpinner {
			get {
				return _RotationControlSpinner;
			}
			set {
				Set(() => RotationControlSpinner, ref _RotationControlSpinner, value);
				UpdateBlueScore();
			}
		}

		private byte _PositionControlSpinner;

		public byte PositionControlSpinner
		{
			get
			{
				return _PositionControlSpinner;
			}
			set
			{
				Set(() => PositionControlSpinner, ref _PositionControlSpinner, value);
				UpdateBlueScore();
			}
		}

		
		private byte _CrossedHabline;

		public byte CrossedHabline
		{
			get
			{
				return _CrossedHabline;
			}
			set
			{
				Set(() => CrossedHabline, ref _CrossedHabline, value);
				UpdateBlueScore();
			}
		}

		private byte _RobotsClimbed; 

		public byte RobotsClimbed {
			get
			{
				return _RobotsClimbed;
			}
			set
			{
				Set(() => RobotsClimbed, ref _RobotsClimbed, value);
				UpdateBlueScore(); 
			}
		}

		private byte _RobotsParked;

		public byte RobotsParked
		{
			get
			{
				return _RobotsParked;
			}
			set
			{
				Set(() => RobotsParked, ref _RobotsParked, value);
				UpdateBlueScore();
			}
		}

		private byte _IsLeveled;

		public byte IsLeveled
		{
			get
			{
				return _IsLeveled;
			}
			set
			{
				Set(() => IsLeveled, ref _IsLeveled, value);
				UpdateBlueScore();
			}
		}

		public MainViewModel() {
			CurrentState = State.Prematch;
			UpdateMatchTimeRemainingString();
			Foul = 0;
			TechFoul = 0;
			BlueCorrection = 0;
			//RedCorrection = 0;
			SandstormNoBonusBlue = 3;
			SandstormNoBonusRed = 3;
			ClimbBonusNoneBlue = 3;
			ClimbBonusNoneRed = 3;
			_MatchTimer.Tick += MatchTimer_Tick;
		}

		private void UpdateMatchTimeRemainingString() {
			MatchTimeRemainingString = string.Format("{0:m\\:ss\\:f}", MatchTimeRemaining);
		}
		private void UpdateBlueScore() {
			ushort endgamePoints = (ushort)(RobotsClimbed * 25 + RobotsParked * 5 + IsLeveled);
			ushort powerCellPoints  = (ushort)(Level1PowerCells * 1  + Level2PowerCells * 2 + Level3PowerCells * 3);
			ushort autonCellPoints = (ushort)(AutonLevel1PowerCells * 2 + AutonLevel2PowerCells * 4 + AutonLevel3PowerCells * 6);
			ushort spinnerPoints = (ushort)(PositionControlSpinner + RotationControlSpinner);
			
			BlueScore = autonCellPoints + powerCellPoints + spinnerPoints + endgamePoints + TechFoul + BlueCorrection + Foul + CrossedHabline ;  //RedCorrection
		}
		//private void UpdateRedScore() {
		//	byte sandstormBonus = (byte)(SandstormBonus1Red * 3 + SandstormBonus2Red * 6);
		//	byte climbBonus = (byte)(ClimbBonus1Red * 3 + ClimbBonus2Red * 6 + ClimbBonus3Red * 12);
		//	byte cargoShipPoints = (byte)(CargoShipHatchPanelsRed * 2 + CargoShipCargoRed * 3);
		//	byte rocketPoints = (byte)(RocketHatchPanelsRed * 2 + RocketCargoRed * 3);
		//	RedScore = sandstormBonus + climbBonus + cargoShipPoints + rocketPoints + Foul; // RedCorrection;
		//}
		
		private void MatchTimer_Tick(object sender, object e) {
			UpdateMatchTimeRemainingString();
			if(_MatchStopwatch.Elapsed > MatchLength) {
				_MatchTimer.Stop();
				_MatchStopwatch.Stop();
				CurrentState = State.Postmatch;
			}
		}

		public void StartMatch() {
			if(CurrentState != State.Prematch)
				return;
			_MatchTimer.Start();
			_MatchStopwatch.Start();
			CurrentState = State.Match;
		}
		public void StopMatch() {
			if(CurrentState != State.Match)
				return;
			_MatchTimer.Stop();
			_MatchStopwatch.Stop();
			CurrentState = State.Postmatch;
		}
		public void Reset() {
			if(CurrentState != State.Postmatch)
				return;
			CurrentState = State.Prematch;
			_MatchStopwatch.Reset();
			UpdateMatchTimeRemainingString();
			Foul = 0;
			BlueCorrection = 0;
			TechFoul = 0;
			//RedCorrection = 0;
			SandstormNoBonusBlue = 3;
			SandstormBonus1Blue = 0;
			SandstormBonus2Blue = 0;
			SandstormNoBonusRed = 3;
			//SandstormBonus1Red = 0;
			//SandstormBonus2Red = 0;
			ClimbBonusNoneBlue = 3;
			ClimbBonus1Blue = 0;
			ClimbBonus2Blue = 0;
			ClimbBonus3Blue = 0;
			ClimbBonusNoneRed = 3;
			//ClimbBonus1Red = 0;
			//ClimbBonus2Red = 0;
			//ClimbBonus3Red = 0;
			AutonLevel1PowerCells = 0;
			AutonLevel2PowerCells = 0;
			AutonLevel3PowerCells = 0;
			Level1PowerCells = 0;
			Level2PowerCells = 0;
			Level3PowerCells = 0;
			//CargoShipHatchPanelsRed = 0;
			//CargoShipCargoRed = 0;
			//RocketHatchPanelsRed = 0;
			RotationControlSpinner = 0;
			PositionControlSpinner = 0;
			CrossedHabline = 0;
		}
	}
}
