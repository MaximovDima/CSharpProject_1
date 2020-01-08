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
		public Bitmap DrawArea;
		public Graphics G;
		
		public TPainter(PictureBox ACtrlScene)
		{
			DrwShapeList = new List<TDrwShape>();
			CtrlScene = ACtrlScene;
			Init();
        }
		
		public void Init()
		{
			DrawArea = new Bitmap(CtrlScene.ClientSize.Width, CtrlScene.Size.Height);
			G = Graphics.FromImage(DrawArea);
			CtrlScene.Image = DrawArea; 
			G.Clear(Color.White); 	
		}
		
		public void Draw()
		{
			foreach(TDrwShape vShape in DrwShapeList)
			{
				vShape.Draw(G);
			}
		}
		
		public void Refresh()
		{
			//Пересоздание битмапа с учетом новых размеров
			Init();
			//Перерисовка слоев с фигурами
			Pen mypen = new Pen(Color.Black);
			G.DrawEllipse(mypen, 50,50,DrawArea.Width/2,DrawArea.Height/2);
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
