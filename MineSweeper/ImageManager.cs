using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Reflection;
using MineView;

namespace MineSweeper {
	public static class ImageManager {
		private static Dictionary<ImageId, Image> images = new Dictionary<ImageId, Image>();

		public static Image GetImage(ImageId imageId) {
			if (images.Count == 0) {
				foreach (string id in Enum.GetNames(typeof(ImageId))) {
					using (Stream stream = Assembly.GetAssembly(typeof(ImageId)).GetManifestResourceStream(id)) {
						images.Add((ImageId)Enum.Parse(typeof(ImageId), id), Image.FromStream(stream));
					}
				}
			}
			
			return images[imageId];
		}
	}
}
