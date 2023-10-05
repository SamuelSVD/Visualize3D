using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Visualize3D.Models {
	public class PointModel{
		[XmlAttribute]
		public float X { get; set; } = 0;
		[XmlAttribute]
		public float Y { get; set; } = 0;
		[XmlAttribute]
		public float Z { get; set; } = 0;
	}
}
