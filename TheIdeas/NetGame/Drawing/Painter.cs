//Отрисовщик
//Класс сцена служит для хранения логических моделей объектов
//для независимого отображения в масштабе, который меняется при изменении окна приложения
//Класс Painter нужен для хранения примитивов и отображения их графически
//Суть отрисовки:
//  Расчитывается логическая модель объектов, с учетом их свойств и взаиморасположения
//  Этот расчет может быть в виде коллекции "кадров", где "кадр" это состояние модели в определенный момент времени
//  Далее модель переносится со сцены на отрисовщик, где каждый модельный объект имеет набор примитивов.
//  Далее примитивы отрисовываются на экране, пропрционально текущему масштабу.
//Изменение масштаба происходит без перерасчета модели сцены
//

using System;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;
using DrwShapeClasses;

namespace Painter
{	
	//Виртуальная сцена
	public class TScene
	{
		//Размеры сцены в пикселях
		public int X;
		public int Y;
		//Коллеккция моделей объектов сцены
		public List<TSceneObject> SceneObjectList;
		//ссылка на отрисовщик
		public TPainter Painter;
			
		
		public TScene(PictureBox ACtrlScene)
		{
			//Инициализация отрисовщика
			Painter = new TPainter(ACtrlScene);
			SceneObjectList = new List<TSceneObject>();
			X = ACtrlScene.Width;
			Y = ACtrlScene.Height;
		}
		//Синхронизация новых размеров окна приложения и сцены
		public void SetXY(int AX, int AY)
		{
			X = AX;
			Y = AY;
		}
		
		//Построение сцены - это построение каждого объекта сцены
		//используя примитивы класса TDrwShape
		public void Build()
		{
			foreach (TSceneObject SceneObj in SceneObjectList)
        	{
				SceneObj.DrwObjList.Clear();
				SceneObj.Build();
  				
  				foreach (TDrwShape Shape in SceneObj.DrwObjList)
  				{
  					SceneObj.CodeList.Add(Shape.GroupCode);
    				Shape.LayerType = TLayerType.ltBack;
    				Shape.ScObjName = SceneObj.Name;
    				Painter.AddShape(Shape);
  				}
        	}
		}
	}
	
	public abstract class TSceneObject
	{
    	public int ID;
    	public string Name;
    	public List<string> CodeList;
    	public List<TDrwShape> DrwObjList;
    	
    	public TSceneObject()
    	{
    		CodeList = new List<string>();
    		DrwObjList = new List<TDrwShape>();
    	}
    	
    	public abstract void Build();
    
	}
	
	public class TPainter
	{
		public List<TDrwShape> DrwShapeList;
		public PictureBox CtrlScene;
		public double InitX;
		public double InitY;
		public double CoeffX;
		public double CoeffY;
		public Bitmap DrawArea;
		public Graphics FrontLayer;
		public Graphics BackLayer; 
		
		public TPainter(PictureBox ACtrlScene)
		{
			DrwShapeList = new List<TDrwShape>();
			CtrlScene = ACtrlScene;
			Init();
        }
		
		public void Init()
		{
			InitX = CtrlScene.ClientSize.Width;
			InitY = CtrlScene.ClientSize.Height;
			InitDrawArea((int)InitX, (int)InitY);
		}
		
		public void InitDrawArea(int AX, int AY)
		{
			DrawArea = new Bitmap(AX, AY);
			BackLayer = Graphics.FromImage(DrawArea);
			FrontLayer = Graphics.FromImage(DrawArea);
			CtrlScene.Image = DrawArea; 
			BackLayer.Clear(Color.White); 		
		}
		
		public void Draw()
		{
			foreach(TDrwShape vShape in DrwShapeList)
			{
				if (vShape.LayerType == TLayerType.ltBack)
				{
					vShape.Draw(BackLayer);
				}
				else
				{
					vShape.Draw(FrontLayer);	
				}
			}
		}
		
		public void Refresh(int AX, int AY)
		{
			//Пересоздание слоев с учетом новых размеров
			InitDrawArea(AX, AY);
			//Масштабирование
			CoeffX = AX / InitX;
  			CoeffY = AY / InitY;
  			ReCalcCoords();
			//Перерисовка слоев с фигурами
			Draw();
		}
		
		public void ReCalcCoords()
		{
			foreach(TDrwShape vShape in DrwShapeList)
			{
				if (vShape is TDrwPolyLine)
				{
					foreach(TDrwPoint vPoint in (vShape as TDrwPolyLine).DrwPointList)
					{
						vPoint.X = (int)(vPoint.InitPoint.X * CoeffX);
						vPoint.Y = (int)(vPoint.InitPoint.Y * CoeffY);
					}
				}
				if (vShape is TDrwCircle)
				{
					(vShape as TDrwCircle).Center.X = (int)((vShape as TDrwCircle).Center.InitPoint.X * CoeffX);
					(vShape as TDrwCircle).Center.Y = (int)((vShape as TDrwCircle).Center.InitPoint.Y * CoeffY);
    				(vShape as TDrwCircle).Radius = (vShape as TDrwCircle).InitRadius * Math.Max(CoeffX, CoeffY);
				}
			}
		}
		
		public void AddShape(TDrwShape AShape)
		{
			if (AShape is TDrwLine)
			{
				(AShape as TDrwLine).StartPoint.Y = CtrlScene.Height - (AShape as TDrwLine).StartPoint.Y;
    			(AShape as TDrwLine).EndPoint.Y = CtrlScene.Height - (AShape as TDrwLine).EndPoint.Y;
    			(AShape as TDrwLine).StartPoint.InitPoint.X = (AShape as TDrwLine).StartPoint.X;
    			(AShape as TDrwLine).StartPoint.InitPoint.Y = (AShape as TDrwLine).StartPoint.Y;
    			(AShape as TDrwLine).EndPoint.InitPoint.X = (AShape as TDrwLine).EndPoint.X;
    			(AShape as TDrwLine).EndPoint.InitPoint.Y = (AShape as TDrwLine).EndPoint.Y;
			}
			if (AShape is TDrwPolyLine)
			{
				foreach (TDrwPoint vPoint in (AShape as TDrwPolyLine).DrwPointList)
				{
					vPoint.Y = CtrlScene.Height - vPoint.Y;
      				vPoint.InitPoint.X = vPoint.X;
      				vPoint.InitPoint.Y = vPoint.Y;	
				}
			}
			if (AShape is TDrwCircle)
			{
				(AShape as TDrwCircle).Center.Y = CtrlScene.Height - (AShape as TDrwCircle).Center.Y;
    			(AShape as TDrwCircle).Center.InitPoint.X = (AShape as TDrwCircle).Center.X;
    			(AShape as TDrwCircle).Center.InitPoint.Y = (AShape as TDrwCircle).Center.Y;
    			(AShape as TDrwCircle).InitRadius = (AShape as TDrwCircle).Radius;
    			(AShape as TDrwCircle).InitRadius = (AShape as TDrwCircle).Radius;
			}
			AddShapeToList(AShape);	
		}
		
		public void AddShapeToList(TDrwShape AShape)
		{
			if (AShape.ID != 0)
			{
    		 	AShape.ID = DrwShapeList.Count + 1;
			}
        	DrwShapeList.Add(AShape);
		}
			
	}
}
