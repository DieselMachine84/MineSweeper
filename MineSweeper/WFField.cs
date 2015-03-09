using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using MineModel;
using MineView;

namespace MineSweeper {
	public class WFField : Field {
		public WFField(GameModel model) : base(model) {
		}
		
		protected override void DrawBorderAndBackGround(object painter, MineView.Rectangle rect) {
			if(rect == new MineView.Rectangle(0, 0, Width, Height)) {
				Graphics graphics = (Graphics)painter;
				using (SolidBrush brush = new SolidBrush(Color.FromArgb(123, 123, 123))) {
					graphics.FillRectangle(brush, new System.Drawing.Rectangle(rect.X, rect.Y,
					                                                           rect.Width, rect.Height)
					);
				}
			}
		}
		
		public void ProcessMouseEvent(MouseEventArgs e, MouseButtons mouseButtons) {
			if (IsMouseAtStateButton(e)) {
				if (e.Button == System.Windows.Forms.MouseButtons.Left) {
					Restart();
				}
			}
			
			if (IsMouseAtFieldCell(e)) {
				FieldCell cell = Cells.Where(b => (e.X >= b.X) && (e.X < b.X + Constants.CellWidth)
					&& (e.Y >= b.Y) && (e.Y < b.Y + Constants.CellHeight)
				).FirstOrDefault();

				if (cell != null) {
					/*if (e.Button == (System.Windows.Forms.MouseButtons.Left & System.Windows.Forms.MouseButtons.Right)) {
						OpenNeighbours(cell);
					}*/
					if (e.Button == System.Windows.Forms.MouseButtons.Left) {
						if ((mouseButtons & MouseButtons.Right) != MouseButtons.None) {
							OpenNeighbours(cell);
						} else {
							Open(cell);
						}
					}
					if (e.Button == System.Windows.Forms.MouseButtons.Right) {
						if ((mouseButtons & MouseButtons.Left) != MouseButtons.None) {
							OpenNeighbours(cell);
						} else {
							ToggleMark(cell);
						}
					}
				}
			}
		}
		
		private bool IsMouseAtStateButton(MouseEventArgs e) {
			return (e.X >= StateButton.X)
				&& (e.X < StateButton.X + StateButton.Width)
				&& (e.Y >= StateButton.Y)
				&& (e.Y < StateButton.Y + StateButton.Height);
		}
		
		private bool IsMouseAtFieldCell(MouseEventArgs e) {
			return (e.X >= Constants.BorderWidth)
				&& (e.X < Constants.BorderWidth + Constants.CellWidth * GameModel.Columns)
				&& (e.Y >= Constants.StateHeightWithBorders)
				&& (e.Y < Constants.StateHeightWithBorders + Constants.CellHeight * GameModel.Rows);
		}

		private int GetRow(MouseEventArgs e) {
			return (e.Y - Constants.StateHeightWithBorders) / Constants.CellHeight;
		}
		
		private int GetColumn(MouseEventArgs e) {
			return (e.X - Constants.BorderWidth) / Constants.CellWidth;
		}
	}
}
