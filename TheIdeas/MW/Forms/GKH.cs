using System;
using System.Drawing;
using System.Windows.Forms;

using MW.Data;
using MW.Core;

namespace MW.Forms
{
	public partial class FrmGKH : Form
	{
		public FrmGKH(TData AData)
		{
			InitializeComponent();
			TModel logs = AData.GetModel("Log");
		}
	}
}
