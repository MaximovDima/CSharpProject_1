using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using MW.Data;
using MW.Core;

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
				string[] vGridRow = new string[5];
				vGridRow[0] = vRow["Date"];
				vGridRow[1] = Directory.GetNameByID("Cost", vRow["Type"]);
				vGridRow[2] = Directory.GetNameByID("Place", vRow["Place"]);
				vGridRow[3] = vRow["Value"];
				vGridRow[4] = vRow["Comment"];
				
				vCosts.Rows.Add(vGridRow);
			}
		}
		
		void BtnAddClick(object sender, EventArgs e)
		{
			FrmEditFinance editForm = new FrmEditFinance(Directory, Costs);
			editForm.Text = "Новый расход...";
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
			Dictionary<string, string> vRow = Costs.Rows[e.RowIndex];
			FrmEditFinance editForm = new FrmEditFinance(Directory, Costs);
			editForm.Text = "Редактировать расход...";
			editForm.ShowDialog();		
			
//			if (editForm.IsModify)
//			{
//				Data.UpdateModel("Cost");
//				SyncCostsView();
//			}
		}
	}
}
