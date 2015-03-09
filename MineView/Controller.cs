using System;
using System.Collections.Generic;
using System.Linq;
using MineModel;

namespace MineView {
	public class Controller {
		protected GameModel GameModel { get; private set; }
		protected Field Field { get; private set; }
		protected MineViewFactory Factory { get; private set; }
		
		public Controller(GameModel model, Field field, MineViewFactory factory) {
			GameModel = model;
			Field = field;
			Factory = factory;

			var mineCounter = Factory.CreateMineCounter(GameModel.MineCounter);
			var timeCounter = Factory.CreateTimeCounter(GameModel.TimeCounter, Field.Width);
			var stateButton = Factory.CreateStateButton(GameModel.StateButton, Field.Width);
			var cells = new List<FieldCell>();
			GameModel.Cells.ForEach(cell => cells.Add(Factory.CreateFieldCell(cell)));
			Field.Initialize(mineCounter, timeCounter, stateButton, cells);

			GameModel.GameStateChanged += (sender, e) => Field.Invalidate();
			GameModel.MineCounter.ValueChanged += (sender, e) => Field.InvalidateMineCounter();
			GameModel.TimeCounter.ValueChanged += (sender, e) => Field.InvalidateTimeCounter();
			GameModel.Cells.ForEach(cell => cell.StateChanged +=
			                      (sender, e) => Field.InvalidateCell((CellModel)sender)
			);
		}
	}
}
