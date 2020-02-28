using System;
using System.Windows.Forms;

namespace MW.Utils
{
	public static class Checks
	{	
		//Проверка на пустые данные
		public static void CheckNull(string AName, TextBox AEdit)
		{
			if (AEdit.Text == "")
			{
				MessageBox.Show("Необходимо указать " + AName + " !", "Неполные данные", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
	}
}
