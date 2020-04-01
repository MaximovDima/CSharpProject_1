using System;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;

using MW.Core;

namespace MW.Drawing
{	
	//Отрисовщик
	public class TPainter
	{
		//Виртуальная сцена с объектами
		public TScene Scene;
		//Информация о графическом компоненте
		public PictureBox CtrlScene;
		//Список примитивов для отображения
		public List<TDrwShape> DrwShapeList;
		//коэффициенты масштабов по осям
		public double CoeffX;
		public double CoeffY;
		//Отрисовочные свойства
		public Bitmap DrawArea;
		public Graphics Layer; 
		
		public TPainter(PictureBox ACtrlScene)
		{
			DrwShapeList = new List<TDrwShape>();
			Scene = new TScene(ACtrlScene.ClientSize.Width, ACtrlScene.ClientSize.Height);
			CtrlScene = ACtrlScene;
        }
		
		//Инициализация области отрисовки
		public void InitDrawArea(double AX, double AY)
		{
			CoeffX = AX / Scene.X;
  			CoeffY = AY / Scene.Y;
  			DrawArea = new Bitmap(Convert.ToInt32(AX), Convert.ToInt32(AY));
			Layer = Graphics.FromImage(DrawArea);
			CtrlScene.Image = DrawArea; 
			Layer.Clear(Color.White); 		
		}
		
		//Построение всей сцены
		public void BuildScene()
		{
			DrwShapeList.Clear();
			foreach (TSceneObject SceneObj in Scene.SceneObjectList)
        	{
				SceneObj.Build(CoeffX, CoeffY);
  				
  				foreach (TDrwShape Shape in SceneObj.DrwObjList)
  				{
  					SceneObj.CodeList.Add(Shape.GroupCode);
    				Shape.ScObjName = SceneObj.Name;
    				AddShape(Shape);
  				}
        	}
		}
		//Перерасчет всей сцены с перерисовкой
		public void ReDraw(double AX, double AY)
		{
			InitDrawArea(AX, AY);
			BuildScene();
			Draw();
		}
		
		//Отрисовка всей сцены 
		public void Draw()
		{
			foreach(TDrwShape vShape in DrwShapeList)
			{
				vShape.Draw(Layer);
			}
		}		
	
		public void AddShape(TDrwShape AShape)
		{
			if (AShape is TDrwLine)
			{
				(AShape as TDrwLine).StartPoint.Y = CtrlScene.Height - (AShape as TDrwLine).StartPoint.Y;
    			(AShape as TDrwLine).EndPoint.Y = CtrlScene.Height - (AShape as TDrwLine).EndPoint.Y;

			}
			if (AShape is TDrwPolyLine)
			{
				foreach (TDrwPoint vPoint in (AShape as TDrwPolyLine).DrwPointList)
				{
					vPoint.Y = CtrlScene.Height - vPoint.Y;

				}
			}
			if (AShape is TDrwCircle)
			{
				(AShape as TDrwCircle).Center.Y = CtrlScene.Height - (AShape as TDrwCircle).Center.Y;
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
