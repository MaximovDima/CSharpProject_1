//Запуск приложения

using System;
using System.Windows.Forms;

namespace NetGame
{
	internal sealed class Program
	{
		[STAThread]
		private static void Main(string[] args)
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			//Инициализация формы
			Application.Run(new MainForm());
		}
		
	}
}
