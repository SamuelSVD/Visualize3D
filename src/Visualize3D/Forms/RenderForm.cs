using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Visualize3D.Models;
using Visualize3D.Models.Drawable;

namespace Visualize3D {

	public partial class RenderForm : Form {
		public Visualize3DModel Model;
		private DrawablePointModel? _selectedPoint;
		public DrawablePointModel? SelectedPoint {
			get {
				return _selectedPoint;
			}
			set {
				_selectedPoint= value;
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
		public RenderForm(Visualize3DModel model) {
			InitializeComponent();
			Model = model;
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
