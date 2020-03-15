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
		
		public FrmFinance(TData AData)
		{
			InitializeComponent();
			Data = AData;
			Directory = Data.GetModel("Directory");
			Costs = Data.GetModel("Cost");
			SyncForm();
		}
		
		public void SyncForm()
		{
			SyncCostsView();
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
		}
		
		void BtnAddClick(object sender, EventArgs e)
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
				SyncCostsView();
			}
			
		}
		
		void VCostsCellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			string vID = vCosts.Rows[e.RowIndex].Cells["ID"].Value.ToString();
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
				SyncCostsView();
			}
		}
	}
}
