﻿//Классы для отрисовки примитивов

using System;
using System.Drawing;
using System.Collections.Generic;
using System.Drawing.Drawing2D;

namespace MW.Drawing
{	
	public class TDrwPoint
	{
		public double X;
		public double Y;
	}
	
	public abstract class TDrwShape
	{
		public int ID;
    	public string ScObjName;
    	public string GroupCode;
    	public string CodeElement;
    	public Color Color;
    	public int PenWidth;
    	public DashStyle DashStyle;
    	public int Opacity;
    	//Свойства заливки
    	public bool Filled;
    	public int FillOpacity;
    	public Color FillColor;
    	public bool ByGroup;
    	public bool Visible;
		
		public TDrwShape()
		{
			ID = 0;
  			PenWidth = 1;
  			Color = Color.Black;
  			DashStyle = DashStyle.Solid;
  			Opacity = 100;
  			Filled = false;
  			ByGroup = false;
  			Visible = true;
		}
		
		public abstract void Draw(Graphics G);
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
	
	public class TDrwLine : TDrwShape
	{
    	public TDrwPoint StartPoint;
    	public TDrwPoint EndPoint;
    	
    	public TDrwLine()
    	{
    		StartPoint = new TDrwPoint();
    		EndPoint = new TDrwPoint();
    	}
 		
    	public override void Draw(Graphics G)
    	{
    		int vOpacity = Convert.ToInt32(255 * Opacity / 100);
    		Pen mypen = new Pen(Color.FromArgb(vOpacity, Color), PenWidth);
    		mypen.DashStyle = DashStyle;
    		G.DrawLine(mypen, Convert.ToInt32(StartPoint.X), Convert.ToInt32(StartPoint.Y), Convert.ToInt32(EndPoint.X), Convert.ToInt32(EndPoint.Y));
    	}
	}
	
	public class TDrwLabel : TDrwShape
	{
		public enum THAlig {HLeft, HCenter, HRight}
		public enum TVAlig {VTop, VCenter, VBottom}
		public string Text;
		public TDrwPoint Point;
		//Выравнивание
		public THAlig HAlig;
		public TVAlig VAlig;

		public TDrwLabel()
		{
			Point = new TDrwPoint();
		}
		
		public override void Draw(Graphics G)
    	{
			float vX, vY;
			Font vFont = new Font(FontFamily.GenericSansSerif, 8, FontStyle.Regular);
			Brush vBrush = new SolidBrush(Color);
			float vWidth = G.MeasureString(Text, vFont).Width;
			float vHeight = G.MeasureString(Text, vFont).Height;
			switch (HAlig) {
				case TDrwLabel.THAlig.HLeft:
					vX = (float)Point.X - vWidth;
					break;
				case TDrwLabel.THAlig.HCenter:
					vX = (float)Point.X - vWidth/2;
					break;
				case TDrwLabel.THAlig.HRight:
					vX = (float)Point.X;
					break;
				default:
					throw new Exception("Invalid value for THAlig");
			}
			switch (VAlig) {
				case TDrwLabel.TVAlig.VTop:
					vY = (float)Point.Y - vHeight;
					break;
				case TDrwLabel.TVAlig.VCenter:
					vY = (float)Point.Y - vHeight/2;
					break;
				case TDrwLabel.TVAlig.VBottom:
					vY = (float)Point.Y;
					break;
				default:
					throw new Exception("Invalid value for TVAlig");
			}
			G.DrawString(Text, vFont, vBrush, vX, vY);
    	}
	}
	
	
	public class TDrwPolygon : TDrwShape
	{
    	public List<TDrwPoint> DrwPointList;
    	//Отрисовка контура (пока что только сверху)
    	public bool OnlyOutLine;

    	public TDrwPolygon()
    	{
    		DrwPointList = new List<TDrwPoint>();
    	}
    	
    	public override void Draw(Graphics G)
    	{
    		if (!Visible)
    		{
    			return;
    		}
    		
			Point[] FilledPoints = new Point[DrwPointList.Count];
			for(int i = 0; i < DrwPointList.Count; i++)
			{
				FilledPoints[i].X = (int)DrwPointList[i].X;
				FilledPoints[i].Y = (int)DrwPointList[i].Y;
			}  					
    		int vOpacity = Convert.ToInt32(255 * Opacity / 100);
    		int vFillOpacity = Convert.ToInt32(255 * FillOpacity / 100); 
    		Pen mypen = new Pen(Color.FromArgb(255, Color), PenWidth);
    		mypen.DashStyle = DashStyle;
    		if (Filled)
    		{
				G.FillPolygon(new SolidBrush(Color.FromArgb(vFillOpacity, FillColor)), FilledPoints, FillMode.Alternate);
    		}
    		if (OnlyOutLine)
    		{
    			DrwPointList.RemoveAt(DrwPointList.Count-1);
    			DrwPointList.RemoveAt(0);
    			Point[] OutLinePoints = new Point[DrwPointList.Count];
				for(int i = 0; i < DrwPointList.Count; i++)
				{
					OutLinePoints[i].X = (int)DrwPointList[i].X;
					OutLinePoints[i].Y = (int)DrwPointList[i].Y;
				}    			
				G.DrawLines(mypen, OutLinePoints);
    		}
    		else
    		{
    			G.DrawLines(mypen, FilledPoints);
    		}
    	}	
	}
	
	public class TDrwCircle : TDrwShape
	{
    	public TDrwPoint Center;
    	public double Radius;
    	
    	public TDrwCircle(double AX, double AY, double ARadius)
    	{
    		Center = new TDrwPoint();
    		Center.X = AX;
    		Center.Y = AY;
    		Radius = ARadius;
    	}
 		
    	public override void Draw(Graphics G)
    	{
    		 if (!Visible)
    		{
    			return;
    		}
    		 
    		int vOpacity = Convert.ToInt32(255 * Opacity / 100);
    		int vFillOpacity = Convert.ToInt32(255 * FillOpacity / 100); 
    		Pen mypen = new Pen(Color.FromArgb(vOpacity, Color), PenWidth);
    		mypen.DashStyle = DashStyle;
    		
    		G.DrawEllipse(mypen, (int)(Center.X - Radius),
    		              		 (int)(Center.Y - Radius),
    		              		 (int)(2*Radius),
    		              		 (int)(2*Radius));
    		if (Filled)
    		{
    			G.FillEllipse(new SolidBrush(Color.FromArgb(vFillOpacity, FillColor)),
    			    	     (int)(Center.X - Radius),
    		            	 (int)(Center.Y - Radius),
    		              	 (int)(2*Radius),
    		              	 (int)(2*Radius));
    		}
    	}
	}
}
