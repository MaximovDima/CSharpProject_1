//Управление геймплеем игры, расчет модельных значений объектов игрового мира

using System;
using System.Data;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;
using System.Collections.Generic;
using Painter;
using SceneClasses;
using DrwShapeClasses;

namespace GamePlay
{		
	
	public class TGame
	{
		public TPainter Painter;
		public TScene Scene;
		
		public TGame(PictureBox ACtrlScene)
		{
			//Инициализация отрисовщика
			Painter = new TPainter(ACtrlScene);
			//Инициализация сцены
			Scene = new TScene(ACtrlScene);
		}
		
		public void SceneResize(int AX, int AY)
		{
			Painter.Refresh(AX, AY);
		}
		
		public void CreateSession()
		{
			//создание сервера
			//Загрзука модели игры если одиноч
			//еще что-то
			
			//построение сцены
			Scene.Build();
			//перевод моделей сцены в отрисовку
			DrawSceneByPainter();
			//Отриовка
			Painter.Draw();
					
		}
		
		public void DrawSceneByPainter()
		{
			foreach (TSceneObject SceneObj in Scene.SceneObjectList)
        	{
				SceneObj.DrwObjList.Clear();
				SceneObj.Build();
  				
  				foreach (TDrwShape Shape in SceneObj.DrwObjList)
  				{
  					SceneObj.CodeList.Add(Shape.GroupCode);
    				Shape.LayerType = TLayerType.ltBack;
    				Shape.ScObjName = SceneObj.Name;
    				Painter.AddShape(Shape);
  				}
        	}
		}
	}
		
}
