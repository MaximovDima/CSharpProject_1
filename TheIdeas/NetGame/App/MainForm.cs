//Основная и единственная форма приложения
//Инициализация сессии игры

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using GameService;

namespace NetGame
{
	public partial class MainForm : Form
	{
		public TGameSession GameSession;
		public MainForm()
		{
			InitializeComponent();
			//Загрузка ресурсов для игры
			GameSession = new TGameSession(CtrlScene);
		}
	
		void MainFormResize(object sender, EventArgs e)
		{
			GameSession.SceneResize(CtrlScene.ClientSize.Width, CtrlScene.ClientSize.Height);
		}
	}
}
