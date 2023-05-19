namespace Visualize3D {
	partial class RenderForm {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.GLControl = new System.Windows.Forms.Panel();
			this.label1 = new System.Windows.Forms.Label();
			this.GLControl.SuspendLayout();
			this.SuspendLayout();
			// 
			// GLControl
			// 
			this.GLControl.Controls.Add(this.label1);
			this.GLControl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.GLControl.Location = new System.Drawing.Point(0, 0);
			this.GLControl.Name = "GLControl";
			this.GLControl.Size = new System.Drawing.Size(800, 450);
			this.GLControl.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(326, 207);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(127, 15);
			this.label1.TabIndex = 0;
			this.label1.Text = "Replace this GLControl";
			// 
			// RenderForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.GLControl);
			this.Name = "RenderForm";
			this.Text = "RenderForm";
			this.GLControl.ResumeLayout(false);
			this.GLControl.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		public Panel GLControl;
		private Label label1;
	}
}