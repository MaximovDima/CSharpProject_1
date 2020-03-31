using System;
using System.Collections.Generic;
using System.Drawing;
using MW.Drawing;

namespace MW.Core
{
	//Виртуальная сцена
	public class TScene
	{
		//Размеры сцены в пикселях
		public double X;
		public double Y;
		//Коллеккция моделей объектов сцены
		public List<TSceneObject> SceneObjectList;	
		
		public TScene(double AX, double AY)
		{
			X = AX;
			Y = AY;
			SceneObjectList = new List<TSceneObject>();
		}	
		
		public void LoadModels(List<TModel> AModels)
		{
			TScObjCoord Coord = new TScObjCoord();
			SceneObjectList.Add(Coord);
		}
		
	}
	//Шаблон модели объекта отрисовки
	public abstract class TSceneObject
	{
		//Идентификатор
    	public int ID;
    	//Наименование
    	public string Name;
    	//Тэги
    	public List<string> CodeList;
    	//Список примитивов
    	public List<TDrwShape> DrwObjList;
    	
    	public TSceneObject()
    	{
    		CodeList = new List<string>();
    		DrwObjList = new List<TDrwShape>();
    	}
    	//Построение объекта из примитивов
    	public abstract void Build(TScene AScene, double ACoeffX, double ACoeffY);
    
	}
	
	//Система координат
	public class TScObjCoord : TSceneObject
	{
//		public double X0;
//		public double X1;
//		public double Y0;
//		public double Y1;
		
		public override void Build(TScene AScene, double ACoeffX, double ACoeffY)
		{
			DrwObjList.Clear();
			TDrwLine vXline = new TDrwLine();
			vXline.Color = Color.Red; 
			vXline.PenWidth = 1;
			
		
			vXline.GroupCode = "Coord";
			vXline.CodeElement = "AxisX";
			vXline.StartPoint.X = Convert.ToInt32(5 * ACoeffX);
			vXline.StartPoint.Y = Convert.ToInt32(5 * ACoeffY);
			vXline.EndPoint.X = Convert.ToInt32((AScene.X / 2) * ACoeffX);
			vXline.EndPoint.Y = Convert.ToInt32(5 * ACoeffY);
			DrwObjList.Add(vXline);
		}
		
	}
}