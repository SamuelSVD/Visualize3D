using Visualize3D.Interfaces;

namespace Visualize3D.Models.Drawable {
	public class DrawableRectanglePrismModel : RectangularPrismModel, IDrawable {
		public DisplayPropertiesModel DisplayProperties { get; set; } = new DisplayPropertiesModel();
	}
}
