using System;
using System.Collections.Generic;
using System.Linq;
using System.Timers;

namespace MineModel {
	public enum GameState { Active, Win, Lose }

	public class Model : IDisposable {
		private GameState gameState;

		private bool MinesPlaced { get; set; }
		private Timer Timer { get; set; }
		public int Rows { get; private set; }
		public int Columns { get; private set; }
		public int MinesCount { get; private set; }
		public List<ButtonModel> Buttons { get; private set; }
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
		
		public Model(int rows, int columns, int minesCount,
		             System.ComponentModel.ISynchronizeInvoke synchronizingObject) {
			MinesPlaced = false;
			Rows = rows;
			Columns = columns;
			MinesCount = minesCount;
			Buttons = new List<ButtonModel>(rows * columns);
			MineCounter = new CounterModel(minesCount);
			TimeCounter = new CounterModel(0);
			StateButton = new StateButtonModel(this);
			Timer = new System.Timers.Timer(1000);
			Timer.SynchronizingObject = synchronizingObject;
			Timer.Elapsed += (sender, e) => UpdateTimeCounter();
			GameState = MineModel.GameState.Active;

			for (int row = 0; row < rows; row++) {
				for (int column = 0; column < columns; column++) {
					Buttons.Add(new ButtonModel(this, row, column));
				}
			}

			Buttons.ForEach(button => button.Neighbours.AddRange(
				Buttons.Where(another =>
			              (Math.Abs(another.Row - button.Row) <= 1)
			              && (Math.Abs(another.Column - button.Column) <= 1)
			              && (button != another))));
		}
		
		private void PlaceMines(ButtonModel cellToOpen) {
			if (MinesPlaced) {
				return;
			}

			int placedCount = 0;
			Random random = new Random();
			while (placedCount < MinesCount) {
				ButtonModel target = Buttons[random.Next(Buttons.Count)];
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
			MineCounter.Value = MinesCount - Buttons.Count(cell => cell.State == ButtonState.MarkedMine);
		}
		
		private void UpdateTimeCounter() {
			TimeCounter.Value++;
		}
		
		private void CheckVictory() {
			bool allMinesMarked = !Buttons.Any(button => button.HasMine
				&& button.State != ButtonState.MarkedMine
			);
			bool allOtherCellsOpened = !Buttons.Any(button => !button.HasMine
				&& button.State != ButtonState.Opened
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
			MinesPlaced = false;
			MineCounter.Value = MinesCount;
			TimeCounter.Value = 0;
			Buttons.ForEach(cell => cell.Reset());
			Timer.Stop();
			GameState = MineModel.GameState.Active;
			OnGameStateChanged(EventArgs.Empty);
		}
		
		public void Open(ButtonModel buttonModel) {
			CheckPreAndPostConditionsAndDoAction(() => {
				PlaceMines(buttonModel);
				buttonModel.Open();
			});
		}

		public void OpenNeighbours(ButtonModel buttonModel) {
			CheckPreAndPostConditionsAndDoAction(() => buttonModel.OpenNeighbours());
		}
		
		public void ToggleMark(ButtonModel buttonModel) {
			CheckPreAndPostConditionsAndDoAction(() => {
				buttonModel.ToggleMark();
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
