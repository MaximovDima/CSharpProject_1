using System;
using System.Collections.Generic;

namespace MW.Core
{	
	//Общий шаблон модели	
	public class TModel
	{		
		//Наименование
		public string Name;
		//Список полей в БД
		public string[] Fields;
		//Строки
		public List<Dictionary<string, string>> Rows;
		
		public TModel(string AName, string[] AFields)
		{
			Name = AName;
			Fields = AFields;			
			Rows = new List<Dictionary<string, string>>();
		}		
		
		//возвращает следующий ID (в виде строки)
		public string GetNextID()
		{
			return Format.IntToStr(Rows.Count + 1);
		}
		
		//Проверка на дубликат строки
		public bool ExistDataRow(string AType, string AName)
		{
			bool vResult = false;
			
			foreach(Dictionary<string, string> vRow in Rows)
			{
				if ((vRow["Type"] == AType) && (String.Compare(vRow["Name"], AName, true) == 0))
				{
					vResult = true;
					break;
				}
			}
			return vResult;			
		}
		
		//Определение ID по списку категорий (в виде строки)
		public string GetIDByTypeAndName(string AType, string AName)
		{
			string vResult = "";
			
			foreach(Dictionary<string, string> vRow in Rows)
			{
				if ((vRow["Type"] == AType) && (String.Compare(vRow["Name"], AName, true) == 0))
				{
					vResult = vRow["ID"];
					break;
				}
			}
			return vResult;	
		}
		
		//Определение наименования по списку категорий
		public string GetNameByID(string AType, string AID)
		{
			string vResult = "";
			
			foreach(Dictionary<string, string> vRow in Rows)
			{
				if ((vRow["Type"] == AType) && (vRow["ID"] == AID))
				{
					vResult = vRow["Name"];
					break;
				}
			}
			return vResult;	
		}
		
		//Определение строки по списку идентфикатору
		public Dictionary<string, string> GetByID(string AID)
		{
			Dictionary<string, string> vResult = null;
			
			foreach(Dictionary<string, string> vRow in Rows)
			{
				if (vRow["ID"] == AID)
				{
					vResult = vRow;
					break;
				}
			}
			return vResult;	
		}
		
		//Строку которую надо удалить
		public int GetDeleteRowID()
		{
			int vID = -1;
			foreach(Dictionary<string, string> vRow in Rows)
			{
				if (vRow["State"] == "delete")
				{
					vID = Format.StrToInt(vRow["ID"]);
					break;
				}
			}
			return vID;
		}
		
		//Возвращает сумму по числовому полю
		public string GetTextSum(string AFieldName)
		{
			int vResult = 0;
			foreach(Dictionary<string, string> vRow in Rows)
			{
				vResult = vResult + Format.StrToInt(vRow[AFieldName]);
			}
			
			return Format.IntToStr(vResult);
		}
		
		//Возвращает среднее в сутки по числовому полю (по максимальный сущ. дату)
		public string GetTextAverageDay(string AFieldName)
		{
			double vResult = 0;
			DateTime vFirstDate = new DateTime(2020, 1, 1);
			string vDate = Convert.ToString(DateTime.Now);
			TimeSpan vTime = Convert.ToDateTime(vDate) - vFirstDate;

			foreach(Dictionary<string, string> vRow in Rows)
			{
				vResult = vResult + Format.StrToInt(vRow[AFieldName]);
			}
			
			return Format.ObjToStr(vResult / (vTime.Days));
		}
		
		//Заполняет список точками для графика
		public void ReFill(List<TFuncPoint> APoints)
		{
			APoints.Clear();
			DateTime d1 = new DateTime(2020, 1, 1);
    		DateTime d2 = DateTime.Now;
    		TimeSpan time = d2 - d1;
    		for (int i = 1; i < time.Days+1; i++) 
    		{
    			double vSum = GetSumByDate(d1.AddDays(i));
    			TFuncPoint p = new TFuncPoint(i, d1.AddDays(i).ToString("dd/MM/yyyy"), vSum/1000);
    			APoints.Add(p);
    		}
		}
		
		//Заполняет сгруппированный список
		public void ReFill(Dictionary<string, int> AParts, string AGroupFactor)
		{
			AParts.Clear();
			int vCurrValue = 0;
			int vSumValue = 0;
			foreach(Dictionary<string, string> vRow in Rows)
			{
				if (AParts.ContainsKey(vRow[AGroupFactor]))
				{
					vSumValue = AParts[vRow[AGroupFactor]];
					vCurrValue = Format.StrToInt(vRow["Value"]);
					vSumValue = vSumValue + vCurrValue;
					AParts[vRow[AGroupFactor]] = vSumValue;
				}
				else
				{
					AParts.Add(vRow[AGroupFactor], Format.StrToInt(vRow["Value"]));
				}
			}
		}
		
		//Заполняет список точками для графика с учетом доп модели с отриц воздействием
		public void ReFill(List<TFuncPoint> APoints, TModel AIncomes)
		{
			APoints.Clear();
			DateTime d1 = new DateTime(2020, 1, 1);
			//Исходное значение баланса = 0;
			TFuncPoint p0 = new TFuncPoint(0, d1.ToString("dd/MM/yyyy"), 0);
    		APoints.Add(p0);
    		DateTime d2 = DateTime.Now;
    		TimeSpan time = d2 - d1;
    		double vBalance = 0;
    		for (int i = 1; i < time.Days+1; i++) 
    		{
    			double vSumCosts = GetSumByDate(d1.AddDays(i));
    			double vSumIncomes = AIncomes.GetSumByDate(d1.AddDays(i));
    			
    			vBalance = vBalance + (vSumIncomes - vSumCosts);
    			TFuncPoint p = new TFuncPoint(i, d1.AddDays(i).ToString("dd/MM/yyyy"), vBalance/1000);
    			APoints.Add(p);
    		}
		}
		
		//Возвращает сумму за определенный период
		public double GetSumByDate(DateTime ADateTime)
		{
			double vResult = 0;
			foreach(Dictionary<string, string> vRow in Rows)
			{
				DateTime vDay = Convert.ToDateTime(vRow["Date"]);
				if (vDay == ADateTime)
				{
					vResult = vResult + Format.StrToInt(vRow["Value"]);
				}
			}
			
			return vResult;
		}
		
		//Возвращает сумму значений мужду двумя датами
		public int GetSumByDate(int AXStart, int AXEnd)
		{
			DateTime d1 = new DateTime(2020, 1, 1);
			int vResult = 0;
			foreach(Dictionary<string, string> vRow in Rows)
			{
				DateTime vDay = Convert.ToDateTime(vRow["Date"]);
				if ((vDay >= d1.AddDays(AXStart)) && (vDay <= d1.AddDays(AXEnd)))
				{
					vResult = vResult + Format.StrToInt(vRow["Value"]);
				}
			}
			
			return vResult;
		}
	}
}
