using System;
using MineModel;

namespace MineView {
	public abstract class Counter {
		public CounterModel Model { get; private set; }
		public int X { get; private set; }
		public int Y { get; private set; }
		public int Width { get { return 3 * Constants.DigitWidth; } }
		public int Height { get { return Constants.DigitHeight; } }
		
		private ImageId GetImageByDigit(int digit) {
			switch (digit) {
			case 0:
				return ImageId.DigitZero;
			case 1:
				return ImageId.DigitOne;
			case 2:
				return ImageId.DigitTwo;
			case 3:
				return ImageId.DigitThree;
			case 4:
				return ImageId.DigitFour;
			case 5:
				return ImageId.DigitFive;
			case 6:
				return ImageId.DigitSix;
			case 7:
				return ImageId.DigitSeven;
			case 8:
				return ImageId.DigitEight;
			case 9:
				return ImageId.DigitNine;
			default:
				throw new MineSweeperException(String.Format("Digit value {0} is out of range", digit));
			}
		}
		
		public ImageId GetDigit1ImageId() {
			return GetImageByDigit(Model.GetDigit1());
		}
		public ImageId GetDigit2ImageId() {
			return GetImageByDigit(Model.GetDigit2());
		}
		public ImageId GetDigit3ImageId() {
			return GetImageByDigit(Model.GetDigit3());
		}
		
		public Counter(CounterModel model, int x, int y) {
			Model = model;
			X = x;
			Y = y;
		}

		public abstract void Draw(object painter, Rectangle rect);
	}
}
