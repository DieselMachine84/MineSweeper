using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MineModel {
    public abstract class MarkStrategy {
        public abstract void ToggleMark(CellModel cell);
    }

    public class MineStrategy : MarkStrategy {
        public override void ToggleMark(CellModel cell) {
            switch (cell.State) {
                case CellState.Closed:
                    cell.State = CellState.MarkedMine;
                    return;
                case CellState.MarkedMine:
                    cell.State = CellState.Closed;
                    return;
            }
        }
    }

    public class QuestionStrategy : MarkStrategy {
        public override void ToggleMark(CellModel cell) {
            switch (cell.State) {
                case CellState.Closed:
                    cell.State = CellState.MarkedMine;
                    return;
                case CellState.MarkedMine:
                    cell.State = CellState.MarkedQuestion;
                    return;
                case CellState.MarkedQuestion:
                    cell.State = CellState.Closed;
                    return;
            }
        }
    }
}
