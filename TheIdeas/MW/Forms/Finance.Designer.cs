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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmFinance));
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
			this.splitter = new System.Windows.Forms.SplitContainer();
			this.gbCosts = new System.Windows.Forms.GroupBox();
			this.button2 = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
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
			this.gbCosts.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.vCosts)).BeginInit();
			this.SuspendLayout();
			// 
			// splitter
			// 
			this.splitter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.splitter.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitter.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
			this.splitter.IsSplitterFixed = true;
			this.splitter.Location = new System.Drawing.Point(0, 0);
			this.splitter.Name = "splitter";
			this.splitter.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitter.Panel1
			// 
			this.splitter.Panel1.Controls.Add(this.gbCosts);
			this.splitter.Size = new System.Drawing.Size(1159, 553);
			this.splitter.SplitterDistance = 273;
			this.splitter.TabIndex = 0;
			// 
			// gbCosts
			// 
			this.gbCosts.Controls.Add(this.button2);
			this.gbCosts.Controls.Add(this.button1);
			this.gbCosts.Controls.Add(this.btnAdd);
			this.gbCosts.Controls.Add(this.vCosts);
			this.gbCosts.Location = new System.Drawing.Point(11, 11);
			this.gbCosts.Name = "gbCosts";
			this.gbCosts.Size = new System.Drawing.Size(529, 256);
			this.gbCosts.TabIndex = 2;
			this.gbCosts.TabStop = false;
			this.gbCosts.Text = "Расходы";
			// 
			// button2
			// 
			this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
			this.button2.Location = new System.Drawing.Point(44, 19);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(32, 32);
			this.button2.TabIndex = 3;
			this.button2.UseVisualStyleBackColor = true;
			// 
			// button1
			// 
			this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
			this.button1.Location = new System.Drawing.Point(82, 19);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(32, 32);
			this.button1.TabIndex = 2;
			this.button1.UseVisualStyleBackColor = true;
			// 
			// btnAdd
			// 
			this.btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.Image")));
			this.btnAdd.Location = new System.Drawing.Point(6, 19);
			this.btnAdd.Name = "btnAdd";
			this.btnAdd.Size = new System.Drawing.Size(32, 32);
			this.btnAdd.TabIndex = 1;
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
			this.vCosts.Location = new System.Drawing.Point(6, 58);
			this.vCosts.Name = "vCosts";
			this.vCosts.Size = new System.Drawing.Size(481, 184);
			this.vCosts.TabIndex = 0;
			this.vCosts.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.VCostsCellDoubleClick);
			// 
			// Date
			// 
			dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			this.Date.DefaultCellStyle = dataGridViewCellStyle9;
			this.Date.HeaderText = "Дата";
			this.Date.Name = "Date";
			this.Date.ReadOnly = true;
			this.Date.Width = 75;
			// 
			// TypeCost
			// 
			this.TypeCost.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
			dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			this.TypeCost.DefaultCellStyle = dataGridViewCellStyle10;
			this.TypeCost.HeaderText = "Тип";
			this.TypeCost.Name = "TypeCost";
			this.TypeCost.ReadOnly = true;
			this.TypeCost.Width = 51;
			// 
			// Place
			// 
			this.Place.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
			dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			this.Place.DefaultCellStyle = dataGridViewCellStyle11;
			this.Place.HeaderText = "Место";
			this.Place.Name = "Place";
			this.Place.ReadOnly = true;
			this.Place.Width = 64;
			// 
			// Value
			// 
			this.Value.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
			dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			this.Value.DefaultCellStyle = dataGridViewCellStyle12;
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
			this.gbCosts.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.vCosts)).EndInit();
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.GroupBox gbCosts;
		private System.Windows.Forms.DataGridViewTextBoxColumn Comment;
		private System.Windows.Forms.DataGridViewTextBoxColumn Value;
		private System.Windows.Forms.DataGridViewTextBoxColumn Place;
		private System.Windows.Forms.DataGridViewTextBoxColumn TypeCost;
		private System.Windows.Forms.DataGridViewTextBoxColumn Date;
		private System.Windows.Forms.Button btnAdd;
		private System.Windows.Forms.DataGridView vCosts;
		private System.Windows.Forms.SplitContainer splitter;
	}
}
