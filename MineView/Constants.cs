using System;

namespace MineWinFormsView {
	internal static class Constants {
		public const int BorderWidth = 5;
		public const int StateHeight = 40;
		public const int ButtonHeight = 16;
		public const int ButtonWidth = 16;
		
		public static int StateHeightWithBorders { get { return BorderWidth * 2 + StateHeight; } }
	}
}
