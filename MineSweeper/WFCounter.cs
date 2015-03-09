using System;
using System.Drawing;
using MineModel;
using MineView;

namespace MineSweeper {
	public class WFCounter : Counter {
		public WFCounter(CounterModel model, int x, int y) : base(model, x, y) {
		}

		public override void Draw(object painter, MineView.Rectangle rect) {
			if (rect.IntersectsWith(new MineView.Rectangle(X, Y, Width, Height))) {
				Graphics graphics = (Graphics)painter;
				graphics.DrawImage(ImageManager.GetImage(GetDigit1ImageId()), X, Y);
				graphics.DrawImage(ImageManager.GetImage(GetDigit2ImageId()), X + Constants.DigitWidth, Y);
				graphics.DrawImage(ImageManager.GetImage(GetDigit3ImageId()), X + 2 * Constants.DigitWidth, Y);
			}
		}
	}
}
