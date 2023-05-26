using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Visualize3D.Models {
	public class ColourModel {
		[XmlAttribute]
		public double Red { get; set; } = 0;
		[XmlAttribute]
		public double Green { get; set; } = 0;
		[XmlAttribute]
		public double Blue { get; set; } = 0;
		[XmlAttribute]
		public double Alpha { get; set; } = 0;
	}
}
