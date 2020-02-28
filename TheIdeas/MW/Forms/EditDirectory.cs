using System;
using System.Drawing;
using System.Windows.Forms;
using MW.Utils;

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
			SyncForm();
		}
		
		//Инициализация справочника
		public void SyncForm()
		{
			SyncName();
					
		}
		
		//Синхронизация наименования
		public void SyncName()
		{
			switch (Type)
			{
				case "addTypeCost":
					Text = "Добавить тип расхода";
					break;
				case "addPlace":
					Text = "Добавить место расхода";
					break; 
				case "SelectTags":
					Text = "Добавить тэги";
					eComment.Enabled = false ;
					break;
					
				default:
					Text = "Новый тип";
					break;
			}
		}	
		
		void BtnCancelClick(object sender, EventArgs e)
		{
			Close();			
		}
		
		void BtnOkClick(object sender, EventArgs e)
		{
			Checks.CheckNull("Наименование", eName);
//			CheckExist();
		}
	}
}
