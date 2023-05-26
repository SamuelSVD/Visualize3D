using System.Xml.Serialization;

namespace Visualize3D.Models {
	public class OrientationModel {
		[XmlAttribute]
		public double RotationX { get; set; } = 0;
		[XmlAttribute]
		public double RotationY { get; set; } = 0;
		[XmlAttribute]
		public double RotationZ { get; set; } = 0;
	}
}