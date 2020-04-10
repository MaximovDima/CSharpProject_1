using System;
using System.Drawing.Drawing2D;
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
		//Слой фона
		public Bitmap Bitmap_BG;
		public Graphics Layer_BG;
		//динамический слой
		public Bitmap Bitmap_FT;
		public Graphics Layer_FT;		
		
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
  			Bitmap_BG = new Bitmap(Convert.ToInt32(AX), Convert.ToInt32(AY));
  			Bitmap_FT = new Bitmap(Convert.ToInt32(AX), Convert.ToInt32(AY));
			Layer_BG = Graphics.FromImage(Bitmap_BG);
			Layer_BG.SmoothingMode = SmoothingMode.HighQuality;
			Layer_FT = Graphics.FromImage(Bitmap_FT);
			Layer_FT.SmoothingMode = SmoothingMode.HighQuality;	
			Layer_BG.Clear(Color.White);
			Bitmap_FT.MakeTransparent();
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
				vShape.Draw(Layer_BG);
			}
		}		
	
		public void AddShape(TDrwShape AShape)
		{
			//Перерасчет координаты Y для привычной системы координат
			AShape.CalcY(CtrlScene.Height);		
			AddShapeToList(AShape);	
		}
		
		public void AddShapeToList(TDrwShape AShape)
		{
   		 	AShape.ID = DrwShapeList.Count + 1;
        	DrwShapeList.Add(AShape);
		}
		
		public void MouseMove(int AX, int AY)
		{
			//Подсветка фигуры
			BacklightShape(AX, AY);
			CtrlScene.Invalidate();
		}
		
		public void BacklightShape(int AX, int AY)
		{
			CtrlScene.Cursor = Cursors.Default;
			Layer_FT.Clear(Color.Transparent);
			foreach (TDrwShape vShape in DrwShapeList) 
			{
				if (vShape.IncludePoint(AX, AY))
				{
					LightOn(vShape);
					return;
				}
			}
		}
		
		//подсветить фигуру
		public void LightOn(TDrwShape AShape)
		{
			CtrlScene.Cursor = Cursors.Hand;
			AShape.Light();
			AShape.Draw(Layer_FT);
		}
	}
}
