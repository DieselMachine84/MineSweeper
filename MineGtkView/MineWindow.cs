using System;
namespace MineGtkView {
	public partial class MineWindow : Gtk.Window {
		public MineWindow() : 
				base(Gtk.WindowType.Toplevel) {
			this.Build();
		}
	}
}

