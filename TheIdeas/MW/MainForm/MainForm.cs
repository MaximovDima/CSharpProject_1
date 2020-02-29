using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

using MW.DataModule;
using MW.Models;
using MW.Controller;
using MW.View;
using MW.Forms;


namespace MW
{
	public partial class FrmMainForm : Form
	{
		//управление приложением
		public TApp App;
		
		public FrmMainForm()
		{
			InitializeComponent();
			App = new TApp("SourceDB From MainForm Component");
		}
		
		void Button1Click(object sender, EventArgs e)
		{
//			DB.SyncDataFromTable("Income");				
		}
		
		void Button2Click(object sender, EventArgs e)
		{
//			DB.AddDataToTable("Directory");
		}	
		
		void FinanceClick(object sender, EventArgs e)
		{
			Form form1 = new FrmFinance();
			form1.MdiParent = this;
			form1.Dock = DockStyle.Fill;
			form1.Show();			
		}
	}
	
	//Приложение
	public class TApp
	{
		//Служба работы с данными
		public TDataService DS;
		//Контроллер
		public TInterface View;
		
		public TApp(string ASourceDB)
		{
			DS = new TDataService(ASourceDB);
			View = new TInterface();
		}
	}
	
	public class TDataService
	{
		//подключение к БД
		public TDataBase DB;
		//Модель данных
		public List<TModel> Models;
		
		public TDataService(string ASourceDB)
		{
			DB = new TDataBase(ASourceDB);
			Models = new List<TModel>();
			InitModel("Directory");
		}
		
		public TModel GetModel(string AName)
		{
			TModel result = null;
			foreach(TModel model in  Models)
			{
				if (model.Name == AName)
				{
					result = model;
					break;
				}
			}
			if (result == null) 
			{
				throw new NullReferenceException();	
			}
			return result;
		}
		
		public void InitModel(string ATableName)
		{
			Models.Add(DB.GetModel(ATableName));
		}
	}

	public class TInterface
	{
		//Связь контроллов и моделей
		public TCRUDService Data;
		//Отрисовка
		public TDrwInfo DrwInfo;
	}
}
