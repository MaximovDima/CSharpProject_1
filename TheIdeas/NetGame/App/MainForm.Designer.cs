namespace NetGame
{
	partial class MainForm
	{
		private System.ComponentModel.IContainer components = null;
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			this.CtrlScene = new System.Windows.Forms.PictureBox();
			this.MainMenu = new System.Windows.Forms.MenuStrip();
			((System.ComponentModel.ISupportInitialize)(this.CtrlScene)).BeginInit();
			this.SuspendLayout();
			// 
			// CtrlScene
			// 
			this.CtrlScene.Dock = System.Windows.Forms.DockStyle.Fill;
			this.CtrlScene.Location = new System.Drawing.Point(0, 24);
			this.CtrlScene.Name = "CtrlScene";
			this.CtrlScene.Size = new System.Drawing.Size(762, 547);
			this.CtrlScene.TabIndex = 2;
			this.CtrlScene.TabStop = false;
			// 
			// MainMenu
			// 
			this.MainMenu.Location = new System.Drawing.Point(0, 0);
			this.MainMenu.Name = "MainMenu";
			this.MainMenu.Size = new System.Drawing.Size(762, 24);
			this.MainMenu.TabIndex = 4;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(762, 571);
			this.Controls.Add(this.CtrlScene);
			this.Controls.Add(this.MainMenu);
			this.IsMdiContainer = true;
			this.MainMenuStrip = this.MainMenu;
			this.Name = "MainForm";
			this.Text = "NetGame";
			this.Resize += new System.EventHandler(this.MainFormResize);
			((System.ComponentModel.ISupportInitialize)(this.CtrlScene)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.MenuStrip MainMenu;
		private System.Windows.Forms.PictureBox CtrlScene;
	}
}
