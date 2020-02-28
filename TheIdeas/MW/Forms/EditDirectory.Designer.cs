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
			this.eName = new System.Windows.Forms.TextBox();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnOk = new System.Windows.Forms.Button();
			this.eComment = new System.Windows.Forms.TextBox();
			this.lblName = new System.Windows.Forms.Label();
			this.lblComment = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// eName
			// 
			this.eName.Location = new System.Drawing.Point(118, 12);
			this.eName.Name = "eName";
			this.eName.Size = new System.Drawing.Size(304, 20);
			this.eName.TabIndex = 0;
			// 
			// btnCancel
			// 
			this.btnCancel.Location = new System.Drawing.Point(349, 69);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(74, 23);
			this.btnCancel.TabIndex = 19;
			this.btnCancel.Text = "Отмена";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.BtnCancelClick);
			// 
			// btnOk
			// 
			this.btnOk.Location = new System.Drawing.Point(258, 69);
			this.btnOk.Name = "btnOk";
			this.btnOk.Size = new System.Drawing.Size(74, 23);
			this.btnOk.TabIndex = 18;
			this.btnOk.Text = "Ок";
			this.btnOk.UseVisualStyleBackColor = true;
			this.btnOk.Click += new System.EventHandler(this.BtnOkClick);
			// 
			// eComment
			// 
			this.eComment.Location = new System.Drawing.Point(118, 43);
			this.eComment.Name = "eComment";
			this.eComment.Size = new System.Drawing.Size(304, 20);
			this.eComment.TabIndex = 20;
			// 
			// lblName
			// 
			this.lblName.Location = new System.Drawing.Point(12, 17);
			this.lblName.Name = "lblName";
			this.lblName.Size = new System.Drawing.Size(100, 17);
			this.lblName.TabIndex = 21;
			this.lblName.Text = "Наименование:";
			// 
			// lblComment
			// 
			this.lblComment.Location = new System.Drawing.Point(12, 43);
			this.lblComment.Name = "lblComment";
			this.lblComment.Size = new System.Drawing.Size(89, 15);
			this.lblComment.TabIndex = 22;
			this.lblComment.Text = "Комментарий:";
			// 
			// frmEditDirectory
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(434, 99);
			this.ControlBox = false;
			this.Controls.Add(this.lblComment);
			this.Controls.Add(this.lblName);
			this.Controls.Add(this.eComment);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOk);
			this.Controls.Add(this.eName);
			this.Name = "frmEditDirectory";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Справочник";
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.Label lblComment;
		private System.Windows.Forms.Label lblName;
		private System.Windows.Forms.TextBox eComment;
		private System.Windows.Forms.Button btnOk;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.TextBox eName;
	}
}
