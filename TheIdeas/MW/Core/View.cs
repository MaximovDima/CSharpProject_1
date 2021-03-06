﻿using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using MW.Drawing;

namespace MW.Core
{
	//Виртуальная сцена
	public class TScene
	{
		//Размеры сцены в пикселях
		public double X;
		public double Y;
		//Коллеккция моделей объектов сцены
		public List<TSceneObject> SceneObjectList;
		public DateTime StartDate;
		public DateTime EndDate;		
		
		public TScene(double AX, double AY)
		{
			X = AX;
			Y = AY;
			SceneObjectList = new List<TSceneObject>();
		}
		
		public void LoadModels(TModel ACosts, TModel AIncomes, TModel ADirectory, 
		                       bool AViewTime, int ATimeType, bool AViewColumns, bool AViewStructura, string ATypeCostID)
		{
			if (ACosts.StartDate < AIncomes.StartDate) 
			{
				StartDate = ACosts.StartDate;	
			}
			else
			{
				StartDate = AIncomes.StartDate;	
			}
			
			if (ACosts.EndDate > AIncomes.EndDate) 
			{
				EndDate = ACosts.EndDate;	
			}
			else
			{
				EndDate = AIncomes.EndDate;	
			}
			
			/*ATimeType
			 * 0-costs
			 * 1-incomes
			 * 2-costs+incomes
			 * 3-balance*/
			if(AViewTime || AViewColumns)
			{
				List<TFuncPoint> vPoints = new List<TFuncPoint>();
				if (ATimeType == 0)
				{
					ACosts.ReFill(vPoints);
					//Построение системы координат
					CreateCoord(vPoints, StartDate, EndDate);
					//Отображение модельных данных
					if (AViewTime)
					{
						CreateFunc(vPoints, ATimeType);					
					}
					else
					{
						CreateColumns(vPoints, ATimeType);
					}
				}
				else if (ATimeType == 1)
				{
					AIncomes.ReFill(vPoints);
					CreateCoord(vPoints, StartDate, EndDate);
					if (AViewTime)
					{
						CreateFunc(vPoints, ATimeType);
					}
					else
					{
						CreateColumns(vPoints, ATimeType);
					}
				}
				else if (ATimeType == 2)
				{
					AIncomes.ReFill(vPoints);
					List<TFuncPoint> vPoints2 = new List<TFuncPoint>();
					ACosts.ReFill(vPoints2);
					CreateCoord(vPoints, vPoints2, StartDate, EndDate);
					if (AViewTime)
					{
						CreateFunc(vPoints, 1);
						CreateFunc(vPoints2, 0);
					}
					else
					{
						CreateColumns(vPoints, 1);
						CreateColumns(vPoints2, 0);
					}
				}
				else if (ATimeType == 3)
				{
					ACosts.ReFill(vPoints, AIncomes);
					CreateCoord(vPoints, StartDate, EndDate);
					if (AViewTime)
					{
						CreateFunc(vPoints, 3);
					}
					else
					{
						CreateColumns(vPoints, 3);
					}
				}
			}
			
			if (AViewStructura)
			{
				Dictionary<string, int> vPartsIncome = new Dictionary<string, int>();
				Dictionary<string, int> vPartsCostType = new Dictionary<string, int>();
				Dictionary<string, int> vPartsCostPlace = new Dictionary<string, int>();
				ACosts.ReFill(vPartsCostType, "Type");
				ACosts.ReFill(vPartsCostPlace, "Place", ATypeCostID);
				AIncomes.ReFill(vPartsIncome, "Type");
				CreatePizza(vPartsIncome, vPartsCostType, vPartsCostPlace, ADirectory, ATypeCostID);
			}
		}
		
		public void CreateCoord(List<TFuncPoint> APoints, DateTime AStartDate, DateTime AEndDate)
		{
			TScObjCoord Coord = new TScObjCoord(this);
			Coord.StartDate = AStartDate;
			Coord.EndDate = AEndDate;
			Coord.SetAxis(APoints);
			SceneObjectList.Add(Coord);
		}
		
				
		public void CreateCoord(List<TFuncPoint> APoints1, List<TFuncPoint> APoints2, DateTime AStartDate, DateTime AEndDate)
		{
			TScObjCoord Coord = new TScObjCoord(this);
			Coord.StartDate = AStartDate;
			Coord.EndDate = AEndDate;
			Coord.SetAxis(APoints1, APoints2);
			SceneObjectList.Add(Coord);
		}
		
		public void CreateFunc(List<TFuncPoint> APoints, int ATimeType)
		{
			TScObjFunc Func = new TScObjFunc(this);
			Func.TimeType = ATimeType;
			Func.Load(APoints);
			SceneObjectList.Add(Func);
		}
		
		public void CreateColumns(List<TFuncPoint> APoints, int ATimeType)
		{
			TScObjColumns Columns = new TScObjColumns(this);
			Columns.TimeType = ATimeType;
			Columns.Load(APoints);
			SceneObjectList.Add(Columns);
		}
		
		public void CreatePizza(Dictionary<string, int> APartsIncome,
		                        Dictionary<string, int> APartsCostType,
		                        Dictionary<string, int> APartsCostPlace,
		                        TModel ADirectory, string AID)
		{
			//Incomes
			double vRadius = Math.Min(X/6, Y/2);
			TScObjSector vIncomes = new TScObjSector(this, "Incomes");
			vIncomes.X = (X/6)*5;
			vIncomes.Y = Y*0.55;
			vIncomes.Radius = vRadius;
			vIncomes.LoadSectors(APartsIncome, ADirectory, "Income");
			SceneObjectList.Add(vIncomes);
			//Costs_Type
			TScObjSector vCostsType = new TScObjSector(this, "Costs_Type");
			vCostsType.X = X/6;
			vCostsType.Y = Y*0.55;
			vCostsType.Radius = vRadius;
			vCostsType.LoadSectors(APartsCostType, ADirectory, "Cost");
			SceneObjectList.Add(vCostsType);
			//Costs_Place
			TScObjSector vCostsPlace = new TScObjSector(this, "Costs_Place");
			vCostsPlace.X = X/2;
			vCostsPlace.Y = Y*0.55;
			vCostsPlace.Radius = vRadius;
			vCostsPlace.LoadSectors(APartsCostPlace, ADirectory, "Place");
			vCostsPlace.CategoryName = ADirectory.GetNameByID("Cost", AID);
			SceneObjectList.Add(vCostsPlace);
		}
		
		public TSceneObject GetSceneObject(string AName)
		{
			TSceneObject vResult = null;
			foreach (TSceneObject vObj in SceneObjectList) 
			{
				if (vObj.Name == AName)
				{
					vResult = vObj;
				}
			}
			return vResult;		
		}
	}
	
	//Шаблон модели объекта отрисовки
	public abstract class TSceneObject
	{
		//Идентификатор
    	public int ID;
    	//Наименование
    	public string Name;
    	//Тэги
    	public List<string> CodeList;
    	//Список примитивов
    	public List<TDrwShape> DrwObjList;
    	//ссылка на параметры сцены
    	public TScene Scene; 
    	
    	public TSceneObject()
    	{
    		CodeList = new List<string>();
    		DrwObjList = new List<TDrwShape>();
    	}
    	//Построение объекта из примитивов
    	public abstract void Build(double ACoeffX, double ACoeffY);
	}
	
	//Система координат
	public class TScObjCoord : TSceneObject
	{
		public DateTime StartDate;
		public DateTime EndDate;
		//Точка начала координат
		public double X0;
		public double X1;
		public double Y0;
		public double Y1;
		//Настройки для оси X
		public double XMin;
		public double XMax;
		public double GetXDrwByUsr(double AXUsr)
		{
			return ((X1-X0)*Math.Abs(AXUsr - XMin))/(XMax - XMin);
		}
		public double GetXUsrByDrw(double AXDrw)
		{
			return XMin + (((XMax - XMin)*(AXDrw - X0))/(X1 - X0));
		}
		//Настройки для оси Y
		public double YMin;
		public double YMax;
		public double GetYUsrByDrw(double AYDrw)
		{
			return YMin + (((YMax - YMin)*(AYDrw - Y0))/(Y1 - Y0));
		}
		public double GetYDrwByUsr(double AYUsr)
		{
			if (YMax == YMin)
			{
				return 0;
			}
			return ((Y1-Y0)*Math.Abs(AYUsr - YMin))/(YMax - YMin);
		}
		
		public TScObjCoord(TScene AScene)
		{
			Scene = AScene;
			Name = "Coord";
			X0 = AScene.X*0.025;
			Y0 = AScene.Y*0.05;
			X1 = AScene.X - 5;
			Y1 = AScene.Y - 5;
		}
		
		public override void Build(double ACoeffX, double ACoeffY)
		{			
			DrwObjList.Clear();
			TDrwLine vXLine, vYLine;
			TDrwLabel vLabel;
			double vStep, vX, vY;
			//ось OX
			vXLine = DrwObjects.GetLine(X0, Y0, X1*ACoeffX, Y0, Color.Black, 2);
			DrwObjList.Add(vXLine);
			//ось OY
			vYLine = DrwObjects.GetLine(X0, Y0, X0, Y1*ACoeffY, Color.Black, 2);
			DrwObjList.Add(vYLine);
			//Сетка OX
			vStep = (X1 - X0) / XMax;
			for (int i = 0; i < Math.Round(XMax); i++)
			{
				if (i!=0)
				{
					vX = X0 + i*vStep*ACoeffX;
					vXLine = DrwObjects.GetLine(vX, Y0, vX, Y0+4, Color.Black, 1);
					DrwObjList.Add(vXLine);
					vXLine = DrwObjects.GetLine(vX, Y0, vX, Y1*ACoeffY, Color.Black, 1, 7);				
					DrwObjList.Add(vXLine);
				}
				if ((i % 7) == 0 & i!=0)
				{
					vX = X0 + i*vStep*ACoeffX;
					vXLine = DrwObjects.GetLine(vX, Y0, vX, Y0+4, Color.Black, 2);
					DrwObjList.Add(vXLine);
					vXLine = DrwObjects.GetLine(vX, Y0, vX, Y1*ACoeffY, Color.Black, 1, 20);				
					DrwObjList.Add(vXLine);

					vLabel = new TDrwLabel();
					vLabel.HAlig = TDrwLabel.THAlig.HCenter;
					vLabel.VAlig = TDrwLabel.TVAlig.VBottom;
					vLabel.Point.X = vX;
					vLabel.Point.Y = Y0-1;					
					DateTime d1 = StartDate;							
					vLabel.Text = d1.AddDays(i).ToString("d MMM");
					DrwObjList.Add(vLabel);
				}
			}
			//Сетка OY
			for (int i = (int)YMin; i < YMax; i++)
			{	
				
				if (((i % 0.5) == 0) && (YMax < 80))
				{
					vY = Y0 + GetYDrwByUsr(i)*ACoeffY;
					vYLine = DrwObjects.GetLine(X0, vY, X0+3, vY, Color.Black, 1);
					DrwObjList.Add(vYLine);
					vYLine = DrwObjects.GetLine(X0, vY, X1*ACoeffX, vY, Color.Black, 1, 7);				
					DrwObjList.Add(vYLine);
				}
				
				int vInc = 2;
				if(YMax > 20) {vInc = 5;}
				if(YMax > 80) {vInc = 10;}
				if(YMax > 200) {vInc = 25;}
				if (((i % vInc) == 0) || YMax < 11)
				{
					vY = Y0 + GetYDrwByUsr(i)*ACoeffY;
					vYLine = DrwObjects.GetLine(X0, vY, X0+3, vY, Color.Black, 2);
					DrwObjList.Add(vYLine);
					vYLine = DrwObjects.GetLine(X0, vY, X1*ACoeffX, vY, Color.Black, 1, 20);				
					DrwObjList.Add(vYLine);

					vLabel = new TDrwLabel();
					vLabel.HAlig = TDrwLabel.THAlig.HLeft;
					vLabel.VAlig = TDrwLabel.TVAlig.VCenter;
					vLabel.Point.X = X0-1;
					vLabel.Point.Y = Math.Abs(vY);
					vLabel.Text = Format.ObjToStr(i)+"K";
					DrwObjList.Add(vLabel);
				}
			}
		}
		
		//Настройка осей
		public void SetAxis(List<TFuncPoint> APoints)
		{
			//Временная шкала
			XMin = 0;
			DateTime d1 = StartDate;
    		DateTime d2 = EndDate;
    		TimeSpan time = d2 - d1;
			XMax = time.Days + 7;
			//Шкала значений
			//Анализ модельных значений
			YMax = 0;
			YMin = 0;
			foreach (TFuncPoint vPoint in APoints)
			{
				YMin = Math.Min(YMin, vPoint.Value);
				YMax = Math.Max(YMax, vPoint.Value);
			}
			//Запас
			if (YMin<0) {YMin = YMin - 5;}
		}
		
		//Настройка осей
		public void SetAxis(List<TFuncPoint> APoints1, List<TFuncPoint> APoints2)
		{
			//Временная шкала
			XMin = 0;
			DateTime d1 = StartDate;
    		DateTime d2 = EndDate;
    		TimeSpan time = d2 - d1;
			XMax = time.Days + 7;
			//Шкала значений
			//Анализ модельных значений
			
			YMax = 0;
			if (APoints1.Count == 0) {YMin = 0;} else
			{
				YMin = APoints1[0].Value;
			}
			foreach (TFuncPoint vPoint in APoints1)
			{
				YMin = Math.Min(YMin, vPoint.Value);
				YMax = Math.Max(YMax, vPoint.Value);
			}
			foreach (TFuncPoint vPoint in APoints2)
			{
				YMin = Math.Min(YMin, vPoint.Value);
				YMax = Math.Max(YMax, vPoint.Value);
			}
		}
	}
	
	//Класс-обертка для загрузки значений в функцию
	public class TFuncPoint
	{
		public int ID;
		public string Date;
		public double Value;
		
		public TFuncPoint(int AID, string ADate, double AValue)
		{
			ID = AID;
			Date = ADate;
			Value = AValue;
		}
	}
	
	//Представление данных в виде непрерывной функции
	public class TScObjFunc : TSceneObject
	{
		public List<TFuncPoint> Points;
		public TScObjCoord Coord;
		public int TimeType;
		
		public TScObjFunc(TScene AScene)
		{
			Scene = AScene;
			Name = "Func";
			Coord = (Scene.GetSceneObject("Coord") as TScObjCoord);
		}
		
		public void Load(List<TFuncPoint> APoints)
		{
			Points = APoints;
		}
		
		public override void Build(double ACoeffX, double ACoeffY)
		{
			if (Points.Count == 0) {return;}
			DrwObjList.Clear();
			TDrwPolygon vPolygon = new TDrwPolygon();
			Color vColor = Color.Black;
			string vModelName = "";
			if (TimeType == 0)
			{
				vColor = Color.Red;
				vModelName = "Cost";
			}
			if (TimeType == 1) 
			{
				vColor = Color.Green;
				vModelName = "Income";
			}
			if (TimeType == 3)
			{
				vColor = Color.Blue;
				vModelName = "Balance";
			}
			vPolygon.Color = vColor;
			vPolygon.Filled = true;
			vPolygon.OutLine = true;
			vPolygon.FillOpacity = 20;
			vPolygon.FillColor = vPolygon.Color;
			
			//Первая виртуальная точка
			TDrwPoint vDrwPointVirtual = new TDrwPoint();
			vDrwPointVirtual.X = Coord.X0 + Coord.GetXDrwByUsr(Points[0].ID)*ACoeffX;
			vDrwPointVirtual.Y = Coord.Y0;
			vPolygon.DrwPointList.Add(vDrwPointVirtual);
			//Массив
			foreach (TFuncPoint vPoint in Points)
			{
				TDrwPoint vDrwPoint = new TDrwPoint();
				vDrwPoint.X = Coord.X0 + Coord.GetXDrwByUsr(vPoint.ID)*ACoeffX;
				vDrwPoint.Y = Coord.Y0 + Coord.GetYDrwByUsr(vPoint.Value)*ACoeffY;
				vPolygon.DrwPointList.Add(vDrwPoint);
			}
			//последняя виртуальная точка
			vDrwPointVirtual = new TDrwPoint();
			vDrwPointVirtual.X = Coord.X0 + Coord.GetXDrwByUsr(Points[Points.Count-1].ID)*ACoeffX;
			vDrwPointVirtual.Y = Coord.Y0;
			vPolygon.DrwPointList.Add(vDrwPointVirtual);
			
			DrwObjList.Add(vPolygon);
			
			//Точки событий
			foreach (TFuncPoint vPoint in Points)
			{
				if (vPoint.Value == 0)
					continue;
				TDrwCircle vDrwPoint = new TDrwCircle(Coord.X0 + Coord.GetXDrwByUsr(vPoint.ID)*ACoeffX,
										Coord.Y0 + Coord.GetYDrwByUsr(vPoint.Value)*ACoeffY,
										2);
				vDrwPoint.Color = vPolygon.Color;
				vDrwPoint.PenWidth = 2;
				vDrwPoint.Filled = true;
				vDrwPoint.OutLine = true;
				vDrwPoint.GroupCode = vModelName;
				DrwObjList.Add(vDrwPoint);
			}
		}
		/*
		//Возвращает координату Y по X у полигона
		public double GetPolygonYByX(double AX)
		{			
			if (AX <= Points[0].X)
			{
				return vPolygon.DrwPointList[0].Y;
			}
			
			if (AX >= vPolygon.DrwPointList[vPolygon.DrwPointList.Count - 1].X)
			{
				return vPolygon.DrwPointList[vPolygon.DrwPointList.Count - 1].Y;
			}

  			int vIndex0 = 0;
  			int vIndex1 = 0;
  			for (int i = 0; i < vPolygon.DrwPointList.Count - 1; i++) {
  				if (vPolygon.DrwPointList[i].X > AX)
  				{
  					vIndex1 = i;
      				vIndex0 = i - 1;
      				break;				
  				}
  			}
  			
  			return vPolygon.DrwPointList[vIndex0].Y +
    			(((vPolygon.DrwPointList[vIndex1].Y - vPolygon.DrwPointList[vIndex0].Y)*(AX - vPolygon.DrwPointList[vIndex0].X))
      				/((vPolygon.DrwPointList[vIndex1]).X - vPolygon.DrwPointList[vIndex0].X));
		
		}*/
	}
	
	//Представление данных в виде гистограммы
	public class TScObjColumns : TSceneObject
	{
		public List<TFuncPoint> Points;
		public TScObjCoord Coord;
		public int TimeType;
		
		public TScObjColumns(TScene AScene)
		{
			Scene = AScene;
			Name = "Columns";
			Coord = (Scene.GetSceneObject("Coord") as TScObjCoord);
		}
		
		public void Load(List<TFuncPoint> APoints)
		{
			Points = APoints;
		}
		
		public override void Build(double ACoeffX, double ACoeffY)
		{
			DrwObjList.Clear();
			Color vColor = Color.Black;
			string vModelName = "";
			if (TimeType == 0)
			{
				vColor = Color.Red;
				vModelName = "Cost";
			}
			if (TimeType == 1) 
			{
				vColor = Color.Green;
				vModelName = "Income";
			}
			if (TimeType == 3)
			{
				vColor = Color.Blue;
				vModelName = "Balance";
			}
			double vWidth = Coord.GetXDrwByUsr(1)*ACoeffX;
						
			//Массив
			foreach (TFuncPoint vPoint in Points)
			{
				if (vPoint.Value == 0)
					continue;
				TDrwRect vDrwRect = new TDrwRect(Coord.X0 + Coord.GetXDrwByUsr(vPoint.ID)*ACoeffX,
				                                Coord.Y0 + Coord.GetYDrwByUsr(vPoint.Value)*ACoeffY,
				                               	vWidth, Coord.GetYDrwByUsr(vPoint.Value)*ACoeffY);
				vDrwRect.Color = vColor;
				vDrwRect.Filled = true;
				vDrwRect.OutLine = true;
				vDrwRect.GroupCode = vModelName;
				vDrwRect.FillOpacity = 20;
				vDrwRect.FillColor = vColor;
				
				DrwObjList.Add(vDrwRect);
			}
		}
	}	
	
	//Представление данных в виде секторной диаграммы
	public class TScObjSector : TSceneObject
	{
		public double Radius;
		public double X;
		public double Y;
		//Набор секторов
		public List<TSector> Sectors;
		public int Sum;
		public string CategoryName;
		
		public override void Build(double ACoeffX, double ACoeffY)
		{
			DrwObjList.Clear();
			//для категорий места укажем тип расхода
			if (Name == "Costs_Place")
			{
				TDrwLabel vLabel = new TDrwLabel();
			    vLabel.Point = new TDrwPoint(X*ACoeffX, Y*ACoeffY + Radius*Math.Min(ACoeffX, ACoeffY)+3);
			    vLabel.Text = CategoryName;
			    vLabel.TextFont = 10;
			    vLabel.HAlig = TDrwLabel.THAlig.HCenter;
			    vLabel.VAlig = TDrwLabel.TVAlig.VTop;
			    DrwObjList.Add(vLabel);
			}
			//Сектора и легенда
			double vStartAngle = 0.00;
			double vLastAngle = 0.00;
			double vSweepAngle = 0.00;
			double vX0 = X*ACoeffX - Radius*Math.Min(ACoeffX, ACoeffY) + 5;
			double vY0 = Y*ACoeffY - Radius*Math.Min(ACoeffX, ACoeffY) - 10;
			double vX = 0;
			double vY = 0;
			int i = 0;
			foreach (TSector vSector in Sectors)
			{
				if ((i >= 0) && (i < 4))
			    {
			    	vX = vX0 + 90*i;
			    	vY = vY0;
			    }
			    if ((i >= 4) && (i < 8))
			    {
			    	vX = vX0 + 90*(i-4);
			    	vY = vY0 - 30;
			    }
				vStartAngle = vLastAngle;
				vSweepAngle = (double)360*vSector.Value / Sum;
				vLastAngle = vLastAngle + vSweepAngle;
				
				TDrwSector vDrwSector = new TDrwSector(X*ACoeffX, Y*ACoeffY, 
				                                       Radius*Math.Min(ACoeffX, ACoeffY), (float)vStartAngle, (float)vSweepAngle);
				vDrwSector.Color = vSector.Color;
				vDrwSector.FillColor = vSector.Color;
				vDrwSector.FillOpacity = 25;
				vDrwSector.Filled = true;
				vDrwSector.Comment = vSector.Name + ": " + Format.IntToStr(vSector.Value);
				vDrwSector.GroupCode = vSector.Code;
				vDrwSector.CodeElement = vSector.ID;
			    DrwObjList.Add(vDrwSector);
			    
			    if (i > 7)
				{
					continue;
				}
			    
			    TDrwRect vRect = new TDrwRect(vX, vY, 10, 10);
			    
			    vRect.Color = vSector.Color;
				vRect.FillColor = vSector.Color;
				vRect.FillOpacity = 25;
				vRect.Filled = true; 
			    DrwObjList.Add(vRect);
			    
			    TDrwLabel vLabel = new TDrwLabel();
			    vLabel.Point = new TDrwPoint(vX + 10, vY + 4);
			    vLabel.Text = vSector.Name;
			    vLabel.TextFont = 10;
			    vLabel.HAlig = TDrwLabel.THAlig.HRight;
			    vLabel.VAlig = TDrwLabel.TVAlig.VBottom;
			    DrwObjList.Add(vLabel);
			    i++;
			}
		}
		
		public TScObjSector(TScene AScene, string AName)
		{
			Scene = AScene;
			Name = AName;
			Sum = 0;
			Sectors = new List<TScObjSector.TSector>();
		}
		
		public class TSector
		{
			public string ID;
			public string Name;
			public int Value;
			public string Code;
			public Color Color;
			
			public TSector(string AID, string AName, int AValue, string ACode, Color AColor)
			{
				ID = AID;
				Name = AName;
				Value = AValue;
				Code = ACode;
				Color = AColor;				
			}
		}
		
		public void LoadSectors(Dictionary<string, int> ASectors, TModel ADirectory, string AType)
		{
			//Сумма
			Dictionary<string, int>.ValueCollection vValues = ASectors.Values;
			foreach (int vValue in vValues)
			{
				Sum = Sum + vValue; 	
			}
			//Категории
			Color vColor;
			Random random = new Random();
			Dictionary<string, int>.KeyCollection vKeys = ASectors.Keys;
			foreach (string vKey in vKeys)
			{
				vColor = Color.FromArgb(random.Next(255), random.Next(255), random.Next(255));
				TSector vSector = new TScObjSector.TSector(vKey, 
				                                           ADirectory.GetNameByID(AType, vKey),
				                                           ASectors[vKey], 
				                                           AType,
				                                           vColor);
				Sectors.Add(vSector);
			} 
		}
	}
	
	//Данные для отображения
	public static class DataInfo
	{
		
	}
}