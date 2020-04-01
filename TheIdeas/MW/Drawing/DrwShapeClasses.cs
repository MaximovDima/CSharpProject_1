//Классы для отрисовки примитивов

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
    	public bool ByGroup;
    	public bool Visible;
		
		public TDrwShape()
		{
			ID = 0;
  			PenWidth = 1;
  			Color = Color.Black;
  			DashStyle = DashStyle.Solid;
  			Opacity = 100;
  			ByGroup = false;
  			Visible = true;
		}
		
		public abstract void Draw(Graphics G);
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
	
//	public class TDrwLabel : TDrwShape
//	{
//		
//	}
	
	public class TDrwPolyLine : TDrwShape
	{
    	public List<TDrwPoint> DrwPointList;

    	public TDrwPolyLine()
    	{
    		DrwPointList = new List<TDrwPoint>();
    	}
    	
    	public override void Draw(Graphics G)
    	{
    		if (!Visible)
    		{
    			return;
    		}
			Point[] points = new Point[DrwPointList.Count];
			for(int i = 0; i < DrwPointList.Count; i++)
			{
				points[i].X = (int)DrwPointList[i].X;
				points[i].Y = (int)DrwPointList[i].Y;
			}  				
    		Pen mypen = new Pen(Color, PenWidth);
    		G.DrawLines(mypen, points);
			
    	}
	}
	
	public class TDrwCircle : TDrwShape
	{
    	public TDrwPoint Center;
    	public double Radius;
    	public double InitRadius;
    	
    	public TDrwCircle(int AX, int AY, int ARadius)
    	{
    		Center = new TDrwPoint();
    		Center.X = AX;
    		Center.Y = AY;
    		InitRadius = ARadius;
    		Radius = ARadius;
    	}
 		
    	public override void Draw(Graphics G)
    	{
    		 if (!Visible)
    		{
    			return;
    		}
    		
    		Pen mypen = new Pen(Color, PenWidth);
    		G.DrawEllipse(mypen, (int)(Center.X - Radius),
    		              		 (int)(Center.Y + Radius),
    		              		 (int)(2*Radius),
    		              		 (int)(2*Radius));
    	}
	}
}
