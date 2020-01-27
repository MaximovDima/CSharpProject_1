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
		
		public TGame()
		{
			//Инициализация сцены
			Scene = new TScene();
			Scene.X = 700;
			Scene.Y = 550;			
		}
		
		public void SceneResize(int AX, int AY)
		{
			Scene.Painter.Refresh(AX, AY);
		}
		
		public void InitScene()
		{
			//Ландшафт
			TGround Ground = new TGround(Scene.X, Scene.Y);
			Scene.SceneObjectList.Add(Ground);	
		}		
	}
		
}
