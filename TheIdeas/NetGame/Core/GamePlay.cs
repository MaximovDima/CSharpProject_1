using System;
using System.Data;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;
using System.Collections.Generic;
using Painter;
using DrwShapeClasses;

namespace GamePlay
{
	public class TScene
	{
		//Координаты сцены
		public int X;
		public int Y;
		//Коллеккция моделей объектов сцены
		public List<TSceneObject> SceneObjectList;
		
		
		public TScene(PictureBox ACtrlScene)
		{
			SceneObjectList = new List<TSceneObject>();
			X = ACtrlScene.Width;
			Y = ACtrlScene.Height;
		}
		
		public void SetXY(int AX, int AY)
		{
			X = AX;
			Y = AY;
		}
		
		public void Build()
		{
			TGround Ground = new TGround(X, Y);
			SceneObjectList.Add(Ground);

//  vPlayer := TPlayer.Create;
//  vPlayer.ReadyMove := False;
//  vPlayer.X := vGround.XBegin + 5 + vPlayer.cRadius;
//  vPlayer.Y := vGround.YHorzLevel + vPlayer.cRadius;
//  vPlayer.XEndLine := vPlayer.X;
//  vPlayer.YEndLine := vPlayer.Y + vPlayer.cRadius - 2;
//  vPlayer.Name := 'Player';
//  vPlayer.Turn := 0;
//  ObjectList.Add(vPlayer);
		}
	}
		
		
	
	public struct TPoint
	{
		public int X;
		public int Y;		
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
	
	public class TGround : TSceneObject
	{
		public List<TPoint> PointList;
		public double[] Points;
		public double XBegin;
		public double XEnd;
		public double YHorzLevel;
		public double YMax;
		public const int h = 33;
		
		public TGround(int AX, int AY)
		{
  			PointList = new List<TPoint>();
  			XBegin = AX/30;
  			XEnd = AX - AX/30;
  			YHorzLevel = AY/20;
  			YMax = AY;
		}
		
		public override void Build()
		{
			DrwObjList.Clear();
			PointList.Clear();
			
  			TPoint vStartPoint, vEndPoint, vPeakPoint;
  			double vStep;
  			TDrwPolyLine vPolyline;
  			TPoint[] vPointUpList, vPointDownList;
  			int vPrevHHUp, vPrevHHDown;
  			Random rnd = new Random();
  
  			//участок слева
  			vStartPoint.X = (int)XBegin;
  			vStartPoint.Y = (int)YHorzLevel;
  			vEndPoint.X = (int)(XBegin + XBegin * 4);
  			vEndPoint.Y = (int)YHorzLevel;
  			PointList.Add(vStartPoint);
  			PointList.Add(vEndPoint);

  			//Гора
  			vStartPoint.X = (int)XBegin + (int)XBegin * 4;
  			vStartPoint.Y = (int)YHorzLevel;
  			vEndPoint.X = (int)(XEnd - XBegin * 4);
  			vEndPoint.Y = (int)YHorzLevel;
  			vPeakPoint.X = (int)((vEndPoint.X + vStartPoint.X)/2);
  			vPeakPoint.Y = (int)(YMax - YHorzLevel * 2);

  			//Склоны
  			vStep = (vEndPoint.X - vStartPoint.X)/h;
  			vPointUpList = new TPoint[(int)h/2];
  			vPointDownList = new TPoint[(int)h/2];
  			for (int i = 0; i < (int)h/2; i++)
  			{
    			vPointUpList[i].X = (int)(vStartPoint.X + vStep * i);
    			vPointDownList[i].X = (int)(vPeakPoint.X + vStep * i);
    			if (i > 0)
    			{
      				vPrevHHUp = vPointUpList[i - 1].Y;
      				vPrevHHDown = vPointDownList[i - 1].Y;
    			}
    			else
    			{
      				vPrevHHUp = vStartPoint.Y;
      				vPrevHHDown = vPeakPoint.Y;
      			}
    			vPointUpList[i].Y = Math.Min(vPeakPoint.Y, (int)(vPrevHHUp + rnd.Next(0,((int)(h*1.2)))));
    			vPointDownList[i].Y = Math.Max(vEndPoint.Y, (int)(vPrevHHDown - rnd.Next(0,((int)(h*2)))));
  			}

  			PointList.Add(vStartPoint);
  			PointList.AddRange(vPointUpList);
 			PointList.Add(vPeakPoint);
  			PointList.AddRange(vPointDownList);
  			PointList.Add(vEndPoint);
  			
  			//справа
  			vStartPoint.X = (int)(XEnd - XBegin * 4);
  			vStartPoint.Y = (int)YHorzLevel;
  			vEndPoint.X = (int)XEnd;
  			vEndPoint.Y = (int)YHorzLevel;
  			PointList.Add(vStartPoint);
  			PointList.Add(vEndPoint);
  			
  			vPolyline = new TDrwPolyLine();
  			foreach (TPoint vPoint in PointList)
  			{
  				TDrwPoint vDrwPoint = new TDrwPoint();
  				vDrwPoint.X = vPoint.X;
  				vDrwPoint.Y = vPoint.Y;
  				vPolyline.DrwPointList.Add(vDrwPoint);
			}

  			UpdatePoints();
  			vPolyline.CodeElement = "Ground";
  			DrwObjList.Add(vPolyline);				
		}
		
		public void UpdatePoints()
		{
			int vCount = PointList[PointList.Count - 1].X;
			Points = new double[vCount];
			for (int i = 0; i < vCount; i++)
			{
				Points[i] = GetYByX(i);
			}
		}
		
		public double GetYByX(int AX)
		{
			if (AX <= PointList[0].X)
			{
				return PointList[0].Y;
			}
			if (AX >= PointList[PointList.Count - 1].X)
			{
				return PointList[PointList.Count - 1].Y;
			}
    		int vIndex0 = 0;
  			int vIndex1 = 0;
  			for (int i = 0; i < PointList.Count; i++)	
  			{
  				if (PointList[i].X > AX)
  				{
      				vIndex1 = i;
      				vIndex0 = i - 1;
     				break;
  				}
  			}
  			return PointList[vIndex0].Y +
   				(((PointList[vIndex1].Y - PointList[vIndex0].Y)*(AX - PointList[vIndex0].X))
      				/((PointList[vIndex1]).X - PointList[vIndex0].X));
		}
		
	}
	
	public class TGame
	{
		public TPainter Painter;
		public TScene Scene;
		
		public TGame(PictureBox ACtrlScene)
		{
			//Инициализация отрисовщика
			Painter = new TPainter(ACtrlScene);
			//Инициализация сцены
			Scene = new TScene(ACtrlScene);
		}
		
		public void SceneResize(int AX, int AY)
		{
			Painter.Refresh(AX, AY);
		}
		
		public void CreateSession()
		{
			//создание сервера
			//Загрзука модели игры если одиноч
			//еще что-то
			
			//построение сцены
			Scene.Build();
			//перевод моделей сцены в отрисовку
			DrawSceneByPainter();
			//Отриовка
			Painter.Draw();
					
		}
		
		public void DrawSceneByPainter()
		{
			foreach (TSceneObject SceneObj in Scene.SceneObjectList)
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
		
}
