using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Visualize3D.Models {
	public class RectangleModel {
		public OrientationModel Orientation { get; set; } = new OrientationModel();
		public PointModel Origin { get; set; } = new PointModel();
		[XmlAttribute]
		public double LengthX { get; set; } = 0;
		[XmlAttribute]
		public double LengthY { get; set; } = 0;
	}
}
