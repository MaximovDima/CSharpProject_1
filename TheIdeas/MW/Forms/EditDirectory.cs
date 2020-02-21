using System;
using System.Drawing;
using System.Windows.Forms;

namespace MW.Forms
{
	public partial class frmEditDirectory : Form
	{
		//Тип справочной информации
		public string Type;
		//Обновление данных
		
		
		public frmEditDirectory(string AType)
		{
			InitializeComponent();
			Type = AType;
		}
	}
}
