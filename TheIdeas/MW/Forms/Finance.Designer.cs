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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
			this.splitter = new System.Windows.Forms.SplitContainer();
			this.btnDelete = new System.Windows.Forms.Button();
			this.btnEdit = new System.Windows.Forms.Button();
			this.btnAdd = new System.Windows.Forms.Button();
			this.vCosts = new System.Windows.Forms.DataGridView();
			this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.TypeCost = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Place = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Value = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Comment = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
			this.vCosts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
									this.Date,
									this.TypeCost,
									this.Place,
									this.Value,
									this.Comment});
			this.vCosts.Location = new System.Drawing.Point(12, 12);
			this.vCosts.Name = "vCosts";
			this.vCosts.Size = new System.Drawing.Size(481, 231);
			this.vCosts.TabIndex = 0;
			// 
			// Date
			// 
			dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			this.Date.DefaultCellStyle = dataGridViewCellStyle1;
			this.Date.HeaderText = "Дата";
			this.Date.Name = "Date";
			this.Date.ReadOnly = true;
			this.Date.Width = 75;
			// 
			// TypeCost
			// 
			this.TypeCost.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			this.TypeCost.DefaultCellStyle = dataGridViewCellStyle2;
			this.TypeCost.HeaderText = "Тип";
			this.TypeCost.Name = "TypeCost";
			this.TypeCost.ReadOnly = true;
			this.TypeCost.Width = 51;
			// 
			// Place
			// 
			this.Place.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
			dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			this.Place.DefaultCellStyle = dataGridViewCellStyle3;
			this.Place.HeaderText = "Место";
			this.Place.Name = "Place";
			this.Place.ReadOnly = true;
			this.Place.Width = 64;
			// 
			// Value
			// 
			this.Value.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
			dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			this.Value.DefaultCellStyle = dataGridViewCellStyle4;
			this.Value.HeaderText = "Сумма";
			this.Value.Name = "Value";
			this.Value.ReadOnly = true;
			this.Value.Width = 66;
			// 
			// Comment
			// 
			this.Comment.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.Comment.HeaderText = "Комментарий";
			this.Comment.Name = "Comment";
			this.Comment.ReadOnly = true;
			// 
			// FrmFinance
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
		private System.Windows.Forms.DataGridViewTextBoxColumn Comment;
		private System.Windows.Forms.DataGridViewTextBoxColumn Value;
		private System.Windows.Forms.DataGridViewTextBoxColumn Place;
		private System.Windows.Forms.DataGridViewTextBoxColumn TypeCost;
		private System.Windows.Forms.DataGridViewTextBoxColumn Date;
		private System.Windows.Forms.Button btnEdit;
		private System.Windows.Forms.Button btnDelete;
		private System.Windows.Forms.Button btnAdd;
		private System.Windows.Forms.DataGridView vCosts;
		private System.Windows.Forms.SplitContainer splitter;
	}
}
