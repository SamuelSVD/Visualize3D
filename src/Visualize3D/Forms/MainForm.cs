using Visualize3D.Models;
using Visualize3D.Models.Drawable;

namespace Visualize3D.Forms {
	public partial class MainForm : Form {
		private RenderForm? _renderForm;
		Visualize3DModel Model {
			get {
				if (ProgramData.Instance == null) {
					ProgramData.Instance = new Visualize3DModel();
				}
				return ProgramData.Instance;
			}
		}
		DrawablePointModel? SelectedPoint {
			get {
				if (_renderForm != null) return _renderForm.SelectedPoint;
				return null;
			}
		}
		DrawableRectangularPrismModel? SelectedBox {
			get {
				if (_renderForm != null) return _renderForm.SelectedBox;
				return null;
			}
		}
		public MainForm() {
			InitializeComponent();
			InitializeForm();
		}
		public void InitializeForm() {
			if (_renderForm != null) {
				splitContainer1.Panel2.Controls.Remove(_renderForm.Control);
				_renderForm.Dispose();
			}
			_renderForm = new RenderForm(Model);
			splitContainer1.Panel2.Controls.Add(_renderForm.Control);
			_renderForm.SelectedBoxChanged += _renderForm_SelectedBoxChanged;
			_renderForm.SelectedPointChanged += _renderForm_SelectedPointChanged;
			UpdateFormText();
		}
		private void newToolStripMenuItem_Click(object sender, EventArgs e) {
			if (ProgramData.Changed) {
				switch (MessageBox.Show("Unsaved changes. Would you like to save before starting a new project?", "Unsaved Changes", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning)) {
					case DialogResult.Yes:
						if (!ProgramData.SaveConfig()) {
							return;
						}
						break;
					case DialogResult.No:
						break;
					default:
						return;
				}
			}
			ProgramData.Instance = new Visualize3DModel();
			ProgramData.Changed = false;
			ProgramData.ValidConfigLocation = false;
			ProgramData.ShouldBeValidConfigLocation = false;
			InitializeForm();
		}
		private void openToolStripMenuItem_Click(object sender, EventArgs e) {
			if (ProgramData.Changed) {
				DialogResult result = MessageBox.Show("Unsaved changes. Would you like to save before opening a different project?", "Unsaved Changes", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
				if (result == DialogResult.Yes) {
					ProgramData.SaveConfig();
					if (ProgramData.Changed) {
						return;
					}
				} else if (result == DialogResult.No) {
				} else {
					return;
				}
			}
			ProgramData.OpenConfig();
			if (ProgramData.Instance == null) {
				if (ProgramData.InvalidFile) {
					MessageBox.Show($"Unable to open {ProgramData.CONFIG}. The file may be corrupted.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				ProgramData.Instance = new Visualize3DModel();
			}
			InitializeForm();
		}
		private void saveToolStripMenuItem_Click(object sender, EventArgs e) {
			ProgramData.SaveConfig();
			UpdateFormText();
		}
		private void saveAsToolStripMenuItem_Click(object sender, EventArgs e) {
			ProgramData.SaveConfigAs();
			UpdateFormText();
		}
		public void UpdateFormText() {
			Text = "Visualize3D - ";
			Text += (ProgramData.Instance == null) || string.IsNullOrEmpty(ProgramData.Instance.ProjectName) ? "Untitled Project" : ProgramData.Instance.ProjectName;
			Text += ProgramData.Changed ? "*" : string.Empty;
		}
		private void AddPointButton_Click(object sender, EventArgs e) {
			float x = 0, y = 0, z = 0;
			if (!TryGetValue(ref x, PointXTextBox.Text)) {
				MessageBox.Show("Invalid X Value");
				return;
			}
			if (!TryGetValue(ref y, PointYTextBox.Text)) {
				MessageBox.Show("Invalid Y Value");
				return;
			}
			if (!TryGetValue(ref z, PointZTextBox.Text)) {
				MessageBox.Show("Invalid Z Value");
				return;
			}
			DrawablePointModel pointModel = new DrawablePointModel()
			{
				X = x,
				Y = y,
				Z = z
			};
			Model.Points.Add(pointModel);
			if (_renderForm != null) {
				_renderForm.SelectedPoint = pointModel;
			}
			ProgramData.Changed = true;
			UpdateFormText();
			if (_renderForm != null) {
				_renderForm.Render();
			}
		}
		private void UpdatePointButton_Click(object sender, EventArgs e) {
			if (SelectedPoint != null) {
				float x = 0, y = 0, z = 0;
				if (!TryGetValue(ref x, SelectedPointXTextBox.Text)) {
					MessageBox.Show("Invalid X Value");
					return;
				}
				if (!TryGetValue(ref y, SelectedPointYTextBox.Text)) {
					MessageBox.Show("Invalid Y Value");
					return;
				}
				if (!TryGetValue(ref z, SelectedPointZTextBox.Text)) {
					MessageBox.Show("Invalid Z Value");
					return;
				}
				SelectedPoint.X = x;
				SelectedPoint.Y = y;
				SelectedPoint.Z = z;
				ProgramData.Changed = true;
				UpdateFormText();
			}
			if (_renderForm != null) {
				_renderForm.Render();
			}
		}
		private void _renderForm_SelectedBoxChanged(object? sender, EventArgs e) {
			if (SelectedBox != null) {
				SelectedBoxXTextBox.Text = SelectedBox.Origin.X.ToString();
				SelectedBoxYTextBox.Text = SelectedBox.Origin.Y.ToString();
				SelectedBoxZTextBox.Text = SelectedBox.Origin.Z.ToString();
				SelectedBoxLenXTextBox.Text = SelectedBox.LengthX.ToString();
				SelectedBoxLenYTextBox.Text = SelectedBox.LengthY.ToString();
				SelectedBoxLenZTextBox.Text = SelectedBox.LengthZ.ToString();
				SelectedBoxAngXTextBox.Text = SelectedBox.Orientation.RotationX.ToString();
				SelectedBoxAngYTextBox.Text = SelectedBox.Orientation.RotationY.ToString();
				SelectedBoxAngZTextBox.Text = SelectedBox.Orientation.RotationZ.ToString();
				SelectedBoxGroupBox.Enabled = true;
			} else {
				SelectedBoxXTextBox.Text = 0.ToString();
				SelectedBoxYTextBox.Text = 0.ToString();
				SelectedBoxZTextBox.Text = 0.ToString();
				SelectedBoxLenXTextBox.Text = 0.ToString();
				SelectedBoxLenYTextBox.Text = 0.ToString();
				SelectedBoxLenZTextBox.Text = 0.ToString();
				SelectedBoxAngXTextBox.Text = 0.ToString();
				SelectedBoxAngYTextBox.Text = 0.ToString();
				SelectedBoxAngZTextBox.Text = 0.ToString();
				SelectedBoxGroupBox.Enabled = false;
			}
		}
		private void _renderForm_SelectedPointChanged(object? sender, EventArgs e) {
			if (SelectedPoint != null) {
				SelectedPointXTextBox.Text = SelectedPoint.X.ToString();
				SelectedPointYTextBox.Text = SelectedPoint.Y.ToString();
				SelectedPointZTextBox.Text = SelectedPoint.Z.ToString();
				SelectedPointGroupBox.Enabled = true;
			} else {
				SelectedPointXTextBox.Text = 0.ToString();
				SelectedPointYTextBox.Text = 0.ToString();
				SelectedPointZTextBox.Text = 0.ToString();
				SelectedPointGroupBox.Enabled = false;
			}
		}
		private void AddBoxButton_Click(object sender, EventArgs e) {
			float x = 0, y = 0, z = 0, lx = 0, ly = 0, lz = 0, rx = 0, ry = 0, rz = 0;
			if (!TryGetValue(ref x, BoxXTextBox.Text)) {
				MessageBox.Show("Invalid X Value");
				return;
			}
			if (!TryGetValue(ref y, BoxYTextBox.Text)) {
				MessageBox.Show("Invalid Y Value");
				return;
			}
			if (!TryGetValue(ref z, BoxZTextBox.Text)) {
				MessageBox.Show("Invalid Z Value");
				return;
			}
			if (!TryGetValue(ref lx, BoxLenXTextBox.Text)) {
				MessageBox.Show("Invalid LenX Value");
				return;
			}
			if (!TryGetValue(ref ly, BoxLenYTextBox.Text)) {
				MessageBox.Show("Invalid LenY Value");
				return;
			}
			if (!TryGetValue(ref lz, BoxLenZTextBox.Text)) {
				MessageBox.Show("Invalid LenZ Value");
				return;
			}
			if (!TryGetValue(ref rx, BoxAngXTextBox.Text)) {
				MessageBox.Show("Invalid AngX Value");
				return;
			}
			if (!TryGetValue(ref ry, BoxAngYTextBox.Text)) {
				MessageBox.Show("Invalid AngY Value");
				return;
			}
			if (!TryGetValue(ref rz, BoxAngZTextBox.Text)) {
				MessageBox.Show("Invalid AngZ Value");
				return;
			}
			DrawableRectangularPrismModel prismModel = new DrawableRectangularPrismModel();
			prismModel.Origin.X = x;
			prismModel.Origin.Y = y;
			prismModel.Origin.Z = z;
			prismModel.LengthX = lx;
			prismModel.LengthY = ly;
			prismModel.LengthZ = lz;
			prismModel.Orientation.RotationX = rx;
			prismModel.Orientation.RotationY = ry;
			prismModel.Orientation.RotationZ = rz;
			Model.Boxes.Add(prismModel);
			if (_renderForm != null) {
				_renderForm.SelectedBox = prismModel;
			}
			ProgramData.Changed = true;
			UpdateFormText();
		}
		private void UpdateBoxButton_Click(object sender, EventArgs e) {
			if (SelectedBox != null) {
				float x = 0, y = 0, z = 0, lx = 0, ly = 0, lz = 0, rx = 0, ry = 0, rz = 0;
				if (!TryGetValue(ref x, BoxXTextBox.Text)) {
					MessageBox.Show("Invalid X Value");
					return;
				}
				if (!TryGetValue(ref y, BoxYTextBox.Text)) {
					MessageBox.Show("Invalid Y Value");
					return;
				}
				if (!TryGetValue(ref z, BoxZTextBox.Text)) {
					MessageBox.Show("Invalid Z Value");
					return;
				}
				if (!TryGetValue(ref lx, BoxLenXTextBox.Text)) {
					MessageBox.Show("Invalid LenX Value");
					return;
				}
				if (!TryGetValue(ref ly, BoxLenYTextBox.Text)) {
					MessageBox.Show("Invalid LenY Value");
					return;
				}
				if (!TryGetValue(ref lz, BoxLenZTextBox.Text)) {
					MessageBox.Show("Invalid LenZ Value");
					return;
				}
				if (!TryGetValue(ref rx, BoxAngXTextBox.Text)) {
					MessageBox.Show("Invalid AngX Value");
					return;
				}
				if (!TryGetValue(ref ry, BoxAngYTextBox.Text)) {
					MessageBox.Show("Invalid AngY Value");
					return;
				}
				if (!TryGetValue(ref rz, BoxAngZTextBox.Text)) {
					MessageBox.Show("Invalid AngZ Value");
					return;
				}
				SelectedBox.Origin.X = x;
				SelectedBox.Origin.Y = y;
				SelectedBox.Origin.Z = z;
				SelectedBox.LengthX = lx;
				SelectedBox.LengthY = ly;
				SelectedBox.LengthZ = lz;
				SelectedBox.Orientation.RotationX = rx;
				SelectedBox.Orientation.RotationY = ry;
				SelectedBox.Orientation.RotationZ = rz;
				ProgramData.Changed = true;
				UpdateFormText();
			}
		}
		private bool TryGetValue(ref float val, string text) {
			try {
				val = Convert.ToSingle(text);
				return true;
			}
			catch {
				return false;
			}
		}
	}
}