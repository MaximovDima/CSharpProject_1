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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
			this.gbCosts = new System.Windows.Forms.GroupBox();
			this.label1 = new System.Windows.Forms.Label();
			this.button2 = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.btnAdd = new System.Windows.Forms.Button();
			this.vCosts = new System.Windows.Forms.DataGridView();
			this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.TypeCost = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Place = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Value = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Comment = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.gbIncomes = new System.Windows.Forms.GroupBox();
			this.label2 = new System.Windows.Forms.Label();
			this.button3 = new System.Windows.Forms.Button();
			this.button4 = new System.Windows.Forms.Button();
			this.btnAddIncome = new System.Windows.Forms.Button();
			this.vIncomes = new System.Windows.Forms.DataGridView();
			this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.gbDraw = new System.Windows.Forms.GroupBox();
			this.gbCosts.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.vCosts)).BeginInit();
			this.gbIncomes.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.vIncomes)).BeginInit();
			this.SuspendLayout();
			// 
			// gbCosts
			// 
			this.gbCosts.Controls.Add(this.label1);
			this.gbCosts.Controls.Add(this.button2);
			this.gbCosts.Controls.Add(this.button1);
			this.gbCosts.Controls.Add(this.btnAdd);
			this.gbCosts.Controls.Add(this.vCosts);
			this.gbCosts.Location = new System.Drawing.Point(6, 12);
			this.gbCosts.Name = "gbCosts";
			this.gbCosts.Size = new System.Drawing.Size(580, 256);
			this.gbCosts.TabIndex = 2;
			this.gbCosts.TabStop = false;
			this.gbCosts.Text = "Расходы";
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
			this.label1.Location = new System.Drawing.Point(432, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(137, 32);
			this.label1.TabIndex = 4;
			this.label1.Text = "100 000";
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
			this.vCosts.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.vCosts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.vCosts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
									this.ID,
									this.Date,
									this.TypeCost,
									this.Place,
									this.Value,
									this.Comment});
			this.vCosts.Location = new System.Drawing.Point(6, 58);
			this.vCosts.Name = "vCosts";
			this.vCosts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.vCosts.Size = new System.Drawing.Size(563, 184);
			this.vCosts.TabIndex = 0;
			this.vCosts.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.VCostsCellDoubleClick);
			// 
			// ID
			// 
			this.ID.HeaderText = "";
			this.ID.Name = "ID";
			this.ID.Visible = false;
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
			// gbIncomes
			// 
			this.gbIncomes.AutoSize = true;
			this.gbIncomes.Controls.Add(this.label2);
			this.gbIncomes.Controls.Add(this.button3);
			this.gbIncomes.Controls.Add(this.button4);
			this.gbIncomes.Controls.Add(this.btnAddIncome);
			this.gbIncomes.Controls.Add(this.vIncomes);
			this.gbIncomes.Location = new System.Drawing.Point(592, 12);
			this.gbIncomes.Name = "gbIncomes";
			this.gbIncomes.Size = new System.Drawing.Size(566, 256);
			this.gbIncomes.TabIndex = 3;
			this.gbIncomes.TabStop = false;
			this.gbIncomes.Text = "Доходы";
			// 
			// label2
			// 
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
			this.label2.Location = new System.Drawing.Point(418, 16);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(133, 32);
			this.label2.TabIndex = 4;
			this.label2.Text = "100 000";
			// 
			// button3
			// 
			this.button3.Image = ((System.Drawing.Image)(resources.GetObject("button3.Image")));
			this.button3.Location = new System.Drawing.Point(44, 19);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(32, 32);
			this.button3.TabIndex = 3;
			this.button3.UseVisualStyleBackColor = true;
			// 
			// button4
			// 
			this.button4.Image = ((System.Drawing.Image)(resources.GetObject("button4.Image")));
			this.button4.Location = new System.Drawing.Point(82, 19);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(32, 32);
			this.button4.TabIndex = 2;
			this.button4.UseVisualStyleBackColor = true;
			// 
			// btnAddIncome
			// 
			this.btnAddIncome.Image = ((System.Drawing.Image)(resources.GetObject("btnAddIncome.Image")));
			this.btnAddIncome.Location = new System.Drawing.Point(6, 19);
			this.btnAddIncome.Name = "btnAddIncome";
			this.btnAddIncome.Size = new System.Drawing.Size(32, 32);
			this.btnAddIncome.TabIndex = 1;
			this.btnAddIncome.UseVisualStyleBackColor = true;
			// 
			// vIncomes
			// 
			this.vIncomes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.vIncomes.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.vIncomes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.vIncomes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
									this.dataGridViewTextBoxColumn1,
									this.dataGridViewTextBoxColumn2,
									this.dataGridViewTextBoxColumn4,
									this.dataGridViewTextBoxColumn5});
			this.vIncomes.Location = new System.Drawing.Point(6, 58);
			this.vIncomes.Name = "vIncomes";
			this.vIncomes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.vIncomes.Size = new System.Drawing.Size(545, 184);
			this.vIncomes.TabIndex = 0;
			// 
			// dataGridViewTextBoxColumn1
			// 
			dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle5;
			this.dataGridViewTextBoxColumn1.HeaderText = "Дата";
			this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
			this.dataGridViewTextBoxColumn1.ReadOnly = true;
			this.dataGridViewTextBoxColumn1.Width = 75;
			// 
			// dataGridViewTextBoxColumn2
			// 
			this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
			dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle6;
			this.dataGridViewTextBoxColumn2.HeaderText = "Тип";
			this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
			this.dataGridViewTextBoxColumn2.ReadOnly = true;
			this.dataGridViewTextBoxColumn2.Width = 51;
			// 
			// dataGridViewTextBoxColumn4
			// 
			this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
			dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			this.dataGridViewTextBoxColumn4.DefaultCellStyle = dataGridViewCellStyle7;
			this.dataGridViewTextBoxColumn4.HeaderText = "Сумма";
			this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
			this.dataGridViewTextBoxColumn4.ReadOnly = true;
			this.dataGridViewTextBoxColumn4.Width = 66;
			// 
			// dataGridViewTextBoxColumn5
			// 
			this.dataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.dataGridViewTextBoxColumn5.HeaderText = "Комментарий";
			this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
			this.dataGridViewTextBoxColumn5.ReadOnly = true;
			// 
			// gbDraw
			// 
			this.gbDraw.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.gbDraw.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.gbDraw.Location = new System.Drawing.Point(6, 279);
			this.gbDraw.Name = "gbDraw";
			this.gbDraw.Size = new System.Drawing.Size(1152, 295);
			this.gbDraw.TabIndex = 4;
			this.gbDraw.TabStop = false;
			// 
			// FrmFinance
			// 
			this.ClientSize = new System.Drawing.Size(1160, 574);
			this.ControlBox = false;
			this.Controls.Add(this.gbDraw);
			this.Controls.Add(this.gbIncomes);
			this.Controls.Add(this.gbCosts);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "FrmFinance";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.gbCosts.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.vCosts)).EndInit();
			this.gbIncomes.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.vIncomes)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.DataGridViewTextBoxColumn ID;
		private System.Windows.Forms.GroupBox gbDraw;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
		private System.Windows.Forms.DataGridView vIncomes;
		private System.Windows.Forms.Button btnAddIncome;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.GroupBox gbIncomes;
		private System.Windows.Forms.Label label1;
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
	}
}
