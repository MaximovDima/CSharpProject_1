using System;
using System.Drawing;
using System.Windows.Forms;

namespace MW.Forms
{
	public partial class FrmFinance : Form
	{
		public FrmFinance()
		{
			InitializeComponent();
		}
		
		void BtnAddClick(object sender, EventArgs e)
		{
			FrmEditFinance editForm = new FrmEditFinance();
			editForm.Text = "Новый расход...";
			editForm.ShowDialog();
		}
	}
}
