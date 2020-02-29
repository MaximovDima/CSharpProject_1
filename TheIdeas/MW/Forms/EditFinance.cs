using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

using MW;
using MW.Models;

namespace MW.Forms
{
	public partial class FrmEditFinance : Form
	{
		//Инициализация модели справочника
		public TDirectory Directory;
		//Списки значений для справочников
		public List<string> TypesCost;
		
		public FrmEditFinance()
		{
			InitializeComponent();
			Directory = (TDirectory)Program.App.DS.GetModel("Directory");
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
					cbTypeCost.Items.Insert(row.ID, row.Name);
				}
				if (row.Type == "Place")
				{
					cbPlace.Items.Insert(row.ID, row.Name);
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
	}
}
