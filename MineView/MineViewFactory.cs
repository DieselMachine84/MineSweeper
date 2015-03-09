using System;

namespace MineView {
	public abstract class ViewFactory {
		public abstract Field CreateField();
		public abstract FieldButton CreateFieldButton();
		public abstract StateButton CreateStateButton();
	}
}
