/*
 * Created by SharpDevelop.
 * User: Admin
 * Date: 16.02.2020
 * Time: 9:00
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace MW.Forms
{
	partial class frmEditDirectory
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.SuspendLayout();
			// 
			// frmEditDirectory
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(434, 303);
			this.Name = "frmEditDirectory";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Справочник";
			this.ResumeLayout(false);
		}
	}
}
