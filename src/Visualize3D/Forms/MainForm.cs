using Visualize3D.Models;

namespace Visualize3D.Forms
{
    public partial class MainForm : Form
    {
		private RenderForm _renderForm;
		public Visualize3DModel Model;
		public MainForm()
        {
            InitializeComponent();
			Model = new Visualize3DModel();
			_renderForm = new RenderForm(Model);
			splitContainer1.Panel2.Controls.Add(_renderForm.GLControl);
        }
    }
}