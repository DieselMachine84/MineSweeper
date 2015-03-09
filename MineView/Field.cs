using System;
using System.Collections.Generic;
using System.Linq;
using MineModel;

namespace MineView {
	public abstract class Field {
		protected Counter MineCounter { get; private set; }
		protected Counter TimeCounter { get; private set; }
		protected StateButton StateButton { get; private set; }
		protected List<FieldCell> Cells { get; private set; }
		public GameModel GameModel { get; private set; }
		public int Width { get { return 2 * Constants.BorderWidth + GameModel.Columns * Constants.CellWidth; } }
		public int Height { get { return 3 * Constants.BorderWidth + GameModel.Rows * Constants.CellHeight + Constants.StatePanelHeight; } }
		
		public event EventHandler<FieldInvalidateEventArgs> Invalidated;
		
		protected virtual void OnInvalidated(FieldInvalidateEventArgs e) {
			if (Invalidated != null) {
				Invalidated(this, e);
			}
		}
		
		internal void Initialize(Counter mineCounter, Counter timeCounter,
		                         StateButton stateButton, List<FieldCell> cells) {
			MineCounter = mineCounter;
			TimeCounter = timeCounter;
			StateButton = stateButton;
			Cells = cells;
		}
		
		public Field(GameModel gameModel) {
			GameModel = gameModel;
		}
		
		public virtual void Draw(object painter, Rectangle rect) {
			DrawBorderAndBackGround(painter, rect);
			MineCounter.Draw(painter, rect);
			TimeCounter.Draw(painter, rect);
			StateButton.Draw(painter, rect);
			Cells.ForEach(b => b.Draw(painter, rect));
		}
		
		protected void Restart() {
			GameModel.Restart();
		}
		
		protected void Open(FieldCell cell) {
			GameModel.Open(cell.CellModel);
		}
		
		protected void OpenNeighbours(FieldCell cell) {
			GameModel.OpenNeighbours(cell.CellModel);
		}
		
		protected void ToggleMark(FieldCell cell) {
			GameModel.ToggleMark(cell.CellModel);
		}

		internal void Invalidate() {
			FieldInvalidateEventArgs args = new FieldInvalidateEventArgs(
				new Rectangle(0, 0, Width, Height)
			);
			OnInvalidated(args);
		}
		
		internal void InvalidateMineCounter() {
			FieldInvalidateEventArgs args = new FieldInvalidateEventArgs(new Rectangle(
				MineCounter.X, MineCounter.Y, MineCounter.Width, MineCounter.Height)
			);
			OnInvalidated(args);
		}

		internal void InvalidateTimeCounter() {
			FieldInvalidateEventArgs args = new FieldInvalidateEventArgs(new Rectangle(
				TimeCounter.X, TimeCounter.Y, TimeCounter.Width, TimeCounter.Height)
			);
			OnInvalidated(args);
		}
		
		internal void InvalidateCell(CellModel cellModel) {
			FieldCell fieldCell = Cells.Where(cell => cell.CellModel == cellModel).First();
			FieldInvalidateEventArgs args = new FieldInvalidateEventArgs(new Rectangle(
				fieldCell.X, fieldCell.Y, fieldCell.Width, fieldCell.Height));
			OnInvalidated(args);
		}
		
		protected abstract void DrawBorderAndBackGround(object painter, Rectangle rect);
	}
	
	public class FieldInvalidateEventArgs : EventArgs {
		public Rectangle InvalidateRect { get; private set; }
		
		public FieldInvalidateEventArgs(Rectangle rect) {
			InvalidateRect = rect;
		}
	}
}
