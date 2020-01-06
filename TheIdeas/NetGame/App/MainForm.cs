using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Painter;
using GamePlay;

namespace NetGame
{
	public partial class MainForm : Form
	{
		public TPainter Painter;
		public TScene Scene; 
		private Bitmap DrawArea;
		
		public MainForm()
		{
			InitializeComponent();
			//Инициализация отрисовщика
			Painter = new TPainter(CtrlScene);
			//Инициализация сцены
			
			
			

//			PainterForm MyPainter = new PainterForm();
//			MyPainter.MdiParent = this;
//			MyPainter.Show();
		}
		
		void Button1Click(object sender, EventArgs e)
		{
					DrawArea = new Bitmap(CtrlScene.ClientSize.Width, CtrlScene.Size.Height);
            CtrlScene.Image = DrawArea;
                Font ff;
                ff = new Font("Arial", 24f);
                
//                DrawArea.
                Graphics g;
                
                g = Graphics.FromImage(DrawArea);
                g.Clear(Color.White);
                Pen mypen = new Pen(Color.Black);
				
//                g.DrawLine(mypen, 0,0,200,150);
				g.DrawEllipse(mypen, 50,50,DrawArea.Width,DrawArea.Height);
				g.DrawString("test", ff, Brushes.Black, 0,DrawArea.Height/2);

                CtrlScene.Image = DrawArea;

                g.Dispose();			
		}
		
		void MainFormResize(object sender, EventArgs e)
		{
			Painter.Refresh();
		}
	}
}
