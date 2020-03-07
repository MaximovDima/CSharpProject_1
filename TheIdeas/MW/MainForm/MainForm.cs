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
		//список форм-разделов
		public List<Form> Forms;
		
		public FrmMainForm()
		{
			InitializeComponent();
			Forms = new List<Form>();
			App = new TApp("SourceDB From MainForm Component");
		}
		//Поиск раздела (создание если еще не создан)
		public Form GetForm(string AName)
		{
			Form vResult = null;
			foreach(Form form in Forms)
			{
				if (form.Name == AName)
				{
					vResult = form;
				}
				else
				{
					form.Hide();
				}
			}
			if (vResult == null)
			{
				switch (AName)
				{
					case "FrmFinance":
						vResult = new FrmFinance();
						break;
					case "FrmGKH":
						vResult = new FrmGKH();
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
			InitModel("Cost");
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
