using System;

namespace MineModel {
	public class CounterModel {
		private int value;
		
		public int Value {
			get { return value; }
			internal set {
				if (value < 0) {
					value = 0;
				}
				if (value > 999) {
					value = 999;
				}
				
				if (this.value == value) {
					return;
				}
				this.value = value;
				OnValueChanged(EventArgs.Empty);
			}
		}

		public event EventHandler<EventArgs> ValueChanged;
		
		protected virtual void OnValueChanged(EventArgs e) {
			if (ValueChanged != null) {
				ValueChanged(this, e);
			}
		}
		
		public CounterModel(int value) {
			Value = value;
		}
		
		public int GetDigit1() {
			return Value / 100;
		}
		
		public int GetDigit2() {
			return (Value % 100) / 10;
		}
		
		public int GetDigit3() {
			return Value % 10;
		}
	}
}
