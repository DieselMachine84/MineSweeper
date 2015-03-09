using System;
using Gdk;
using Cairo;

namespace MineGtkView {
	public partial class MineWindow : Gtk.Window {
		private FieldControl field;

		public MineWindow() : base(Gtk.WindowType.Toplevel) {
			this.Build();
			field = new FieldControl();
		}
		
		/*protected override bool OnExposeEvent(Gdk.EventExpose evnt) {
			base.OnExposeEvent(evnt);
			using (Context g = Gdk.CairoHelper.Create (evnt.Window)) {
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
		}*/
	}
}
