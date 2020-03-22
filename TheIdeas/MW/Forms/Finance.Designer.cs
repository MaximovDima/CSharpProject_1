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
			this.lblAverage = new System.Windows.Forms.Label();
			this.lblCostSum = new System.Windows.Forms.Label();
			this.btnCostEdit = new System.Windows.Forms.Button();
			this.btnCostDelete = new System.Windows.Forms.Button();
			this.btnCostAdd = new System.Windows.Forms.Button();
			this.vCosts = new System.Windows.Forms.DataGridView();
			this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.TypeCost = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Place = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Value = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Comment = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.gbIncomes = new System.Windows.Forms.GroupBox();
			this.label2 = new System.Windows.Forms.Label();
			this.lblAverageInc = new System.Windows.Forms.Label();
			this.lblIncomeSum = new System.Windows.Forms.Label();
			this.btnIncomeEdit = new System.Windows.Forms.Button();
			this.btnIncomeDelete = new System.Windows.Forms.Button();
			this.btnIncomeAdd = new System.Windows.Forms.Button();
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
			this.gbCosts.Controls.Add(this.lblAverage);
			this.gbCosts.Controls.Add(this.lblCostSum);
			this.gbCosts.Controls.Add(this.btnCostEdit);
			this.gbCosts.Controls.Add(this.btnCostDelete);
			this.gbCosts.Controls.Add(this.btnCostAdd);
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
			this.label1.Location = new System.Drawing.Point(520, 34);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(40, 13);
			this.label1.TabIndex = 6;
			this.label1.Text = "в день";
			// 
			// lblAverage
			// 
			this.lblAverage.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.lblAverage.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
			this.lblAverage.Location = new System.Drawing.Point(463, 24);
			this.lblAverage.Name = "lblAverage";
			this.lblAverage.Size = new System.Drawing.Size(60, 23);
			this.lblAverage.TabIndex = 5;
			this.lblAverage.Text = "1000";
			// 
			// lblCostSum
			// 
			this.lblCostSum.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.lblCostSum.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
			this.lblCostSum.Location = new System.Drawing.Point(334, 15);
			this.lblCostSum.Name = "lblCostSum";
			this.lblCostSum.Size = new System.Drawing.Size(123, 32);
			this.lblCostSum.TabIndex = 4;
			this.lblCostSum.Text = "100000";
			// 
			// btnCostEdit
			// 
			this.btnCostEdit.Image = ((System.Drawing.Image)(resources.GetObject("btnCostEdit.Image")));
			this.btnCostEdit.Location = new System.Drawing.Point(44, 19);
			this.btnCostEdit.Name = "btnCostEdit";
			this.btnCostEdit.Size = new System.Drawing.Size(32, 32);
			this.btnCostEdit.TabIndex = 3;
			this.btnCostEdit.UseVisualStyleBackColor = true;
			this.btnCostEdit.Click += new System.EventHandler(this.BtnCostEditClick);
			// 
			// btnCostDelete
			// 
			this.btnCostDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnCostDelete.Image")));
			this.btnCostDelete.Location = new System.Drawing.Point(82, 19);
			this.btnCostDelete.Name = "btnCostDelete";
			this.btnCostDelete.Size = new System.Drawing.Size(32, 32);
			this.btnCostDelete.TabIndex = 2;
			this.btnCostDelete.UseVisualStyleBackColor = true;
			this.btnCostDelete.Click += new System.EventHandler(this.BtnCostDeleteClick);
			// 
			// btnCostAdd
			// 
			this.btnCostAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnCostAdd.Image")));
			this.btnCostAdd.Location = new System.Drawing.Point(6, 19);
			this.btnCostAdd.Name = "btnCostAdd";
			this.btnCostAdd.Size = new System.Drawing.Size(32, 32);
			this.btnCostAdd.TabIndex = 1;
			this.btnCostAdd.UseVisualStyleBackColor = true;
			this.btnCostAdd.Click += new System.EventHandler(this.BtnAddCostClick);
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
			this.gbIncomes.Controls.Add(this.lblAverageInc);
			this.gbIncomes.Controls.Add(this.lblIncomeSum);
			this.gbIncomes.Controls.Add(this.btnIncomeEdit);
			this.gbIncomes.Controls.Add(this.btnIncomeDelete);
			this.gbIncomes.Controls.Add(this.btnIncomeAdd);
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
			this.label2.Location = new System.Drawing.Point(505, 34);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(40, 13);
			this.label2.TabIndex = 9;
			this.label2.Text = "в день";
			// 
			// lblAverageInc
			// 
			this.lblAverageInc.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.lblAverageInc.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
			this.lblAverageInc.Location = new System.Drawing.Point(448, 24);
			this.lblAverageInc.Name = "lblAverageInc";
			this.lblAverageInc.Size = new System.Drawing.Size(60, 23);
			this.lblAverageInc.TabIndex = 8;
			this.lblAverageInc.Text = "1000";
			// 
			// lblIncomeSum
			// 
			this.lblIncomeSum.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.lblIncomeSum.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
			this.lblIncomeSum.Location = new System.Drawing.Point(319, 15);
			this.lblIncomeSum.Name = "lblIncomeSum";
			this.lblIncomeSum.Size = new System.Drawing.Size(123, 32);
			this.lblIncomeSum.TabIndex = 7;
			this.lblIncomeSum.Text = "100000";
			// 
			// btnIncomeEdit
			// 
			this.btnIncomeEdit.Image = ((System.Drawing.Image)(resources.GetObject("btnIncomeEdit.Image")));
			this.btnIncomeEdit.Location = new System.Drawing.Point(44, 19);
			this.btnIncomeEdit.Name = "btnIncomeEdit";
			this.btnIncomeEdit.Size = new System.Drawing.Size(32, 32);
			this.btnIncomeEdit.TabIndex = 3;
			this.btnIncomeEdit.UseVisualStyleBackColor = true;
			// 
			// btnIncomeDelete
			// 
			this.btnIncomeDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnIncomeDelete.Image")));
			this.btnIncomeDelete.Location = new System.Drawing.Point(82, 19);
			this.btnIncomeDelete.Name = "btnIncomeDelete";
			this.btnIncomeDelete.Size = new System.Drawing.Size(32, 32);
			this.btnIncomeDelete.TabIndex = 2;
			this.btnIncomeDelete.UseVisualStyleBackColor = true;
			// 
			// btnIncomeAdd
			// 
			this.btnIncomeAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnIncomeAdd.Image")));
			this.btnIncomeAdd.Location = new System.Drawing.Point(6, 19);
			this.btnIncomeAdd.Name = "btnIncomeAdd";
			this.btnIncomeAdd.Size = new System.Drawing.Size(32, 32);
			this.btnIncomeAdd.TabIndex = 1;
			this.btnIncomeAdd.UseVisualStyleBackColor = true;
			this.btnIncomeAdd.Click += new System.EventHandler(this.BtnIncomeAddClick);
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
		private System.Windows.Forms.Label lblIncomeSum;
		private System.Windows.Forms.Label lblAverageInc;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label lblAverage;
		private System.Windows.Forms.DataGridViewTextBoxColumn ID;
		private System.Windows.Forms.GroupBox gbDraw;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
		private System.Windows.Forms.DataGridView vIncomes;
		private System.Windows.Forms.Button btnIncomeAdd;
		private System.Windows.Forms.Button btnIncomeDelete;
		private System.Windows.Forms.Button btnIncomeEdit;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.GroupBox gbIncomes;
		private System.Windows.Forms.Label lblCostSum;
		private System.Windows.Forms.Button btnCostDelete;
		private System.Windows.Forms.Button btnCostEdit;
		private System.Windows.Forms.GroupBox gbCosts;
		private System.Windows.Forms.DataGridViewTextBoxColumn Comment;
		private System.Windows.Forms.DataGridViewTextBoxColumn Value;
		private System.Windows.Forms.DataGridViewTextBoxColumn Place;
		private System.Windows.Forms.DataGridViewTextBoxColumn TypeCost;
		private System.Windows.Forms.DataGridViewTextBoxColumn Date;
		private System.Windows.Forms.Button btnCostAdd;
		private System.Windows.Forms.DataGridView vCosts;
	}
}
