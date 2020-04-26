/*
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
		public int SelectedShapeID;
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
		//Режимы движения мышкой
		public bool IsMoveScheme;
		public int OldMoveX;
		public bool IsMoveDelta;
		//режим выделения (начальная точка X)
		public int SelectAreaXStart;		
		
		public TPainter(PictureBox ACtrlScene)
		{
			DrwShapeList = new List<TDrwShape>();
			DrwFrontShapeList = new List<TDrwShape>();
			Scene = new TScene(ACtrlScene.ClientSize.Width, ACtrlScene.ClientSize.Height);
			CtrlScene = ACtrlScene;
			SelectedShapeID = -1;
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
			//Очитска динамического слоя
			Layer_FT.Clear(Color.Transparent);
			//Отрисовка выделенной фигуры
			DrawSelectedShape();
			//Отрисовка динамических фигур
			foreach(TDrwShape vShape in DrwFrontShapeList)
			{
				vShape.Draw(Layer_FT);
			}
		}
		
		//Отрисовка выделенной фигуры
		public void DrawSelectedShape()
		{
			if (SelectedShapeID != -1)
			{
				TDrwShape vShape = GetShapeByID(SelectedShapeID);
				if(vShape != null)
				{
					vShape.Light();
					vShape.Draw(Layer_FT);
				}
			}
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
			TDrwRect vRect = new TDrwRect((AX + SelectAreaXStart)/2, 0, Math.Abs(AX - SelectAreaXStart), Scene.Y*CoeffY-1);
			vRect.PenWidth = 2;
			vRect.DashStyle = DashStyle.Custom;
				
			DrwFrontShapeList.Add(vRect);
		}
		
		//Работа указателя мышки по умолчанию
		public void MouseDown(int AX, int AY, double AHorizScaleValue)
		{
			IsMoveScheme = false;
  			if (AHorizScaleValue > 1)
  			{
    			IsMoveScheme = true;
  			}
  			OldMoveX = AX;
		}
		
		public void MouseMove(int AX, int AY)
		{
			if (!IsMoveScheme)
			{
				//Подсветка фигуры
				BacklightShape(AX, AY);
				//Обновление контрола
				CtrlScene.Invalidate();
			}
//			else
//			{
//				int vStartX = OldMoveX;
//			  	OldMoveX = AX;
//			  	IsMoveDelta = false;
//			  	if (IsMoveScheme)
//			  	{
//			  		IsMoveDelta = true;
//			  		(CtrlScene.Parent as Panel).AutoScrollPosition = new Point((vStartX - AX), 0);
////			  			new Point((CtrlScene.Parent as Panel).AutoScrollPosition.X + (vStartX - AX), (CtrlScene.Parent as Panel).AutoScrollPosition.Y);
//    			 	CtrlScene.Cursor = Cursors.SizeWE;			  	
//			  	}
//			}
		}
		
		public void MouseUp(int AX, int AY)
		{
			IsMoveScheme = false;
  			CtrlScene.Cursor = Cursors.Default;
			
			SelectedShapeID = -1;
			TDrwShape vShape = GetDrwShape(AX, AY);
			if (vShape != null)
			{
				SelectedShapeID = vShape.ID;
			}

			if (IsMoveDelta)
			{
				IsMoveScheme = false;
				IsMoveDelta = false;
			}
		}
	}
}
