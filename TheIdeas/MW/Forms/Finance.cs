using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using MW.Data;
using MW.Core;
using MW.Utils;

namespace MW.Forms
{
	public partial class FrmFinance : Form
	{
		//Инициализация моделей
		public TData Data;
		//Справочник
		public TModel Directory;
		//Расходы
		public TModel Costs;
		//Доходы
		public TModel Incomes;
		
		public FrmFinance(TData AData)
		{
			InitializeComponent();
			Data = AData;
			Directory = Data.GetModel("Directory");
			Costs = Data.GetModel("Cost");
			Incomes = Data.GetModel("Income");
			SyncForm();
		}
		
		public void SyncForm()
		{
			SyncCostsInfo();
			SyncIncomesInfo();
		}
		
		public void SyncCostsInfo()
		{
			SyncCostsView();
			lblCostSum.Text = Costs.GetTextSum("Value");
			lblAverage.Text = Costs.GetTextAverageDay("Value");
		}
		
		public void SyncIncomesInfo()
		{
			SyncIncomesView();
			lblIncomeSum.Text = Incomes.GetTextSum("Value");
			lblAverageInc.Text = Incomes.GetTextAverageDay("Value");
		}
		
		public void SyncCostsView()
		{
			vCosts.Rows.Clear();
			foreach(Dictionary<string, string> vRow in Costs.Rows)
			{
				object[] vGridRow = new object[6];
				vGridRow[0] = vRow["ID"];
				vGridRow[1] = vRow["Date"];
				vGridRow[2] = Directory.GetNameByID("Cost", vRow["Type"]);
				vGridRow[3] = Directory.GetNameByID("Place", vRow["Place"]);
				vGridRow[4] = Format.StrToInt(vRow["Value"]);
				vGridRow[5] = vRow["Comment"];
				
				vCosts.Rows.Add(vGridRow);
			}

			vCosts.FirstDisplayedScrollingRowIndex = vCosts.RowCount - 1;		
		}
		
		public void SyncIncomesView()
		{
			vIncomes.Rows.Clear();
			foreach(Dictionary<string, string> vRow in Incomes.Rows)
			{
				object[] vGridRow = new object[6];
				vGridRow[0] = vRow["ID"];
				vGridRow[1] = vRow["Date"];
				vGridRow[2] = Directory.GetNameByID("Cost", vRow["Type"]);
				vGridRow[3] = Directory.GetNameByID("Place", vRow["Place"]);
				vGridRow[4] = Format.StrToInt(vRow["Value"]);
				vGridRow[5] = vRow["Comment"];
				
				vCosts.Rows.Add(vGridRow);
			}

			vCosts.FirstDisplayedScrollingRowIndex = vCosts.RowCount - 1;		
		}
		
		void BtnAddCostClick(object sender, EventArgs e)
		{
			FrmEditFinance editForm = new FrmEditFinance(Directory, Costs);
			editForm.Text = "Новый расход...";
			editForm.IsEdit = false;
			editForm.IsCosts = true;
			editForm.SyncForm();
			editForm.ShowDialog();
			if (editForm.IsModify)
			{
				Data.UpdateModel("Directory");
				Data.UpdateModel("Cost");
				SyncCostsInfo();
			}
		}
		
		void VCostsCellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			EditCost(e.RowIndex);
		}
		
		public void EditCost(int ARowIndex)
		{
			if (ARowIndex >= vCosts.RowCount - 1)
				return;
				
			string vID = vCosts.Rows[ARowIndex].Cells["ID"].Value.ToString();
			Dictionary<string, string> vRow = Costs.Rows[Format.StrToInt(vID) - 1];

			FrmEditFinance editForm = new FrmEditFinance(Directory, Costs);
			editForm.Text = "Редактировать расход...";
			editForm.IsEdit = true;
			editForm.IsCosts = true;
			editForm.EditRow = vRow;
			editForm.SyncForm();
			editForm.ShowDialog();		
			
			if (editForm.IsModify)
			{
				Data.UpdateModel("Directory");
				Data.UpdateModel("Cost");
				SyncCostsInfo();
			}
		}	
		
		void BtnCostEditClick(object sender, EventArgs e)
		{
			EditCost(vCosts.CurrentRow.Index);	
		}
		
		void BtnCostDeleteClick(object sender, EventArgs e)
		{
			if (vCosts.CurrentRow.Index >= vCosts.RowCount - 1)
				return;
			string vID = vCosts.Rows[vCosts.CurrentRow.Index].Cells["ID"].Value.ToString();
			Dictionary<string, string> vRow = Costs.Rows[Format.StrToInt(vID) - 1];
			
			DialogResult vResult = MessageBox.Show("Удалить расход " + vRow["Value"] + " за " + vRow["Date"],
			                                      "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (vResult == DialogResult.Yes)
			{
				vRow["State"] = "delete";
				Data.UpdateModel("Cost");
				SyncForm();
			}
		}
		
		void BtnIncomeAddClick(object sender, EventArgs e)
		{
			FrmEditFinance editForm = new FrmEditFinance(Incomes, Costs);
			editForm.Text = "Новый доход...";
			editForm.IsEdit = false;
			editForm.IsCosts = false;
			editForm.SyncForm();
			editForm.ShowDialog();
			if (editForm.IsModify)
			{
				Data.UpdateModel("Directory");
				Data.UpdateModel("Income");
				SyncForm();
			}			
		}
	}
}
