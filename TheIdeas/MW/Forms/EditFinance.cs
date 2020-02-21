using System;
using System.Drawing;
using System.Windows.Forms;

namespace MW.Forms
{
	public partial class FrmEditFinance : Form
	{
		public FrmEditFinance()
		{
			InitializeComponent();
		}
		
		void AddTypeCostClick(object sender, EventArgs e)
		{
			frmEditDirectory editDirectory = new frmEditDirectory((sender as Button).Name);
			editDirectory.Text = "Добавить тип расхода";
			editDirectory.ShowDialog();			
		}
	}
}
