using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using MW.Utils;
using MW.Models;

namespace MW.Forms
{
	public partial class frmEditDirectory : Form
	{
		//Подгрузка справочника
		public TDirectory Directory;
		//Тип справочной информации
		public string Type;
		
		public frmEditDirectory(string ATypeName, TDirectory ADirectory)
		{
			InitializeComponent();
			Directory = ADirectory;
			SyncForm(ATypeName);
		}
		
		//Инициализация справочника
		public void SyncForm(string ATypeName)
		{
			SyncName(ATypeName);					
		}
		
		//Синхронизация наименования
		public void SyncName(string ATypeName)
		{
			switch (ATypeName)
			{
				case "addTypeCost":
					Text = "Добавить тип расхода";
					Type = "TypeCost";
					break;
				case "addPlace":
					Text = "Добавить место расхода";
					Type = "Place";
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
		
		//синхронизация текущих значений (необходима для исключения
		// дублирующих значений)
		public void SyncExistValueByType(string AType)
		{
			
		}
		
		void BtnCancelClick(object sender, EventArgs e)
		{
			Close();			
		}
		
		void BtnOkClick(object sender, EventArgs e)
		{
			//Проверки
			if (Checks.IsNull("Наименование", eName) || IsExist())
			{
				return;
			}
			//Добавление в модель
			Directory.Add(Type, eName.Text, eComment.Text);
			Close();
		}
		
		//Проверка на дубликат
		public bool IsExist()
		{
			if (Directory.Exist(Type, eName.Text))
			{
				MessageBox.Show("Раздел '" + eName.Text + "' уже существует!", "Дубликация", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return true;
			}
			else return false;
		}
	}
}
