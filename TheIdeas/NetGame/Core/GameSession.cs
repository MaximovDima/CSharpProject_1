//Классы обеспечивающие глобальное управление геймплея и связи с другим клиентом

using System;
using System.Windows.Forms;
using GamePlay;

namespace GameService
{
	public class TGameSession
	{
		public TGame Game;
		public TClient Client;
		public TServer Server;
		
		public TGameSession(PictureBox ACtrlScene)
		{
			//Экземпляр клиента
			Game = new TGame(ACtrlScene);
			//Инициализация сервера
			Server = new TServer();
			
			//выполняется выбор одиночная игра или подключение к серверу
			//загрузка типа геймплея
			Game.CreateSession();
		}
		
		public void SceneResize(int AX, int AY)
		{
			Game.SceneResize(AX, AY);
		}
	}
	
	public class TClient
	{
		public TClient()
		{
			
		}
	}
	
	public class TServer
	{
		public TServer()
		{
			//Инициализация игры
//			Game = new TGame(ACtrlScene);		
		}
	}
}
