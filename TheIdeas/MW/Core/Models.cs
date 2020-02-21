using System;
using System.Data.SQLite;
using System.Collections.Generic;

namespace MW.Models
{
	//Фабрика моделей
	public class ModelFactory
	{
		public TModel GetModel(string ATableName)
		{
			TModel toReturn = null;
			switch (ATableName)
			{
				case "Log":
					toReturn = new TLogs(ATableName);
					break;
				case "Income":
					toReturn = new TIncomes(ATableName);
					break; 
				case "Cost":
					toReturn = new TCosts(ATableName);
					break;
					
				default:
					throw new ArgumentException("Таблицы " + ATableName + " не существует!");
			}
			return toReturn;
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
		public string Fields;
		//Текущее количество строк
		public int RowCount;
		
		public TModel(string AName)
		{
			Name = AName; 
		}
		
		//инициализация данных
		public abstract void InitDataRow(SQLiteDataReader AReader);
		
		//Добавление новых данных
		public virtual void AddDataRow()
		{
		}
		
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
			Fields = " ID, Comment, Date, ActionType, AdviceType, Change, User";
		}
		
		public void AddDataRow(TDateRow ARow)
		{
		
		}
		
		public override void InitDataRow(SQLiteDataReader AReader)
		{
	    		TRowLog Row = new TRowLog(RowCount++,
					Convert.ToInt32(AReader["ID"]),
					Convert.ToString(AReader["Comment"]),
					Convert.ToString(AReader["Date"]),
					Convert.ToString(AReader["ActionType"]),
					Convert.ToString(AReader["AdviceType"]),
					Convert.ToString(AReader["Change"]),
					Convert.ToString(AReader["User"]));
            	Rows.Add(Row);
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
			Fields = " ID, Comment, Date, Value, IncomeType";
		}
		
		public override void InitDataRow(SQLiteDataReader AReader)
		{
	    		TRowIncome Row = new TRowIncome(RowCount++,
					Convert.ToInt32(AReader["ID"]),
					Convert.ToString(AReader["Comment"]),
					Convert.ToString(AReader["Date"]),
					Convert.ToInt32(AReader["Value"]),
					Convert.ToString(AReader["State"]),
					Convert.ToInt32(AReader["IncomeType"]));
            	Rows.Add(Row);
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
			Fields = " ID, Comment, Date, Value, CostType, Place, Tag";
		}
		
		public override void InitDataRow(SQLiteDataReader AReader)
		{
	    		TRowCost Row = new TRowCost(RowCount++,
					Convert.ToInt32(AReader["ID"]),
					Convert.ToString(AReader["Comment"]),
					Convert.ToString(AReader["Date"]),
					Convert.ToInt32(AReader["Value"]),
					Convert.ToString(AReader["State"]),
					Convert.ToInt32(AReader["CostType"]),
					Convert.ToInt32(AReader["Place"]),
					Convert.ToInt32(AReader["Tag"]));
            	Rows.Add(Row);
		}
		
	}
	
	//Модель справочник
	public class TDirectory : TModel
	{
		//Список строк
		public List<TRowDirectory> Rows;
		//строка справочника
		public class TRowDirectory : TRow
		{
			//Наименование
			public string Name;
			
			public TRowDirectory(int AIndex, int AID, string AComment, 
				string AName) : base(AIndex, AID, AComment)
			{
				Name = AName;
			}
		}
			
		public TDirectory (string AName) : base(AName)
		{
			RowCount = 0;
			Rows = new List<TRowDirectory>();
			Fields = " ID, Name, Comment";
		}
		
		public override void InitDataRow(SQLiteDataReader AReader)
		{
	    		TRowDirectory Row = new TRowDirectory(RowCount++,
					Convert.ToInt32(AReader["ID"]),
					Convert.ToString(AReader["Comment"]),
					Convert.ToString(AReader["NAme"]));
            	Rows.Add(Row);
		}
		
	}
}
