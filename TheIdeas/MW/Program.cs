using System;
using System.Windows.Forms;

namespace MW
{
	internal sealed class Program
	{
		public static FrmMainForm MainForm;
		public static TApp App;
		[STAThread]
		private static void Main(string[] args)
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			MainForm = new FrmMainForm();
			App = MainForm.App;			
			Application.Run(MainForm);
		}
	}
}
