using System;
using Gdk;
using Cairo;

namespace MineGtkView {
	public class FieldControl : Gtk.DrawingArea {
		public FieldControl() {
			// Insert initialization code here.
		}

		protected override bool OnButtonPressEvent(Gdk.EventButton ev) {
			// Insert button press handling code here.
			return base.OnButtonPressEvent(ev);
		}

		protected override bool OnExposeEvent(Gdk.EventExpose ev) {
			base.OnExposeEvent(ev);
			using (Context g = Gdk.CairoHelper.Create (ev.Window)) {
				int x = 30, y = 30, width = 300, height = 200;
				g.Save();
				g.MoveTo(x, y + height / 2);
				g.CurveTo(x, y, x, y, x + width / 2, y);
				g.CurveTo(x + width, y, x + width, y, x + width, y + height / 2);
				g.CurveTo(x + width, y + height, x + width, y + height, x + width / 2, y + height);
				g.CurveTo(x, y + height, x, y + height, x, y + height / 2);
				g.Restore();
				g.Color = new Cairo.Color(0.1, 0.6, 1, 1);
				g.FillPreserve();
				g.Color = new Cairo.Color(0.2, 0.8, 1, 1);
				g.LineWidth = 5;
				g.Stroke();
			}
			return true;
		}

		protected override void OnSizeAllocated(Gdk.Rectangle allocation) {
			base.OnSizeAllocated(allocation);
			// Insert layout code here.
		}

		protected override void OnSizeRequested(ref Gtk.Requisition requisition) {
			// Calculate desired size here.
			//requisition.Height = 50;
			//requisition.Width = 50;
		}
	}
}
