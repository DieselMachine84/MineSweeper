using System;
using MineModel;
using MineView;

namespace MineSweeper {
	public abstract class WinFormsFactory : MineViewFactory {
		public override Counter CreateMineCounter(CounterModel model) {
			return new WFCounter(model, 2 * Constants.BorderWidth, 2 * Constants.BorderWidth);
		}

		public override Counter CreateTimeCounter(CounterModel model, int fieldWidth) {
			return new WFCounter(model, fieldWidth - 2 * Constants.BorderWidth - 3 * Constants.DigitWidth, 2 * Constants.BorderWidth);
		}
		
		public override StateButton CreateStateButton(StateButtonModel model, int fieldWidth) {
			return new WFStateButton(model, fieldWidth / 2 - Constants.StateButtonWidth / 2, 2 * Constants.BorderWidth);
		}
	}
	
	public class RectangleFactory : WinFormsFactory {
		public override FieldCell CreateFieldCell(CellModel model) {
			return new WFFieldCell(model);
		}
	}
}
