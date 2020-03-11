using System;
using System.Collections.Generic;
using System.Data.SQLite;

using MW.Core;

namespace MW.Data
{
	public class TData
	{
		//подключение к БД
		public TDataBase DB;
		//Модель данных
		public List<TModel> Models;
		
		public TData(string ASourceDB)
		{
			DB = new TDataBase(ASourceDB);
			Models = new List<TModel>();
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
			ModelFactory vMFactory = new ModelFactory();
			TModel vModel = vMFactory.GetModel(ATableName);
			GetData(vModel);
			Models.Add(vModel);
            
            return vModel;
		}
		//Заполнение таблицы данными
		public void GetData(TModel AModel)
		{
			List<Dictionary<string, string>> vRows = new List<Dictionary<string, string>>();
			DB.ReFillModelRows(vRows, AModel.Fields, AModel.Name);
            	
            foreach(Dictionary<string, string> vRow in vRows)
            {
            	AModel.CreateNewRow(vRow);
            }
		}
		
		//Синхронизация модели данных с БД
		public void SetData(TModel AModel)
		{
			List<Dictionary<string, string>> vInsertRows = new List<Dictionary<string, string>>();
			Dictionary<string, string> vUpdateRow = new Dictionary<string, string>();
			int vDeleteID = AModel.GetDeleteRowID();
			if (vDeleteID > -1)
			{
				DB.DeleteRow(AModel.Name, vDeleteID);
				//лог
				return;
			}
			//Заполнение изменений
			AModel.ReFillChangeRows(vInsertRows, vUpdateRow);
			//вставка			
			if (vInsertRows.Count > 0)
			{
				foreach(Dictionary<string, string> vRow in vInsertRows)
				{
					//Формируем логи
				}
			}//обновление
			else if (vUpdateRow.Count > 0)
			{
				
			}
			
			//Insert Logs
		}
		
		//Обновление данных модели
		public void UpdateModel(string AName)
		{
			TModel vModel = GetModel(AName);
			SetData(vModel);
			vModel.Clear();
			GetData(vModel);
			
		}
	}
}