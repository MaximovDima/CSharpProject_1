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
			this.lblValue = new System.Windows.Forms.Label();
			this.lblPalce = new System.Windows.Forms.Label();
			this.lblTypeCost = new System.Windows.Forms.Label();
			this.cbType = new System.Windows.Forms.ComboBox();
			this.eValue = new System.Windows.Forms.TextBox();
			this.cbPlace = new System.Windows.Forms.ComboBox();
			this.eComment = new System.Windows.Forms.TextBox();
			this.addType = new System.Windows.Forms.Button();
			this.addPlace = new System.Windows.Forms.Button();
			this.btnOk = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
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
			this.lblComment.Location = new System.Drawing.Point(12, 131);
			this.lblComment.Name = "lblComment";
			this.lblComment.Size = new System.Drawing.Size(100, 18);
			this.lblComment.TabIndex = 2;
			this.lblComment.Text = "Комментарий:";
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
			this.lblPalce.Location = new System.Drawing.Point(14, 105);
			this.lblPalce.Name = "lblPalce";
			this.lblPalce.Size = new System.Drawing.Size(100, 14);
			this.lblPalce.TabIndex = 6;
			this.lblPalce.Text = "Место/причина:";
			// 
			// lblTypeCost
			// 
			this.lblTypeCost.Location = new System.Drawing.Point(12, 76);
			this.lblTypeCost.Name = "lblTypeCost";
			this.lblTypeCost.Size = new System.Drawing.Size(100, 16);
			this.lblTypeCost.TabIndex = 7;
			this.lblTypeCost.Text = "Тип/вид:";
			// 
			// cbType
			// 
			this.cbType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.cbType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.cbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbType.FormattingEnabled = true;
			this.cbType.Location = new System.Drawing.Point(120, 73);
			this.cbType.Name = "cbType";
			this.cbType.Size = new System.Drawing.Size(256, 21);
			this.cbType.TabIndex = 2;
			// 
			// eValue
			// 
			this.eValue.Location = new System.Drawing.Point(120, 45);
			this.eValue.Name = "eValue";
			this.eValue.Size = new System.Drawing.Size(257, 20);
			this.eValue.TabIndex = 1;
			// 
			// cbPlace
			// 
			this.cbPlace.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.cbPlace.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.cbPlace.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbPlace.FormattingEnabled = true;
			this.cbPlace.Location = new System.Drawing.Point(120, 100);
			this.cbPlace.Name = "cbPlace";
			this.cbPlace.Size = new System.Drawing.Size(257, 21);
			this.cbPlace.TabIndex = 3;
			// 
			// eComment
			// 
			this.eComment.Location = new System.Drawing.Point(120, 131);
			this.eComment.Name = "eComment";
			this.eComment.Size = new System.Drawing.Size(257, 20);
			this.eComment.TabIndex = 4;
			// 
			// addType
			// 
			this.addType.Location = new System.Drawing.Point(386, 74);
			this.addType.Name = "addType";
			this.addType.Size = new System.Drawing.Size(28, 20);
			this.addType.TabIndex = 13;
			this.addType.Text = "+";
			this.addType.UseVisualStyleBackColor = true;
			this.addType.Click += new System.EventHandler(this.AddTypeCostClick);
			// 
			// addPlace
			// 
			this.addPlace.Location = new System.Drawing.Point(386, 101);
			this.addPlace.Name = "addPlace";
			this.addPlace.Size = new System.Drawing.Size(28, 20);
			this.addPlace.TabIndex = 15;
			this.addPlace.Text = "+";
			this.addPlace.UseVisualStyleBackColor = true;
			this.addPlace.Click += new System.EventHandler(this.AddPlaceClick);
			// 
			// btnOk
			// 
			this.btnOk.Location = new System.Drawing.Point(248, 157);
			this.btnOk.Name = "btnOk";
			this.btnOk.Size = new System.Drawing.Size(75, 23);
			this.btnOk.TabIndex = 5;
			this.btnOk.Text = "Ок";
			this.btnOk.UseVisualStyleBackColor = true;
			this.btnOk.Click += new System.EventHandler(this.BtnOkClick);
			// 
			// btnCancel
			// 
			this.btnCancel.Location = new System.Drawing.Point(339, 157);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 17;
			this.btnCancel.Text = "Отмена";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.BtnCancelClick);
			// 
			// FrmEditFinance
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(426, 188);
			this.ControlBox = false;
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOk);
			this.Controls.Add(this.addPlace);
			this.Controls.Add(this.addType);
			this.Controls.Add(this.eComment);
			this.Controls.Add(this.cbPlace);
			this.Controls.Add(this.eValue);
			this.Controls.Add(this.cbType);
			this.Controls.Add(this.lblTypeCost);
			this.Controls.Add(this.lblPalce);
			this.Controls.Add(this.lblValue);
			this.Controls.Add(this.lblComment);
			this.Controls.Add(this.lblDate);
			this.Controls.Add(this.eDate);
			this.Name = "FrmEditFinance";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnOk;
		private System.Windows.Forms.Button addPlace;
		private System.Windows.Forms.Button addType;
		private System.Windows.Forms.TextBox eComment;
		private System.Windows.Forms.ComboBox cbPlace;
		private System.Windows.Forms.TextBox eValue;
		private System.Windows.Forms.ComboBox cbType;
		private System.Windows.Forms.Label lblTypeCost;
		private System.Windows.Forms.Label lblPalce;
		private System.Windows.Forms.Label lblValue;
		private System.Windows.Forms.Label lblComment;
		private System.Windows.Forms.Label lblDate;
		private System.Windows.Forms.DateTimePicker eDate;
	}
}
