//Классы обеспечивающие глобальное управление геймплея и связи с другим клиентом

using System;
using System.Windows.Forms;
using System.Collections.Generic;
using GamePlay;
using Painter;

namespace GameService
{
	public class TGameSession
	{
		public TClient Client;
		public TServer Server;
		
		public TGameSession(PictureBox ACtrlScene)
		{
			//Экземпляр клиента
			Client = new TClient(ACtrlScene);
			//Инициализация сервера
			Server = new TServer();
			//Добавление текущего клиента в лист отслеживания
			Server.ClientList.Add(Client);
			
			//по умолчанию выбор одиночной игры
			Client.NewSingleGame(Server);
//			Game.CreateSession();
		}
		
		public void SceneResize(int AX, int AY)
		{
//			Game.SceneResize(AX, AY);
		}
	}
	
	public class TClient
	{
		
		public TClient(PictureBox ACtrlScene)
		{
			
		}
		
		//Запрос к сервреру для начала одиночной игры
		public void NewSingleGame(TServer Server)
		{
			
		}
	}
	
	public class TServer
	{
		public TScene Scene;
		
		public List<TClient> ClientList;
		public TServer()
		{
			ClientList = new List<TClient>();
			//Инициализация игровой модели
//			Game = new TGame(ACtrlScene);		
		}
	}
}
