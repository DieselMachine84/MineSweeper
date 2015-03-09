using System;
using System.Drawing;
using MineModel;
using MineView;

namespace MineWinFormsView {
	public class WFFieldButton : FieldButton {
		public override int Width { get { return Constants.ButtonWidth; } }
		
		public override int Height { get { return Constants.ButtonHeight; } }
		
		public WFFieldButton(ButtonModel buttonModel) : base(buttonModel) {
		}
		
		public override void Draw(object painter) {
			Graphics graphics = (Graphics)painter;
			graphics.DrawImage(ImageManager.GetImage(ImageId), X, Y);
		}
	}
}
