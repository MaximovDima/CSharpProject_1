using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

using MW;
using MW.Core;

namespace MW.Forms
{
	public partial class FrmEditFinance : Form
	{
		//Инициализация моделей
		public TModel Directory;
		public TModel FinModel;
		//Флаг регистрации изменения
		public bool IsModify;
		//Флаг редактирования
		public bool IsEdit;
		//Флаг расходы
		public bool IsCosts;
		//Редактируемая строка
		public Dictionary<string, string> EditRow;
		
		public FrmEditFinance(TModel ADirectory, TModel AModel)
		{
			Directory = ADirectory;
			FinModel = AModel;
			IsModify = false;
		    
			InitializeComponent();
		}
		
		//синхронизация формы(параметров, выпадающих списков)
		public void SyncForm()
		{
			if(!IsCosts)
			{
				lblPalce.Enabled = false;
				cbPlace.Enabled = false;
				addPlace.Enabled = false;
				
			}
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
			if(IsCosts)
			{
				cbType.SelectedIndex = cbType.Items.IndexOf(Directory.GetNameByID("Cost", EditRow["Type"]));
				cbPlace.SelectedIndex = cbPlace.Items.IndexOf(Directory.GetNameByID("Place", EditRow["Place"]));
			}
			else
			{
				cbType.SelectedIndex = cbType.Items.IndexOf(Directory.GetNameByID("Income", EditRow["Type"]));
			}
			eComment.Text = EditRow["Comment"];
		}
		
		public void SyncValuesForComboBoxes()
		{
			if(IsCosts)
			{
				cbType.Items.Clear();
				cbPlace.Items.Clear();
				foreach(Dictionary<string, string> vRow in Directory.Rows)
				{
					if (vRow["Type"] == "Cost")
					{
						cbType.Items.Add(vRow["Name"]);
					}
					if (vRow["Type"] == "Place")
					{
						cbPlace.Items.Add(vRow["Name"]);
					}				
				}
			}
			else
			{
				cbType.Items.Clear();
				foreach(Dictionary<string, string> vRow in Directory.Rows)
				{
					if (vRow["Type"] == "Income")
					{
						cbType.Items.Add(vRow["Name"]);
					}			
				}
			}
		}
				
		void AddTypeCostClick(object sender, EventArgs e)
		{
			frmEditDirectory editDirectory = new frmEditDirectory((sender as Button).Name, Directory, IsCosts);
			editDirectory.ShowDialog();
			SyncValuesForComboBoxes();
		}
		
		void BtnCancelClick(object sender, EventArgs e)
		{
			Close();
		}
		
		void AddPlaceClick(object sender, EventArgs e)
		{
			frmEditDirectory editDirectory = new frmEditDirectory((sender as Button).Name, Directory, IsCosts);
			editDirectory.ShowDialog();
			SyncValuesForComboBoxes();			
		}
		
		void BtnOkClick(object sender, EventArgs e)
		{
			//Проверки
			if (Checks.IsNull("Сумма", eValue) ||
			    Checks.IsNull("Тип расхода", cbType) ||
			    (IsCosts && Checks.IsNull("Место", cbPlace)) ||
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
				if(IsCosts)
				{
					EditRow["Type"] = Directory.GetIDByTypeAndName("Cost", cbType.Text);
					EditRow["Place"] = Directory.GetIDByTypeAndName("Place", cbPlace.Text);
				}
				else
				{
					EditRow["Type"] = Directory.GetIDByTypeAndName("Income", cbType.Text);
				}
				EditRow["State"] = "edit";
			}
			else
			//Добавление
			{
				Dictionary<string, string> vRow = new Dictionary<string, string>();
				vRow.Add("ID", FinModel.GetNextID());
				vRow.Add("Comment", eComment.Text);
				vRow.Add("Date", eDate.Value.ToString());
				vRow.Add("Value", eValue.Text);
				if(IsCosts)
				{
					vRow.Add("Type", Directory.GetIDByTypeAndName("Cost", cbType.Text));
					vRow.Add("Place", Directory.GetIDByTypeAndName("Place", cbPlace.Text));
				}
				else
				{
					vRow.Add("Type", Directory.GetIDByTypeAndName("Income", cbType.Text));
				}
				vRow.Add("State", "add");
			
				FinModel.Rows.Add(vRow);
			}
			
			IsModify = true;
			Close();
		}
	}
}
