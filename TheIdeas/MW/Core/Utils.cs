using System;
using System.Security.Cryptography.X509Certificates;
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
		//Проверка числа на буквы
		public static bool IsString(string AName, TextBox AEdit)
		{
			string Str = AEdit.Text.Trim();
			int Num;
			bool isNum = int.TryParse(Str, out Num);

			if (isNum)
			{
				return false;
			} 
			else
			{
				MessageBox.Show("Неверное числовое значение '" + AName + "'", "Некорректные данные", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return true;
			}

		}
	}
	//Форматирование
	public static class Format
	{
		public static string ObjToStr(object AObj)
		{
			if (AObj == null)
			{
				return "";
			} else
			{
				return Convert.ToString(AObj);
			}
		}
		
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
		//Перевод массива строк в SQL-запрос
		public static string GetSQL(string[] AStrings)
		{
			return String.Join(", ", AStrings); 
		}
	}
}
