using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Visualize3D.Models.Drawable;

namespace Visualize3D.Models {
	public class Visualize3DModel {
		public List<DrawablePointModel> Points { get; set; } = new List<DrawablePointModel>();
		public List<DrawableRectanglePrismModel> Boxes { get; set; } = new List<DrawableRectanglePrismModel>();
	}
}
