using System;
using MineModel;

namespace MineView {
	public abstract class FieldCell {
		public CellModel CellModel { get; private set; }
		public int X { get; private set; }
		public int Y { get; private set; }
		public abstract int Width { get; }
		public abstract int Height { get; }

		public ImageId GetImageId() {
			switch (CellModel.State) {
			case CellState.Closed:
				if (CellModel.HasMine && (CellModel.GameModel.GameState == GameState.Lose)) {
					return ImageId.MineBlack;
				} else {
					return ImageId.CellClosed;
				}
			case CellState.MarkedMine:
				if (!CellModel.HasMine && (CellModel.GameModel.GameState == GameState.Lose)) {
					return ImageId.MineCrossed;
				} else {
					return ImageId.CellMine;
				}
			case CellState.MarkedQuestion:
				return ImageId.CellMark;
			case CellState.Opened:
				if (CellModel.HasMine) {
					return ImageId.MineRed;
				}
					
				switch (CellModel.GetNumberOfNearbyMines()) {
				case 0:
					return ImageId.CellOpened;
				case 1:
					return ImageId.CellOne;
				case 2:
					return ImageId.CellTwo;
				case 3:
					return ImageId.CellThree;
				case 4:
					return ImageId.CellFour;
				case 5:
					return ImageId.CellFive;
				case 6:
					return ImageId.CellSix;
				case 7:
					return ImageId.CellSeven;
				case 8:
					return ImageId.CellEight;
				default:
					throw new MineSweeperException("Unexpected number of mines");
				}
			default:
				throw new MineSweeperException("Unknown cell state");
			}
		}
		
		public FieldCell(CellModel cellModel) {
			CellModel = cellModel;
			X = Constants.BorderWidth + cellModel.Column * Constants.CellWidth;
			Y = Constants.StatePanelHeight + 2 * Constants.BorderWidth + cellModel.Row * Constants.CellHeight;
		}

		public abstract void Draw(object painter, Rectangle rect);
	}
}
