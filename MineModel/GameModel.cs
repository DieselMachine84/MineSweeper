using System;
using System.Collections.Generic;
using System.Linq;
using System.Timers;

namespace MineModel {
	public enum GameState { None, Active, Win, Lose }

	public class GameModel : IDisposable {
		private GameState gameState;

		private bool MinesPlaced { get; set; }
		private Timer Timer { get; set; }
		public int Rows { get; private set; }
		public int Columns { get; private set; }
		public int MinesCount { get; private set; }
		public List<CellModel> Cells { get; private set; }
		public CounterModel MineCounter { get; private set; }
		public CounterModel TimeCounter { get; private set; }
		public StateButtonModel StateButton { get; private set; }
		public GameState GameState {
			get { return gameState; }
			set {
				if (gameState == value) {
					return;
				}
				gameState = value;
				OnGameStateChanged(EventArgs.Empty);
			}
		}

		public event EventHandler<EventArgs> GameStateChanged;
		
		protected virtual void OnGameStateChanged(EventArgs e) {
			if (GameStateChanged != null) {
				GameStateChanged(this, e);
			}
		}
		
		public GameModel(int rows, int columns, int minesCount,
		             System.ComponentModel.ISynchronizeInvoke synchronizingObject) {
			GameState = MineModel.GameState.None;
			MinesPlaced = false;
			Rows = (rows >= 5) ? rows : 5;
			Columns = (columns >= 5) ? columns : 5;
			MinesCount = (minesCount <= rows * columns - 10) ? minesCount : rows * columns - 10;
			Cells = new List<CellModel>(rows * columns);
			MineCounter = new CounterModel(minesCount);
			TimeCounter = new CounterModel(0);
			StateButton = new StateButtonModel(this);
			Timer = new System.Timers.Timer(1000);
			Timer.SynchronizingObject = synchronizingObject;
			Timer.Elapsed += (sender, e) => UpdateTimeCounter();

			for (int row = 0; row < rows; row++) {
				for (int column = 0; column < columns; column++) {
					Cells.Add(new CellModel(this, row, column));
				}
			}

			Cells.ForEach(cell => cell.Neighbours.AddRange(
				Cells.Where(another =>
			            (Math.Abs(another.Row - cell.Row) <= 1)
			            && (Math.Abs(another.Column - cell.Column) <= 1)
			            && (cell != another))));
			GameState = MineModel.GameState.Active;
		}
		
		private void PlaceMines(CellModel cellToOpen) {
			if (MinesPlaced) {
				return;
			}

			int placedCount = 0;
			Random random = new Random();
			while (placedCount < MinesCount) {
				CellModel target = Cells[random.Next(Cells.Count)];
				if (!target.HasMine && (target != cellToOpen)) {
					target.HasMine = true;
					placedCount++;
				}
			}
			MinesPlaced = true;
			UpdateMineCounter();
			Timer.Start();
		}
		
		private void UpdateMineCounter() {
			MineCounter.Value = MinesCount - Cells.Count(cell => cell.State == CellState.MarkedMine);
		}
		
		private void UpdateTimeCounter() {
			TimeCounter.Value++;
		}
		
		private void CheckVictory() {
			bool allMinesMarked = !Cells.Any(cell => cell.HasMine
				&& cell.State != CellState.MarkedMine
			);
			bool allOtherCellsOpened = !Cells.Any(cell => !cell.HasMine
				&& cell.State != CellState.Opened
			);
			if (allMinesMarked && allOtherCellsOpened) {
				GameState = GameState.Win;
				Timer.Stop();
			}
		}

		internal void GameOver() {
			GameState = GameState.Lose;
			Timer.Stop();
		}
		
		private void CheckPreAndPostConditionsAndDoAction(Action action) {
			if (GameState != GameState.Active) {
				return;
			}
			
			action();

			CheckVictory();
		}
		
		public void Restart() {
			GameState = MineModel.GameState.None;
			MinesPlaced = false;
			MineCounter.Value = MinesCount;
			TimeCounter.Value = 0;
			Cells.ForEach(cell => cell.Reset());
			Timer.Stop();
			GameState = MineModel.GameState.Active;
		}
		
		public void Open(CellModel cellModel) {
			CheckPreAndPostConditionsAndDoAction(() => {
				PlaceMines(cellModel);
				cellModel.Open();
			});
		}

		public void OpenNeighbours(CellModel cellModel) {
			CheckPreAndPostConditionsAndDoAction(() => cellModel.OpenNeighbours());
		}
		
		public void ToggleMark(CellModel cellModel) {
			CheckPreAndPostConditionsAndDoAction(() => {
				cellModel.ToggleMark();
				UpdateMineCounter();
			});
		}
		
		#region IDisposable
		public void Dispose() {
			Timer.Stop();
			Timer.Dispose();
		}
		#endregion
	}
}
