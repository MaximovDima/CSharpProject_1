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
		
		public TScene Scene;
		
		public TGame(PictureBox ACtrlScene)
		{

			//Инициализация сцены
			Scene = new TScene(ACtrlScene);
		}
		
		public void SceneResize(int AX, int AY)
		{
			Scene.Painter.Refresh(AX, AY);
		}
		
		public void CreateSession()
		{
			//создание сервера
			//Загрзука модели игры если одиноч
			//еще что-то
			
			//построение сцены
			Scene.Build();
			//перевод моделей сцены в отрисовку
//			DrawSceneByPainter();
			//Отриовка
			Scene.Painter.Draw();
					
		}		
	}
		
}
