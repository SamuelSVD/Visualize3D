using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visualize3D.Utils {
	internal class GLHelper {
		public static void Fill(Color color) {
			GL.Color3(color);
		}
		public static void Rect(float x1, float y1, float x2, float y2) {
			GL.Begin(PrimitiveType.Polygon);
			//GL.Vertex2(0f, 0f);
			//GL.Vertex2(1f, 1f);
			//GL.Vertex2(-1f, 1f);
			//GL.Vertex2(-10f, -10f);
			//GL.Vertex2(10f, -10f);
			//GL.Vertex2(10f, 10f);
			//GL.Vertex2(-10f, 10f);
			GL.Vertex2(x1, y1);
			GL.Vertex2(x2, y1);
			GL.Vertex2(x2, y2);
			GL.Vertex2(x1, y2);
			GL.End();
		}
	}
}
