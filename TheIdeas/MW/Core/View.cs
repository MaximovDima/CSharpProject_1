using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
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
		//Масштаб
		public double Scale;		
		
		public TScene(double AX, double AY)
		{
			X = AX;
			Y = AY;
			SceneObjectList = new List<TSceneObject>();
			Scale = 1;
		}	
		
		public void LoadModels(List<TModel> AModels)
		{
			//Построение системы координат
			CreateCoord();
		}
		
		public void CreateCoord()
		{
			TScObjCoord Coord = new TScObjCoord(this);
			SceneObjectList.Add(Coord);
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
	
	public static class DrwObjects
	{
		public static TDrwLine GetLine(double AX0, double AY0, double AX1, double AY1, Color AColor,
	                       int APenWidth, int AOpacity = 100, DashStyle ADashStyle = DashStyle.Solid, string AGroupCode = "",
	                       string ACode = "")
		{
			TDrwLine vLine = new TDrwLine();
			vLine.StartPoint.X = AX0;
			vLine.StartPoint.Y = AY0;
			vLine.EndPoint.X = AX1;
			vLine.EndPoint.Y = AY1;
			vLine.Color = AColor; 
			vLine.PenWidth = APenWidth;
			vLine.Opacity = AOpacity;
			vLine.DashStyle = ADashStyle;
			vLine.CodeElement = ACode;
			vLine.GroupCode = AGroupCode;
			
			return vLine;		
		}
	}
	
	//Система координат
	public class TScObjCoord : TSceneObject
	{
//		//Ось X
//		public TAxis AxisX;
//		//Ось Y
//		public TAxis AxisY;
		
		public double X0;
		public double X1;
		public double Y0;
		public double Y1;
		
		public TScObjCoord(TScene AScene)
		{
			Scene = AScene;
			Name = "Coord";
			X0 = 20;
			Y0 = 10;
			X1 = AScene.X - 5;
			Y1 = AScene.Y - 5;
		}
		
		public override void Build(double ACoeffX, double ACoeffY)
		{			
			if (Scene.Scale > 1) {Y0 = 15;} else {Y0 = 10;}
			DrwObjList.Clear();
			TDrwLine vXLine, vYLine;
			double vStep, vX, vY;
			//ось OX
			vXLine = DrwObjects.GetLine(X0*ACoeffX, Y0*ACoeffY, X1*ACoeffX, Y0*ACoeffY, Color.Black, 2);
			DrwObjList.Add(vXLine);
			//Сетка OX
			vStep = (X1 - X0) / 10;
			for (int i = 1; i < 10; i++) 
			{
				vX = X0 + i*vStep;
				vXLine = DrwObjects.GetLine(vX*ACoeffX, Y0*ACoeffY, vX*ACoeffX, (Y0+2)*ACoeffY, Color.Black, 2);
				DrwObjList.Add(vXLine);
				vXLine = DrwObjects.GetLine(vX*ACoeffX, Y0*ACoeffY, vX*ACoeffX, Y1*ACoeffY, Color.Black, 1, 20);				
				DrwObjList.Add(vXLine);
			}
			//ось OY
			vYLine = DrwObjects.GetLine(X0*ACoeffX, Y0*ACoeffY, X0*ACoeffX, Y1*ACoeffY, Color.Black, 2);
			DrwObjList.Add(vYLine);
			//Сетка OY
			vStep = (Y1 - Y0) / 10;
			for (int i = 1; i < 10; i++) 
			{
				vY = Y0 + i*vStep;
				vYLine = DrwObjects.GetLine(X0*ACoeffX, vY*ACoeffY, (X0 + 2)*ACoeffX, vY*ACoeffY, Color.Black, 2);
				DrwObjList.Add(vYLine);
				vYLine = DrwObjects.GetLine((X0 - 2)*ACoeffX, vY*ACoeffY, X1*ACoeffX, vY*ACoeffY, Color.Black, 1, 20);				
				DrwObjList.Add(vYLine);
			}
			
		}
		
	}			
}