using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace MW.Forms
{
	public partial class FrmEditFinance : Form
	{
		//Списки значений для справочников
		public List<string> TypesCost;
		
		public FrmEditFinance()
		{
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
			SyncTypesCost();
//			SyncPlaces();
//			SyncTags();
		}
		
		public void SyncTypesCost()
		{
			TypesCost = new List<string>();
//			Data.FillListValues(TypesCost, Models.Dy
		}
		
		void AddTypeCostClick(object sender, EventArgs e)
		{
			frmEditDirectory editDirectory = new frmEditDirectory((sender as Button).Name);
			editDirectory.ShowDialog();			
		}
		
		void BtnCancelClick(object sender, EventArgs e)
		{
			Close();
		}
		
		void AddPlaceClick(object sender, EventArgs e)
		{
			frmEditDirectory editDirectory = new frmEditDirectory((sender as Button).Name);
			editDirectory.ShowDialog();				
		}
		
		void SelectTagsClick(object sender, EventArgs e)
		{
			frmEditDirectory editDirectory = new frmEditDirectory((sender as Button).Name);
			editDirectory.ShowDialog();				
		}
	}
}
