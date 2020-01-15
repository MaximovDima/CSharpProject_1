//Классы обеспечивающие глобальное управление геймплея и связи с другим клиентом

using System;
using System.Windows.Forms;
using GamePlay;

namespace GameService
{
	public class TGameSession
	{
		public TGame Game;
		public TServer Server;
		
		public TGameSession(PictureBox ACtrlScene)
		{
			
			Game = new TGame(ACtrlScene);
			//первичной инициализации
			
			//выполняется выбор одиночная игра или подключение к серверу
			//загрузка типа геймплея
			Game.CreateSession();
		}
		
		public void SceneResize(int AX, int AY)
		{
			Game.SceneResize(AX, AY);
		}
	}
	
	public class TServer
	{
		public TServer()
		{
			
		}
	}
}
