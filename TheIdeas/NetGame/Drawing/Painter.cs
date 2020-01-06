using System;
using System.Windows.Forms;
using System.Drawing;

namespace Painter
{
	public class TPainter
	{
		public PictureBox CtrlScene;
		public Bitmap DrawArea;
		public Graphics G;
		
		public TPainter(PictureBox ACtrlScene)
		{
			CtrlScene = ACtrlScene;
			Init();
        }
		
		public void Init()
		{
			DrawArea = new Bitmap(CtrlScene.ClientSize.Width, CtrlScene.Size.Height);
			G = Graphics.FromImage(DrawArea);
			CtrlScene.Image = DrawArea; 
			G.Clear(Color.White); 	
		}
		
		public void Refresh()
		{
			//Пересоздание битмапа с учетом новых размеров
			Init();
			//Перерисовка слоев с фигурами
			Pen mypen = new Pen(Color.Black);
			G.DrawEllipse(mypen, 50,50,DrawArea.Width/2,DrawArea.Height/2);
		}
			
	}
}
