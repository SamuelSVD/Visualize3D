﻿using Visualize3D.Interfaces;

namespace Visualize3D.Models.Drawable {
	public class DrawablePointModel : PointModel, IDrawable {
		public DisplayPropertiesModel DisplayProperties { get; set; } = new DisplayPropertiesModel();
	}
}
