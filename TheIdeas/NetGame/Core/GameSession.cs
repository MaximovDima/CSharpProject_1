//Классы обеспечивающие глобальное управление геймплея и связи с другим клиентом

using System;
using System.Windows.Forms;
using System.Collections.Generic;
using GamePlay;
using Painter;

//
using SceneClasses;

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
			Client.Painter.Refresh(AX, AY);
		}
	}
	
	public class TClient
	{
		public TPainter Painter;
		public int X;
		public int Y;
		
		public TClient(PictureBox ACtrlScene)
		{
			//Инициализация отрисовщика
			Painter = new TPainter(ACtrlScene);
			X = ACtrlScene.Width;
			Y = ACtrlScene.Height;
		}
		
		//Запрос к серверу для начала одиночной игры
		public void NewSingleGame(TServer AServer)
		{
			//Иницализация отрисовщика для сцены из сервера
			AServer.Game.Scene.Painter = Painter; 
			AServer.Game.Scene.X = 700;//X;
			AServer.Game.Scene.Y = 550;//Y;

				
			AServer.Game.Scene.Build();
			AServer.Game.Scene.Painter.Draw();
		}
	}
	
	public class TServer
	{
		public TGame Game;
		
		public List<TClient> ClientList;
		public TServer()
		{
			ClientList = new List<TClient>();
			//Инициализация игровой модели
			Game = new TGame();
			//Первичная иницализация объктов сцены
			Game.InitScene();
		}
		
		public TScene GetScene(int AMaxX, int AMaxY)
		{
			return null;	
		}
	}
}
