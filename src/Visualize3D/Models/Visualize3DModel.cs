using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Visualize3D.Models.Drawable;

namespace Visualize3D.Models {
	public class Visualize3DModel {
		public List<DrawablePointModel> Points { get; set; } = new List<DrawablePointModel>();
		public List<DrawableRectangularPrismModel> Boxes { get; set; } = new List<DrawableRectangularPrismModel>();

		[XmlAttribute]
		public string ProjectName { get; set; } = string.Empty;
	}
}
