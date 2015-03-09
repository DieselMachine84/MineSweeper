using System;
using System.Collections.Generic;
using System.Linq;

namespace MineModel {
	public enum CellState { Closed, Opened, MarkedMine, MarkedQuestion }

	public class CellModel {
		private CellState state;

		public GameModel GameModel { get; private set; }
		public int Row { get; private set; }
		public int Column { get; private set; }
		public bool HasMine { get; internal set; }
		public CellState State {
			get { return state; }
			set {
				if (state == value) {
					return;
				}
				state = value;
				OnStateChanged(EventArgs.Empty);
			}
		}
		public List<CellModel> Neighbours { get; private set; }
		
		public event EventHandler<EventArgs> StateChanged;
		
		protected virtual void OnStateChanged(EventArgs e) {
			if (StateChanged != null) {
				StateChanged(this, e);
			}
		}
		
		public CellModel(GameModel model, int row, int column) {
			GameModel = model;
			Row = row;
			Column = column;
			Neighbours = new List<CellModel>();
			Reset();
		}
		
		public int GetNumberOfNearbyMines() {
			return Neighbours.Count(cell => cell.HasMine);
		}
		
		internal void Reset() {
			HasMine = false;
			State = CellState.Closed;
		}
		
		internal void OpenNeighbours() {
			if (State == CellState.Opened) {
				foreach (var cell in Neighbours) {
					cell.Open();
					if ((cell.HasMine && (cell.State != CellState.MarkedMine))
						|| (!cell.HasMine && (cell.State == CellState.MarkedMine))) {
						GameModel.GameOver();
					}
				}
			}
		}
		
		internal void Open() {
			if (State == CellState.Closed) {
				State = CellState.Opened;
				if (HasMine) {
					GameModel.GameOver();
				} else {
					if (GetNumberOfNearbyMines() == 0) {
						Neighbours.ForEach(cell => cell.Open());
					}
				}
			}
		}
		
		internal void ToggleMark() {
			switch (State) {
			case CellState.Closed:
				State = CellState.MarkedMine;
				return;
			case CellState.MarkedMine:
				State = CellState.MarkedQuestion;
				return;
			case CellState.MarkedQuestion:
				State = CellState.Closed;
				return;
			}
		}
	}
}
