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
		//Флаг редактирования
		public bool IsEdit;
		//Флаг расходы
		public bool IsCosts;
		//Редактируемая строка
		public Dictionary<string, string> EditRow;
		
		public FrmEditFinance(TModel ADirectory, TModel ACosts)
		{
			Directory = ADirectory;
		    Costs = ACosts;
			IsModify = false;
		    
			InitializeComponent();
		}
		
		//синхронизация формы(параметров, выпадающих списков)
		public void SyncForm()
		{
			SyncValuesForComboBoxes();
			if(IsEdit)
			{
				SyncEdits();
			}
		}
		
		//Синхронизация контролов в случае редактирования
		public void SyncEdits()
		{
			eDate.Value = Convert.ToDateTime(EditRow["Date"]);
			eValue.Text = EditRow["Value"];
			cbTypeCost.SelectedIndex = cbTypeCost.Items.IndexOf(Directory.GetNameByID("Cost", EditRow["Type"]));
			cbPlace.SelectedIndex = cbPlace.Items.IndexOf(Directory.GetNameByID("Place", EditRow["Place"]));
			eComment.Text = EditRow["Comment"];
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
			
			//Обновление
			if(IsEdit)
			{
				EditRow["Comment"] = eComment.Text;
				EditRow["Date"] = eDate.Value.ToString();
				EditRow["Value"] = eValue.Text;
				EditRow["Type"] = Directory.GetIDByTypeAndName("Cost", cbTypeCost.Text);
				EditRow["Place"] = Directory.GetIDByTypeAndName("Place", cbPlace.Text);
				EditRow["Tag"] = eTags.Text;
				EditRow["State"] = "edit";
			}
			else
			//Добавление
			{
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
			}
			
			IsModify = true;
			Close();
		}
	}
}
