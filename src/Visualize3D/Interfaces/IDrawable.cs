using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Visualize3D.Models;

namespace Visualize3D.Interfaces {
	public interface IDrawable {
		public DisplayPropertiesModel DisplayProperties { get; set; }
	}
}
