//Классы объектов моделей игрового мира

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Painter;
using DrwShapeClasses;

namespace SceneClasses
{

	public struct TPoint
	{
		public int X;
		public int Y;		
	}
	
//	public class TPlayer : TSceneObject
//	{
//		public int X;
//		public int Y;
//		
//		public TPlayer(double AX, double AY)
//		{
//			X = (int)AX;
//			Y = (int)AY;
//		}
//	}
	
	public class TGround : TSceneObject
	{
		public List<TPoint> PointList;
		public double[] Points;
		public double XBegin;
		public double XEnd;
		public double YHorzLevel;
		public double YMax;
		public const int cH = 33;
		
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
  			vStep = (vEndPoint.X - vStartPoint.X)/cH;
  			vPointUpList = new TPoint[(int)cH/2];
  			vPointDownList = new TPoint[(int)cH/2];
  			for (int i = 0; i < (int)cH/2; i++)
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
    			vPointUpList[i].Y = Math.Min(vPeakPoint.Y, (int)(vPrevHHUp + rnd.Next(0,((int)(cH*1.2)))));
    			vPointDownList[i].Y = Math.Max(vEndPoint.Y, (int)(vPrevHHDown - rnd.Next(0,((int)(cH*2)))));
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
	
	public class TPlayer : TSceneObject
	{
    	public double X;
    	public double Y;
    	//точка для отображения положения 1 спицы
    	public double XEndLine;
    	public double YEndLine;
    	//Поворот 0-23
    	public int Turn;
    	public int BarrelTurn;
    	//выделенность (готовность к движению)
    	public bool ReadyMove;
    	//готвность к прицеливанию
    	public bool ReadyAim;
    	//ось вращения ствола
    	public double AxisX;
    	public double AxisY;
    	//Угол наклона ствола
    	public double Angle;
  		public const int cRadius = 10;
      	public const int cStep = 3;
      	
      	public TPlayer(int AX, int AY)
      	{
      		X = AX;
      		Y = AY;
      	}
      	
      	public override void Build()
      	{
      		Color vWheelColor;
      		if (ReadyMove)
      		{
      			vWheelColor = Color.Red;
      		}
      		else
      		{
      			vWheelColor = Color.Black;
      		}
      		
      		DrwObjList.Clear();
  			//наружняя часть колеса
  			TDrwCircle vWheel1 = new TDrwCircle((int)X, (int)Y, cRadius);
  			vWheel1.CodeElement = "ExtWheel";
  			vWheel1.Color = vWheelColor;
  			vWheel1.GroupCode = "Wheel";
  			vWheel1.ByGroup = true;
  			DrwObjList.Add(vWheel1);	
      	}
      	
      	public int AddTurn(int AInc)
      	{
      		return 0;
      	}
	}
}
