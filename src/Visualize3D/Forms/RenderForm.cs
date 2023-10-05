using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using Visualize3D.Models;
using Visualize3D.Models.Drawable;
using Visualize3D.Utils;

namespace Visualize3D {

	public partial class RenderForm : Form {
		public UserControl Control {
			get {
				return _glControl;
			}
		}
		public Visualize3DModel Model;
		private DrawablePointModel? _selectedPoint;
		public DrawablePointModel? SelectedPoint {
			get {
				return _selectedPoint;
			}
			set {
				_selectedPoint = value;
				if (SelectedPointChanged != null) {
					SelectedPointChanged(this, EventArgs.Empty);
				}
			}
		}
		public DrawableRectangularPrismModel? _selectedBox;
		public DrawableRectangularPrismModel? SelectedBox {
			get {
				return _selectedBox;
			}
			set {
				_selectedBox = value;
				if (SelectedBoxChanged != null) {
					SelectedBoxChanged(this, EventArgs.Empty);
				}
			}
		}
		GLControl _glControl = new GLControl();
		public RenderForm(Visualize3DModel model) {
			InitializeComponent();
			_glControl.Load += glControl_Load;
			Model = model;
		}
		public void Render() {
			glControl_Paint(this, null);
		}
		private void glControl_Load(object? sender, EventArgs e) {
			_glControl.Dock = DockStyle.Fill;
			_glControl.Paint += glControl_Paint;
			_glControl.Resize += _glControl_Resize;
			_glControl_Resize(null, null);
		}

		private void _glControl_Resize(object? sender, EventArgs e) {
			GL.Viewport(0, 0, _glControl.Size.Width, _glControl.Size.Height);
		}

		float _angle = 0;
		private void glControl_Paint(object? sender, PaintEventArgs e) {
			_glControl.MakeCurrent();
			GL.ClearColor(Color4.MidnightBlue);
			GL.Enable(EnableCap.DepthTest);

			//Vector3 cameraPosition = new Vector3(0f, 0f, 3f);
			//Vector3 cameraTarget = new Vector3();
			//Vector3 cameraDirection = Vector3.Normalize(cameraPosition - cameraTarget);
			//Vector3 up = Vector3.UnitY;
			//Vector3 cameraRight = Vector3.Normalize(Vector3.Cross(up, cameraDirection));
			//Vector3 cameraUp = Vector3.Cross(cameraDirection, cameraRight);
			//Matrix4 lookat = Matrix4.LookAt(0, 0, 5, 0, 0, 0, 0, 0, 1);
			//lookat = Matrix4.LookAt(cameraPosition, cameraTarget, cameraUp);
			//GL.MatrixMode(MatrixMode.Modelview);
			//GL.LoadMatrix(ref lookat);

			//GL.Rotate(_angle, 0.0f, 1.0f, 0.0f);
			//_angle += 0.01f;
			GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
			GLHelper.Fill(Color.Red);
			if (SelectedPoint != null) {
				GLHelper.Rect(SelectedPoint.X - 0.1f, SelectedPoint.Y - 0.1f, SelectedPoint.X + 0.1f, SelectedPoint.Y + 0.1f);
			}
			GL.Flush();
			_glControl.SwapBuffers();
		}
		public void Draw() {
			DrawAllBoxes();
			DrawAllLines();
			DrawAllPoints();
		}

		private void DrawAllLines() {
			throw new NotImplementedException();
		}

		private void DrawAllBoxes() {
			throw new NotImplementedException();
		}

		public void DrawAllPoints() {
			for (int i = 0; i < Model.Points.Count(); i++) {
				DrawablePointModel pm = Model.Points[i];
				Fill(pm.DisplayProperties.Colour);
				DrawSphere(pm.X, pm.Y, pm.Z, 10);
			}
		}

		private void DrawSphere(double x, double y, double z, double radius) {
			throw new NotImplementedException();
		}

		private void Fill(ColourModel selectedColour) {
			throw new NotImplementedException();
		}
	}
}
