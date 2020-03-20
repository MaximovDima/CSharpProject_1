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
			Connect = new SQLiteConnection("Data Source=" + Source + ";Version=3;");
			Connect.Open();
		}
		
		//Результат запроса в виде списка строк	
		public void ReFillModelRows(List<Dictionary<string, string>> ARows, string[] AFields, string ATableName)
		{
			ARows.Clear();
			string vSQLQuery = "Select " + Format.GetSQL(AFields) + " from " + ATableName;
			SQLiteCommand command = new SQLiteCommand(vSQLQuery, Connect);
            SQLiteDataReader vReader = command.ExecuteReader();
            while (vReader.Read())
            {
            	Dictionary<string, string> vRow = new Dictionary<string, string>();
            	for(int i = 0; i < AFields.Length; i++)
            	{
            		vRow.Add(AFields[i], Format.ObjToStr(vReader[AFields[i]]));
            	}
            	vRow.Add("State", "current");
            	
            	ARows.Add(vRow);
            }
		}
		
		//Результат запроса в виде списка строк	
		public string InsertRow(Dictionary<string, string> ARow, string[] AFields, string ATableName)
		{
			string[] vValues = new string[AFields.Length];
			string[] vReturnValues = new string[AFields.Length];
			for(int i = 0; i < AFields.Length; i++)
			{
				vValues[i] = "'" + ARow[AFields[i]] + "'";
				vReturnValues[i] = ARow[AFields[i]];
			}
			string vSQLQuery = "Insert into " + ATableName + " (" + Format.GetSQL(AFields) +") values (" + Format.GetSQL(vValues) + ")";
			SQLiteCommand command = new SQLiteCommand(vSQLQuery, Connect);
			command.ExecuteNonQuery();
			
			return Format.GetSQL(vReturnValues);
		}
		
		//Результат запроса в виде обновленного списка строк	
		public string UpdateRow(Dictionary<string, string> ARow, string[] AFields, string ATableName)
		{
			//ID всегда идет первым в конфигурации
			string[] vValues = new string[AFields.Length - 1];
			string[] vReturnValues = new string[AFields.Length - 1];
			for(int i = 1; i < AFields.Length; i++)
			{
				vValues[i - 1] = AFields[i] + " = "+ "'" + ARow[AFields[i]] + "'";
				vReturnValues[i - 1] = AFields[i] + " = " + ARow[AFields[i]];
			}
			string vSQLQuery = "Update " + ATableName + " set " + Format.GetSQL(vValues) + " where ID = " + ARow["ID"];
			SQLiteCommand command = new SQLiteCommand(vSQLQuery, Connect);
			command.ExecuteNonQuery();

			return Format.GetSQL(vReturnValues);
		}
		
		//Удаление в таблице БД
		public void DeleteRow(string ATableName, int ADeleteID)
		{
			string vSQLQuery = "Delete from " + ATableName + " where ID = " + Format.IntToStr(ADeleteID);
			SQLiteCommand command = new SQLiteCommand(vSQLQuery, Connect);
			command.ExecuteNonQuery();
		}
		
	}
}
