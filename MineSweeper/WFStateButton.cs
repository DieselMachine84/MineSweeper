using System;
using System.Drawing;
using MineModel;
using MineView;

namespace MineSweeper {
	public class WFStateButton : StateButton {
		public WFStateButton(StateButtonModel model, int x, int y) : base(model, x, y) {
		}

		public override void Draw(object painter, MineView.Rectangle rect) {
			if (rect.IntersectsWith(new MineView.Rectangle(X, Y, Width, Height))) {
				Graphics graphics = (Graphics)painter;
				graphics.DrawImage(ImageManager.GetImage(GetImageId()), X, Y);
			}
		}
	}
}
