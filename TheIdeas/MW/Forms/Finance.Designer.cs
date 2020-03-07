namespace MW.Forms
{
	public partial class FrmFinance
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
			this.splitter = new System.Windows.Forms.SplitContainer();
			this.btnDelete = new System.Windows.Forms.Button();
			this.btnEdit = new System.Windows.Forms.Button();
			this.btnAdd = new System.Windows.Forms.Button();
			this.vCosts = new System.Windows.Forms.DataGridView();
			((System.ComponentModel.ISupportInitialize)(this.splitter)).BeginInit();
			this.splitter.Panel1.SuspendLayout();
			this.splitter.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.vCosts)).BeginInit();
			this.SuspendLayout();
			// 
			// splitter
			// 
			this.splitter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.splitter.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitter.Location = new System.Drawing.Point(0, 0);
			this.splitter.Name = "splitter";
			this.splitter.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitter.Panel1
			// 
			this.splitter.Panel1.Controls.Add(this.btnDelete);
			this.splitter.Panel1.Controls.Add(this.btnEdit);
			this.splitter.Panel1.Controls.Add(this.btnAdd);
			this.splitter.Panel1.Controls.Add(this.vCosts);
			this.splitter.Size = new System.Drawing.Size(1159, 553);
			this.splitter.SplitterDistance = 258;
			this.splitter.TabIndex = 0;
			// 
			// btnDelete
			// 
			this.btnDelete.Location = new System.Drawing.Point(499, 70);
			this.btnDelete.Name = "btnDelete";
			this.btnDelete.Size = new System.Drawing.Size(92, 23);
			this.btnDelete.TabIndex = 3;
			this.btnDelete.Text = "Удалить";
			this.btnDelete.UseVisualStyleBackColor = true;
			// 
			// btnEdit
			// 
			this.btnEdit.Location = new System.Drawing.Point(499, 41);
			this.btnEdit.Name = "btnEdit";
			this.btnEdit.Size = new System.Drawing.Size(92, 23);
			this.btnEdit.TabIndex = 2;
			this.btnEdit.Text = "Редактировать";
			this.btnEdit.UseVisualStyleBackColor = true;
			// 
			// btnAdd
			// 
			this.btnAdd.Location = new System.Drawing.Point(499, 12);
			this.btnAdd.Name = "btnAdd";
			this.btnAdd.Size = new System.Drawing.Size(92, 23);
			this.btnAdd.TabIndex = 1;
			this.btnAdd.Text = "Добавить";
			this.btnAdd.UseVisualStyleBackColor = true;
			this.btnAdd.Click += new System.EventHandler(this.BtnAddClick);
			// 
			// vCosts
			// 
			this.vCosts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.vCosts.Location = new System.Drawing.Point(12, 12);
			this.vCosts.Name = "vCosts";
			this.vCosts.Size = new System.Drawing.Size(481, 231);
			this.vCosts.TabIndex = 0;
			// 
			// TFinance
			// 
			this.ClientSize = new System.Drawing.Size(1159, 553);
			this.ControlBox = false;
			this.Controls.Add(this.splitter);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "FrmFinance";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.splitter.Panel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitter)).EndInit();
			this.splitter.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.vCosts)).EndInit();
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.Button btnEdit;
		private System.Windows.Forms.Button btnDelete;
		private System.Windows.Forms.Button btnAdd;
		private System.Windows.Forms.DataGridView vCosts;
		private System.Windows.Forms.SplitContainer splitter;
	}
}
