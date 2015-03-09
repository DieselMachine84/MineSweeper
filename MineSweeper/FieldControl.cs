using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MineView;

namespace MineSweeper {
	public class FieldControl : Control {
		protected WFField Field { get; private set; }
		
		private System.Drawing.Rectangle ToDrawingRectangle(MineView.Rectangle rect) {
			return new System.Drawing.Rectangle(rect.X, rect.Y, rect.Width, rect.Height);
		}
		
		private MineView.Rectangle FromDrawingRectangle(System.Drawing.Rectangle rect) {
			return new MineView.Rectangle(rect.X, rect.Y, rect.Width, rect.Height);
		}
		
		public FieldControl(WFField field) {
			Field = field;
			Field.Invalidated += (sender, e) => Invalidate(ToDrawingRectangle(e.InvalidateRect));
		}
		
		protected override void OnPaint(PaintEventArgs e) {
			base.OnPaint(e);
			Field.Draw(e.Graphics, FromDrawingRectangle(e.ClipRectangle));
		}
		
		protected override void OnMouseClick(MouseEventArgs e) {
			base.OnMouseClick(e);
			Field.ProcessMouseEvent(e, MouseButtons);
		}
		
		protected override void OnKeyPress(KeyPressEventArgs e) {
			base.OnKeyPress(e);
		}
	}
}
