using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Visualize3D.Models {
	public class RectangularPrismModel : RectangleModel {
		[XmlAttribute]
		public double LengthZ { get; set; } = 0;
	}
}
