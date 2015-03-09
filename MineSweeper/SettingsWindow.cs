using System;
using System.Windows.Forms;

namespace MineSweeper {
	public class SettingsWindow : Form {
		private System.Windows.Forms.Button btnOk;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Label lblHeight;
		private System.Windows.Forms.Label lblWidth;
		private System.Windows.Forms.Label lblMines;
		private System.Windows.Forms.Label lblBeginnerHeight;
		private System.Windows.Forms.Label lblBeginnerWidth;
		private System.Windows.Forms.Label lblBeginnerMines;
		private System.Windows.Forms.Label lblIntermediateHeight;
		private System.Windows.Forms.Label lblIntermediateWidth;
		private System.Windows.Forms.Label lblIntermediateMines;
		private System.Windows.Forms.Label lblExpertHeight;
		private System.Windows.Forms.Label lblExpertWidth;
		private System.Windows.Forms.Label lblExpertMines;
		private System.Windows.Forms.RadioButton rbBeginner;
		private System.Windows.Forms.RadioButton rbIntermediate;
		private System.Windows.Forms.RadioButton rbExpert;
		private System.Windows.Forms.RadioButton rbCustom;
		private System.Windows.Forms.TextBox txtCustomHeight;
		private System.Windows.Forms.TextBox txtCustomWidth;
		private System.Windows.Forms.TextBox txtCustomMines;

		private void InitializeComponent() {
			SuspendLayout();
			
			lblHeight = new System.Windows.Forms.Label();
			lblHeight.Location = new System.Drawing.Point(100, 0);
			lblHeight.Size = new System.Drawing.Size(60, 24);
			lblHeight.Text = "Height";

			lblWidth = new System.Windows.Forms.Label();
			lblWidth.Location = new System.Drawing.Point(166, 0);
			lblWidth.Size = new System.Drawing.Size(60, 24);
			lblWidth.Text = "Width";

			lblMines = new System.Windows.Forms.Label();
			lblMines.Location = new System.Drawing.Point(232, 0);
			lblMines.Size = new System.Drawing.Size(60, 24);
			lblMines.Text = "Mines";

			lblBeginnerHeight = new System.Windows.Forms.Label();
			lblBeginnerHeight.Location = new System.Drawing.Point(100, 30);
			lblBeginnerHeight.Size = new System.Drawing.Size(60, 24);
			lblBeginnerHeight.Text = "9";

			lblBeginnerWidth = new System.Windows.Forms.Label();
			lblBeginnerWidth.Location = new System.Drawing.Point(166, 30);
			lblBeginnerWidth.Size = new System.Drawing.Size(60, 24);
			lblBeginnerWidth.Text = "9";

			lblBeginnerMines = new System.Windows.Forms.Label();
			lblBeginnerMines.Location = new System.Drawing.Point(232, 30);
			lblBeginnerMines.Size = new System.Drawing.Size(60, 24);
			lblBeginnerMines.Text = "10";

			lblIntermediateHeight = new System.Windows.Forms.Label();
			lblIntermediateHeight.Location = new System.Drawing.Point(100, 60);
			lblIntermediateHeight.Size = new System.Drawing.Size(60, 24);
			lblIntermediateHeight.Text = "16";

			lblIntermediateWidth = new System.Windows.Forms.Label();
			lblIntermediateWidth.Location = new System.Drawing.Point(166, 60);
			lblIntermediateWidth.Size = new System.Drawing.Size(60, 24);
			lblIntermediateWidth.Text = "16";

			lblIntermediateMines = new System.Windows.Forms.Label();
			lblIntermediateMines.Location = new System.Drawing.Point(232, 60);
			lblIntermediateMines.Size = new System.Drawing.Size(60, 24);
			lblIntermediateMines.Text = "40";

			lblExpertHeight = new System.Windows.Forms.Label();
			lblExpertHeight.Location = new System.Drawing.Point(100, 90);
			lblExpertHeight.Size = new System.Drawing.Size(60, 24);
			lblExpertHeight.Text = "16";

			lblExpertWidth = new System.Windows.Forms.Label();
			lblExpertWidth.Location = new System.Drawing.Point(166, 90);
			lblExpertWidth.Size = new System.Drawing.Size(60, 24);
			lblExpertWidth.Text = "30";

			lblExpertMines = new System.Windows.Forms.Label();
			lblExpertMines.Location = new System.Drawing.Point(232, 90);
			lblExpertMines.Size = new System.Drawing.Size(60, 24);
			lblExpertMines.Text = "99";
			
			rbBeginner = new System.Windows.Forms.RadioButton();
			rbBeginner.Location = new System.Drawing.Point(6, 26);
			rbBeginner.Size = new System.Drawing.Size(80, 24);
			rbBeginner.Checked = false;
			rbBeginner.Text = "Beginner";
			
			rbIntermediate = new System.Windows.Forms.RadioButton();
			rbIntermediate.Location = new System.Drawing.Point(6, 56);
			rbIntermediate.Size = new System.Drawing.Size(80, 24);
			rbIntermediate.Checked = false;
			rbIntermediate.Text = "Intermediate";
			
			rbExpert = new System.Windows.Forms.RadioButton();
			rbExpert.Location = new System.Drawing.Point(6, 86);
			rbExpert.Size = new System.Drawing.Size(80, 24);
			rbExpert.Checked = true;
			rbExpert.Text = "Expert";

			rbCustom = new System.Windows.Forms.RadioButton();
			rbCustom.Location = new System.Drawing.Point(6, 116);
			rbCustom.Size = new System.Drawing.Size(80, 24);
			rbCustom.Checked = false;
			rbCustom.Text = "Custom";

			txtCustomHeight = new System.Windows.Forms.TextBox();
			txtCustomHeight.Location = new System.Drawing.Point(100, 120);
			txtCustomHeight.Size = new System.Drawing.Size(60, 24);
			txtCustomHeight.Text = "20";

			txtCustomWidth = new System.Windows.Forms.TextBox();
			txtCustomWidth.Location = new System.Drawing.Point(166, 120);
			txtCustomWidth.Size = new System.Drawing.Size(60, 24);
			txtCustomWidth.Text = "30";

			txtCustomMines = new System.Windows.Forms.TextBox();
			txtCustomMines.Location = new System.Drawing.Point(232, 120);
			txtCustomMines.Size = new System.Drawing.Size(60, 24);
			txtCustomMines.Text = "145";
			
			btnOk = new System.Windows.Forms.Button();
			btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
			btnOk.Location = new System.Drawing.Point(6, 206);
			btnOk.Size = new System.Drawing.Size(60, 24);
			btnOk.Text = "Ok";

			btnCancel = new System.Windows.Forms.Button();
			btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			btnCancel.Location = new System.Drawing.Point(72, 206);
			btnCancel.Size = new System.Drawing.Size(60, 24);
			btnCancel.Text = "Cancel";

			AcceptButton = btnOk;
			CancelButton = btnCancel;
			AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			MaximizeBox = false;
			Name = "MineSettings";
			StartPosition = FormStartPosition.CenterParent;
			Size = new System.Drawing.Size(300, 300);
			Text = "MineSweeper Settings";
			Controls.Add(lblHeight);
			Controls.Add(lblWidth);
			Controls.Add(lblMines);
			Controls.Add(lblBeginnerHeight);
			Controls.Add(lblBeginnerWidth);
			Controls.Add(lblBeginnerMines);
			Controls.Add(lblIntermediateHeight);
			Controls.Add(lblIntermediateWidth);
			Controls.Add(lblIntermediateMines);
			Controls.Add(lblExpertHeight);
			Controls.Add(lblExpertWidth);
			Controls.Add(lblExpertMines);
			Controls.Add(rbBeginner);
			Controls.Add(rbIntermediate);
			Controls.Add(rbExpert);
			Controls.Add(rbCustom);
			Controls.Add(txtCustomHeight);
			Controls.Add(txtCustomWidth);
			Controls.Add(txtCustomMines);
			Controls.Add(btnOk);
			Controls.Add(btnCancel);
			
			ResumeLayout(false);
			PerformLayout();
		}

		public SettingsWindow() {
			InitializeComponent();
		}
		
		public int GetHeight() {
			if (rbBeginner.Checked) {
				return 9;
			}
			if (rbIntermediate.Checked) {
				return 16;
			}
			if (rbExpert.Checked) {
				return 16;
			}
			return 0;
		}
		
		public int GetWidth() {
			if (rbBeginner.Checked) {
				return 9;
			}
			if (rbIntermediate.Checked) {
				return 16;
			}
			if (rbExpert.Checked) {
				return 30;
			}
			return 0;
		}
		
		public int GetMines() {
			if (rbBeginner.Checked) {
				return 10;
			}
			if (rbIntermediate.Checked) {
				return 40;
			}
			if (rbExpert.Checked) {
				return 99;
			}
			return 0;
		}
	}
}

