using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

using MW;
using MW.Utils;
using MW.Core;

namespace MW.Forms
{
	public partial class FrmEditFinance : Form
	{
		//Инициализация моделей
		public TModel Directory;
		public TModel Costs;
		//Флаг регистрации изменения
		public bool IsModify;
		
		public FrmEditFinance(TModel ADirectory, TModel ACosts)
		{
			Directory = ADirectory;
		    Costs = ACosts;
			IsModify = false;
		    
			InitializeComponent();
			SyncForm();
		}
		
		//синхронизация формы(параметров, выпадающих списков)
		public void SyncForm()
		{
			SyncValuesForComboBoxes();
		}
		
		public void SyncValuesForComboBoxes()
		{
			cbTypeCost.Items.Clear();
			cbPlace.Items.Clear();
			foreach(Dictionary<string, string> vRow in Directory.Rows)
			{
				if (vRow["Type"] == "Cost")
				{
					cbTypeCost.Items.Add(vRow["Name"]);
				}
				if (vRow["Type"] == "Place")
				{
					cbPlace.Items.Add(vRow["Name"]);
				}				
			}
			
		}
				
		void AddTypeCostClick(object sender, EventArgs e)
		{
			frmEditDirectory editDirectory = new frmEditDirectory((sender as Button).Name, Directory);
			editDirectory.ShowDialog();
			SyncValuesForComboBoxes();
		}
		
		void BtnCancelClick(object sender, EventArgs e)
		{
			Close();
		}
		
		void AddPlaceClick(object sender, EventArgs e)
		{
			frmEditDirectory editDirectory = new frmEditDirectory((sender as Button).Name, Directory);
			editDirectory.ShowDialog();
			SyncValuesForComboBoxes();			
		}
		
		void SelectTagsClick(object sender, EventArgs e)
		{
			frmEditDirectory editDirectory = new frmEditDirectory((sender as Button).Name, Directory);
			editDirectory.ShowDialog();
			SyncValuesForComboBoxes();			
		}
		
		void BtnOkClick(object sender, EventArgs e)
		{
			//Проверки
			if (Checks.IsNull("Сумма", eValue) ||
			    Checks.IsNull("Тип расхода", cbTypeCost) ||
			    Checks.IsNull("Место", cbPlace) ||
			    Checks.IsString("Сумма", eValue))
			{
				return;
			}
			
			//Добавление в модель
			Dictionary<string, string> vRow = new Dictionary<string, string>();
			vRow.Add("ID", Costs.GetNextID());
			vRow.Add("Comment", eComment.Text);
			vRow.Add("Date", eDate.Value.ToString());
			vRow.Add("Value", eValue.Text);
			vRow.Add("Type", Directory.GetIDByTypeAndName("Cost", cbTypeCost.Text));
			vRow.Add("Place", Directory.GetIDByTypeAndName("Place", cbPlace.Text));
			vRow.Add("Tag", eTags.Text);
			vRow.Add("State", "add");
			
			Costs.Rows.Add(vRow);
			
			IsModify = true;
			Close();
		}
	}
}
