using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Painter;

namespace NetGame
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
			PainterForm MyPainter = new PainterForm();
			MyPainter.MdiParent = this;
			MyPainter.Show();
		}
	}
}
