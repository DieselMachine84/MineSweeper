using System;
using MineModel;

namespace MineView {
	public abstract class FieldButton {
		public ButtonModel ButtonModel { get; private set; }
		public int X { get; private set; }
		public int Y { get; private set; }
		public abstract int Width { get; }
		public abstract int Height { get; }

		public ImageId ImageId {
			get {
				switch (ButtonModel.State) {
				case ButtonState.Closed:
					if (ButtonModel.HasMine && (ButtonModel.Model.GameState == GameState.Lose)) {
						return ImageId.MineBlack;
					} else {
						return ImageId.ButtonClosed;
					}
				case ButtonState.MarkedMine:
					if (!ButtonModel.HasMine && (ButtonModel.Model.GameState == GameState.Lose)) {
						return ImageId.MineCrossed;
					} else {
						return ImageId.ButtonMine;
					}
				case ButtonState.MarkedQuestion:
					return ImageId.ButtonMark;
				case ButtonState.Opened:
					if (ButtonModel.HasMine) {
						return ImageId.MineRed;
					}
					
					switch (ButtonModel.GetNumberOfNearbyMines()) {
					case 0:
						return ImageId.ButtonOpened;
					case 1:
						return ImageId.ButtonOne;
					case 2:
						return ImageId.ButtonTwo;
					case 3:
						return ImageId.ButtonThree;
					case 4:
						return ImageId.ButtonFour;
					case 5:
						return ImageId.ButtonFive;
					case 6:
						return ImageId.ButtonSix;
					case 7:
						return ImageId.ButtonSeven;
					case 8:
						return ImageId.ButtonEight;
					default:
						throw new Exception("Unexpected number of mines");
					}
				default:
					throw new Exception("Unknown button state");
				}
			}
		}
		
		public FieldButton(ButtonModel buttonModel) {
			ButtonModel = buttonModel;
			X = Constants.BorderWidth + buttonModel.Column * Constants.ButtonWidth;
			Y = Constants.StateHeight + 2 * Constants.BorderWidth + buttonModel.Row * Constants.ButtonHeight;
		}

		public abstract void Draw(object painter);
	}
}
