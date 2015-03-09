using System;
using MineModel;

namespace MineView {
	public abstract class MineViewFactory {
		public abstract Counter CreateMineCounter(CounterModel model);
		public abstract Counter CreateTimeCounter(CounterModel model, int fieldWidth);
		public abstract StateButton CreateStateButton(StateButtonModel model, int fieldWidth);
		public abstract FieldCell CreateFieldCell(CellModel model);
	}
}
