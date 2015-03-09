using System;

namespace MineModel {
	public class StateButtonModel {
		public GameModel GameModel { get; private set; }

		public StateButtonModel(GameModel gameModel) {
			GameModel = gameModel;
		}
	}
}
