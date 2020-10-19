using System;
using System.Drawing;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Text;

using MW.Data;
using MW.Core;

namespace MW.Forms
{
	public partial class FrmGKH : Form
	{
		public FrmGKH(TData AData)
		{
			InitializeComponent();
			TModel logs = AData.GetModel("Log");
		}
		
		void Button1Click(object sender, EventArgs e)
		{
			label1.Text = "test";
		}
		
		private string Exchange(string address, int port, string outMessage)
		{
    // Инициализация
    TcpClient client = new TcpClient(address, port);
    Byte[] data = Encoding.UTF8.GetBytes(outMessage);
    NetworkStream stream = client.GetStream();
    try
    {
        // Отправка сообщения
        stream.Write(data, 0, data.Length);
        // Получение ответа
        Byte[] readingData = new Byte[256];
        String responseData = String.Empty;
        StringBuilder completeMessage = new StringBuilder();
        int numberOfBytesRead = 0;
        do
        {
            numberOfBytesRead = stream.Read(readingData, 0, readingData.Length);
            completeMessage.AppendFormat("{0}", Encoding.UTF8.GetString(readingData, 0, numberOfBytesRead));
        }
        while (stream.DataAvailable);
        responseData = completeMessage.ToString();
        return responseData;
    }
    finally
    {
        stream.Close();
        client.Close();
    }
}
	}
}
