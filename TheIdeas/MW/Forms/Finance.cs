using System;
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
			}
			
		}
	}
}
