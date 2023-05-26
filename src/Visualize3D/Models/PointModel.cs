using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Visualize3D.Models {
	public class PointModel{
		[XmlAttribute]
		public double X { get; set; } = 0;
		[XmlAttribute]
		public double Y { get; set; } = 0;
		[XmlAttribute]
		public double Z { get; set; } = 0;
	}
}
