using System;
using System.Collections.Generic;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;
using MW.Data;
using MW.Core;
using MW.Drawing;

namespace MW.Forms
{
	public partial class FrmFinance : Form
	{
		//Инициализация моделей
		public TData Data;
		//Справочник
		public TModel Directory;
		//Расходы
		public TModel Costs;
		//Доходы
		public TModel Incomes;
		//Режим масштабирования
		public bool IsScale;
		//Отрисовщик
		public TPainter Painter;
		
		public FrmFinance(TData AData)
		{
			InitializeComponent();
			this.DoubleBuffered = true;
			Data = AData;
			Directory = Data.GetModel("Directory");
			Costs = Data.GetModel("Cost");
			Incomes = Data.GetModel("Income");
			Painter = new TPainter(DrwControl);
			cbTimeType.SelectedIndex = 0;		
			SyncForm();
		}
		
		public void SyncForm()
		{
			SyncCostsInfo();
			SyncIncomesInfo();
		}
		
		public void SyncView()
		{
			Painter.Scene.SceneObjectList.Clear();
			Painter.Scene.LoadModels(Costs, Incomes, rbTime.Checked, cbTimeType.SelectedIndex, rbColumns.Checked, rbStructura.Checked);
			Painter.ReDraw(DrwControl.Width, DrwControl.Height);
			DrwControl.Invalidate();
		}
		
		public void SyncCostsInfo()
		{
			SyncCostsView();
			lblCostSum.Text = Costs.GetTextSum("Value");
			lblAverage.Text = Costs.GetTextAverageDay("Value");
		}
		
		public void SyncIncomesInfo()
		{
			SyncIncomesView();
			lblIncomeSum.Text = Incomes.GetTextSum("Value");
			lblAverageInc.Text = Incomes.GetTextAverageDay("Value");
		}
		
		public void SyncCostsView()
		{
			vCosts.Rows.Clear();
			foreach(Dictionary<string, string> vRow in Costs.Rows)
			{
				object[] vGridRow = new object[6];
				vGridRow[0] = vRow["ID"];
				vGridRow[1] = Convert.ToDateTime(vRow["Date"]);
				vGridRow[2] = Directory.GetNameByID("Cost", vRow["Type"]);
				vGridRow[3] = Directory.GetNameByID("Place", vRow["Place"]);
				vGridRow[4] = Format.StrToInt(vRow["Value"]);
				vGridRow[5] = vRow["Comment"];
				
				vCosts.Rows.Add(vGridRow);
			}

			vCosts.FirstDisplayedScrollingRowIndex = vCosts.RowCount - 1;		
		}
		
		public void SyncIncomesView()
		{
			vIncomes.Rows.Clear();
			foreach(Dictionary<string, string> vRow in Incomes.Rows)
			{
				object[] vGridRow = new object[6];
				vGridRow[0] = vRow["ID"];
				vGridRow[1] = Convert.ToDateTime(vRow["Date"]);
				vGridRow[2] = Directory.GetNameByID("Income", vRow["Type"]);
				vGridRow[3] = Format.StrToInt(vRow["Value"]);
				vGridRow[4] = vRow["Comment"];
				
				vIncomes.Rows.Add(vGridRow);
			}

			vIncomes.FirstDisplayedScrollingRowIndex = vIncomes.RowCount - 1;		
		}
		
		void BtnAddCostClick(object sender, EventArgs e)
		{
			FrmEditFinance editForm = new FrmEditFinance(Directory, Costs);
			editForm.Text = "Новый расход...";
			editForm.IsEdit = false;
			editForm.IsCosts = true;
			editForm.SyncForm();
			editForm.ShowDialog();
			if (editForm.IsModify)
			{
				Data.UpdateModel("Directory");
				Data.UpdateModel("Cost");
				SyncCostsInfo();
				SyncView();
			}
		}
		
		void VCostsCellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			EditCost(e.RowIndex);
		}
		
		public void EditCost(int ARowIndex)
		{
			if (ARowIndex >= vCosts.RowCount - 1)
				return;
				
			string vID = vCosts.Rows[ARowIndex].Cells["ID"].Value.ToString();
			Dictionary<string, string> vRow = Costs.GetByID(vID);

			FrmEditFinance editForm = new FrmEditFinance(Directory, Costs);
			editForm.Text = "Редактировать расход...";
			editForm.IsEdit = true;
			editForm.IsCosts = true;
			editForm.EditRow = vRow;
			editForm.SyncForm();
			editForm.ShowDialog();		
			
			if (editForm.IsModify)
			{
				Data.UpdateModel("Directory");
				Data.UpdateModel("Cost");
				SyncCostsInfo();
				SyncView();
			}
		}	
		
		void BtnCostEditClick(object sender, EventArgs e)
		{
			EditCost(vCosts.CurrentRow.Index);	
		}
		
		void BtnCostDeleteClick(object sender, EventArgs e)
		{
			if (vCosts.CurrentRow.Index >= vCosts.RowCount - 1)
				return;
			string vID = vCosts.Rows[vCosts.CurrentRow.Index].Cells["ID"].Value.ToString();
			Dictionary<string, string> vRow = Costs.Rows[Format.StrToInt(vID) - 1];
			
			DialogResult vResult = MessageBox.Show("Удалить расход " + vRow["Value"] + " за " + vRow["Date"],
			                                      "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (vResult == DialogResult.Yes)
			{
				vRow["State"] = "delete";
				Data.UpdateModel("Cost");
				SyncCostsInfo();
				SyncView();
			}
		}
		
		void BtnIncomeAddClick(object sender, EventArgs e)
		{
			FrmEditFinance editForm = new FrmEditFinance(Directory, Incomes);
			editForm.Text = "Новый доход...";
			editForm.IsEdit = false;
			editForm.IsCosts = false;
			editForm.SyncForm();
			editForm.ShowDialog();
			if (editForm.IsModify)
			{
				Data.UpdateModel("Directory");
				Data.UpdateModel("Income");
				SyncIncomesInfo();
				SyncView();
			}			
		}
		
		void VIncomesCellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			EditIncome(e.RowIndex);
		}
		
		public void EditIncome(int ARowIndex)
		{
			if (ARowIndex >= vIncomes.RowCount - 1)
				return;
				
			string vID = vIncomes.Rows[ARowIndex].Cells["id1"].Value.ToString();
			Dictionary<string, string> vRow = Incomes.Rows[Format.StrToInt(vID) - 1];

			FrmEditFinance editForm = new FrmEditFinance(Directory, Incomes);
			editForm.Text = "Редактировать расход...";
			editForm.IsEdit = true;
			editForm.IsCosts = false;
			editForm.EditRow = vRow;
			editForm.SyncForm();
			editForm.ShowDialog();		
			
			if (editForm.IsModify)
			{
				Data.UpdateModel("Directory");
				Data.UpdateModel("Income");
				SyncIncomesInfo();
				SyncView();
			}
		}
		
		void BtnIncomeDeleteClick(object sender, EventArgs e)
		{
			if (vIncomes.CurrentRow.Index >= vIncomes.RowCount - 1)
				return;
			string vID = vIncomes.Rows[vCosts.CurrentRow.Index].Cells["id1"].Value.ToString();
			Dictionary<string, string> vRow = Incomes.Rows[Format.StrToInt(vID) - 1];
			
			DialogResult vResult = MessageBox.Show("Удалить доход " + vRow["Value"] + " за " + vRow["Date"],
			                                      "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (vResult == DialogResult.Yes)
			{
				vRow["State"] = "delete";
				Data.UpdateModel("Income");
				SyncIncomesInfo();
				SyncView();
			}			
		}
		
		void BtnIncomeEditClick(object sender, EventArgs e)
		{
			EditIncome(vCosts.CurrentRow.Index);	
		}
		
		void PnlGraphicResize(object sender, EventArgs e)
		{
			if (!IsScale)
			{
				pnlGraphic.AutoScroll = false;
				try
				{
					DrwControl.Width = pnlGraphic.Width - 5;
					DrwControl.Height = pnlGraphic.Height - 20;
					Painter.ReDraw(DrwControl.Width, DrwControl.Height);					
					//Отрисовка динамического слоя
					Painter.ReDrawFrontLayer();
					DrwControl.Invalidate();
				}
				finally 
				{
					pnlGraphic.AutoScroll = true;
				}
			    
			}
		}
		
		void CbIsCostCheckStateChanged(object sender, EventArgs e)
		{
			SyncView();
		}
		
		void RbTimeCheckedChanged(object sender, EventArgs e)
		{
			if (cbTimeType.SelectedIndex == -1)
			{
				cbTimeType.SelectedIndex = 0;
			}
			cbTimeType.Enabled = true;
			ReZoom.Visible = true;
			ZoomIn.Visible = true;
			ZoomOut.Visible = true;
			cbScale.Visible = true;
			cbInfo.Visible = true;
			SyncView();
		}
		
		void RbStructuraCheckedChanged(object sender, EventArgs e)
		{
			cbTimeType.SelectedIndex = -1;
			cbTimeType.Enabled = false;
			ReZoom.Visible = false;
			ZoomIn.Visible = false;
			ZoomOut.Visible = false;
			cbScale.Visible = false;
			cbInfo.Visible = false;
			SyncView();
		}
		
		void ZoomOutClick(object sender, EventArgs e)
		{
			IsScale = true;
			DrwControl.Width = Convert.ToInt32(DrwControl.Width * 0.9);
			Painter.ReDraw(DrwControl.Width, DrwControl.Height);
			//Отрисовка динамического слоя
			Painter.ReDrawFrontLayer();
			IsScale = false;
			DrwControl.Invalidate();
			int vCenter = DrwControl.Width/2;
			pnlGraphic.AutoScrollPosition = new Point(vCenter-pnlGraphic.Width/2, DrwControl.Height);			
			
		}
		
		void CbScaleCheckedChanged(object sender, EventArgs e)
		{
			cbInfo.Checked = false;
		}
		
		void ZoomInClick(object sender, EventArgs e)
		{
			IsScale = true;
			DrwControl.Width = Convert.ToInt32(DrwControl.Width * 1.1);
			pnlGraphic.HorizontalScroll.Value = Math.Abs(DrwControl.Width/2-pnlGraphic.Width/2);
			Painter.ReDraw(DrwControl.Width, DrwControl.Height);
			//Отрисовка динамического слоя
			Painter.ReDrawFrontLayer();
			IsScale = false;
			DrwControl.Invalidate();
		}		
		
		void CbTimeTypeSelectedIndexChanged(object sender, EventArgs e)
		{
			SyncView();
		}
		
		void CbInfoCheckedChanged(object sender, EventArgs e)
		{
			cbScale.Checked = false;
		}
		
		void DrwControlPaint(object sender, PaintEventArgs e)
		{
			if (!IsScale)
			{
				e.Graphics.DrawImage(Painter.Bitmap_BG, 0,0);
				e.Graphics.DrawImage(Painter.Bitmap_FT, 0,0);
			}
		}
		
		void DrwControlMouseDown(object sender, MouseEventArgs e)
		{
			//Режим выделения
			if (cbScale.Checked || cbInfo.Checked)
			{
				Painter.SelectAreaXStart = e.X;
			}
		}
		
		void DrwControlMouseMove(object sender, MouseEventArgs e)
		{
			if (!rbStructura.Checked)
			{
				Painter.MouseMove(e.X, e.Y);
			}
			//Режим выделения
			if ((cbScale.Checked || cbInfo.Checked) && (Painter.SelectAreaXStart != -1))
			{
				Painter.ViewSelectRect(e.X, e.Y);
				if ((cbInfo.Checked) && (cbTimeType.SelectedIndex != 3))
				{
					Painter.ViewSelectData(e.X, e.Y, cbTimeType.SelectedIndex, Costs, Incomes);
				}
			}
		}
		
		void DrwControlMouseUp(object sender, MouseEventArgs e)
		{	
			if ((cbScale.Checked) && (Painter.SelectAreaXStart != -1))
			{
				IsScale = true;
				double vCoeff = pnlGraphic.Width/Math.Abs(e.X - Painter.SelectAreaXStart);
				double vX = (e.X + Painter.SelectAreaXStart)/2;
				DrwControl.Width = Convert.ToInt32(DrwControl.Width*vCoeff);
				pnlGraphic.AutoScrollPosition = new Point(pnlGraphic.HorizontalScroll.Maximum/2, 0);
			    Painter.ReDraw(DrwControl.Width, DrwControl.Height);
			    cbScale.Checked = false;
			    IsScale = false;
			}
			
			Painter.ReDraw(DrwControl.Width, DrwControl.Height);
			Painter.SelectAreaXStart = -1;
			if (cbTimeType.SelectedIndex != 3)
			{
				Painter.MouseUp(e.X, e.Y, Costs, Incomes, Directory);
			}
		}
	}
}
