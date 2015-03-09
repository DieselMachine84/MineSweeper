using System;

namespace MineView {
	public static class Constants {
		public const int BorderWidth = 6;
		public const int CellWidth = 16;
		public const int CellHeight = 16;
		public const int DigitWidth = 13;
		public const int DigitHeight = 23;
		public const int StateButtonWidth = 26;
		public const int StateButtonHeight = 26;
		
		public static int StatePanelHeight { get { return 2 * BorderWidth + DigitHeight; } }
		public static int StateHeightWithBorders { get { return 2 * BorderWidth + StatePanelHeight; } }
	}
}
