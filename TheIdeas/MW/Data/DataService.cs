using System;
using System.Collections.Generic;
using System.Data.SQLite;

using MW.Core;
using MW.Utils;

namespace MW.Data
{
	public class TData
	{
		//подключение к БД
		public TDataBase DB;
		//Модель данных
		public List<TModel> Models;
		//Конфигурации (пока захардкодим, реализация настройки в отедельном файле!)
		public string SourceDB = @"D:\MaxiWiki";
		public string[] LogFields = new string[] {"ID", "Comment", "Date", "ActionType", "AdviceType", "Change", "User"};
		public string[] DirectoryFields = new string[] {"ID", "Name", "Type", "Comment"};
		public string[] CostFields = new string[] {"ID", "Comment", "Date", "Value", "Type", "Place", "Tag"};
		public string[] IncomeFields = new string[] {"ID", "Date", "Value", "Type", "Comment"};
		
		public TData(string ASourceFile)
		{
			DB = new TDataBase(SourceDB);
			Models = new List<TModel>();
		}
		
		public string[] GetFields(string AName)
		{
			switch (AName)
			{
				case "Log":
					return LogFields;
				case "Directory":
					return DirectoryFields;
				case "Cost":
					return CostFields;
				case "Income":
					return IncomeFields;
				
				default:
					throw new ArgumentException("Таблицы " + AName + " не существует!");
			}				
		}
		
		public TModel GetModel(string AName)
		{
			TModel vResult = null;
			foreach(TModel vModel in  Models)
			{
				if (vModel.Name == AName)
				{
					vResult = vModel;
					break;
				}
			}
			if (vResult == null) 
			{		
				vResult = CreateModel(AName);
			}
			return vResult;
		}
		//Создание новой модели по таблице БД
		public TModel CreateModel(string ATableName)
		{
			TModel vModel = new TModel(ATableName, GetFields(ATableName));
			GetData(vModel);
			Models.Add(vModel);
            
            return vModel;
		}
		//Заполнение таблицы данными
		public void GetData(TModel AModel)
		{
			DB.ReFillModelRows(AModel.Rows, AModel.Fields, AModel.Name);
		}
		
		//Синхронизация модели данных с БД
		public void SetData(TModel AModel)
		{
			int vDeleteID = AModel.GetDeleteRowID();
			if (vDeleteID > -1)
			{
				DB.DeleteRow(AModel.Name, vDeleteID);
				
				Dictionary<string, string> vLogRow = new Dictionary<string, string>();
				vLogRow.Add("ID", "1");
				vLogRow.Add("Comment", "auto");
				vLogRow.Add("Date", DateTime.Now.ToString());
				vLogRow.Add("AdviceType", "PC");
				vLogRow.Add("User", "Maximov");
				vLogRow.Add("ActionType", "Удаление");
				vLogRow.Add("Change", "Данные: " + AModel.Name + "/ Ключ строки = " + Format.IntToStr(vDeleteID));
				DB.InsertRow(vLogRow, LogFields, "Log");
				
				return;
			}
			
			//Синхронизация изменений
			foreach(Dictionary<string, string> vRow in AModel.Rows)
			{
				if ((vRow["State"] == "add") || (vRow["State"] == "edit"))
				{
					Dictionary<string, string> vLogRow = new Dictionary<string, string>();
					vLogRow.Add("ID", "1");
					vLogRow.Add("Comment", "auto");
					vLogRow.Add("Date", DateTime.Now.ToString());
					vLogRow.Add("AdviceType", "PC");
					vLogRow.Add("User", "Maximov");
					//вставка			
					if (vRow["State"] == "add")
					{
						string vNewValues = DB.InsertRow(vRow, AModel.Fields, AModel.Name);
						vLogRow.Add("ActionType", "Добавление");
						string vChange = AModel.Name + ": " + vNewValues; 
						vLogRow.Add("Change", vChange);
					}//обновление
					else if (vRow["State"] == "edit")
					{
						string vNewValues = DB.UpdateRow(vRow, AModel.Fields, AModel.Name);
						vLogRow.Add("ActionType", "Редактирование");
						string vChange = AModel.Name + ": " + vNewValues; 
						vLogRow.Add("Change", vChange);
					}
			
					//Insert Logs
					DB.InsertRow(vLogRow, LogFields, "Log");
				}
			}
		}

			
		//Обновление данных модели
		public void UpdateModel(string AName)
		{
			TModel vModel = GetModel(AName);
			SetData(vModel);
			vModel.Rows.Clear();
			GetData(vModel);
			
		}
	}
}