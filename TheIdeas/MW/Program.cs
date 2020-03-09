using System;
using System.Windows.Forms;

using MW.Data;

namespace MW
{
	internal sealed class Program
	{
		public static FrmMainForm MainForm;
		//Интерфейс базы данных
		public static TData Data;
		[STAThread]
		private static void Main(string[] args)
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			MainForm = new FrmMainForm();
			Data = MainForm.Data;			
			Application.Run(MainForm);
		}
	}
}
