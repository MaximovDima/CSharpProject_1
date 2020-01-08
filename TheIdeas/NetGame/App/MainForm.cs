using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using GamePlay;
namespace NetGame
{
	public partial class MainForm : Form
	{
		
		public TGame Game; 
	
		public MainForm()
		{
			InitializeComponent();
			//Загрузка ресурсов для игры
			Game = new TGame(CtrlScene);
			//первичной инициализации
			
			//выполняется выбор одиночная игра или подключение к серверу
			//загрузка типа геймплея
			Game.CreateSession();
			//процесс игры 
			// 1.отслеживания активности мыши
			// 2.в случае сетевой игры - обмен с сервером		
		}
	
		void MainFormResize(object sender, EventArgs e)
		{
			Game.SceneResize();
		}
	}
}
