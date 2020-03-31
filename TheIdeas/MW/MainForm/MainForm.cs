using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

using MW.Data;
using MW.Forms;


namespace MW
{
	public partial class FrmMainForm : Form
	{
		//управление приложением
		public TData Data;
		//список форм-разделов
		public List<Form> Forms;
		
		public FrmMainForm()
		{
			InitializeComponent();
			Forms = new List<Form>();
			Data = new TData("Передаем Config");
		}
		//Поиск раздела (создание если еще не создан)
		public Form GetForm(string AName)
		{
			Form vResult = null;
			foreach(Form vForm in Forms)
			{
				if (vForm.Name == AName)
				{
					vResult = vForm;
				}
				else
				{
					vForm.Hide();
				}
			}
			if (vResult == null)
			{
				switch (AName)
				{
					case "FrmFinance":
						vResult = new FrmFinance(Data);
						break;
					case "FrmGKH":
						vResult = new FrmGKH(Data);
						break; 
						
					default:
						throw new ArgumentException("Формы " + AName + " не существует!");
				}
				Forms.Add(vResult);
			}
			vResult.MdiParent = this;
			vResult.Dock = DockStyle.Fill;
			
			return vResult;
		}
		
		void FinanceClick(object sender, EventArgs e)
		{
			GetForm("FrmFinance").Show();			
		}
		
		void GKHClick(object sender, EventArgs e)
		{
			GetForm("FrmGKH").Show();			
		}
	}
}
