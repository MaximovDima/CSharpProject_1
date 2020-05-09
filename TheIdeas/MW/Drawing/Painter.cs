﻿/*
 *Класс предназначен для отрисовки графических примитивов на поверхности графического компонента.
 * Реализация отображения через двухслойный битмап, где один является статическим фоном, с бОльшей частью примитивов из модели сцены,
 * а второй является прозрачным и динамически перерисовываемым незасимо от модели сцены.
 * Порядок отрисовки:
 * 	1. Создание и настройка виртуальной сцены с объектами модели.
 * 	2. Заполнение сцены, загрузка и базовый расчет моделей системы в масштабе 1:1
 * 	3. Инициализация текущих размеров сцены, расчет масштабных коэффициентов
 * 	4. Отрисовка примитивов на стат. слой с учетом масштабных коэфф.
 * 	5. Отрисовка динамич. слоя (если есть, то только "выделенный" объект)
 *  динамический слой отвечает за работу мыши (подсветка, клики мышкой и т.д.)
 * 
 * 
 */

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
		//Список примитивов для отображения фона
		public List<TDrwShape> DrwShapeList;
		//Список примитивов динамического слоя
		public List<TDrwShape> DrwFrontShapeList;
		//Идентификатор выделенного примитива
//		public int SelectedShapeID;
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
		//режим выделения (начальная точка X)
		public int SelectAreaXStart;		
		//режим выделения (начальная точка Y)
		public double SelectAreaYStart;
		
		public TPainter(PictureBox ACtrlScene)
		{
			DrwShapeList = new List<TDrwShape>();
			DrwFrontShapeList = new List<TDrwShape>();
			Scene = new TScene(ACtrlScene.ClientSize.Width, ACtrlScene.ClientSize.Height);
			CtrlScene = ACtrlScene;
			SelectAreaXStart = -1;
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
		
		//Возвращает ссылку на объект под курсором мышки
		public TDrwShape GetDrwShape(int AX, int AY)
		{
			TDrwShape vResult = null;
			foreach (TDrwShape vShape in DrwShapeList) 
			{
				if (vShape.IncludePoint(AX, AY))
				{
					vResult = vShape;
					break;
				}
			}
			return vResult;
		}
		
		//Возвращает ссылку на объект по идентификатору
		public TDrwShape GetShapeByID(int AID)
		{
			TDrwShape vResult = null;
			foreach (TDrwShape vShape in DrwShapeList) 
			{
				if (vShape.ID == AID)
				{
					vResult = vShape;
					break;
				}
			}
			return vResult;
		}
		
		//Подсветка фигуры
		public void BacklightShape(int AX, int AY)
		{
			CtrlScene.Cursor = Cursors.Default;
			ReDrawFrontLayer();
			TDrwShape vShape = GetDrwShape(AX, AY);
			if (vShape != null)
			{
				LightOn(vShape);
			}
		}
		
		//Перерисовка динаимческого слоя
		public void ReDrawFrontLayer()
		{
			//Очитска
			Layer_FT.Clear(Color.Transparent);
			//Отрисовка
			foreach(TDrwShape vShape in DrwFrontShapeList)
			{
				vShape.Draw(Layer_FT);
			}
		}
		
		//добавление/удаление фигуры с динамического слоя
		public void Add(TDrwShape ADrwShape)
		{
			
		}
		
		public void Remove(TDrwShape ADrwShape)
		{
			
		}
		
		//подсветить фигуру
		public void LightOn(TDrwShape AShape)
		{
			CtrlScene.Cursor = Cursors.Hand;
			AShape.Light();
			//Отрисовка временной фигуры динамического слоя
			AShape.Draw(Layer_FT);
		}	
		
		//Отображения "прямоугольника" выделяемой области 
		public void ViewSelectRect(int AX, int AY)
		{
			DrwFrontShapeList.Clear();
			double vY0 = (Scene.GetSceneObject("Coord") as TScObjCoord).Y0;
			double vY1 = (Scene.GetSceneObject("Coord") as TScObjCoord).Y1*CoeffY;
			TDrwRect vRect = new TDrwRect((AX + SelectAreaXStart)/2, vY1, Math.Abs(AX - SelectAreaXStart), vY1-vY0);
			vRect.DashStyle = DashStyle.Custom;
			vRect.CalcY(CtrlScene.Height);
			DrwFrontShapeList.Add(vRect);
		}
		
		//Отображение "выделенных данных"
		public void ViewSelectData(int AX, int AY)
		{
			DrwFrontShapeList.Clear();
			//прямоугольник области
			double vY0 = (Scene.GetSceneObject("Coord") as TScObjCoord).Y0;
			double vY1 = (Scene.GetSceneObject("Coord") as TScObjCoord).Y1*CoeffY;
			TDrwRect vRect = new TDrwRect((AX + SelectAreaXStart)/2, vY1, Math.Abs(AX - SelectAreaXStart), vY1-vY0);
			vRect.DashStyle = DashStyle.Custom;
			vRect.CalcY(CtrlScene.Height);
			DrwFrontShapeList.Add(vRect);
			//Выделение графика
			TDrwPolygon vPolygon = new TDrwPolygon();
//			double vY0 = 
//			vPolygon.
		}
		
		//Работа указателя мышки по умолчанию
		public void MouseDown(int AX, int AY, double AHorizScaleValue)
		{

		}
		
		public void MouseMove(int AX, int AY)
		{
			//Подсветка фигуры
			BacklightShape(AX, AY);
			//Обновление контрола
			CtrlScene.Invalidate();
		}
		
		public void MouseUp(int AX, int AY)
		{
  			CtrlScene.Cursor = Cursors.Default;
  			TDrwShape vShape = GetDrwShape(AX, AY);
  			double vX, vY;
			if (vShape != null)
			{
				if ((vShape is TDrwCircle) || (vShape is TDrwRect))
				{
					if (vShape is TDrwCircle)
					{
						vX = (vShape as TDrwCircle).Center.X;
						vY = (vShape as TDrwCircle).Center.Y;
					} else
					{
						vX = (vShape as TDrwRect).InitPoint.X;
						vY = (vShape as TDrwRect).InitPoint.Y;
					}
					vX = (Scene.GetSceneObject("Coord") as TScObjCoord).GetXUsrByDrw(vX)/CoeffX;
					ViewInfoBox(AX, AY, vX, vY);
				}
			}
			ReDrawFrontLayer();
		}
		
		public void ViewInfoBox(int ADrwX, int ADrwY, double AUsrX, double AUsrY)
		{
			int vDay = Convert.ToInt32(AUsrX);
			TDrwLabel vLabel = new TDrwLabel();
			vLabel.Point.X = ADrwX + 5;
			vLabel.Point.Y = ADrwY + 25;
			DateTime d1 = new DateTime(2020, 1, 1);
			vLabel.Text = d1.AddDays(vDay).ToString("d MMM");
			vLabel.HAlig = TDrwLabel.THAlig.HCenter;
			vLabel.VAlig = TDrwLabel.TVAlig.VTop;
											
			vLabel.Draw(Layer_BG);				
		}
	}
}
