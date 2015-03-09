using System;
using System.Drawing;
using MineModel;
using MineView;

namespace MineSweeper {
	public class WFFieldCell : FieldCell {
		public override int Width { get { return Constants.CellWidth; } }
		
		public override int Height { get { return Constants.CellHeight; } }
		
		public WFFieldCell(CellModel model) : base(model) {
		}
		
		public override void Draw(object painter, MineView.Rectangle rect) {
			if (rect.IntersectsWith(new MineView.Rectangle(X, Y, Width, Height))) {
				Graphics graphics = (Graphics)painter;
				graphics.DrawImage(ImageManager.GetImage(GetImageId()), X, Y);
			}
		}
	}
}
