using System;
using MineModel;

namespace MineView {
	public abstract class StateButton {
		public StateButtonModel Model { get; private set; }
		public int X { get; private set; }
		public int Y { get; private set; }
		public int Width { get { return Constants.StateButtonWidth; } }
		public int Height { get { return Constants.StateButtonHeight; } }
		
		public ImageId GetImageId() {
			switch (Model.GameModel.GameState) {
			case GameState.Active:
				return ImageId.Smile;
			case GameState.Win:
				return ImageId.SmileWin;
			case GameState.Lose:
				return ImageId.SmileLose;
			default:
				throw new MineSweeperException("Unknown game state");
			}
		}
		
		public StateButton(StateButtonModel model, int x, int y) {
			Model = model;
			X = x;
			Y = y;
		}

		public abstract void Draw(object painter, Rectangle rect);
	}
}
