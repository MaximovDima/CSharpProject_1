using System;
using System.Data.SQLite;
using System.Collections.Generic;
using MW.Utils;

namespace MW.Data
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
		
		//Результат запроса в виде списка строк	
		public void ReFillModelRows(List<Dictionary<string, string>> ARows, string[] AStrings, string ATableName)
		{
			ARows.Clear();
			string vSQLQuery = "Select " + Format.GetSQL(AStrings) + " from " + ATableName;
			SQLiteCommand command = new SQLiteCommand(vSQLQuery, Connect);
            SQLiteDataReader vReader = command.ExecuteReader();
            while (vReader.Read())
            {
            	Dictionary<string, string> vRow = new Dictionary<string, string>();
            	for(int i = 0; i < AStrings.Length; i++)
            	{
            		vRow[AStrings[i]] = Convert.ToString(vReader[AStrings[i]]);
            	}
            	
            	ARows.Add(vRow);
            }
		}
		
		//Удаление в таблице БД
		public void DeleteRow(string ATableName, int ADeleteID)
		{
			
		}
		
	}
}
