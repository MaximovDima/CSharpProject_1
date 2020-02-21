namespace MW.Forms
{
	public partial class FrmEditFinance
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
			this.eDate = new System.Windows.Forms.DateTimePicker();
			this.lblDate = new System.Windows.Forms.Label();
			this.lblComment = new System.Windows.Forms.Label();
			this.lblTags = new System.Windows.Forms.Label();
			this.lblValue = new System.Windows.Forms.Label();
			this.lblPalce = new System.Windows.Forms.Label();
			this.lblTypeCost = new System.Windows.Forms.Label();
			this.cbTypeCost = new System.Windows.Forms.ComboBox();
			this.eValue = new System.Windows.Forms.TextBox();
			this.cbPlace = new System.Windows.Forms.ComboBox();
			this.eTags = new System.Windows.Forms.TextBox();
			this.eComment = new System.Windows.Forms.TextBox();
			this.addTypeCost = new System.Windows.Forms.Button();
			this.SelectTags = new System.Windows.Forms.Button();
			this.addPlace = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// eDate
			// 
			this.eDate.Location = new System.Drawing.Point(120, 18);
			this.eDate.Name = "eDate";
			this.eDate.Size = new System.Drawing.Size(257, 20);
			this.eDate.TabIndex = 0;
			// 
			// lblDate
			// 
			this.lblDate.Location = new System.Drawing.Point(14, 20);
			this.lblDate.Name = "lblDate";
			this.lblDate.Size = new System.Drawing.Size(100, 18);
			this.lblDate.TabIndex = 1;
			this.lblDate.Text = "Дата:";
			// 
			// lblComment
			// 
			this.lblComment.Location = new System.Drawing.Point(14, 156);
			this.lblComment.Name = "lblComment";
			this.lblComment.Size = new System.Drawing.Size(100, 18);
			this.lblComment.TabIndex = 2;
			this.lblComment.Text = "Комментарий:";
			// 
			// lblTags
			// 
			this.lblTags.Location = new System.Drawing.Point(14, 131);
			this.lblTags.Name = "lblTags";
			this.lblTags.Size = new System.Drawing.Size(100, 18);
			this.lblTags.TabIndex = 4;
			this.lblTags.Text = "Тэги:";
			// 
			// lblValue
			// 
			this.lblValue.Location = new System.Drawing.Point(14, 48);
			this.lblValue.Name = "lblValue";
			this.lblValue.Size = new System.Drawing.Size(100, 18);
			this.lblValue.TabIndex = 5;
			this.lblValue.Text = "Сумма:";
			// 
			// lblPalce
			// 
			this.lblPalce.Location = new System.Drawing.Point(14, 106);
			this.lblPalce.Name = "lblPalce";
			this.lblPalce.Size = new System.Drawing.Size(100, 15);
			this.lblPalce.TabIndex = 6;
			this.lblPalce.Text = "Место:";
			// 
			// lblTypeCost
			// 
			this.lblTypeCost.Location = new System.Drawing.Point(12, 76);
			this.lblTypeCost.Name = "lblTypeCost";
			this.lblTypeCost.Size = new System.Drawing.Size(100, 16);
			this.lblTypeCost.TabIndex = 7;
			this.lblTypeCost.Text = "Тип расхода:";
			// 
			// cbTypeCost
			// 
			this.cbTypeCost.FormattingEnabled = true;
			this.cbTypeCost.Location = new System.Drawing.Point(120, 73);
			this.cbTypeCost.Name = "cbTypeCost";
			this.cbTypeCost.Size = new System.Drawing.Size(256, 21);
			this.cbTypeCost.TabIndex = 8;
			// 
			// eValue
			// 
			this.eValue.Location = new System.Drawing.Point(120, 45);
			this.eValue.Name = "eValue";
			this.eValue.Size = new System.Drawing.Size(257, 20);
			this.eValue.TabIndex = 9;
			// 
			// cbPlace
			// 
			this.cbPlace.FormattingEnabled = true;
			this.cbPlace.Location = new System.Drawing.Point(120, 100);
			this.cbPlace.Name = "cbPlace";
			this.cbPlace.Size = new System.Drawing.Size(257, 21);
			this.cbPlace.TabIndex = 10;
			// 
			// eTags
			// 
			this.eTags.Location = new System.Drawing.Point(120, 127);
			this.eTags.Name = "eTags";
			this.eTags.ReadOnly = true;
			this.eTags.Size = new System.Drawing.Size(257, 20);
			this.eTags.TabIndex = 11;
			// 
			// eComment
			// 
			this.eComment.Location = new System.Drawing.Point(120, 153);
			this.eComment.Name = "eComment";
			this.eComment.Size = new System.Drawing.Size(257, 20);
			this.eComment.TabIndex = 12;
			// 
			// addTypeCost
			// 
			this.addTypeCost.Location = new System.Drawing.Point(386, 74);
			this.addTypeCost.Name = "addTypeCost";
			this.addTypeCost.Size = new System.Drawing.Size(28, 20);
			this.addTypeCost.TabIndex = 13;
			this.addTypeCost.Text = "+";
			this.addTypeCost.UseVisualStyleBackColor = true;
			this.addTypeCost.Click += new System.EventHandler(this.AddTypeCostClick);
			// 
			// SelectTags
			// 
			this.SelectTags.Location = new System.Drawing.Point(386, 127);
			this.SelectTags.Name = "SelectTags";
			this.SelectTags.Size = new System.Drawing.Size(28, 20);
			this.SelectTags.TabIndex = 14;
			this.SelectTags.Text = "+";
			this.SelectTags.UseVisualStyleBackColor = true;
			// 
			// addPlace
			// 
			this.addPlace.Location = new System.Drawing.Point(386, 101);
			this.addPlace.Name = "addPlace";
			this.addPlace.Size = new System.Drawing.Size(28, 20);
			this.addPlace.TabIndex = 15;
			this.addPlace.Text = "+";
			this.addPlace.UseVisualStyleBackColor = true;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(215, 197);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 16;
			this.button1.Text = "button1";
			this.button1.UseVisualStyleBackColor = true;
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(322, 188);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(75, 23);
			this.button2.TabIndex = 17;
			this.button2.Text = "button2";
			this.button2.UseVisualStyleBackColor = true;
			// 
			// FrmEditFinance
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(426, 223);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.addPlace);
			this.Controls.Add(this.SelectTags);
			this.Controls.Add(this.addTypeCost);
			this.Controls.Add(this.eComment);
			this.Controls.Add(this.eTags);
			this.Controls.Add(this.cbPlace);
			this.Controls.Add(this.eValue);
			this.Controls.Add(this.cbTypeCost);
			this.Controls.Add(this.lblTypeCost);
			this.Controls.Add(this.lblPalce);
			this.Controls.Add(this.lblValue);
			this.Controls.Add(this.lblTags);
			this.Controls.Add(this.lblComment);
			this.Controls.Add(this.lblDate);
			this.Controls.Add(this.eDate);
			this.Name = "FrmEditFinance";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button addPlace;
		private System.Windows.Forms.Button SelectTags;
		private System.Windows.Forms.Button addTypeCost;
		private System.Windows.Forms.TextBox eComment;
		private System.Windows.Forms.TextBox eTags;
		private System.Windows.Forms.ComboBox cbPlace;
		private System.Windows.Forms.TextBox eValue;
		private System.Windows.Forms.ComboBox cbTypeCost;
		private System.Windows.Forms.Label lblTypeCost;
		private System.Windows.Forms.Label lblPalce;
		private System.Windows.Forms.Label lblValue;
		private System.Windows.Forms.Label lblTags;
		private System.Windows.Forms.Label lblComment;
		private System.Windows.Forms.Label lblDate;
		private System.Windows.Forms.DateTimePicker eDate;
	}
}
