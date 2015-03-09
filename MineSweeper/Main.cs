using System;
using System.Windows.Forms;

namespace MineSweeper {
	class MainClass {
		public static void Main(string[] args) {
			Application.ThreadException += HandleThreadException;
			Application.EnableVisualStyles();
			//Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new MineWindow());
		}

		static void HandleThreadException(object sender, System.Threading.ThreadExceptionEventArgs e) {
			string message = String.Format("Oops, something went wrong{0}{1}", Environment.NewLine, e.Exception.Message);
			MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}
	}
}
