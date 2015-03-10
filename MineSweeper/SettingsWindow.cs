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
        private CheckBox chkMark;

		private void InitializeComponent() {
            this.lblHeight = new System.Windows.Forms.Label();
            this.lblWidth = new System.Windows.Forms.Label();
            this.lblMines = new System.Windows.Forms.Label();
            this.lblBeginnerHeight = new System.Windows.Forms.Label();
            this.lblBeginnerWidth = new System.Windows.Forms.Label();
            this.lblBeginnerMines = new System.Windows.Forms.Label();
            this.lblIntermediateHeight = new System.Windows.Forms.Label();
            this.lblIntermediateWidth = new System.Windows.Forms.Label();
            this.lblIntermediateMines = new System.Windows.Forms.Label();
            this.lblExpertHeight = new System.Windows.Forms.Label();
            this.lblExpertWidth = new System.Windows.Forms.Label();
            this.lblExpertMines = new System.Windows.Forms.Label();
            this.rbBeginner = new System.Windows.Forms.RadioButton();
            this.rbIntermediate = new System.Windows.Forms.RadioButton();
            this.rbExpert = new System.Windows.Forms.RadioButton();
            this.rbCustom = new System.Windows.Forms.RadioButton();
            this.txtCustomHeight = new System.Windows.Forms.TextBox();
            this.txtCustomWidth = new System.Windows.Forms.TextBox();
            this.txtCustomMines = new System.Windows.Forms.TextBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.chkMark = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // lblHeight
            // 
            this.lblHeight.Location = new System.Drawing.Point(120, 6);
            this.lblHeight.Name = "lblHeight";
            this.lblHeight.Size = new System.Drawing.Size(60, 24);
            this.lblHeight.TabIndex = 0;
            this.lblHeight.Text = "Height";
            this.lblHeight.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblWidth
            // 
            this.lblWidth.Location = new System.Drawing.Point(190, 6);
            this.lblWidth.Name = "lblWidth";
            this.lblWidth.Size = new System.Drawing.Size(60, 24);
            this.lblWidth.TabIndex = 1;
            this.lblWidth.Text = "Width";
            this.lblWidth.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblMines
            // 
            this.lblMines.Location = new System.Drawing.Point(260, 6);
            this.lblMines.Name = "lblMines";
            this.lblMines.Size = new System.Drawing.Size(60, 24);
            this.lblMines.TabIndex = 2;
            this.lblMines.Text = "Mines";
            this.lblMines.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblBeginnerHeight
            // 
            this.lblBeginnerHeight.Location = new System.Drawing.Point(120, 36);
            this.lblBeginnerHeight.Name = "lblBeginnerHeight";
            this.lblBeginnerHeight.Size = new System.Drawing.Size(60, 24);
            this.lblBeginnerHeight.TabIndex = 3;
            this.lblBeginnerHeight.Text = "9";
            this.lblBeginnerHeight.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblBeginnerWidth
            // 
            this.lblBeginnerWidth.Location = new System.Drawing.Point(190, 36);
            this.lblBeginnerWidth.Name = "lblBeginnerWidth";
            this.lblBeginnerWidth.Size = new System.Drawing.Size(60, 24);
            this.lblBeginnerWidth.TabIndex = 4;
            this.lblBeginnerWidth.Text = "9";
            this.lblBeginnerWidth.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblBeginnerMines
            // 
            this.lblBeginnerMines.Location = new System.Drawing.Point(260, 36);
            this.lblBeginnerMines.Name = "lblBeginnerMines";
            this.lblBeginnerMines.Size = new System.Drawing.Size(60, 24);
            this.lblBeginnerMines.TabIndex = 5;
            this.lblBeginnerMines.Text = "10";
            this.lblBeginnerMines.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblIntermediateHeight
            // 
            this.lblIntermediateHeight.Location = new System.Drawing.Point(120, 66);
            this.lblIntermediateHeight.Name = "lblIntermediateHeight";
            this.lblIntermediateHeight.Size = new System.Drawing.Size(60, 24);
            this.lblIntermediateHeight.TabIndex = 6;
            this.lblIntermediateHeight.Text = "16";
            this.lblIntermediateHeight.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblIntermediateWidth
            // 
            this.lblIntermediateWidth.Location = new System.Drawing.Point(190, 66);
            this.lblIntermediateWidth.Name = "lblIntermediateWidth";
            this.lblIntermediateWidth.Size = new System.Drawing.Size(60, 24);
            this.lblIntermediateWidth.TabIndex = 7;
            this.lblIntermediateWidth.Text = "16";
            this.lblIntermediateWidth.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblIntermediateMines
            // 
            this.lblIntermediateMines.Location = new System.Drawing.Point(260, 66);
            this.lblIntermediateMines.Name = "lblIntermediateMines";
            this.lblIntermediateMines.Size = new System.Drawing.Size(60, 24);
            this.lblIntermediateMines.TabIndex = 8;
            this.lblIntermediateMines.Text = "40";
            this.lblIntermediateMines.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblExpertHeight
            // 
            this.lblExpertHeight.Location = new System.Drawing.Point(120, 96);
            this.lblExpertHeight.Name = "lblExpertHeight";
            this.lblExpertHeight.Size = new System.Drawing.Size(60, 24);
            this.lblExpertHeight.TabIndex = 9;
            this.lblExpertHeight.Text = "16";
            this.lblExpertHeight.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblExpertWidth
            // 
            this.lblExpertWidth.Location = new System.Drawing.Point(190, 96);
            this.lblExpertWidth.Name = "lblExpertWidth";
            this.lblExpertWidth.Size = new System.Drawing.Size(60, 24);
            this.lblExpertWidth.TabIndex = 10;
            this.lblExpertWidth.Text = "30";
            this.lblExpertWidth.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblExpertMines
            // 
            this.lblExpertMines.Location = new System.Drawing.Point(260, 96);
            this.lblExpertMines.Name = "lblExpertMines";
            this.lblExpertMines.Size = new System.Drawing.Size(60, 24);
            this.lblExpertMines.TabIndex = 11;
            this.lblExpertMines.Text = "99";
            this.lblExpertMines.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rbBeginner
            // 
            this.rbBeginner.Location = new System.Drawing.Point(12, 36);
            this.rbBeginner.Name = "rbBeginner";
            this.rbBeginner.Size = new System.Drawing.Size(100, 24);
            this.rbBeginner.TabIndex = 12;
            this.rbBeginner.Text = "Beginner";
            // 
            // rbIntermediate
            // 
            this.rbIntermediate.Location = new System.Drawing.Point(12, 66);
            this.rbIntermediate.Name = "rbIntermediate";
            this.rbIntermediate.Size = new System.Drawing.Size(100, 24);
            this.rbIntermediate.TabIndex = 13;
            this.rbIntermediate.Text = "Intermediate";
            // 
            // rbExpert
            // 
            this.rbExpert.Checked = true;
            this.rbExpert.Location = new System.Drawing.Point(12, 96);
            this.rbExpert.Name = "rbExpert";
            this.rbExpert.Size = new System.Drawing.Size(100, 24);
            this.rbExpert.TabIndex = 14;
            this.rbExpert.TabStop = true;
            this.rbExpert.Text = "Expert";
            // 
            // rbCustom
            // 
            this.rbCustom.Location = new System.Drawing.Point(12, 126);
            this.rbCustom.Name = "rbCustom";
            this.rbCustom.Size = new System.Drawing.Size(80, 24);
            this.rbCustom.TabIndex = 15;
            this.rbCustom.Text = "Custom";
            // 
            // txtCustomHeight
            // 
            this.txtCustomHeight.Location = new System.Drawing.Point(120, 126);
            this.txtCustomHeight.Name = "txtCustomHeight";
            this.txtCustomHeight.Size = new System.Drawing.Size(60, 20);
            this.txtCustomHeight.TabIndex = 16;
            this.txtCustomHeight.Text = "20";
            // 
            // txtCustomWidth
            // 
            this.txtCustomWidth.Location = new System.Drawing.Point(190, 126);
            this.txtCustomWidth.Name = "txtCustomWidth";
            this.txtCustomWidth.Size = new System.Drawing.Size(60, 20);
            this.txtCustomWidth.TabIndex = 17;
            this.txtCustomWidth.Text = "30";
            // 
            // txtCustomMines
            // 
            this.txtCustomMines.Location = new System.Drawing.Point(260, 126);
            this.txtCustomMines.Name = "txtCustomMines";
            this.txtCustomMines.Size = new System.Drawing.Size(60, 20);
            this.txtCustomMines.TabIndex = 18;
            this.txtCustomMines.Text = "145";
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(190, 180);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(60, 24);
            this.btnOk.TabIndex = 19;
            this.btnOk.Text = "Ok";
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(260, 180);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(60, 24);
            this.btnCancel.TabIndex = 20;
            this.btnCancel.Text = "Cancel";
            // 
            // chkMark
            // 
            this.chkMark.AutoSize = true;
            this.chkMark.Location = new System.Drawing.Point(13, 157);
            this.chkMark.Name = "chkMark";
            this.chkMark.Size = new System.Drawing.Size(91, 17);
            this.chkMark.TabIndex = 21;
            this.chkMark.Text = "Use marks (?)";
            this.chkMark.UseVisualStyleBackColor = true;
            // 
            // SettingsWindow
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(334, 221);
            this.Controls.Add(this.chkMark);
            this.Controls.Add(this.lblHeight);
            this.Controls.Add(this.lblWidth);
            this.Controls.Add(this.lblMines);
            this.Controls.Add(this.lblBeginnerHeight);
            this.Controls.Add(this.lblBeginnerWidth);
            this.Controls.Add(this.lblBeginnerMines);
            this.Controls.Add(this.lblIntermediateHeight);
            this.Controls.Add(this.lblIntermediateWidth);
            this.Controls.Add(this.lblIntermediateMines);
            this.Controls.Add(this.lblExpertHeight);
            this.Controls.Add(this.lblExpertWidth);
            this.Controls.Add(this.lblExpertMines);
            this.Controls.Add(this.rbBeginner);
            this.Controls.Add(this.rbIntermediate);
            this.Controls.Add(this.rbExpert);
            this.Controls.Add(this.rbCustom);
            this.Controls.Add(this.txtCustomHeight);
            this.Controls.Add(this.txtCustomWidth);
            this.Controls.Add(this.txtCustomMines);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "SettingsWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "MineSweeper Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

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
            if (rbCustom.Checked) {
                int height = 0;
                Int32.TryParse(txtCustomHeight.Text, out height);
                return height;
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
            if (rbCustom.Checked) {
                int width = 0;
                Int32.TryParse(txtCustomWidth.Text, out width);
                return width;
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
            if (rbCustom.Checked) {
                int minesCount = 0;
                Int32.TryParse(txtCustomMines.Text, out minesCount);
                return minesCount;
            }
            return 0;
		}

        public bool UseMarks() {
            return chkMark.Checked;
        }
	}
}

