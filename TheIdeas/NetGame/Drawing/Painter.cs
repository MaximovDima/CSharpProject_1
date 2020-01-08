using System;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;
using DrwShapeClasses;

namespace Painter
{
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
//  if AShape is TDrwCircle then
//  begin
//    TDrwCircle(AShape).Center.Y := BackLayer.Height - TDrwCircle(AShape).Center.Y;
//    TDrwCircle(AShape).Center.InitPoint.X := TDrwCircle(AShape).Center.X;
//    TDrwCircle(AShape).Center.InitPoint.Y := TDrwCircle(AShape).Center.Y;
//    TDrwCircle(AShape).InitRadius := TDrwCircle(AShape).Radius;
//    TDrwCircle(AShape).InitRadius := TDrwCircle(AShape).Radius;
//  end;
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
