using System;
using System.Drawing;
using System.Collections.Generic;

namespace DrwShapeClasses
{	
	
	public struct TInitPoint
	{
		public int X;
		public int Y;
	}
	
	public class TDrwPoint
	{
		public TInitPoint InitPoint;
		public int X;
		public int Y;
	}
	
	public enum TLayerType 
	{
		ltBack,
		ltFront
	}
	
	public abstract class TDrwShape
	{
		public int ID;
    	public string ScObjName;
    	public string GroupCode;
    	public string CodeElement;
    	public Color Color;
    	public int PenWidth;
    	public bool ByGroup;
    	public bool Visible;
    	public TLayerType LayerType;
		
		public TDrwShape()
		{
			ID = 0;
  			PenWidth = 1;
  			Color = Color.Black;
  			ByGroup = false;
  			Visible = true;
  			LayerType = TLayerType.ltBack;
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
    		
    	}
	}
	
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
}
