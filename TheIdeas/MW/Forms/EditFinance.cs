using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

using MW;
using MW.Utils;
using MW.Models;

namespace MW.Forms
{
	public partial class FrmEditFinance : Form
	{
		//Инициализация моделей
		public TDirectory Directory;
		public TCosts Costs;
		//Флаг регистрации изменения
		public bool IsModify;
		
		public FrmEditFinance(TDirectory ADirectory, TCosts ACosts)
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
			foreach(TDirectory.TRowDirectory row in Directory.Rows)
			{
				if (row.Type == "TypeCost")
				{
					cbTypeCost.Items.Add(row.Name);
				}
				if (row.Type == "Place")
				{
					cbPlace.Items.Add(row.Name);
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
			Costs.Add(eComment.Text, eDate.Value.ToString(), Format.StrToInt(eValue.Text),
			          Directory.GetIDByTypeAndName("TypeCost", cbTypeCost.Text),  
			          Directory.GetIDByTypeAndName("Place", cbPlace.Text), Format.StrToInt(eTags.Text));
			IsModify = true;
			Close();
		}
	}
}
