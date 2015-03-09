using System;
using System.Windows.Forms;

namespace MineSweeper {
	public class MineWindow : Form {
		private MineModel.GameModel model;
		private MineView.Controller controller;
		private WFField field;
		private FieldControl fieldControl;
		private System.Windows.Forms.Button btnRestart;
		private System.Windows.Forms.Button btnSettings;
		private System.Windows.Forms.Button btnExit;
		private System.Windows.Forms.Panel panel;

		private void InitializeComponent() {
			CreateNewGame(16, 30, 99);

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
			panel.Location = new System.Drawing.Point(0, 36);

			CreateFieldControl();
			//fieldControl = new FieldControl(field);
			//fieldControl.Dock = DockStyle.Fill;
			//fieldControl.Location = new System.Drawing.Point(0, 36);
			//fieldControl.Size = new System.Drawing.Size(field.Width, field.Height);
			
			AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			MaximizeBox = false;
			MinimumSize = new System.Drawing.Size(204, 100);
			Name = "MineWindow";
			StartPosition = FormStartPosition.CenterScreen;
			Text = "MineSweeper";
			Controls.Add(btnRestart);
			Controls.Add(btnSettings);
			Controls.Add(btnExit);
			Controls.Add(panel);
			//Controls.Add(fieldControl);

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
					CreateNewGame(settingsWindow.GetHeight(),
					              settingsWindow.GetWidth(), settingsWindow.GetMines());
					CreateFieldControl();
				}
			}
		}
		
		private void BtnExitHandleClick(object sender, EventArgs e) {
			Close();
		}
		
		private void CreateNewGame(int rows, int columns, int minesCount) {
			if (model != null) {
				model.Dispose();
			}
			model = new MineModel.GameModel(rows, columns, minesCount, this);
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
			fieldControl.Size = new System.Drawing.Size(field.Width, field.Height);
			panel.Controls.Add(fieldControl);
			panel.Size = new System.Drawing.Size(field.Width, field.Height);
			Size = new System.Drawing.Size(field.Width, 36 + field.Height + 50);
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
