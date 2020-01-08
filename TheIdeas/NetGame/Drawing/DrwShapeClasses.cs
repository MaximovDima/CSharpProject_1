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
//    		  if not Visible then
//    Exit;
//  vBrushStyle := ALayer.Canvas.Brush.Style;
//  vColor := ALayer.Canvas.Pen.Color;
//  vPenWidth := ALayer.Canvas.Pen.Width;
//  try
//    ALayer.Canvas.Pen.Width := PenWidth;
//    ALayer.Canvas.Pen.Color := Color;
//    ALayer.Canvas.Brush.Style := bsClear;
//    SetLength(vPointArray, DrwPointList.Count);
//    for I := 0 to DrwPointList.Count - 1 do
//    begin
//      vPointArray[I].X := Trunc(DrwPointList[I].X);
//      vPointArray[I].Y := Trunc(DrwPointList[I].Y);
//    end;
//    ALayer.Canvas.Polyline(vPointArray);
//  finally
//    ALayer.Canvas.Pen.Color := vColor;
//    ALayer.Canvas.Brush.Style := vBrushStyle;
//    ALayer.Canvas.Pen.Width := vPenWidth;
//  end;
    				
    		Pen mypen = new Pen(Color.Black);
//    		G.DrawPolygon(mypen, 
			
    	}
	}
}
