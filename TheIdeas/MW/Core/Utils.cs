using System;
using System.Windows.Forms;

namespace MW.Utils
{
	public static class Checks
	{	
		//Проверка на пустые данные
		public static bool IsNull(string AName, TextBox AEdit)
		{
			if (AEdit.Text == "")
			{
				MessageBox.Show("Необходимо указать '" + AName + "'", "Неполные данные", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return true;
			}
			else return false;
		}
		public static bool IsNull(string AName, ComboBox AEdit)
		{
			if (AEdit.Text == "")
			{
				MessageBox.Show("Необходимо указать '" + AName + "'", "Неполные данные", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return true;
			}
			else return false;
		}
	}
	//Форматирование
	public static class Format
	{
		public static int StrToInt(string AString)
		{
			if (AString == "")
			{
				return 0;
			} else
			{
				return Convert.ToInt32(AString);
			}
		}
		public static string IntToStr(int AValue)
		{
			if (AValue == 0)
			{
				return "";
			} else
			{
				return Convert.ToString(AValue);
			}
		}
	}
}
