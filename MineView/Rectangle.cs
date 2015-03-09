using System;

namespace MineView {
	public struct Rectangle {
		public int X { get; set; }
		public int Y { get; set; }
		public int Width { get; set; }
		public int Height { get; set; }

		public Rectangle(int x, int y, int width, int height) : this() {
			this.X = x;
			this.Y = y;
			this.Width = width;
			this.Height = height;
		}
		
		public bool IntersectsWith(Rectangle other) {
			return X <= (other.X + other.Width)
					&& (X + Width) >= other.X
					&& Y <= (other.Y + other.Height)
					&& (Y + Height) >= other.Y;
		}

		public static bool operator ==(Rectangle left, Rectangle right) {
			return left.X == right.X && left.Y == right.Y
				&& left.Width == right.Width && left.Height == right.Height;
		}
		public static bool operator !=(Rectangle left, Rectangle right) {
			return !(left == right);
		}
		
		public override bool Equals(object obj) {
			if (obj is Rectangle) {
				return this == (Rectangle)obj;
			} else {
				return false;
			}
		}
		
		public override int GetHashCode() {
			return unchecked(X + Y + Width + Height);
		}
	}
}
