using System;
using System.Drawing;
using System.Windows.Forms;

using MW.Models;

namespace MW.Forms
{
	public partial class FrmFinance : Form
	{
		//Инициализация моделей
		public TDirectory Directory;
		public TCosts Costs;
		
		public FrmFinance()
		{
			InitializeComponent();
			Directory = (TDirectory)Program.App.DS.GetModel("Directory");
			Costs = (TCosts)Program.App.DS.GetModel("Cost");
		}
		
		void BtnAddClick(object sender, EventArgs e)
		{
			FrmEditFinance editForm = new FrmEditFinance(Directory, Costs);
			editForm.Text = "Новый расход...";
			editForm.ShowDialog();
			if (editForm.IsModify)
			{
				int q = 1;	
			}
			
		}
	}
}
