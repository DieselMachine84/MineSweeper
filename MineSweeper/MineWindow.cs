using System;
using System.Windows.Forms;

namespace MineSweeper {
	public class MineWindow : Form {
        private const int PanelHeight = 36;

        private MineModel.GameModel model;
		private MineView.Controller controller;
		private WFField field;
		private FieldControl fieldControl;
		private System.Windows.Forms.Button btnRestart;
		private System.Windows.Forms.Button btnSettings;
		private System.Windows.Forms.Button btnExit;
		private System.Windows.Forms.Panel panel;

		private void InitializeComponent() {
			CreateNewGame(16, 30, 99, false);

			SuspendLayout();

			btnRestart = new System.Windows.Forms.Button();
			btnRestart.Click += BtnRestartHandleClick;
			btnRestart.Location = new System.Drawing.Point(6, 6);
			btnRestart.Size = new System.Drawing.Size(60, 24);
			btnRestart.Text = "Restart";
			
			btnSettings = new System.Windows.Forms.Button();
			btnSettings.Click += BtnSettingsHandleClick;
			btnSettings.Location = new System.Drawing.Point(72, 6);
			btnSettings.Size = new System.Drawing.Size(60, 24);
			btnSettings.Text = "Settings";

			btnExit = new System.Windows.Forms.Button();
			btnExit.Click += BtnExitHandleClick;
			btnExit.Location = new System.Drawing.Point(138, 6);
			btnExit.Size = new System.Drawing.Size(60, 24);
			btnExit.Text = "Exit";
			
			panel = new System.Windows.Forms.Panel();
            panel.BackColor = System.Drawing.Color.FromArgb(123, 123, 123);
            panel.Location = new System.Drawing.Point(0, PanelHeight);

			CreateFieldControl();
			
			//AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			MaximizeBox = false;
			MinimumSize = new System.Drawing.Size(220, 100);
			Name = "MineWindow";
			StartPosition = FormStartPosition.CenterScreen;
			Text = "MineSweeper";
			Controls.Add(btnRestart);
			Controls.Add(btnSettings);
			Controls.Add(btnExit);
			Controls.Add(panel);

			ResumeLayout(false);
			PerformLayout();
		}

		private void BtnRestartHandleClick(object sender, EventArgs e) {
			model.Restart();
		}
		
		private void BtnSettingsHandleClick(object sender, EventArgs e) {
			using (SettingsWindow settingsWindow = new SettingsWindow()) {
				DialogResult result = settingsWindow.ShowDialog();
				if (result == System.Windows.Forms.DialogResult.OK) {
					CreateNewGame(settingsWindow.GetHeight(), settingsWindow.GetWidth(),
                        settingsWindow.GetMines(), settingsWindow.UseMarks());
					CreateFieldControl();
				}
			}
		}
		
		private void BtnExitHandleClick(object sender, EventArgs e) {
			Close();
		}
		
		private void CreateNewGame(int rows, int columns, int minesCount, bool useMarks) {
			if (model != null) {
				model.Dispose();
			}
            MineModel.MarkStrategy markStrategy = null;
            if (useMarks) {
                markStrategy = new MineModel.QuestionStrategy();
            } else {
                markStrategy = new MineModel.MineStrategy();
            }
			model = new MineModel.GameModel(rows, columns, minesCount, markStrategy, this);
			field = new WFField(model);
			controller = new MineView.Controller(model, field, new RectangleFactory());
		}
		
		private void CreateFieldControl() {
			if (fieldControl != null) {
				panel.Controls.Remove(fieldControl);
				fieldControl.Dispose();
			}
			fieldControl = new FieldControl(field);
			fieldControl.Location = new System.Drawing.Point(0, 0);
			fieldControl.ClientSize = new System.Drawing.Size(field.Width, field.Height);
			panel.Controls.Add(fieldControl);
			panel.ClientSize = new System.Drawing.Size(field.Width, field.Height);
            ClientSize = new System.Drawing.Size(field.Width, PanelHeight + field.Height);
		}
		
		protected override void Dispose(bool disposing) {
			if (disposing) {
				model.Dispose();
			}
			base.Dispose(disposing);
		}

		public MineWindow() {
			InitializeComponent();
		}
	}
}
