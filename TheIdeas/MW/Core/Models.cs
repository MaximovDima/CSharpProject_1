using System;
using System.Collections.Generic;
using MW.Utils;

namespace MW.Core
{
	//Фабрика моделей
	public class ModelFactory
	{
		public TModel GetModel(string ATableName)
		{
			TModel vReturn = null;
			switch (ATableName)
			{
				case "Log":
					vReturn = new TLogs(ATableName);
					break;
				case "Income":
					vReturn = new TIncomes(ATableName);
					break; 
				case "Cost":
					vReturn = new TCosts(ATableName);
					break;
				case "Directory":
					vReturn = new TDirectory(ATableName);
					break;
					
				default:
					throw new ArgumentException("Таблицы " + ATableName + " не существует!");
			}
			return vReturn;
		}
	}
	
	//Шаблон общей строки
	public abstract class TRow
	{
		//Индекс строки в модели
		public int Index;
		//Идентификатор из таблицы БД
		public int ID;
		//Примечание
		public string Comment;
			
		public TRow(int AIndex, int AID, string AComment)
		{
			Index = AIndex;
			ID = AID;
			Comment = AComment;
		}
	}
	
	//Строка с состоянием
	public abstract class TStateRow : TRow
	{
		//Состояние (Current/Add/Edit/Delete)
		public string State;
		
		public TStateRow(int AIndex, int AID, string AComment, string AState) : base(AIndex, AID, AComment) 
		{
			State = AState;
		}
	}
	
	//Датированная строка
	public abstract class TDateRow : TRow
	{
		//Дата
		public string DateTime;
		
		public TDateRow(int AIndex, int AID, string AComment, string ADateTime) : base(AIndex, AID, AComment) 
		{
			DateTime = ADateTime;
		}
	}
	
	//Строка с численным значением и состоянием
	public abstract class TValueAndStateRow : TDateRow
	{
		//Значение
		public int Value;
		//Состояние (Current/Add/Edit/Delete)
		public string State;
		
		public TValueAndStateRow(int AIndex, int AID, string AComment, string ADateTime, 
			int AValue, string AState) : base(AIndex, AID, AComment, ADateTime)
		{
			Value = AValue;
			State = AState;
		}
	}
	
	//Общий шаблон модели	
	public abstract class TModel
	{		
		//Наименование
		public string Name;
		//Список полей в БД
		public string[] Fields;
		//Текущее количество строк
		public int RowCount;
		
		public TModel(string AName)
		{
			Name = AName; 
		}
		
		//Создание строки синхронизированной с данными
		public abstract void CreateNewRow(Dictionary<string, string> ARow);

		//Очистка данных
		public abstract void Clear();
		
		//Строку которую надо удалить
		public abstract int GetDeleteRowID();
		
		//Синхронизация изменений
		public abstract void ReFillChangeRows(List<Dictionary<string, string>> AInsertRows, 
		                                      Dictionary<string, string> AUpdateRow);
	}
	
	//Модель логирования
	public class TLogs : TModel
	{
		//Список строк
		public List<TRowLog> Rows;
		//строка лога
		public class TRowLog : TDateRow
		{
			//Тип действия
			public string ActionType;
			//Тип устройства
			public string AdviceType;
			//Изменение
			public string Change;
			//Пользователь
			public string User;			
			
			public TRowLog(int AIndex, int AID, string AComment, string ADateTime, string AActionType, string AAdviceType, 
	    		string AChange, string AUser) : base(AIndex, AID, AComment, ADateTime)
			{
				ActionType = AActionType;
				AdviceType = AAdviceType;
				Change = AChange;
				User = AUser;
			}
		}
			
		public TLogs(string AName) : base(AName)
		{
			RowCount = 0;
			Rows = new List<TRowLog>();
			Fields = new string[] {"ID", "Comment", "Date", "ActionType", "AdviceType", "Change", "User"};
		}
		
		public override void CreateNewRow(Dictionary<string, string> ARow)
		{
	    		TRowLog Row = new TRowLog(RowCount++,
			        Format.StrToInt(ARow["ID"]),
					ARow["Comment"],
					ARow["Date"],
					ARow["ActionType"],
					ARow["AdviceType"],
					ARow["Change"],
					ARow["User"]);
            	Rows.Add(Row);
		}
		
		public override void Clear()
		{
			RowCount = 0;
			Rows.Clear();
		}
		
		public override int GetDeleteRowID()
		{
			return -1;
		}
		
		public override void ReFillChangeRows(List<Dictionary<string, string>> AInsertRows, 
		                                      Dictionary<string, string> AUpdateRow)
		{
			
		}
	}

	//Модель доходы
	public class TIncomes : TModel
	{
		//Список строк
		public List<TRowIncome> Rows;
		//строка дохода
		public class TRowIncome : TValueAndStateRow
		{
			//Тип
			public int IncomeType;
			
			public TRowIncome(int AIndex, int AID, string AComment, string ADateTime, int AValue, 
				string AState, int AIncomeType) : base(AIndex, AID, AComment, ADateTime, AValue, AState)
			{
				IncomeType = AIncomeType;
			}
		}
			
		public TIncomes(string AName) : base(AName)
		{
			RowCount = 0;
			Rows = new List<TRowIncome>();
			Fields = new string[] {"ID", "Comment", "Date", "Value", "IncomeType"};
		}
		
		public override void CreateNewRow(Dictionary<string, string> ARow)
		{
	    		TRowIncome Row = new TRowIncome(RowCount++,
					Format.StrToInt(ARow["ID"]),
					ARow["Comment"],
					ARow["Date"],
					Format.StrToInt(ARow["Value"]),
					"Current",
					Format.StrToInt(ARow["IncomeType"]));
            	Rows.Add(Row);
		}
		
		public override void Clear()
		{
			RowCount = 0;
			Rows.Clear();
		}
		
		public override int GetDeleteRowID()
		{
			int vID = -1;
			foreach(TRowIncome vRow in Rows)
			{
				if (vRow.State == "delete")
				{
					vID = vRow.ID;
					break;
				}
			}
			return vID;
		}
		
		public override void ReFillChangeRows(List<Dictionary<string, string>> AInsertRows, 
		                                      Dictionary<string, string> AUpdateRow)
		{
			
		}
	}

	//Модель расходы
	public class TCosts : TModel
	{
		//Список строк
		public List<TRowCost> Rows;
		//строка дохода
		public class TRowCost : TValueAndStateRow
		{
			//Тип
			public int CostType;
			//Место
			public int Place ;
			//Тэг
			public int Tag;
			
			public TRowCost(int AIndex, int AID, string AComment, string ADateTime, int AValue, 
				string AState, int ACostType, int APlace, int ATag) : base(AIndex, AID, AComment, ADateTime, AValue, AState)
			{
				CostType = ACostType;
				Place = APlace;
				Tag = ATag;
			}
		}
			
		public TCosts(string AName) : base(AName)
		{
			RowCount = 0;
			Rows = new List<TRowCost>();
			Fields = new string[] {"ID", "Comment", "Date", "Value", "CostType", "Place", "Tag"};
		}
		
		public override void CreateNewRow(Dictionary<string, string> ARow)
		{
	    		TRowCost Row = new TRowCost(RowCount++,
					Format.StrToInt(ARow["ID"]),
					ARow["Comment"],
					ARow["Date"],
					Format.StrToInt(ARow["Value"]),
					"Current",
					Format.StrToInt(ARow["CostType"]),
					Format.StrToInt(ARow["Place"]),
					Format.StrToInt(ARow["Tag"]));
            	Rows.Add(Row);
		}
		
		public void Add(string AComment, string ADate, int AValue, int ACostType, int APlace, int ATag)
		{
			TRowCost Row = new TRowCost(RowCount++, 0, AComment, ADate, AValue, "Add", ACostType, APlace, ATag);
			Rows.Add(Row);
		}
		
		public override void Clear()
		{
			RowCount = 0;
			Rows.Clear();
		}
		
		public override int GetDeleteRowID()
		{
			int vID = -1;
			foreach(TRowCost vRow in Rows)
			{
				if (vRow.State == "delete")
				{
					vID = vRow.ID;
					break;
				}
			}
			return vID;
		}
		
		public override void ReFillChangeRows(List<Dictionary<string, string>> AInsertRows, 
		                                      Dictionary<string, string> AUpdateRow)
		{
			
		}		
	}
	
	//Модель справочник
	public class TDirectory : TModel
	{
		//Список строк
		public List<TRowDirectory> Rows;
		//строка справочника
		public class TRowDirectory : TStateRow
		{
			//Наименование
			public string Name;
			//Тип справочника
			public string Type;
			
			public TRowDirectory(int AIndex, int AID, string AComment, string AState,
				string AName, string AType) : base(AIndex, AID, AComment, AState)
			{
				Name = AName;
				Type = AType;
			}
		}
		//Конструктор	
		public TDirectory (string AName) : base(AName)
		{
			RowCount = 1;
			Rows = new List<TRowDirectory>();
			Fields = new string[] {"ID", "Name", "Type", "Comment"};
		}
		//Инициализация из БД
		public override void CreateNewRow(Dictionary<string, string> ARow)
		{
	    		TRowDirectory Row = new TRowDirectory(RowCount++,
					Format.StrToInt(ARow["ID"]),
					ARow["Comment"], 
					"Current",
					ARow["Name"],
					ARow["Type"]);
            	Rows.Add(Row);
		}
		//Проверка на наличие
		public bool Exist(string AType, string AName)
		{
			bool vResult = false;
			
			foreach(TRowDirectory row in Rows)
			{
				if ((row.Type == AType) && (String.Compare(row.Name, AName, true) == 0))
				{
					vResult = true;
					break;
				}
			}
			return vResult;	
		}
		//Определение ID по списку категорий
		public int GetIDByTypeAndName(string AType, string AName)
		{
			int vResult = 0;
			
			foreach(TRowDirectory row in Rows)
			{
				if ((row.Type == AType) && (String.Compare(row.Name, AName, true) == 0))
				{
					vResult = row.Index;
					break;
				}
			}
			return vResult;	
		}
		//Определение категории по ID
		/*public int GetIDByTypeAndName(string AType, int AName)
		{
			int vResult = 0;
			
			foreach(TRowDirectory row in Rows)
			{
				if ((row.Type == AType) && (String.Compare(row.Name, AName, true) == 0))
				{
					vResult = row.ID;
					break;
				}
			}
			return vResult;	
		}*/
		//Добавление в модель пользователем
		public void Add(string AType, string AName, string AComment)
		{
			TRowDirectory Row = new TRowDirectory(RowCount++, 0, AComment, "Add", AName, AType);
			Rows.Add(Row);
		}
		
		public override void Clear()
		{
			RowCount = 0;
			Rows.Clear();
		}
		
		public override int GetDeleteRowID()
		{
			int vID = -1;
			foreach(TRowDirectory vRow in Rows)
			{
				if (vRow.State == "delete")
				{
					vID = vRow.ID;
					break;
				}
			}
			return vID;
		}
		
		public override void ReFillChangeRows(List<Dictionary<string, string>> AInsertRows, 
		                                      Dictionary<string, string> AUpdateRow)
		{
			AInsertRows.Clear();
			AUpdateRow.Clear();
			foreach(TRowDirectory vRow in Rows)
			{
				if (vRow.State == "Edit")
				{
					AUpdateRow["ID"] = Convert.ToString(vRow.ID);
					AUpdateRow["Index"] = Convert.ToString(vRow.Index);
					AUpdateRow["Name"] = Convert.ToString(vRow.Name);
					AUpdateRow["Type"] = Convert.ToString(vRow.Type);
					AUpdateRow["Comment"] = Convert.ToString(vRow.Comment);
				}
				
				if (vRow.State == "Add")
				{
					Dictionary<string, string> vInsertRow = new Dictionary<string, string>();
					
					vInsertRow["ID"] = Convert.ToString(vRow.ID);
					vInsertRow["Index"] = Convert.ToString(vRow.Index);
					vInsertRow["Name"] = Convert.ToString(vRow.Name);
					vInsertRow["Type"] = Convert.ToString(vRow.Type);
					vInsertRow["Comment"] = Convert.ToString(vRow.Comment);
					AInsertRows.Add(vInsertRow);
				}
			}
		}		
	}
}
