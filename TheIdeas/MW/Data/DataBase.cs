using System;
using System.Data.SQLite;
using System.Collections.Generic;
using MW.Models;

namespace MW.DataModule
{
	public class TDataBase
	{
		//Путь к БД
		public string Source;
		//Подключение к БД
		public SQLiteConnection Connect;
		
		public TDataBase(string ASource)
		{
			Source = ASource;
			Source = @"D:\projects\CSharpProject_1\TheIdeas\MW\Data\MaxiWiki";
			Connect = new SQLiteConnection("Data Source=" + Source + ";Version=3;");
			Connect.Open();
		}
		
		public TModel GetModel(string ATableName)
		{
			ModelFactory MFactory = new ModelFactory();
			
			TModel Model = MFactory.GetModel(ATableName);
			string sqlQuery = "Select " + Model.Fields + " from " + ATableName;
					
			SQLiteCommand command = new SQLiteCommand(sqlQuery, Connect);
            SQLiteDataReader reader = command.ExecuteReader();
            	
            while (reader.Read())
            {
            	Model.InitDataRow(reader);
            }
			
            return Model;
		}
		
		public void AddDataToTable(string ATableName)
		{

		}
	}
}
