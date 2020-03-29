namespace MW
{
	public partial class FrmMainForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMainForm));
			this.MWMenu = new System.Windows.Forms.MenuStrip();
			this.Finance = new System.Windows.Forms.ToolStripMenuItem();
			this.GKH = new System.Windows.Forms.ToolStripMenuItem();
			this.MWMenu.SuspendLayout();
			this.SuspendLayout();
			// 
			// MWMenu
			// 
			this.MWMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.Finance,
									this.GKH});
			this.MWMenu.Location = new System.Drawing.Point(0, 0);
			this.MWMenu.Name = "MWMenu";
			this.MWMenu.Size = new System.Drawing.Size(1274, 24);
			this.MWMenu.TabIndex = 0;
			// 
			// Finance
			// 
			this.Finance.Image = ((System.Drawing.Image)(resources.GetObject("Finance.Image")));
			this.Finance.Name = "Finance";
			this.Finance.Size = new System.Drawing.Size(86, 20);
			this.Finance.Text = "Финансы";
			this.Finance.Click += new System.EventHandler(this.FinanceClick);
			// 
			// GKH
			// 
			this.GKH.Image = ((System.Drawing.Image)(resources.GetObject("GKH.Image")));
			this.GKH.Name = "GKH";
			this.GKH.Size = new System.Drawing.Size(60, 20);
			this.GKH.Text = "ЖКХ";
			this.GKH.Click += new System.EventHandler(this.GKHClick);
			// 
			// FrmMainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1274, 721);
			this.Controls.Add(this.MWMenu);
			this.HelpButton = true;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.IsMdiContainer = true;
			this.MainMenuStrip = this.MWMenu;
			this.Name = "FrmMainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Вики";
			this.MWMenu.ResumeLayout(false);
			this.MWMenu.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.ToolStripMenuItem Finance;
		private System.Windows.Forms.ToolStripMenuItem GKH;
		private System.Windows.Forms.MenuStrip MWMenu;
	}
}
