using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visualize3D.Models {
	public class RectangleModel {
		public OrientationModel Orientation { get; set; } = new OrientationModel();
		public PointModel Origin { get; set; } = new PointModel();
		public double LengthX { get; set; } = 0;
		public double LengthY { get; set; } = 0;
	}
}
